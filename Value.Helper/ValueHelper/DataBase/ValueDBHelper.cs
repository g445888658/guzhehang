using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace ValueHelper.DataBase
{
    public class ValueDBHelper
    {
        private String dbServer;

        private String userID;

        private String password;

        public ValueDBHelper(String dbServer, String userID, String password)
        {
            this.dbServer = dbServer;
            this.userID = userID;
            this.password = password;
        }

        private SqlConnection getConnection()
        {
            var sql = String.Format("Data Source={0};User ID={1};Password={2};", this.dbServer, this.userID, this.password);
            var conn = new SqlConnection(sql);
            return conn;
        }

        public SqlCommand GetCommand(String sql)
        {
            var conn = getConnection();
            var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd;
        }

        public void DisposeCommand(SqlCommand cmd)
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }

        /// <summary>
        ///  附加数据库
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="datafile"></param>
        /// <param name="logfile"></param>
        /// <returns></returns>
        public Boolean AttachDataBase(String dbname, String datafile, String logfile)
        {
            try
            {
                var sql = String.Format("EXEC sp_attach_db @dbname='{0}',@filename1='{1}',@filename2='{2}'", dbname, datafile, logfile);
                var cmd = GetCommand(sql);
                cmd.ExecuteNonQuery();
                DisposeCommand(cmd);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        /// <summary>
        ///  备份数据库
        /// </summary>
        /// <param name="dbname"></param>
        /// <param name="backname"></param>
        /// <returns></returns>
        public Boolean BackupDataBase(String dbname, String backname)
        {
            try
            {
                var sql = String.Format("backup database {0} to disk ='{1}'", dbname, backname);
                var cmd = GetCommand(sql);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///  分离数据库
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        public Boolean DetachDataBase(String dbname)
        {
            try
            {
                var sql = String.Format("EXEC sp_detach_db @dbname='{0}'", dbname);
                var cmd = GetCommand(sql);
                cmd.ExecuteNonQuery();
                DisposeCommand(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///  删除数据库
        /// </summary>
        /// <param name="dbname"></param>
        /// <returns></returns>
        public Boolean DeleteDataBase(String dbname)
        {
            try
            {
                var sql = String.Format("if exists (select * from sys.databases where name = '{0}') drop database [{1}]", dbname, dbname);
                var cmd = GetCommand(sql);
                cmd.ExecuteNonQuery();
                DisposeCommand(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ExecuteScript(String scriptname, String dbname)
        {
            try
            {
                var pr = new Process();
                pr.StartInfo.FileName = "osql.exe";
                pr.StartInfo.Arguments = String.Format("-U {0} -P {1} -d {2} -s {3} -i {4}", this.userID, this.password, dbname, this.dbServer, scriptname);
                pr.StartInfo.UseShellExecute = false;
                pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //隐藏输出窗口
                pr.StartInfo.RedirectStandardOutput = true; // 重定向输出
                pr.Start();

                var streamReader = pr.StandardOutput;
                var result = streamReader.ReadToEnd();

                pr.WaitForExit();
                pr.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

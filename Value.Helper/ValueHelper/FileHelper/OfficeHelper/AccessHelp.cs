/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 2.23.2013                |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.IO;
using System.Data;
using ADOX;
using System.Data.OleDb;
using System.Collections.Generic;

namespace ValueHelper.FileHelper.OfficeHelper
{
    public class AccessHelp : FileBase.FileBase
    {
        public AccessHelp() { }
        /// <summary>
        ///  设置要处理的文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SetFileName(string fileName)
        {
            base.SetParams(fileName);
        }

        public AccessHelp(string fileName)
        {
            base.SetParams(fileName);
        }

        private OleDbConnection getConn()
        {
            String connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + base.FileName;
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;
        }

        #region Create

        public override bool CreateFile()
        {
            if (CheckParams())
            {
                if (File.Exists(base.FileName))
                    return false;

                base.CreateDirectory();
                createFile();
                return true;
            }
            return false;
        }

        private void createFile()
        {
            Catalog catalog = new Catalog();
            catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + base.FileName + ";Jet OLEDB:Engine Type=5");
            catalog = null;
        }

        public Boolean CreateTable(String tableName, params ASColumn[] columns)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            if (String.IsNullOrEmpty(tableName))
                return false;
            try
            {
                ADOX.Catalog catalog = new Catalog();
                ADODB.Connection conn = new ADODB.Connection();
                conn.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + base.FileName, null, null, -1);
                catalog.ActiveConnection = conn;

                ADOX.Table table = new Table();
                table.Name = tableName;

                for (int i = 0; i < columns.Length; i++)
                {
                    ADOX.Column column = new Column();
                    column.ParentCatalog = catalog;
                    column.Name = columns[i].Name;
                    column.Type = columns[i].Type;
                    column.Attributes = columns[i].Attribute;
                    column.DefinedSize = columns[i].DefinedSize;
                    table.Columns.Append(column, column.Type, column.DefinedSize);
                    if (columns[i].Key != null)
                        table.Keys.Append(columns[i].Name + columns[i].Key.Type, columns[i].Key.Type, column, null, null);
                }
                catalog.Tables.Append(table);

                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Read

        public String[] GetTables()
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            var conn = getConn();
            conn.Open();
            System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            List<String> rows = new List<string>();
            foreach (DataRow dr in schemaTable.Rows)
            {
                rows.Add(dr["TABLE_NAME"].ToString());
            }
            conn.Close();
            return rows.ToArray();
        }

        public DataTable Query(String tableName, params String[] columns)
        {
            var sql = "SELECT ";
            for (int i = 0; i < columns.Length; i++)
            {
                sql += columns[i];
                if (i != columns.Length - 1)
                    sql += ",";
            }
            sql += "FROM " + tableName;
            return Query(sql);
        }

        public DataTable Query(String sql)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            var conn = getConn();
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            return dt;
        }

        #endregion

        #region Write

        public void DropTable(String tableName)
        {
            String sql = "DROP table " + tableName;
            Execute(sql);
        }

        public void Execute(String sql)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            var conn = getConn();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        #endregion

        #region ExtendClass

        public class ASColumn
        {
            public ColumnKey Key;
            public String Name;
            public DataTypeEnum Type;
            public ColumnAttributesEnum Attribute;

            private Int32 definedSize = 9;
            public Int32 DefinedSize
            {
                get
                {
                    return definedSize;
                }
                set
                {
                    definedSize = value;
                }
            }
        }

        public class ColumnKey
        {
            public KeyTypeEnum Type;
        }

        #endregion
    }
}

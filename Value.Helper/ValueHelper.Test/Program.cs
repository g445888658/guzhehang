using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueHelper.EncryptHelper;
using ValueHelper.Infrastructure;
using ValueHelper.MIMEHelper;
using ValueHelper.TDCodeHelper.QR2DCodeHelper;
using ValueHelper.TDCodeHelper.QR2DCodeHelper.Infrastructure;
using System.Windows.Forms;
using ValueHelper.FileHelper;
using ValueHelper.Image;
using System.Drawing;
using ValueHelper.Math;
using ValueHelper.IIS;
using ValueHelper.DataBase;
using ValueHelper.RegexHelper;
using ValueHelper.RegeditHelper;
//using ValueHelper.OtherHelper;

namespace ValueHelper.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Regedit
            //以下是读取的注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下的XXX目录中名称为name的注册表值； 
            //string registData;
            //RegistryKey hkml = Registry.LocalMachine;
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            //RegistryKey safe = software.OpenSubKey("360Safe", true);
            //RegistryKey Liveup = safe.OpenSubKey("Liveup", true);
            //registData = Liveup.GetValue("mid").ToString();

            //以上是在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下新建XXX目录并在此目录下创建名称为name值为tovalue的注册表项； 
            //RegistryKey hklm = Registry.LocalMachine;
            //RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
            //RegistryKey aimdir = software.CreateSubKey("Ezio");
            //aimdir.SetValue("test", "123"); 

            //以上是在注册表中HKEY_LOCAL_MACHINE\SOFTWARE目录下XXX目录中删除名称为name注册表项；
            //string[] aimnames;
            //RegistryKey hkml = Registry.LocalMachine;
            //RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            //aimnames = software.GetSubKeyNames();
            //foreach (string aimKey in aimnames)
            //{
            //    if (aimKey == "Ezio")
            //        software.DeleteSubKeyTree("Ezio");
            //}


            //判断指定注册表项是否存在 
            bool _exit = false;
            string[] subkeyNames;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
            RegistryKey aimdir = software.OpenSubKey("360Safe", true);
            subkeyNames = aimdir.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                if (keyName == "Liveup")
                {
                    _exit = true;
                }
            }




            Console.ReadLine();
            #endregion

            #region RegexHelper
            //CommonRegex commonRegex = new RegexHelper.CommonRegex();
            //Console.WriteLine(commonRegex.IDCardRegex("330481199210244853").Msg);
            //Console.ReadLine();
            #endregion

            #region ValueFileHelper

            //FileBase fileHelper = FileBase.GetFileBase("E:\\Text2.txt");
            //fileHelper.CreateFile();
            ////fileHelper.WriteLine("asdsadasdsadsadaanak\r\ndasdasd", true);
            //String context = fileHelper.ReadContext();
            //Console.WriteLine(context);

            #endregion

            var source = "123456";
            #region ValueMD5Helper

            var encryptCodeMD5 = MD5Helper.Encrypt(source);
            Console.WriteLine(encryptCodeMD5);
            Console.WriteLine("MD5Helper Result");
            Console.WriteLine();
            #endregion

            #region ValueDESHelper

            // 由于每次key 都不同所以要注意加密与解密的时间性
            // DESkey是64位二进制,转字符串的话就是8个字符
            var key = DESHelper.GenerateKey();

            var encryptCodeDES = DESHelper.Encrypt(source, key);
            Console.WriteLine(encryptCodeDES);

            var decryptCodeDES = DESHelper.Decrypt(source, key);
            Console.WriteLine(decryptCodeDES);
            Console.WriteLine("DESHelper Result");
            Console.WriteLine();
            #endregion

            #region StringHelper

            String[] array = new String[] { "1", "2", "3", "4" };
            var str = StringHelper.ConvertToString(array, ';');
            Console.WriteLine(str);

            var strArry = StringHelper.Split(str, ';');
            foreach (var item in strArry)
            {
                Console.Write(item + " ");
            }

            var str2 = "asdajdahda\r\nasdasda\r\nasdasdasd\r\n";
            Console.WriteLine("asdajdahda\\r\\nasdasda\\r\\nasdasdasd\\r\\nsdfsdfsdf");
            Console.WriteLine("StringHelper.SplitByCRLF()");
            var tst = StringHelper.SplitByCRLF(str2, StringSplitOptions.RemoveEmptyEntries);

            var strArry2 = StringHelper.SplitByCRLF(str2, StringSplitOptions.None);
            foreach (var item in strArry2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("StringHelper Result");
            Console.WriteLine();
            #endregion

            #region RandomHelper

            Console.WriteLine(RandomHelper.NewRandom());
            Console.WriteLine(RandomHelper.NewRandom(6));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.Number));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.String));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.Number, 6));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.String, 6));
            Console.WriteLine(RandomHelper.NewRandom('Z', 'Z'));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.Number, '1', 'a'));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.String, 'a', 'f'));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.Number, '1', '4', 6));
            Console.WriteLine(RandomHelper.NewRandom(RandomType.String, 'a', 'f', 6));
            Console.WriteLine("RandomHelper Result");
            Console.WriteLine();

            #endregion

            #region QPHelper

            String QPString = "管理员";
            String QPEncodeStr = QPHelper.Encrypt(QPString, Encoding.UTF8);
            Console.WriteLine(QPEncodeStr);
            Console.WriteLine(QPHelper.Decrypt2(QPEncodeStr, Encoding.UTF8));
            Console.WriteLine(QPHelper.Decrypt(QPEncodeStr, Encoding.UTF8));
            #endregion

            #region MIMEHelper

            //var mime = "Content-Type: multipart/alternative; \r\n\tboundary=\"----=_Part_73323_510855019.1362313432376\"\r\nDate: Sun, 3 Mar 2013 20:23:52 +0800 (CST)\r\nFrom: zformular <zformular@163.com>\r\nSubject: =?GBK?B?0ru2/sj9y8TO5cH5xt+wy77Fyq7KrtK7yq62/squyP0=?=\r\n =?GBK?B?yq7LxMquzuXKrsH5yq7G38qusMvKrr7Ftv7Krrb+yq4=?=\r\n";
            ////mime = "Content-Transfer-Encoding: 8Bit\r\nContent-Type: multipart/mixed;\r\n\tboundary=\"----=_NextPart_5099C48D_D63B7690_6364F090\"\r\n";
            ////var mime = "Date: Mon, 25 Mar 2013 18:28:25 +0800\r\nFrom: \"=?gb2312?B?zNrRtsbz0rXTys/k?=\" <10000@qq.com>\r\nTo: \"=?gb2312?B?zNrRtsbz0rXTys/k08O7pw==?=\"\r\nSubject: =?gb2312?B?u7bTrcq508PM2tG2xvPStdPKz+Q=?=\r\nMessage-ID: <10000@qq.com>\r\nX-QQ-STYLE: 1\r\nContent-Type: text/html;\r\n        charset=\"gb2312\"\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n\t<title></title>\r\n<style type=\"text/css\">\r\nbody{background:#ECECEC;font-family:\"lucida Grande\",Verdana;}\r\n.invite{width:606px;margin:0 auto;overflow:hidden;}\r\n.invite, .invite td, .invite th{border-collapse:collapse;padding:0;vertical-align:middle;}\r\n.invite th{font-weight:bold;font-size:16px;color:white;text-align:left;background:#3B5999;}\r\n.invite th .mailLogo{margin:-2px 5px 0 0; padding:0 0 0 30px;}\r\n.invite th div{height:65px;overflow:hidden;}\r\n.invite .borderLeft{width:4px;*width:3px;border-left:1px solid #EBEBEB;border-right:1px solid #C9C9C9;background:#E9E9E9;}\r\n.invite .borderRight{width:3px;border-left:1px solid #C9C9C9;border-right:1px solid #EBEBEB;background:#E9E9E9;}\r\n.invite h2{margin:26px 34px 16px;font-size:18px;font-weight:bold;}\r\n.invite p{color:#313131;display:block;font-size:14px;line-height:150%;padding:1px 34px 21px;margin:0;}\r\n.invite p.team, .invite p.team a{color:#999999;text-decoration:none;}\r\n.invite p.team a:hover{color:#999999;text-decoration:underline;}\r\n.invite a{color:#3B5999}\r\n</style>\r\n</head>\r\n<body>\r\n<div style=\"background:#ECECEC;\">\r\n<table class=\"invite\" align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">\r\n\t<tr>\r\n\t\t<td colspan=\"4\" class=\"radius\" style=\"vertical-align:bottom;overflow:hidden;line-height:6px;font-size:0;\"><img src=\"http://exmail.qq.com/zh_CN/htmledition/images/newicon/sysmail/mail_invite_top.png\" alt=\"\" /></td>\r\n\t</tr>\r\n\t<tr>\r\n\t\t<td rowspan=\"2\" class=\"border borderLeft\"></td>\r\n\t\t<th width=\"416\"><img src=\"http://exmail.qq.com/zh_CN/htmledition/images/logo/logo_sysmail_biz_0.gif\" alt=\"mail企业邮箱\" class=\"mailLogo\"/>欢迎信</th>\r\n\t\t<th width=\"180\"><div><img src=\"http://exmail.qq.com/zh_CN/htmledition/images/bizmail/top_biz.gif\" class=\"mailBg\"/></div></th>\r\n\t\t<td rowspan=\"2\" class=\"border borderRight\"></td>\r\n\t</tr>\r\n\t<tr>\r\n\t\t<td colspan=\"2\">\r\n\t\t\t<p style=\"margin-top:20px;\">叶夏，您好：</p>\r\n\t\t\t<p>欢迎启用您的企业邮箱，请收藏登录地址 <a href=\"http://exmail.qq.com/login\" target=\"_blank\">http://exmail.qq.com/login</a>。<br/>\r\n\t\t\t如果您想通过Outlook，Foxmail来管理邮件，可在这里查看<a href=\"http://service.exmail.qq.com/cgi-bin/help?subtype=1&&id=28&&no=1000564\" target=\"_blank\">设置方法</a>。</p>\r\n\t\t\t<p>腾讯企业邮箱支持发送50MB普通附件，2GB超大附件。更有：</p>\r\n\t\t\t<p>\r\n\t\t\t<img src=\"http://exmail.qq.com/zh_CN/htmledition/images/bizmail/icon_bindqq.png\" style=\"vertical-align:middle;margin-right:4px\" height=\"18\" width=\"18px\"/>\r\n\t\t\t<strong>绑定QQ</strong><br/>\r\n\t\t\t<span style=\"margin-left:27px;\">新邮件将在QQ上提醒，还能一键登录，沟通更方便。</span>\r\n\t\t\t</p>\r\n\t\t\t<p>\r\n\t\t\t<img src=\"http://exmail.qq.com/zh_CN/htmledition/images/bizmail/icon_bindwx.png\" style=\"vertical-align:middle;margin-right:4px\" height=\"18\" width=\"18px\"/>\r\n\t\t\t<strong>微信提醒</strong><br/>\r\n\t\t\t<span style=\"margin-left:27px;\">微信助手帮你随时处理新来信、日程提醒，还能快捷查询同事联系方式 。</span>\r\n\t\t\t</p>\r\n\t\t\t<p>\r\n\t\t\t\t<img src=\"http://exmail.qq.com/zh_CN/htmledition/images/bizmail/icon_exsfile.gif\" style=\"vertical-align:middle;margin-right:4px\" height=\"18\" width=\"18px\"/>\r\n\t\t\t\t<strong>企业网盘</strong><br/>\r\n\t\t\t\t<span style=\"margin-left:27px;\">与同事共享文档、照片变得更简单，只需上传到企业网盘轻松共享。</span>\r\n\t\t\t</p>\r\n\t\t\t<p style=\"margin-left:27px;\">\r\n\t\t\t\t<a href=\"http://exmail.qq.com/cgi-bin/readtemplate?check=false&t=bizmail_learnmore.html\" target=\"_blank\">了解更多</a>\r\n\t\t\t</p>\r\n\t\t\t<p>\r\n\t\t\t\t祝您使用愉快。如果有任何疑惑，欢迎发信至 <a href=\"mailto:bizsupport@qq.com\">bizsupport@qq.com</a> 获取帮助。\r\n\t\t\t</p>\r\n\t\t\t<p class=\"team\">\r\n\t\t\t\t腾讯企业邮箱<br />\r\n\t\t\t\t<span style=\"background:#ddd;height:1px;width:100%;overflow:hidden;display:block;margin:2px 0;\"></span>\r\n\t\t\t\t腾讯企业邮箱门户：<a href=\"http://exmail.qq.com\" target=\"_blank\">http://exmail.qq.com</a><br/>\r\n\t\t\t\t企业邮箱帮助中心：<a href=\"http://service.exmail.qq.com\" target=\"_blank\">http://service.exmail.qq.com</a>\t\r\n\t\t\t</p>\r\n\t\t</td>\r\n\t</tr>\r\n\t<tr>\r\n\t\t<td colspan=\"4\"  style=\"vertical-align:top;line-height:5px;overflow:hidden;font-size:0;\"><img src=\"http://exmail.qq.com/zh_CN/htmledition/images/newicon/sysmail/mail_invite_bottom.png\" alt=\"\" /></td>\r\n\t</tr>\r\n</table>\r\n</div>\r\n</body>\r\n</html>\r\n";
            //var sad = ValueMIME.SerializeMIME(mime);

            #endregion

            #region TDCodeHelper



            #endregion

            #region FileHelper

            //FileManager.CreateFile("D:\\test.txt");
            //FileManager.CreateFile("D:\\test.doc");
            //FileManager.CreateFile("D:\\test.xls");
            //FileManager.CreateFile("D:\\test.mdb");

            //var access = FileManager.GetAccessHelp();
            //access.SetFileName("D:\\test.mdb");

            //var cols = new ValueHelper.FileHelper.OfficeHelper.AccessHelp.ASColumn[2];
            //cols[0] = new FileHelper.OfficeHelper.AccessHelp.ASColumn
            //{
            //    DefinedSize = 9,
            //    Name = "col0",
            //    Type = ADOX.DataTypeEnum.adInteger,
            //    Key = new ValueHelper.FileHelper.OfficeHelper.AccessHelp.ColumnKey()
            //    {
            //        Type = ADOX.KeyTypeEnum.adKeyPrimary
            //    }
            //};
            //cols[1] = new FileHelper.OfficeHelper.AccessHelp.ASColumn
            //{
            //    DefinedSize = 30,
            //    Name = "col1",
            //    Type = ADOX.DataTypeEnum.adVarWChar
            //};

            //var tables = access.GetTables();
            ////access.DropTable(tables[0]);
            //access.CreateTable("test", cols);

            #endregion

            //Byte asd = (Byte)'s';
            //var asdddd = asd | 0;

            //var asdd = Convert.ToString(asd, 2);
            //Value2DCode value2DCode = new Value2DCode();

            //var bitmap = value2DCode.ProduceBitmap("123");
            //bitmap.Save("D:\\二维码测试.jpg");


            #region ValueWebcam


            //Form frmtest = new Form();
            //frmtest.Width = 400;
            //frmtest.Height = 400;
            //frmtest.Controls.Add(valueWebcam.Content);
            //valueWebcam.OpenWebcam();

            //frmtest.FormClosing += new FormClosingEventHandler(frmtest_FormClosing);


            #endregion

            /// 未实现
            //////////#region JSONHelper

            //////////var jsonstr = "[{\"UserId\":\"11\",\"UserName\":{\"FirstName\":\"323\",\"LastName\":\"2323\"},\"Keys\":[\"xiaoming\",\"xiaohong\"]},{\"UserId\":\"22\",\"UserName\":{\"FirstName\":\"323\",\"LastName\":\"2323\"},\"Keys\":[\"xiaoming\",\"xiaohong\"]},{\"UserId\":\"33\",\"UserName\":{\"FirstName\":\"323\",\"LastName\":\"2323\"},\"Keys\":[\"xiaoming\",\"xiaohong\"]}]";
            //////////JSONHelper.Parse(jsonstr);

            //////////#endregion

            #region ValueImage

            //var imageHelper = ValueImage.GetInstance();
            //var srcImage = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\Image\logo.png");
            //var zoomImage = imageHelper.ZoomImage(srcImage as Bitmap, 4F);
            //zoomImage.Save(@"C:\Users\Administrator\Desktop\Image\zoom.png");

            //var cutImage = imageHelper.CutImage(srcImage as Bitmap, 0, 0, srcimage.Width / 2, srcimage.Height / 2);
            //cutImage.Save(@"C:\Users\Administrator\Desktop\Image\cut.png");

            //var grayscalmaxImage = imageHelper.ConvertToGrayscale(srcImage as Bitmap, Image.Infrastructure.GrayscaleType.Maximum);
            //grayscalmaxImage.Save(@"C:\Users\Administrator\Desktop\Image\RGBMax.png");

            //var grayscalminImage = imageHelper.ConvertToGrayscale(srcImage as Bitmap, Image.Infrastructure.GrayscaleType.Minimal);
            //grayscalminImage.Save(@"C:\Users\Administrator\Desktop\Image\RGBMin.png");

            //var grayscalaverageImage = imageHelper.ConvertToGrayscale(srcImage as Bitmap, Image.Infrastructure.GrayscaleType.Average);
            //grayscalaverageImage.Save(@"C:\Users\Administrator\Desktop\Image\RGBAverage.png");

            //var graysvalweigthImage = imageHelper.ConvertToGrayscale(srcImage as Bitmap, 0.3F, 0.59F, 0.11F);
            //graysvalweigthImage.Save(@"C:\Users\Administrator\Desktop\Image\RGBWeight.png");

            #endregion

            #region ValueMath

            var mathHelper = ValueMath.GetInstance();

            var list = new Int32[] { 10, 2, 505, 54, 11, 45, 12, 6, 15, 2, 7, 56 };

            //mathHelper.ChurningDescending(list);

            //mathHelper.ChurningAscending(list);

            //mathHelper.InsertionDescending(list);

            mathHelper.MergenAscending(list, 0, list.Length);

            #endregion

            //// Console.ReadLine();
            //var iisHelper = new IISHelper("localhost");
            //iisHelper.CreateWebSite(new WebSiteInfo
            // {
            //     Physicaldir = @"D:\",
            //     Virtualdir = String.Empty,
            //     Name = "test",
            //     IP = String.Empty,
            //     Port = "8010",
            //     ThreadPoolName = "testpool"
            // });

            //var dbHelper = new ValueDBHelper(".\\sql2005", "sa", "123456");

            //dbHelper.AttachDataBase("OrderDB", @"D:\OrderBD\OrderDB.mdf", @"D:\OrderBD\OrderDB_log.ldf");
        }
    }
}

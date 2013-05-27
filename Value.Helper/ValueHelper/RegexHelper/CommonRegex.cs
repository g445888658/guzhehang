using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ValueHelper.RegexHelper
{
    public class CommonRegex
    {
        /*15位身份证号码=6位地区代码+6位生日+3位编号
         *18位身份证号码=6位地区代码+8位生日+3位编号+1位检验码
         *各省市地区国家代码前两位代码是：     
         *北京   11   吉林   22     福建   35   广东   44   云南   53   天津   12   黑龙江   23     江西   36   广西   45     西藏   54   河北   13     上海   31     山东   37     海南   46     陕西   61     山西   14     江苏   32     河南   41     重庆   50   
         *甘肃   62   内蒙古   15     浙江   33     湖北   42     四川   51     青海   63       辽宁   21     安徽   34     湖南   43     贵州   52     宁夏   64     新疆   65     台湾   71     香港   81     澳门   82     国外   91*/

        private String[] City = new String[] { null, null, null, null, null, null, null, null, null, null, null, "北京", "天津", "河北", "山西", "内蒙古", null, null, null, null, null, "辽宁", "吉林", "黑龙江", null, null, null, null, null, null, null, "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", null, null, null, "河南", "湖北", "湖南", "广东", "广西", "海南", null, null, null, "重庆", "四川", "贵州", "云南", "西藏", null, null, null, null, null, null, "陕西", "甘肃", "青海", "宁夏", "新疆", null, null, null, null, null, "台湾", null, null, null, null, null, null, null, null, null, "香港", "澳门", null, null, null, null, null, null, null, null, "国外" };


        private String[,] Beijing = new String[,] 
        {
            {"110000","北京市"},{"110100","北京市辖区"},{"110101","北京市东城区"},{"110102","北京市西城区"},{"110103","北京市崇文区"},{"110104","北京市宣武区"},
            {"110105","北京市朝阳区"},{"110106","北京市丰台区"},{"110107","北京市石景山区"},{"110108","北京市海淀区"},{"110109","北京市门头沟区"},
            {"110111","北京市房山区"},{"110112","北京市通州区"},{"110113","北京市顺义区"},{"110114","北京市昌平区"},{"110115","北京市大兴区"},{"110116","北京市怀柔区"},
            {"110117","北京市平谷区"},{"110200","北京市县"},{"110228","北京市密云县"},{"110229","北京市延庆县"}
        };

        private String[,] zhejiang = new String[,] 
        {
            {"330000","浙江省"},{"330100","浙江省杭州市"},{"330101","浙江省市辖区"},{"330102","浙江省上城区"},{"330103","浙江省下城区"},{"330104","浙江省江干区"},
            {"330105","拱墅区"},{"330106","西湖区"},{"330108","滨江区"},{"330109","萧山区"},{"330110","余杭区"},
            {"330122","桐庐县"},{"330127","淳安县"},{"330182","建德市"},{"330183","富阳市"},{"330185","临安市"},{"330200","宁波市"},
            {"330201","市辖区"},{"330203","海曙区"},{"330204","江东区"},{"330205","江北区"},{"330206","北仑区"},{"330211","镇海区"},{"330212","鄞州区"}
            ,{"330225","象山县"},{"330226","宁海县"},{"330281","余姚市"},{"330282","慈溪市"},{"330283","奉化市"},{"330300","温州市"},{"330301","市辖区"}
            ,{"330302","鹿城区"},{"330303","龙湾区"},{"330304","瓯海区"},{"330322","洞头县"},{"330324","永嘉县"},{"330326","平阳县"},{"330327","苍南县"}
            ,{"330328","文成县"},{"330329","泰顺县"},{"330381","瑞安市"},{"330382","乐清市"},{"330400","嘉兴市"},{"330401","市辖区"},{"330402","秀城区"}
            ,{"330411","秀洲区"},{"330421","嘉善县"},{"330424","海盐县"},{"330481","海宁市"},{"330482","平湖市"},{"330483","桐乡市"},{"330500","湖州市"}
            ,{"330501","市辖区"},{"330502","吴兴区"},{"330503","南浔区"},{"330521","德清县"},{"330522","长兴县"},{"330523","安吉县"},{"330600","绍兴市"}
            ,{"330601","市辖区"},{"330602","越城区"},{"330621","绍兴县"},{"330624","新昌县"},{"330681","诸暨市"},{"330682","上虞市"},{"330683","嵊州市"}
            ,{"330700","金华市"},{"330701","市辖区"},{"330702","婺城区"},{"330703","金东区"},{"330723","武义县"},{"330726","浦江县"},{"330727","磐安县"}
            ,{"330781","兰溪市"},{"330782","义乌市"},{"330783","东阳市"},{"330784","永康市"},{"330800","衢州市"},{"330801","市辖区"}
            ,{"330802","柯城区"},{"330803","衢江区"},{"330822","常山县"},{"330824","开化县"},{"330825","龙游县"},{"330881","江山市"}
            ,{"331000","台州市"},{"331001","市辖区"},{"331002","椒江区"},{"331003","黄岩区"},{"331004","路桥区"},{"331021","玉环县"}
            ,{"331022","三门县"},{"331023","天台县"},{"331024","仙居县"},{"331081","温岭市"},{"331082","临海市"},{"330900","丽水市"}
            ,{"331101","市辖区"},{"331102","莲都区"},{"331121","青田县"},{"331122","缙云县"},{"331123","遂昌县"},{"331124","松阳县"}
            ,{"331125","云和县"},{"331126","庆元县"},{"331127","景宁畲族自治县"},{"331181","龙泉市"}
        };



        /*校验码(最后一位号码)
        *（1）十七位数字本体码加权求和公式
        *S = Sum(Ai * Wi), i = 0, ... , 16 ，先对前17位数字的权求和
        *Ai:表示第i位置上的身份证号码数字值
        *Wi:表示第i位置上的加权因子
        *Wi: 7 9 10 5 8 4 2 1 6 3 7 9 10 5 8 4 2 
        
        *（2）计算模
        *Y = mod(S, 11)

        *（3）通过模得到对应的校验码
        *Y: 0 1 2 3 4 5 6 7 8 9 10
        *校验码: 1 0 X 9 8 7 6 5 4 3 2*/
        private Int32[] Wi = new Int32[] { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
        private String[] Y = new String[] { "1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2" };

        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="Text">要验证的文本</param>
        /// <param name="Num">身份证位数</param>
        /// <returns></returns>
        public ArgsHelper IDCardRegex(String str)
        {
            if (str.Length == 18)
            {
                Regex rg = new Regex(@"^\d{18}$|^\d{17}[\d|X|x]$", RegexOptions.IgnoreCase);
                if (rg.IsMatch(str))//基本验证
                {
                    if (Int32.Parse(str.Substring(0, 2)) > 91)
                    {
                        return new ArgsHelper("非法地区");
                    }
                    if (City[Int32.Parse(str.Substring(0, 2))] == null)//验证地区
                        return new ArgsHelper("非法地区");

                    for (int i = 0; i < zhejiang.GetLength(0); i++)
                    {
                        if (zhejiang[i, 0] == str.Substring(0, 6))
                        {
                            var area = zhejiang[i, 1];
                        }
                    }


                    var year = str.Substring(6, 4);
                    var month = str.Substring(10, 2);
                    var day = str.Substring(12, 2);
                    var birth = year + "-" + month + "-" + day;
                    try
                    {
                        DateTime.Parse(birth);//验证生日
                    }
                    catch (Exception)
                    {
                        return new ArgsHelper("非法生日");
                    }

                    //验证校验码
                    Int32 sum = 0;
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        sum += (Int32.Parse(str[i].ToString()) * Wi[i]);
                    }
                    Int32 index = sum % 11;
                    String code = Y[index];
                    if (code != str[17].ToString())
                        return new ArgsHelper("非法证号");

                    var sex = str.Substring(16, 1);
                    var Sex = "";
                    if (Int32.Parse(sex.ToString()) % 2 == 0)
                        Sex = "女";
                    else
                        Sex = "男";
                    return new ArgsHelper(Sex, true);
                }
                else
                    return new ArgsHelper("非法证号");
            }
            else if (str.Length == 15)
            {
                Regex rg = new Regex(@"^\d{15}$", RegexOptions.IgnoreCase);
                if (rg.IsMatch(str))//基本验证
                {
                    if (City[Int32.Parse(str.Substring(0, 2))] == null)//验证地区
                        return new ArgsHelper("非法地区");

                    var year = str.Substring(6, 2);
                    var month = str.Substring(8, 2);
                    var day = str.Substring(10, 2);
                    var birth = year + "-" + month + "-" + day;
                    try
                    {
                        DateTime.Parse(birth);//验证生日
                    }
                    catch (Exception)
                    {
                        return new ArgsHelper("非法生日");
                    }


                    var sex = str.Substring(14, 1);
                    var Sex = "";
                    if (Int32.Parse(sex.ToString()) % 2 == 0)
                        Sex = "女";
                    else
                        Sex = "男";
                    return new ArgsHelper(Sex, true);

                }
                else
                    return new ArgsHelper("非法证号");
            }
            else
                return new ArgsHelper("非法证号");
        }





    }
}

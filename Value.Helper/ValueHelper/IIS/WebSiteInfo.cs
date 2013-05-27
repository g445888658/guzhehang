using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.IIS
{
    public class WebSiteInfo
    {
        /// <summary>
        ///  物理路径
        /// </summary>
        public String Physicaldir { get; set; }

        /// <summary>
        ///  虚拟路径
        /// </summary>
        public String Virtualdir { get; set; }

        /// <summary>
        ///  网站名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///  端口
        /// </summary>
        public String Port { get; set; }

        /// <summary>
        ///  线程池名称
        /// </summary>
        public String ThreadPoolName { get; set; }

        /// <summary>
        ///  IP地址
        /// </summary>
        public String IP { get; set; }
    }
}

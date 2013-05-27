using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.RegexHelper
{
    public class ArgsHelper
    {
        private Boolean flag;
        public Boolean Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        private String msg;
        public String Msg
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }

        /// <summary>
        /// 返回true
        /// </summary>
        public ArgsHelper()
        {
            this.flag = true;
        }

        /// <summary>
        /// 返回false
        /// </summary>
        public ArgsHelper(String msg)
        {
            this.msg = msg;
        }

        public ArgsHelper(Boolean flag)
        {
            this.flag = flag;
        }

        public ArgsHelper(String msg, Boolean flag)
        {
            this.flag = flag;
            this.msg = msg;
        }
    }
}

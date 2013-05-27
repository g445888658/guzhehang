using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValueHelper.HotKeyHelper;

namespace ValueHelper.FrmUI
{
    public partial class HotKeyFrm : Form
    {
        public HotKeyFrm()
        {
            InitializeComponent();
        }

        private void HotKeyFrm_Activated(object sender, EventArgs e)
        {
            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);

            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.B);

            //注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Alt, Keys.D);

        }

        private void HotKeyFrm_Leave(object sender, EventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);

            //注销Id号为101的热键设定
            HotKey.UnregisterHotKey(Handle, 101);

            //注销Id号为102的热键设定
            HotKey.UnregisterHotKey(Handle, 102);

        }

        /// <summary>
        /// 重载From中的WndProc函数
        /// 监视Windows消息
        /// 重载WndProc方法，用于实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是Shift+S
                            //此处填写快捷键响应代码    
                            System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\calc.exe");
                            break;
                        case 101:    //按下的是Ctrl+B
                            //此处填写快捷键响应代码
                            break;
                        case 102:    //按下的是Alt+D
                            //此处填写快捷键响应代码
                            break;
                    }
                    break;
            }

            base.WndProc(ref m);
        }


    }
}

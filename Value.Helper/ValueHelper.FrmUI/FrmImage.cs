using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValueHelper.FrmUI
{
    public partial class FrmHistImage : Form
    {
        public FrmHistImage(Action<Graphics> act)
        {
            InitializeComponent();

            this.PicImage.Paint += new PaintEventHandler(delegate(Object sender, PaintEventArgs e)
            {
                var graphics = e.Graphics;
                graphics.Clear(Color.White);
                graphics.TranslateTransform(0, this.PicImage.Height);
                graphics.ScaleTransform(1, -0.5F);
                act(e.Graphics);
            });
        }
    }
}

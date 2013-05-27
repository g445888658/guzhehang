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
    public partial class FrmGrayscaleStretch : Form
    {
        private static FrmGrayscaleStretch instance;

        public static FrmGrayscaleStretch GetInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new FrmGrayscaleStretch();

            return instance;
        }

        private FrmGrayscaleStretch()
        {
            InitializeComponent();
        }
        private Action<Point, Point> action;

        public void SetAction(Action<Point, Point> act)
        {
            this.action = act;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var point1 = new Point(Int32.Parse(this.TxtX1.Text), Int32.Parse(this.TxtY1.Text));
            var point2 = new Point(Int32.Parse(this.TxtX2.Text), Int32.Parse(this.TxtY2.Text));

            var graphics = this.PicShowLine.CreateGraphics();
            var pen = new Pen(Color.Blue);
            graphics.Clear(Color.White);
            graphics.TranslateTransform(0, this.PicShowLine.Height);
            graphics.ScaleTransform(1, -1);
            graphics.DrawLine(pen, new Point(0, 0), point1);
            graphics.DrawLine(pen, point1, point2);
            graphics.DrawLine(pen, point2, new Point(255, 255));

            this.action(point1, point2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValueHelper.Image;
using ValueHelper.Image.Infrastructure;

namespace ValueHelper.FrmUI
{
    public partial class FrmImageTest : Form
    {
        private ValueImage imageHelper;
        private OpenFileDialog fileDialog;
        private String fileName;

        public FrmImageTest()
        {
            InitializeComponent();
            fileDialog = new OpenFileDialog();
            imageHelper = ValueImage.GetInstance();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                this.PicImage.Image = System.Drawing.Image.FromFile(fileName);
            }
        }

        private void BtnOriImage_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(fileName)) return;
            this.PicImage.Image = System.Drawing.Image.FromFile(fileName);
        }

        private void BtnGrayscalMax_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.ConvertToGrayscale(srcImage, Image.Infrastructure.GrayscaleType.Maximum);
            this.PicImage.Refresh();
        }

        private void BtnGrayscalMin_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.ConvertToGrayscale(srcImage, Image.Infrastructure.GrayscaleType.Minimal);
            this.PicImage.Refresh();
        }

        private void BtnGrayscalAverage_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.ConvertToGrayscale(srcImage, Image.Infrastructure.GrayscaleType.Average);
            this.PicImage.Refresh();
        }

        private void BtnHistogram_Click(object sender, EventArgs e)
        {
            var frmHistImage = new FrmHistImage(DrawHistogram);
            frmHistImage.Show();
        }

        private void DrawHistogram(Graphics graphics)
        {
            var pen = new Pen(Color.Blue);
            var srcImage = (Bitmap)this.PicImage.Image;
            var frequnce = imageHelper.GetFrequency(srcImage);
            for (int i = 0; i < frequnce.Length; i++)
            {
                graphics.DrawLine(pen, i, 0, i, frequnce[i]);
            }
        }

        private void BtnGrayscaleStretch_Click(object sender, EventArgs e)
        {
            FrmGrayscaleStretch frmStretch = FrmGrayscaleStretch.GetInstance();
            frmStretch.SetAction(GrayscaleStretch);

            frmStretch.Show();
        }

        public void GrayscaleStretch(Point point1, Point point2)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.GrayscaleStretch(srcImage, point1.X, point1.Y, point2.X, point2.Y);
            this.PicImage.Refresh();
        }

        private void BtnMedianFiltering_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.MedianFiltering(srcImage, Image.Infrastructure.MedianFilterFrame.F3X3);
            this.PicImage.Image = dstImage;
        }

        private void BtnBinarization_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.Binarization(srcImage, 155);
            this.PicImage.Image = dstImage;
        }

        private void BtnHistEqualization_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.HistEqualization(srcImage);
            this.PicImage.Refresh();
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            //var srcImage = (Bitmap)this.PicImage.Image;
            //var angle = Int32.Parse(this.TxtRotate.Text);
            //var dstImage = imageHelper.RotateImage(srcImage, angle);
            //this.PicImage.Image = dstImage;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            //srcImage.Save(@"D:\tesqt.jpg");
            //var dstImage = imageHelper.KFill(srcImage);
            //var dstImage = robert(srcImage);
            //this.PicImage.Image = dstImage;
        }

        private void BtnlaplacianSharpen_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var frmlaplacianSharpen = FrmlaplacianSharpen.GetInstance();
            frmlaplacianSharpen.SetParameters(laplacianSharpen, getSrcImage);
            frmlaplacianSharpen.Show();
        }

        private Bitmap getSrcImage()
        {
            return (Bitmap)this.PicImage.Image;
        }

        private void laplacianSharpen(Bitmap dstImage)
        {
            this.PicImage.Image = dstImage;
        }

        private void BtnInvertColor_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.InvertColor(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnRobertsOperator_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.RobertsSharpen(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnkFill_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.KFill(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnPrewitt_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.PrewittSharpen(srcImage, OperatorSet.prewittOperator1);
            this.PicImage.Image = dstImage;
        }

        private void BtnRobinsion_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.RobinsonSharpen(srcImage, OperatorSet.robinsonOperator3);
            this.PicImage.Image = dstImage;
        }

        private void BtnKirsch_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.PrewittSharpen(srcImage, OperatorSet.kirschOperator3);
            this.PicImage.Image = dstImage;
        }

        private void BtnLoG_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.LoG5Sharpen(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnOstu_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.OstuVary(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnOptimal_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.OptimalThreshold(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnSobel_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.SobelSharpen(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnInnerBorder_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            var dstImage = imageHelper.InnerBorder(srcImage);
            this.PicImage.Image = dstImage;
        }

        private void BtnPersonEye_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.ConvertToGrayscale(srcImage, 0.299F, 0.587F, 0.114F);
            this.PicImage.Refresh();
        }

        private void BtnLinearChange_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.LinearChange(srcImage, -1F, 255F, FrequencyDimension.RGB);
            this.PicImage.Refresh();
        }

        private void BtnInnerGrayscale_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.GrayscaleStretch(srcImage, FrequencyDimension.RGB);
            this.PicImage.Refresh();
        }

        private void BtnHistMatch_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            // 这个是用来匹配的直方图;
            // 此处偷懒,用原图直方图替代
            var frequency = imageHelper.GetFrequency(srcImage);
            imageHelper.HistMatch(srcImage, frequency);
            this.PicImage.Refresh();
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.Move(srcImage, -100, 100);
            this.PicImage.Refresh();
        }

        private void BtnMirror_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.HoriMirror(srcImage);
            this.PicImage.Refresh();
        }

        private void BtnNearestInterpolation_Click(object sender, EventArgs e)
        {
            var srcImage = (Bitmap)this.PicImage.Image;
            imageHelper.NearestInterpolation(srcImage, 1, 1);
            this.PicImage.Refresh();
        }

        private void FrmImageTest_Load(object sender, EventArgs e)
        {
            //var bimt = new Bitmap(80, 80, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //for (int i = 0; i < 80; i++)
            //{
            //    for (int j = 0; j < 80; j++)
            //    {
            //        bimt.SetPixel(i, j, Color.Blue);
            //    }
            //}
            //bimt.Save("D:\\ts.jpg");
        }
    }
}

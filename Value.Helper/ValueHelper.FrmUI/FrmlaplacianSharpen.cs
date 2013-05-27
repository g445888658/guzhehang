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
    public partial class FrmlaplacianSharpen : Form
    {
        private ValueImage imageHelper = null;
        private Action<Bitmap> act;
        private Func<Bitmap> getImageFun;
        private Bitmap srcImage;

        private static FrmlaplacianSharpen frmLaplacian;
        public static FrmlaplacianSharpen GetInstance()
        {
            if (frmLaplacian == null || frmLaplacian.IsDisposed)
                frmLaplacian = new FrmlaplacianSharpen();

            return frmLaplacian;
        }

        public void SetParameters(Action<Bitmap> act, Func<Bitmap> getImageFun)
        {
            this.act = act;
            this.getImageFun = getImageFun;
        }

        private FrmlaplacianSharpen()
        {
            InitializeComponent();
            imageHelper = ValueImage.GetInstance();
        }

        private void BtnSharpen_Click(object sender, EventArgs e)
        {
            var type = this.CbolaplacianOperator.Items[this.CbolaplacianOperator.SelectedIndex].ToString();
            var strength = float.Parse(this.TxtStrength.Text);
            srcImage = this.getImageFun();
            switch (type)
            {
                case "3x3掩膜算子":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperator3, FrequencyDimension.R));
                    break;
                case "4x4掩膜算子":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperator4, FrequencyDimension.R));
                    break;
                case "5x5掩膜算子":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperator5, FrequencyDimension.R));
                    break;
                case "4-邻接算子":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperator4Adjoin, FrequencyDimension.R));
                    break;
                case "8-邻接算子":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperator8Adjoin, FrequencyDimension.R));
                    break;
                case "强调中心算子1":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperatorCenter1, FrequencyDimension.R));
                    break;
                case "强调中心算子2":
                    act(imageHelper.LaplacianSharpen(srcImage, strength, OperatorSet.laplacianOperatorCenter2, FrequencyDimension.R));
                    break;
            }
        }
    }
}

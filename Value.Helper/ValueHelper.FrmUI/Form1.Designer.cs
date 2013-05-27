namespace ValueHelper.FrmUI
{
    partial class FrmImageTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PicImage = new System.Windows.Forms.PictureBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnOriImage = new System.Windows.Forms.Button();
            this.BtnGrayscalMax = new System.Windows.Forms.Button();
            this.BtnGrayscalMin = new System.Windows.Forms.Button();
            this.BtnGrayscalAverage = new System.Windows.Forms.Button();
            this.BtnHist = new System.Windows.Forms.Button();
            this.BtnGrayscaleStretch = new System.Windows.Forms.Button();
            this.BtnMedianFiltering = new System.Windows.Forms.Button();
            this.BtnBinarization = new System.Windows.Forms.Button();
            this.BtnHistEqualization = new System.Windows.Forms.Button();
            this.BtnRotate = new System.Windows.Forms.Button();
            this.TxtRotate = new System.Windows.Forms.TextBox();
            this.BtnTest = new System.Windows.Forms.Button();
            this.BtnRaplacianSharpen = new System.Windows.Forms.Button();
            this.BtnInvertColor = new System.Windows.Forms.Button();
            this.BtnRobertsOperator = new System.Windows.Forms.Button();
            this.BtnkFill = new System.Windows.Forms.Button();
            this.BtnPrewitt = new System.Windows.Forms.Button();
            this.BtnRobinsion = new System.Windows.Forms.Button();
            this.BtnKirsch = new System.Windows.Forms.Button();
            this.BtnLoG = new System.Windows.Forms.Button();
            this.BtnOstu = new System.Windows.Forms.Button();
            this.BtnOptimal = new System.Windows.Forms.Button();
            this.BtnSobel = new System.Windows.Forms.Button();
            this.BtnInnerBorder = new System.Windows.Forms.Button();
            this.BtnPersonEye = new System.Windows.Forms.Button();
            this.BtnLinearChange = new System.Windows.Forms.Button();
            this.BtnInnerGrayscale = new System.Windows.Forms.Button();
            this.BtnHistMatch = new System.Windows.Forms.Button();
            this.BtnMove = new System.Windows.Forms.Button();
            this.BtnMirror = new System.Windows.Forms.Button();
            this.BtnNearestInterpolation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.BackColor = System.Drawing.Color.White;
            this.PicImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicImage.Location = new System.Drawing.Point(12, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(413, 371);
            this.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(431, 12);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(107, 23);
            this.BtnOpen.TabIndex = 1;
            this.BtnOpen.Text = "打开图像";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnOriImage
            // 
            this.BtnOriImage.Location = new System.Drawing.Point(431, 41);
            this.BtnOriImage.Name = "BtnOriImage";
            this.BtnOriImage.Size = new System.Drawing.Size(107, 23);
            this.BtnOriImage.TabIndex = 2;
            this.BtnOriImage.Text = "原图";
            this.BtnOriImage.UseVisualStyleBackColor = true;
            this.BtnOriImage.Click += new System.EventHandler(this.BtnOriImage_Click);
            // 
            // BtnGrayscalMax
            // 
            this.BtnGrayscalMax.Location = new System.Drawing.Point(431, 70);
            this.BtnGrayscalMax.Name = "BtnGrayscalMax";
            this.BtnGrayscalMax.Size = new System.Drawing.Size(107, 23);
            this.BtnGrayscalMax.TabIndex = 3;
            this.BtnGrayscalMax.Text = "最大值灰度图";
            this.BtnGrayscalMax.UseVisualStyleBackColor = true;
            this.BtnGrayscalMax.Click += new System.EventHandler(this.BtnGrayscalMax_Click);
            // 
            // BtnGrayscalMin
            // 
            this.BtnGrayscalMin.Location = new System.Drawing.Point(431, 99);
            this.BtnGrayscalMin.Name = "BtnGrayscalMin";
            this.BtnGrayscalMin.Size = new System.Drawing.Size(107, 23);
            this.BtnGrayscalMin.TabIndex = 4;
            this.BtnGrayscalMin.Text = "最小值灰度图";
            this.BtnGrayscalMin.UseVisualStyleBackColor = true;
            this.BtnGrayscalMin.Click += new System.EventHandler(this.BtnGrayscalMin_Click);
            // 
            // BtnGrayscalAverage
            // 
            this.BtnGrayscalAverage.Location = new System.Drawing.Point(431, 128);
            this.BtnGrayscalAverage.Name = "BtnGrayscalAverage";
            this.BtnGrayscalAverage.Size = new System.Drawing.Size(107, 23);
            this.BtnGrayscalAverage.TabIndex = 5;
            this.BtnGrayscalAverage.Text = "平均值灰度图";
            this.BtnGrayscalAverage.UseVisualStyleBackColor = true;
            this.BtnGrayscalAverage.Click += new System.EventHandler(this.BtnGrayscalAverage_Click);
            // 
            // BtnHist
            // 
            this.BtnHist.Location = new System.Drawing.Point(431, 186);
            this.BtnHist.Name = "BtnHist";
            this.BtnHist.Size = new System.Drawing.Size(107, 23);
            this.BtnHist.TabIndex = 6;
            this.BtnHist.Text = "直方图";
            this.BtnHist.UseVisualStyleBackColor = true;
            this.BtnHist.Click += new System.EventHandler(this.BtnHistogram_Click);
            // 
            // BtnGrayscaleStretch
            // 
            this.BtnGrayscaleStretch.Location = new System.Drawing.Point(431, 244);
            this.BtnGrayscaleStretch.Name = "BtnGrayscaleStretch";
            this.BtnGrayscaleStretch.Size = new System.Drawing.Size(107, 23);
            this.BtnGrayscaleStretch.TabIndex = 12;
            this.BtnGrayscaleStretch.Text = "灰度拉伸";
            this.BtnGrayscaleStretch.UseVisualStyleBackColor = true;
            this.BtnGrayscaleStretch.Click += new System.EventHandler(this.BtnGrayscaleStretch_Click);
            // 
            // BtnMedianFiltering
            // 
            this.BtnMedianFiltering.Location = new System.Drawing.Point(431, 273);
            this.BtnMedianFiltering.Name = "BtnMedianFiltering";
            this.BtnMedianFiltering.Size = new System.Drawing.Size(107, 23);
            this.BtnMedianFiltering.TabIndex = 13;
            this.BtnMedianFiltering.Text = "中值滤波";
            this.BtnMedianFiltering.UseVisualStyleBackColor = true;
            this.BtnMedianFiltering.Click += new System.EventHandler(this.BtnMedianFiltering_Click);
            // 
            // BtnBinarization
            // 
            this.BtnBinarization.Location = new System.Drawing.Point(431, 302);
            this.BtnBinarization.Name = "BtnBinarization";
            this.BtnBinarization.Size = new System.Drawing.Size(107, 23);
            this.BtnBinarization.TabIndex = 14;
            this.BtnBinarization.Text = "二值化";
            this.BtnBinarization.UseVisualStyleBackColor = true;
            this.BtnBinarization.Click += new System.EventHandler(this.BtnBinarization_Click);
            // 
            // BtnHistEqualization
            // 
            this.BtnHistEqualization.Location = new System.Drawing.Point(431, 215);
            this.BtnHistEqualization.Name = "BtnHistEqualization";
            this.BtnHistEqualization.Size = new System.Drawing.Size(107, 23);
            this.BtnHistEqualization.TabIndex = 15;
            this.BtnHistEqualization.Text = "直方图均衡化";
            this.BtnHistEqualization.UseVisualStyleBackColor = true;
            this.BtnHistEqualization.Click += new System.EventHandler(this.BtnHistEqualization_Click);
            // 
            // BtnRotate
            // 
            this.BtnRotate.Location = new System.Drawing.Point(770, 39);
            this.BtnRotate.Name = "BtnRotate";
            this.BtnRotate.Size = new System.Drawing.Size(107, 23);
            this.BtnRotate.TabIndex = 16;
            this.BtnRotate.Text = "旋转";
            this.BtnRotate.UseVisualStyleBackColor = true;
            this.BtnRotate.Click += new System.EventHandler(this.BtnRotate_Click);
            // 
            // TxtRotate
            // 
            this.TxtRotate.Location = new System.Drawing.Point(789, 12);
            this.TxtRotate.Name = "TxtRotate";
            this.TxtRotate.Size = new System.Drawing.Size(86, 21);
            this.TxtRotate.TabIndex = 17;
            this.TxtRotate.Text = "30";
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(800, 70);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(75, 23);
            this.BtnTest.TabIndex = 18;
            this.BtnTest.Text = "测试";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // BtnRaplacianSharpen
            // 
            this.BtnRaplacianSharpen.Location = new System.Drawing.Point(544, 12);
            this.BtnRaplacianSharpen.Name = "BtnRaplacianSharpen";
            this.BtnRaplacianSharpen.Size = new System.Drawing.Size(107, 23);
            this.BtnRaplacianSharpen.TabIndex = 19;
            this.BtnRaplacianSharpen.Text = "拉普拉斯锐化x7";
            this.BtnRaplacianSharpen.UseVisualStyleBackColor = true;
            this.BtnRaplacianSharpen.Click += new System.EventHandler(this.BtnlaplacianSharpen_Click);
            // 
            // BtnInvertColor
            // 
            this.BtnInvertColor.Location = new System.Drawing.Point(431, 360);
            this.BtnInvertColor.Name = "BtnInvertColor";
            this.BtnInvertColor.Size = new System.Drawing.Size(107, 23);
            this.BtnInvertColor.TabIndex = 20;
            this.BtnInvertColor.Text = "反色";
            this.BtnInvertColor.UseVisualStyleBackColor = true;
            this.BtnInvertColor.Click += new System.EventHandler(this.BtnInvertColor_Click);
            // 
            // BtnRobertsOperator
            // 
            this.BtnRobertsOperator.Location = new System.Drawing.Point(544, 41);
            this.BtnRobertsOperator.Name = "BtnRobertsOperator";
            this.BtnRobertsOperator.Size = new System.Drawing.Size(107, 23);
            this.BtnRobertsOperator.TabIndex = 21;
            this.BtnRobertsOperator.Text = "Roberts锐化";
            this.BtnRobertsOperator.UseVisualStyleBackColor = true;
            this.BtnRobertsOperator.Click += new System.EventHandler(this.BtnRobertsOperator_Click);
            // 
            // BtnkFill
            // 
            this.BtnkFill.Location = new System.Drawing.Point(544, 244);
            this.BtnkFill.Name = "BtnkFill";
            this.BtnkFill.Size = new System.Drawing.Size(107, 23);
            this.BtnkFill.TabIndex = 22;
            this.BtnkFill.Text = "kFill种子填色";
            this.BtnkFill.UseVisualStyleBackColor = true;
            this.BtnkFill.Click += new System.EventHandler(this.BtnkFill_Click);
            // 
            // BtnPrewitt
            // 
            this.BtnPrewitt.Location = new System.Drawing.Point(544, 70);
            this.BtnPrewitt.Name = "BtnPrewitt";
            this.BtnPrewitt.Size = new System.Drawing.Size(107, 23);
            this.BtnPrewitt.TabIndex = 23;
            this.BtnPrewitt.Text = "Prewitt锐化x3";
            this.BtnPrewitt.UseVisualStyleBackColor = true;
            this.BtnPrewitt.Click += new System.EventHandler(this.BtnPrewitt_Click);
            // 
            // BtnRobinsion
            // 
            this.BtnRobinsion.Location = new System.Drawing.Point(544, 99);
            this.BtnRobinsion.Name = "BtnRobinsion";
            this.BtnRobinsion.Size = new System.Drawing.Size(107, 23);
            this.BtnRobinsion.TabIndex = 24;
            this.BtnRobinsion.Text = "Robinsion锐化x3";
            this.BtnRobinsion.UseVisualStyleBackColor = true;
            this.BtnRobinsion.Click += new System.EventHandler(this.BtnRobinsion_Click);
            // 
            // BtnKirsch
            // 
            this.BtnKirsch.Location = new System.Drawing.Point(544, 128);
            this.BtnKirsch.Name = "BtnKirsch";
            this.BtnKirsch.Size = new System.Drawing.Size(107, 23);
            this.BtnKirsch.TabIndex = 25;
            this.BtnKirsch.Text = "Kirsch锐化x3";
            this.BtnKirsch.UseVisualStyleBackColor = true;
            this.BtnKirsch.Click += new System.EventHandler(this.BtnKirsch_Click);
            // 
            // BtnLoG
            // 
            this.BtnLoG.Location = new System.Drawing.Point(544, 157);
            this.BtnLoG.Name = "BtnLoG";
            this.BtnLoG.Size = new System.Drawing.Size(107, 23);
            this.BtnLoG.TabIndex = 26;
            this.BtnLoG.Text = "LoG锐化x2";
            this.BtnLoG.UseVisualStyleBackColor = true;
            this.BtnLoG.Click += new System.EventHandler(this.BtnLoG_Click);
            // 
            // BtnOstu
            // 
            this.BtnOstu.Location = new System.Drawing.Point(544, 186);
            this.BtnOstu.Name = "BtnOstu";
            this.BtnOstu.Size = new System.Drawing.Size(107, 23);
            this.BtnOstu.TabIndex = 27;
            this.BtnOstu.Text = "Ostu二值化";
            this.BtnOstu.UseVisualStyleBackColor = true;
            this.BtnOstu.Click += new System.EventHandler(this.BtnOstu_Click);
            // 
            // BtnOptimal
            // 
            this.BtnOptimal.Location = new System.Drawing.Point(431, 331);
            this.BtnOptimal.Name = "BtnOptimal";
            this.BtnOptimal.Size = new System.Drawing.Size(107, 23);
            this.BtnOptimal.TabIndex = 28;
            this.BtnOptimal.Text = "最优阈值化";
            this.BtnOptimal.UseVisualStyleBackColor = true;
            this.BtnOptimal.Click += new System.EventHandler(this.BtnOptimal_Click);
            // 
            // BtnSobel
            // 
            this.BtnSobel.Location = new System.Drawing.Point(544, 215);
            this.BtnSobel.Name = "BtnSobel";
            this.BtnSobel.Size = new System.Drawing.Size(107, 23);
            this.BtnSobel.TabIndex = 29;
            this.BtnSobel.Text = "Sobel算法";
            this.BtnSobel.UseVisualStyleBackColor = true;
            this.BtnSobel.Click += new System.EventHandler(this.BtnSobel_Click);
            // 
            // BtnInnerBorder
            // 
            this.BtnInnerBorder.Location = new System.Drawing.Point(544, 273);
            this.BtnInnerBorder.Name = "BtnInnerBorder";
            this.BtnInnerBorder.Size = new System.Drawing.Size(107, 23);
            this.BtnInnerBorder.TabIndex = 30;
            this.BtnInnerBorder.Text = "内边界测定";
            this.BtnInnerBorder.UseVisualStyleBackColor = true;
            this.BtnInnerBorder.Click += new System.EventHandler(this.BtnInnerBorder_Click);
            // 
            // BtnPersonEye
            // 
            this.BtnPersonEye.Location = new System.Drawing.Point(431, 157);
            this.BtnPersonEye.Name = "BtnPersonEye";
            this.BtnPersonEye.Size = new System.Drawing.Size(107, 23);
            this.BtnPersonEye.TabIndex = 31;
            this.BtnPersonEye.Text = "人眼最优灰度图";
            this.BtnPersonEye.UseVisualStyleBackColor = true;
            this.BtnPersonEye.Click += new System.EventHandler(this.BtnPersonEye_Click);
            // 
            // BtnLinearChange
            // 
            this.BtnLinearChange.Location = new System.Drawing.Point(544, 302);
            this.BtnLinearChange.Name = "BtnLinearChange";
            this.BtnLinearChange.Size = new System.Drawing.Size(107, 23);
            this.BtnLinearChange.TabIndex = 32;
            this.BtnLinearChange.Text = "线性变化";
            this.BtnLinearChange.UseVisualStyleBackColor = true;
            this.BtnLinearChange.Click += new System.EventHandler(this.BtnLinearChange_Click);
            // 
            // BtnInnerGrayscale
            // 
            this.BtnInnerGrayscale.Location = new System.Drawing.Point(544, 331);
            this.BtnInnerGrayscale.Name = "BtnInnerGrayscale";
            this.BtnInnerGrayscale.Size = new System.Drawing.Size(107, 23);
            this.BtnInnerGrayscale.TabIndex = 33;
            this.BtnInnerGrayscale.Text = "灰度拉伸内置算法";
            this.BtnInnerGrayscale.UseVisualStyleBackColor = true;
            this.BtnInnerGrayscale.Click += new System.EventHandler(this.BtnInnerGrayscale_Click);
            // 
            // BtnHistMatch
            // 
            this.BtnHistMatch.Location = new System.Drawing.Point(544, 360);
            this.BtnHistMatch.Name = "BtnHistMatch";
            this.BtnHistMatch.Size = new System.Drawing.Size(107, 23);
            this.BtnHistMatch.TabIndex = 34;
            this.BtnHistMatch.Text = "直方图匹配";
            this.BtnHistMatch.UseVisualStyleBackColor = true;
            this.BtnHistMatch.Click += new System.EventHandler(this.BtnHistMatch_Click);
            // 
            // BtnMove
            // 
            this.BtnMove.Location = new System.Drawing.Point(657, 12);
            this.BtnMove.Name = "BtnMove";
            this.BtnMove.Size = new System.Drawing.Size(107, 23);
            this.BtnMove.TabIndex = 35;
            this.BtnMove.Text = "平移";
            this.BtnMove.UseVisualStyleBackColor = true;
            this.BtnMove.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnMirror
            // 
            this.BtnMirror.Location = new System.Drawing.Point(657, 41);
            this.BtnMirror.Name = "BtnMirror";
            this.BtnMirror.Size = new System.Drawing.Size(107, 23);
            this.BtnMirror.TabIndex = 36;
            this.BtnMirror.Text = "镜像";
            this.BtnMirror.UseVisualStyleBackColor = true;
            this.BtnMirror.Click += new System.EventHandler(this.BtnMirror_Click);
            // 
            // BtnNearestInterpolation
            // 
            this.BtnNearestInterpolation.Location = new System.Drawing.Point(657, 70);
            this.BtnNearestInterpolation.Name = "BtnNearestInterpolation";
            this.BtnNearestInterpolation.Size = new System.Drawing.Size(107, 23);
            this.BtnNearestInterpolation.TabIndex = 37;
            this.BtnNearestInterpolation.Text = "最近邻插值法";
            this.BtnNearestInterpolation.UseVisualStyleBackColor = true;
            this.BtnNearestInterpolation.Click += new System.EventHandler(this.BtnNearestInterpolation_Click);
            // 
            // FrmImageTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 401);
            this.Controls.Add(this.BtnNearestInterpolation);
            this.Controls.Add(this.BtnMirror);
            this.Controls.Add(this.BtnMove);
            this.Controls.Add(this.BtnHistMatch);
            this.Controls.Add(this.BtnInnerGrayscale);
            this.Controls.Add(this.BtnLinearChange);
            this.Controls.Add(this.BtnPersonEye);
            this.Controls.Add(this.BtnInnerBorder);
            this.Controls.Add(this.BtnSobel);
            this.Controls.Add(this.BtnOptimal);
            this.Controls.Add(this.BtnOstu);
            this.Controls.Add(this.BtnLoG);
            this.Controls.Add(this.BtnKirsch);
            this.Controls.Add(this.BtnRobinsion);
            this.Controls.Add(this.BtnPrewitt);
            this.Controls.Add(this.BtnkFill);
            this.Controls.Add(this.BtnRobertsOperator);
            this.Controls.Add(this.BtnInvertColor);
            this.Controls.Add(this.BtnRaplacianSharpen);
            this.Controls.Add(this.BtnRotate);
            this.Controls.Add(this.TxtRotate);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.BtnHistEqualization);
            this.Controls.Add(this.BtnBinarization);
            this.Controls.Add(this.BtnMedianFiltering);
            this.Controls.Add(this.BtnGrayscaleStretch);
            this.Controls.Add(this.BtnHist);
            this.Controls.Add(this.BtnGrayscalAverage);
            this.Controls.Add(this.BtnGrayscalMin);
            this.Controls.Add(this.BtnGrayscalMax);
            this.Controls.Add(this.BtnOriImage);
            this.Controls.Add(this.BtnOpen);
            this.Controls.Add(this.PicImage);
            this.Name = "FrmImageTest";
            this.Text = "图像处理测试";
            this.Load += new System.EventHandler(this.FrmImageTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicImage;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnOriImage;
        private System.Windows.Forms.Button BtnGrayscalMax;
        private System.Windows.Forms.Button BtnGrayscalMin;
        private System.Windows.Forms.Button BtnGrayscalAverage;
        private System.Windows.Forms.Button BtnHist;
        private System.Windows.Forms.Button BtnGrayscaleStretch;
        private System.Windows.Forms.Button BtnMedianFiltering;
        private System.Windows.Forms.Button BtnBinarization;
        private System.Windows.Forms.Button BtnHistEqualization;
        private System.Windows.Forms.Button BtnRotate;
        private System.Windows.Forms.TextBox TxtRotate;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Button BtnRaplacianSharpen;
        private System.Windows.Forms.Button BtnInvertColor;
        private System.Windows.Forms.Button BtnRobertsOperator;
        private System.Windows.Forms.Button BtnkFill;
        private System.Windows.Forms.Button BtnPrewitt;
        private System.Windows.Forms.Button BtnRobinsion;
        private System.Windows.Forms.Button BtnKirsch;
        private System.Windows.Forms.Button BtnLoG;
        private System.Windows.Forms.Button BtnOstu;
        private System.Windows.Forms.Button BtnOptimal;
        private System.Windows.Forms.Button BtnSobel;
        private System.Windows.Forms.Button BtnInnerBorder;
        private System.Windows.Forms.Button BtnPersonEye;
        private System.Windows.Forms.Button BtnLinearChange;
        private System.Windows.Forms.Button BtnInnerGrayscale;
        private System.Windows.Forms.Button BtnHistMatch;
        private System.Windows.Forms.Button BtnMove;
        private System.Windows.Forms.Button BtnMirror;
        private System.Windows.Forms.Button BtnNearestInterpolation;
    }
}


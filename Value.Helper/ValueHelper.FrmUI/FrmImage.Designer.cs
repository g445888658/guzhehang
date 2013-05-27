namespace ValueHelper.FrmUI
{
    partial class FrmHistImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PicImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.BackColor = System.Drawing.Color.White;
            this.PicImage.Location = new System.Drawing.Point(12, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(255, 451);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // FrmHistImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 475);
            this.Controls.Add(this.PicImage);
            this.Name = "FrmHistImage";
            this.Text = "直方图窗口";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PicImage;

    }
}
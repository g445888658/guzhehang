namespace ValueHelper.FrmUI
{
    partial class FrmGrayscaleStretch
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
            this.PicShowLine = new System.Windows.Forms.PictureBox();
            this.TxtX1 = new System.Windows.Forms.TextBox();
            this.TxtX2 = new System.Windows.Forms.TextBox();
            this.TxtY1 = new System.Windows.Forms.TextBox();
            this.TxtY2 = new System.Windows.Forms.TextBox();
            this.LblY1 = new System.Windows.Forms.Label();
            this.LblX2 = new System.Windows.Forms.Label();
            this.LblY2 = new System.Windows.Forms.Label();
            this.LblX1 = new System.Windows.Forms.Label();
            this.BtnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicShowLine)).BeginInit();
            this.SuspendLayout();
            // 
            // PicShowLine
            // 
            this.PicShowLine.BackColor = System.Drawing.Color.White;
            this.PicShowLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicShowLine.Location = new System.Drawing.Point(12, 12);
            this.PicShowLine.Name = "PicShowLine";
            this.PicShowLine.Size = new System.Drawing.Size(255, 255);
            this.PicShowLine.TabIndex = 0;
            this.PicShowLine.TabStop = false;
            // 
            // TxtX1
            // 
            this.TxtX1.Location = new System.Drawing.Point(299, 12);
            this.TxtX1.Name = "TxtX1";
            this.TxtX1.Size = new System.Drawing.Size(114, 21);
            this.TxtX1.TabIndex = 1;
            this.TxtX1.Text = "25";
            // 
            // TxtX2
            // 
            this.TxtX2.Location = new System.Drawing.Point(299, 115);
            this.TxtX2.Name = "TxtX2";
            this.TxtX2.Size = new System.Drawing.Size(114, 21);
            this.TxtX2.TabIndex = 2;
            this.TxtX2.Text = "200";
            // 
            // TxtY1
            // 
            this.TxtY1.Location = new System.Drawing.Point(299, 64);
            this.TxtY1.Name = "TxtY1";
            this.TxtY1.Size = new System.Drawing.Size(114, 21);
            this.TxtY1.TabIndex = 3;
            this.TxtY1.Text = "25";
            // 
            // TxtY2
            // 
            this.TxtY2.Location = new System.Drawing.Point(299, 164);
            this.TxtY2.Name = "TxtY2";
            this.TxtY2.Size = new System.Drawing.Size(114, 21);
            this.TxtY2.TabIndex = 4;
            this.TxtY2.Text = "200";
            // 
            // LblY1
            // 
            this.LblY1.AutoSize = true;
            this.LblY1.Location = new System.Drawing.Point(276, 67);
            this.LblY1.Name = "LblY1";
            this.LblY1.Size = new System.Drawing.Size(23, 12);
            this.LblY1.TabIndex = 5;
            this.LblY1.Text = "Y1:";
            // 
            // LblX2
            // 
            this.LblX2.AutoSize = true;
            this.LblX2.Location = new System.Drawing.Point(276, 118);
            this.LblX2.Name = "LblX2";
            this.LblX2.Size = new System.Drawing.Size(23, 12);
            this.LblX2.TabIndex = 6;
            this.LblX2.Text = "X2:";
            // 
            // LblY2
            // 
            this.LblY2.AutoSize = true;
            this.LblY2.Location = new System.Drawing.Point(276, 167);
            this.LblY2.Name = "LblY2";
            this.LblY2.Size = new System.Drawing.Size(23, 12);
            this.LblY2.TabIndex = 7;
            this.LblY2.Text = "Y2:";
            // 
            // LblX1
            // 
            this.LblX1.AutoSize = true;
            this.LblX1.Location = new System.Drawing.Point(276, 15);
            this.LblX1.Name = "LblX1";
            this.LblX1.Size = new System.Drawing.Size(23, 12);
            this.LblX1.TabIndex = 8;
            this.LblX1.Text = "X1:";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Location = new System.Drawing.Point(315, 219);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtnConfirm.TabIndex = 9;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // FrmGrayscaleStretch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 281);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.LblX1);
            this.Controls.Add(this.LblY2);
            this.Controls.Add(this.LblX2);
            this.Controls.Add(this.LblY1);
            this.Controls.Add(this.TxtY2);
            this.Controls.Add(this.TxtY1);
            this.Controls.Add(this.TxtX2);
            this.Controls.Add(this.TxtX1);
            this.Controls.Add(this.PicShowLine);
            this.Name = "FrmGrayscaleStretch";
            this.Text = "灰度拉伸参数设置";
            ((System.ComponentModel.ISupportInitialize)(this.PicShowLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicShowLine;
        private System.Windows.Forms.TextBox TxtX1;
        private System.Windows.Forms.TextBox TxtX2;
        private System.Windows.Forms.TextBox TxtY1;
        private System.Windows.Forms.TextBox TxtY2;
        private System.Windows.Forms.Label LblY1;
        private System.Windows.Forms.Label LblX2;
        private System.Windows.Forms.Label LblY2;
        private System.Windows.Forms.Label LblX1;
        private System.Windows.Forms.Button BtnConfirm;
    }
}
namespace ValueHelper.FrmUI
{
    partial class FrmlaplacianSharpen
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
            this.CbolaplacianOperator = new System.Windows.Forms.ComboBox();
            this.BtnSharpen = new System.Windows.Forms.Button();
            this.TxtStrength = new System.Windows.Forms.TextBox();
            this.LblStrength = new System.Windows.Forms.Label();
            this.LblOperator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CbolaplacianOperator
            // 
            this.CbolaplacianOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbolaplacianOperator.FormattingEnabled = true;
            this.CbolaplacianOperator.Items.AddRange(new object[] {
            "3x3掩膜算子",
            "4x4掩膜算子",
            "5x5掩膜算子",
            "4-邻接算子",
            "8-邻接算子",
            "强调中心算子1",
            "强调中心算子2"});
            this.CbolaplacianOperator.Location = new System.Drawing.Point(61, 73);
            this.CbolaplacianOperator.Name = "CbolaplacianOperator";
            this.CbolaplacianOperator.Size = new System.Drawing.Size(121, 20);
            this.CbolaplacianOperator.TabIndex = 0;
            // 
            // BtnSharpen
            // 
            this.BtnSharpen.Location = new System.Drawing.Point(89, 111);
            this.BtnSharpen.Name = "BtnSharpen";
            this.BtnSharpen.Size = new System.Drawing.Size(67, 23);
            this.BtnSharpen.TabIndex = 1;
            this.BtnSharpen.Text = "锐化";
            this.BtnSharpen.UseVisualStyleBackColor = true;
            this.BtnSharpen.Click += new System.EventHandler(this.BtnSharpen_Click);
            // 
            // TxtStrength
            // 
            this.TxtStrength.Location = new System.Drawing.Point(61, 27);
            this.TxtStrength.Name = "TxtStrength";
            this.TxtStrength.Size = new System.Drawing.Size(121, 21);
            this.TxtStrength.TabIndex = 2;
            this.TxtStrength.Text = "1";
            // 
            // LblStrength
            // 
            this.LblStrength.AutoSize = true;
            this.LblStrength.Location = new System.Drawing.Point(12, 30);
            this.LblStrength.Name = "LblStrength";
            this.LblStrength.Size = new System.Drawing.Size(29, 12);
            this.LblStrength.TabIndex = 3;
            this.LblStrength.Text = "强度";
            // 
            // LblOperator
            // 
            this.LblOperator.AutoSize = true;
            this.LblOperator.Location = new System.Drawing.Point(12, 76);
            this.LblOperator.Name = "LblOperator";
            this.LblOperator.Size = new System.Drawing.Size(29, 12);
            this.LblOperator.TabIndex = 4;
            this.LblOperator.Text = "算子";
            // 
            // FrmlaplacianSharpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 150);
            this.Controls.Add(this.LblOperator);
            this.Controls.Add(this.LblStrength);
            this.Controls.Add(this.TxtStrength);
            this.Controls.Add(this.BtnSharpen);
            this.Controls.Add(this.CbolaplacianOperator);
            this.Name = "FrmlaplacianSharpen";
            this.Text = "FrmlaplacianSharpen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbolaplacianOperator;
        private System.Windows.Forms.Button BtnSharpen;
        private System.Windows.Forms.TextBox TxtStrength;
        private System.Windows.Forms.Label LblStrength;
        private System.Windows.Forms.Label LblOperator;
    }
}
namespace SHOLEI
{
    partial class studentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkBlouse = new System.Windows.Forms.CheckBox();
            this.cmbSizeBlouse = new System.Windows.Forms.ComboBox();
            this.txtQtyblouse = new System.Windows.Forms.TextBox();
            this.tbPriceBlouse = new System.Windows.Forms.TextBox();
            this.tbPriceSkirt = new System.Windows.Forms.TextBox();
            this.txtQtySkirt = new System.Windows.Forms.TextBox();
            this.cmbSizeSkirt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSkirt = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(27, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(113, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // chkBlouse
            // 
            this.chkBlouse.AutoSize = true;
            this.chkBlouse.Location = new System.Drawing.Point(38, 143);
            this.chkBlouse.Name = "chkBlouse";
            this.chkBlouse.Size = new System.Drawing.Size(84, 24);
            this.chkBlouse.TabIndex = 2;
            this.chkBlouse.Text = "Blouse";
            this.chkBlouse.UseVisualStyleBackColor = true;
            this.chkBlouse.CheckedChanged += new System.EventHandler(this.chkBlouse_CheckedChanged);
            // 
            // cmbSizeBlouse
            // 
            this.cmbSizeBlouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeBlouse.FormattingEnabled = true;
            this.cmbSizeBlouse.Items.AddRange(new object[] {
            "small",
            "medium",
            "large",
            "xl",
            "xxl",
            "xxxl"});
            this.cmbSizeBlouse.Location = new System.Drawing.Point(162, 104);
            this.cmbSizeBlouse.Name = "cmbSizeBlouse";
            this.cmbSizeBlouse.Size = new System.Drawing.Size(131, 28);
            this.cmbSizeBlouse.TabIndex = 4;
            this.cmbSizeBlouse.SelectedIndexChanged += new System.EventHandler(this.cmbSizeBlouse_SelectedIndexChanged);
            // 
            // txtQtyblouse
            // 
            this.txtQtyblouse.Location = new System.Drawing.Point(330, 106);
            this.txtQtyblouse.Name = "txtQtyblouse";
            this.txtQtyblouse.Size = new System.Drawing.Size(100, 26);
            this.txtQtyblouse.TabIndex = 5;
            this.txtQtyblouse.TextChanged += new System.EventHandler(this.txtQtyblouse_TextChanged);
            // 
            // tbPriceBlouse
            // 
            this.tbPriceBlouse.Enabled = false;
            this.tbPriceBlouse.Location = new System.Drawing.Point(467, 106);
            this.tbPriceBlouse.Name = "tbPriceBlouse";
            this.tbPriceBlouse.Size = new System.Drawing.Size(100, 26);
            this.tbPriceBlouse.TabIndex = 6;
            // 
            // tbPriceSkirt
            // 
            this.tbPriceSkirt.Enabled = false;
            this.tbPriceSkirt.Location = new System.Drawing.Point(467, 290);
            this.tbPriceSkirt.Name = "tbPriceSkirt";
            this.tbPriceSkirt.Size = new System.Drawing.Size(100, 26);
            this.tbPriceSkirt.TabIndex = 9;
            this.tbPriceSkirt.TextChanged += new System.EventHandler(this.txtPrice2_TextChanged);
            // 
            // txtQtySkirt
            // 
            this.txtQtySkirt.Location = new System.Drawing.Point(330, 290);
            this.txtQtySkirt.Name = "txtQtySkirt";
            this.txtQtySkirt.Size = new System.Drawing.Size(100, 26);
            this.txtQtySkirt.TabIndex = 8;
            this.txtQtySkirt.TextChanged += new System.EventHandler(this.txtQtySkirt_TextChanged);
            // 
            // cmbSizeSkirt
            // 
            this.cmbSizeSkirt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizeSkirt.FormattingEnabled = true;
            this.cmbSizeSkirt.Items.AddRange(new object[] {
            "small",
            "medium",
            "large",
            "xl",
            "xxl",
            "xxxl"});
            this.cmbSizeSkirt.Location = new System.Drawing.Point(162, 288);
            this.cmbSizeSkirt.Name = "cmbSizeSkirt";
            this.cmbSizeSkirt.Size = new System.Drawing.Size(131, 28);
            this.cmbSizeSkirt.TabIndex = 7;
            this.cmbSizeSkirt.SelectedIndexChanged += new System.EventHandler(this.cmbSizeSkirt_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Price";
            // 
            // chkSkirt
            // 
            this.chkSkirt.AutoSize = true;
            this.chkSkirt.Location = new System.Drawing.Point(44, 329);
            this.chkSkirt.Name = "chkSkirt";
            this.chkSkirt.Size = new System.Drawing.Size(67, 24);
            this.chkSkirt.TabIndex = 52;
            this.chkSkirt.Text = "Skirt";
            this.chkSkirt.UseVisualStyleBackColor = true;
            this.chkSkirt.CheckedChanged += new System.EventHandler(this.chkSkirt_CheckedChanged);
            // 
            // studentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(594, 381);
            this.Controls.Add(this.chkSkirt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPriceSkirt);
            this.Controls.Add(this.txtQtySkirt);
            this.Controls.Add(this.cmbSizeSkirt);
            this.Controls.Add(this.tbPriceBlouse);
            this.Controls.Add(this.txtQtyblouse);
            this.Controls.Add(this.cmbSizeBlouse);
            this.Controls.Add(this.chkBlouse);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "studentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "studentForm";
            this.Load += new System.EventHandler(this.studentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkBlouse;
        private System.Windows.Forms.ComboBox cmbSizeBlouse;
        private System.Windows.Forms.TextBox txtQtyblouse;
        private System.Windows.Forms.TextBox tbPriceBlouse;
        private System.Windows.Forms.TextBox tbPriceSkirt;
        private System.Windows.Forms.TextBox txtQtySkirt;
        private System.Windows.Forms.ComboBox cmbSizeSkirt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkSkirt;
    }
}
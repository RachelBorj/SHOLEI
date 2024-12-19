namespace SHOLEI
{
    partial class BoysForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoysForm));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPricePants = new System.Windows.Forms.TextBox();
            this.txtQtyPants = new System.Windows.Forms.TextBox();
            this.cmbSizePants = new System.Windows.Forms.ComboBox();
            this.txtPricePolo = new System.Windows.Forms.TextBox();
            this.txtQtyPolo = new System.Windows.Forms.TextBox();
            this.cmbSizePolo = new System.Windows.Forms.ComboBox();
            this.chkPants = new System.Windows.Forms.CheckBox();
            this.chkPolo = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Size";
            // 
            // txtPricePants
            // 
            this.txtPricePants.Enabled = false;
            this.txtPricePants.Location = new System.Drawing.Point(451, 290);
            this.txtPricePants.Name = "txtPricePants";
            this.txtPricePants.Size = new System.Drawing.Size(100, 26);
            this.txtPricePants.TabIndex = 30;
            this.txtPricePants.TextChanged += new System.EventHandler(this.txtPricePants_TextChanged);
            // 
            // txtQtyPants
            // 
            this.txtQtyPants.Location = new System.Drawing.Point(324, 290);
            this.txtQtyPants.Name = "txtQtyPants";
            this.txtQtyPants.Size = new System.Drawing.Size(100, 26);
            this.txtQtyPants.TabIndex = 29;
            this.txtQtyPants.TextChanged += new System.EventHandler(this.txtQtyPants_TextChanged);
            // 
            // cmbSizePants
            // 
            this.cmbSizePants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizePants.FormattingEnabled = true;
            this.cmbSizePants.Items.AddRange(new object[] {
            "small",
            "medium",
            "large",
            "xl",
            "xxl",
            "xxxl"});
            this.cmbSizePants.Location = new System.Drawing.Point(166, 288);
            this.cmbSizePants.Name = "cmbSizePants";
            this.cmbSizePants.Size = new System.Drawing.Size(131, 28);
            this.cmbSizePants.TabIndex = 28;
            this.cmbSizePants.SelectedIndexChanged += new System.EventHandler(this.cmbSizePants_SelectedIndexChanged);
            // 
            // txtPricePolo
            // 
            this.txtPricePolo.Enabled = false;
            this.txtPricePolo.Location = new System.Drawing.Point(451, 106);
            this.txtPricePolo.Name = "txtPricePolo";
            this.txtPricePolo.Size = new System.Drawing.Size(100, 26);
            this.txtPricePolo.TabIndex = 27;
            // 
            // txtQtyPolo
            // 
            this.txtQtyPolo.Location = new System.Drawing.Point(324, 106);
            this.txtQtyPolo.Name = "txtQtyPolo";
            this.txtQtyPolo.Size = new System.Drawing.Size(100, 26);
            this.txtQtyPolo.TabIndex = 26;
            this.txtQtyPolo.TextChanged += new System.EventHandler(this.txtQtyPolo_TextChanged);
            // 
            // cmbSizePolo
            // 
            this.cmbSizePolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSizePolo.FormattingEnabled = true;
            this.cmbSizePolo.Items.AddRange(new object[] {
            "small",
            "medium",
            "large",
            "xl",
            "xxl",
            "xxxl"});
            this.cmbSizePolo.Location = new System.Drawing.Point(166, 104);
            this.cmbSizePolo.Name = "cmbSizePolo";
            this.cmbSizePolo.Size = new System.Drawing.Size(131, 28);
            this.cmbSizePolo.TabIndex = 25;
            this.cmbSizePolo.SelectedIndexChanged += new System.EventHandler(this.cmbSizePolo_SelectedIndexChanged);
            // 
            // chkPants
            // 
            this.chkPants.AutoSize = true;
            this.chkPants.Location = new System.Drawing.Point(42, 326);
            this.chkPants.Name = "chkPants";
            this.chkPants.Size = new System.Drawing.Size(76, 24);
            this.chkPants.TabIndex = 24;
            this.chkPants.Text = "Pants";
            this.chkPants.UseVisualStyleBackColor = true;
            this.chkPants.CheckedChanged += new System.EventHandler(this.chkPants_CheckedChanged);
            // 
            // chkPolo
            // 
            this.chkPolo.AutoSize = true;
            this.chkPolo.Location = new System.Drawing.Point(46, 142);
            this.chkPolo.Name = "chkPolo";
            this.chkPolo.Size = new System.Drawing.Size(66, 24);
            this.chkPolo.TabIndex = 23;
            this.chkPolo.Text = "Polo";
            this.chkPolo.UseVisualStyleBackColor = true;
            this.chkPolo.CheckedChanged += new System.EventHandler(this.chkPolo_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(27, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 106);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // BoysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(594, 381);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPricePants);
            this.Controls.Add(this.txtQtyPants);
            this.Controls.Add(this.cmbSizePants);
            this.Controls.Add(this.txtPricePolo);
            this.Controls.Add(this.txtQtyPolo);
            this.Controls.Add(this.cmbSizePolo);
            this.Controls.Add(this.chkPants);
            this.Controls.Add(this.chkPolo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BoysForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoysForm";
            this.Load += new System.EventHandler(this.BoysForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPricePants;
        private System.Windows.Forms.TextBox txtQtyPants;
        private System.Windows.Forms.ComboBox cmbSizePants;
        private System.Windows.Forms.TextBox txtPricePolo;
        private System.Windows.Forms.TextBox txtQtyPolo;
        private System.Windows.Forms.ComboBox cmbSizePolo;
        private System.Windows.Forms.CheckBox chkPants;
        private System.Windows.Forms.CheckBox chkPolo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace SHOLEI
{
    partial class PriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceForm));
            this.btnAddSizePrice = new System.Windows.Forms.Button();
            this.btnSaveProductDetails = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.lstSizePrice = new System.Windows.Forms.ListBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateSizePrice = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddSizePrice
            // 
            this.btnAddSizePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btnAddSizePrice.FlatAppearance.BorderSize = 0;
            this.btnAddSizePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSizePrice.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSizePrice.Location = new System.Drawing.Point(118, 431);
            this.btnAddSizePrice.Name = "btnAddSizePrice";
            this.btnAddSizePrice.Size = new System.Drawing.Size(121, 73);
            this.btnAddSizePrice.TabIndex = 15;
            this.btnAddSizePrice.Text = "Add Price";
            this.btnAddSizePrice.UseVisualStyleBackColor = false;
            this.btnAddSizePrice.Click += new System.EventHandler(this.btnAddSizePrice_Click);
            // 
            // btnSaveProductDetails
            // 
            this.btnSaveProductDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btnSaveProductDetails.Font = new System.Drawing.Font("Calisto MT", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProductDetails.Location = new System.Drawing.Point(195, 555);
            this.btnSaveProductDetails.Name = "btnSaveProductDetails";
            this.btnSaveProductDetails.Size = new System.Drawing.Size(639, 108);
            this.btnSaveProductDetails.TabIndex = 18;
            this.btnSaveProductDetails.Text = "Save Product Details";
            this.btnSaveProductDetails.UseVisualStyleBackColor = false;
            this.btnSaveProductDetails.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(195, 369);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(343, 30);
            this.txtPrice.TabIndex = 20;
            // 
            // txtSize
            // 
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSize.Location = new System.Drawing.Point(195, 300);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(343, 30);
            this.txtSize.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 21;
            this.label1.Text = "Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 28);
            this.label3.TabIndex = 24;
            this.label3.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(195, 230);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(343, 30);
            this.txtDescription.TabIndex = 23;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(407, 431);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(140, 73);
            this.btndelete.TabIndex = 26;
            this.btndelete.Text = "Delete Price ";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lstSizePrice
            // 
            this.lstSizePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSizePrice.FormattingEnabled = true;
            this.lstSizePrice.ItemHeight = 25;
            this.lstSizePrice.Location = new System.Drawing.Point(576, 230);
            this.lstSizePrice.Name = "lstSizePrice";
            this.lstSizePrice.Size = new System.Drawing.Size(417, 304);
            this.lstSizePrice.TabIndex = 27;
            this.lstSizePrice.SelectedIndexChanged += new System.EventHandler(this.lstSizePrice_SelectedIndexChanged);
            // 
            // cboProducts
            // 
            this.cboProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(407, 99);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(279, 34);
            this.cboProducts.TabIndex = 28;
            this.cboProducts.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 44);
            this.label4.TabIndex = 29;
            this.label4.Text = "Products:";
            // 
            // btnUpdateSizePrice
            // 
            this.btnUpdateSizePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btnUpdateSizePrice.FlatAppearance.BorderSize = 0;
            this.btnUpdateSizePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSizePrice.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSizePrice.Location = new System.Drawing.Point(261, 431);
            this.btnUpdateSizePrice.Name = "btnUpdateSizePrice";
            this.btnUpdateSizePrice.Size = new System.Drawing.Size(121, 73);
            this.btnUpdateSizePrice.TabIndex = 30;
            this.btnUpdateSizePrice.Text = "Update Price";
            this.btnUpdateSizePrice.UseVisualStyleBackColor = false;
            this.btnUpdateSizePrice.Click += new System.EventHandler(this.btnUpdateSizePrice_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // PriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(182)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1107, 724);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnUpdateSizePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboProducts);
            this.Controls.Add(this.lstSizePrice);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.btnSaveProductDetails);
            this.Controls.Add(this.btnAddSizePrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceForm";
            this.Load += new System.EventHandler(this.PriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddSizePrice;
        private System.Windows.Forms.Button btnSaveProductDetails;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.ListBox lstSizePrice;
        private System.Windows.Forms.ComboBox cboProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateSizePrice;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
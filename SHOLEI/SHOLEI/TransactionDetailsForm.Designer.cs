namespace SHOLEI
{
    partial class TransactionDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDoneOrdering = new System.Windows.Forms.Button();
            this.dataGridViewTransactionDetails = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transaction Slip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 614);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 140);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDoneOrdering
            // 
            this.btnDoneOrdering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(172)))), ((int)(((byte)(120)))));
            this.btnDoneOrdering.FlatAppearance.BorderSize = 0;
            this.btnDoneOrdering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneOrdering.Location = new System.Drawing.Point(245, 715);
            this.btnDoneOrdering.Name = "btnDoneOrdering";
            this.btnDoneOrdering.Size = new System.Drawing.Size(116, 67);
            this.btnDoneOrdering.TabIndex = 3;
            this.btnDoneOrdering.Text = "Place Order";
            this.btnDoneOrdering.UseVisualStyleBackColor = false;
            this.btnDoneOrdering.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTransactionDetails
            // 
            this.dataGridViewTransactionDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransactionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactionDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Size,
            this.Quantity,
            this.Price});
            this.dataGridViewTransactionDetails.Location = new System.Drawing.Point(81, 184);
            this.dataGridViewTransactionDetails.Name = "dataGridViewTransactionDetails";
            this.dataGridViewTransactionDetails.RowHeadersWidth = 62;
            this.dataGridViewTransactionDetails.RowTemplate.Height = 28;
            this.dataGridViewTransactionDetails.Size = new System.Drawing.Size(442, 353);
            this.dataGridViewTransactionDetails.TabIndex = 4;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 8;
            this.Size.Name = "Size";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(83, 78);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(51, 20);
            this.lblStudentID.TabIndex = 5;
            this.lblStudentID.Text = "label3";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(83, 144);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "label3";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(278, 150);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(51, 20);
            this.lblOrderDate.TabIndex = 10;
            this.lblOrderDate.Text = "label3";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(278, 115);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(51, 20);
            this.lblSection.TabIndex = 9;
            this.lblSection.Text = "label3";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(277, 78);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(51, 20);
            this.lblCourse.TabIndex = 8;
            this.lblCourse.Text = "label3";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(341, 550);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(51, 20);
            this.lblTotalAmount.TabIndex = 11;
            this.lblTotalAmount.Text = "label3";
            // 
            // TransactionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(207)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(615, 813);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.dataGridViewTransactionDetails);
            this.Controls.Add(this.btnDoneOrdering);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransactionDetailsForm";
            this.Load += new System.EventHandler(this.TransactionDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDoneOrdering;
        private System.Windows.Forms.DataGridView dataGridViewTransactionDetails;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}
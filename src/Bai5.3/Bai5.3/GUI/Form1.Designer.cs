
namespace Bai5._3
{
    partial class Form1
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
            this.flpTableLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSelectedTable = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboFood = new System.Windows.Forms.ComboBox();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // flpTableLayout
            // 
            this.flpTableLayout.AutoScroll = true;
            this.flpTableLayout.Location = new System.Drawing.Point(12, 12);
            this.flpTableLayout.Name = "flpTableLayout";
            this.flpTableLayout.Size = new System.Drawing.Size(521, 410);
            this.flpTableLayout.TabIndex = 0;
            this.flpTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTableLayout_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddFood);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nmFoodCount);
            this.groupBox1.Controls.Add(this.cboFood);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.lblSelectedTable);
            this.groupBox1.Location = new System.Drawing.Point(553, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 162);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn món && Thông tin bàn";
            // 
            // lblSelectedTable
            // 
            this.lblSelectedTable.AutoSize = true;
            this.lblSelectedTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTable.Location = new System.Drawing.Point(6, 16);
            this.lblSelectedTable.Name = "lblSelectedTable";
            this.lblSelectedTable.Size = new System.Drawing.Size(93, 13);
            this.lblSelectedTable.TabIndex = 0;
            this.lblSelectedTable.Text = "Chưa chọn bàn";
            this.lblSelectedTable.Click += new System.EventHandler(this.lblSelectedTable_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(69, 32);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(143, 21);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // cboFood
            // 
            this.cboFood.FormattingEnabled = true;
            this.cboFood.Location = new System.Drawing.Point(69, 59);
            this.cboFood.Name = "cboFood";
            this.cboFood.Size = new System.Drawing.Size(143, 21);
            this.cboFood.TabIndex = 2;
            this.cboFood.SelectedIndexChanged += new System.EventHandler(this.cboFood_SelectedIndexChanged);
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(69, 86);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(143, 20);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmFoodCount.ValueChanged += new System.EventHandler(this.nmFoodCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đồ ăn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng";
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(9, 112);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(201, 23);
            this.btnAddFood.TabIndex = 7;
            this.btnAddFood.Text = "Thêm món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPay);
            this.groupBox2.Controls.Add(this.txtTotalPrice);
            this.groupBox2.Controls.Add(this.dgvBill);
            this.groupBox2.Location = new System.Drawing.Point(553, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 242);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng hóa đơn && Thanh toán";
            // 
            // dgvBill
            // 
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Location = new System.Drawing.Point(9, 19);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.Size = new System.Drawing.Size(220, 143);
            this.dgvBill.TabIndex = 0;
            this.dgvBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBill_CellContentClick);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(9, 177);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(220, 20);
            this.txtTotalPrice.TabIndex = 1;
            this.txtTotalPrice.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(9, 203);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(220, 23);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flpTableLayout);
            this.Name = "Form1";
            this.Text = "HỆ THỐNG QUẢN LÝ QUÁN CAFE & BÁN HÀNG";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTableLayout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.ComboBox cboFood;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblSelectedTable;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.TextBox txtTotalPrice;
    }
}


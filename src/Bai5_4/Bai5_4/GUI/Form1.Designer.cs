namespace Bai5_4
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnCleanRoom = new System.Windows.Forms.Button();
            this.lblSelectedRoom = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.btnSearchCCCD = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.nmServiceCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddService = new System.Windows.Forms.Button();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblTitleCheckout = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblCheckoutDetail = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblCheckoutTotal = new System.Windows.Forms.Label();
            this.btnCheckOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmServiceCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.tabControl1);
            this.SplitContainer.Panel2.Controls.Add(this.lblSelectedRoom);
            this.SplitContainer.Size = new System.Drawing.Size(925, 498);
            this.SplitContainer.SplitterDistance = 339;
            this.SplitContainer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCleanRoom);
            this.groupBox1.Controls.Add(this.dgvRooms);
            this.groupBox1.Controls.Add(this.cboFilterStatus);
            this.groupBox1.Controls.Add(this.cboFilterType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 498);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH & LỌC PHÒNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trạng thái";
            // 
            // cboFilterType
            // 
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Location = new System.Drawing.Point(102, 23);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(170, 21);
            this.cboFilterType.TabIndex = 2;
            this.cboFilterType.SelectedIndexChanged += new System.EventHandler(this.cboFilterType_SelectedIndexChanged);
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Location = new System.Drawing.Point(102, 52);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(170, 21);
            this.cboFilterStatus.TabIndex = 3;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged);
            // 
            // dgvRooms
            // 
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(3, 79);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(339, 367);
            this.dgvRooms.TabIndex = 4;
            this.dgvRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellContentClick);
            // 
            // btnCleanRoom
            // 
            this.btnCleanRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanRoom.Location = new System.Drawing.Point(60, 452);
            this.btnCleanRoom.Name = "btnCleanRoom";
            this.btnCleanRoom.Size = new System.Drawing.Size(212, 34);
            this.btnCleanRoom.TabIndex = 5;
            this.btnCleanRoom.Text = "Đã dọn xong phòng";
            this.btnCleanRoom.UseVisualStyleBackColor = true;
            this.btnCleanRoom.Click += new System.EventHandler(this.btnCleanRoom_Click);
            // 
            // lblSelectedRoom
            // 
            this.lblSelectedRoom.AutoSize = true;
            this.lblSelectedRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedRoom.Location = new System.Drawing.Point(12, 9);
            this.lblSelectedRoom.Name = "lblSelectedRoom";
            this.lblSelectedRoom.Size = new System.Drawing.Size(231, 18);
            this.lblSelectedRoom.TabIndex = 0;
            this.lblSelectedRoom.Text = "Đang chọn: Chưa chọn phòng";
            this.lblSelectedRoom.Click += new System.EventHandler(this.lblSelectedRoom_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 468);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCheckIn);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.txtCustomerName);
            this.tabPage1.Controls.Add(this.btnSearchCCCD);
            this.tabPage1.Controls.Add(this.txtCCCD);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1. Nhận phòng (Check-in)";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvServices);
            this.tabPage2.Controls.Add(this.btnAddService);
            this.tabPage2.Controls.Add(this.nmServiceCount);
            this.tabPage2.Controls.Add(this.cboService);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Dịch vụ lưu trú";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCheckOut);
            this.tabPage3.Controls.Add(this.lblCheckoutTotal);
            this.tabPage3.Controls.Add(this.lblTotalTitle);
            this.tabPage3.Controls.Add(this.lblCheckoutDetail);
            this.tabPage3.Controls.Add(this.lblDetailTitle);
            this.tabPage3.Controls.Add(this.lblTitleCheckout);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(574, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3. Trả phòng (Check-out)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Họ và tên khách";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số CCCD / CMND";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(146, 38);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(176, 22);
            this.txtCCCD.TabIndex = 3;
            this.txtCCCD.TextChanged += new System.EventHandler(this.txtCCCD_TextChanged);
            // 
            // btnSearchCCCD
            // 
            this.btnSearchCCCD.Location = new System.Drawing.Point(352, 38);
            this.btnSearchCCCD.Name = "btnSearchCCCD";
            this.btnSearchCCCD.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCCCD.TabIndex = 4;
            this.btnSearchCCCD.Text = "Tra cứu CCCD";
            this.btnSearchCCCD.UseVisualStyleBackColor = true;
            this.btnSearchCCCD.Click += new System.EventHandler(this.btnSearchCCCD_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(146, 75);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(176, 22);
            this.txtCustomerName.TabIndex = 5;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(146, 112);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(176, 22);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(184, 160);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(180, 45);
            this.btnCheckIn.TabIndex = 7;
            this.btnCheckIn.Text = "XÁC NHẬN \r\nNHẬN PHÒNG (CHECK-IN)";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn dịch vụ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Danh sách dịch vụ phòng đã gọi";
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(129, 10);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(154, 24);
            this.cboService.TabIndex = 3;
            this.cboService.SelectedIndexChanged += new System.EventHandler(this.cboService_SelectedIndexChanged);
            // 
            // nmServiceCount
            // 
            this.nmServiceCount.Location = new System.Drawing.Point(130, 46);
            this.nmServiceCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmServiceCount.Name = "nmServiceCount";
            this.nmServiceCount.Size = new System.Drawing.Size(153, 22);
            this.nmServiceCount.TabIndex = 4;
            this.nmServiceCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmServiceCount.ValueChanged += new System.EventHandler(this.nmServiceCount_ValueChanged);
            // 
            // btnAddService
            // 
            this.btnAddService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddService.Location = new System.Drawing.Point(341, 43);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(131, 23);
            this.btnAddService.TabIndex = 5;
            this.btnAddService.Text = "Thêm dịch vụ";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // dgvServices
            // 
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvServices.Location = new System.Drawing.Point(3, 100);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersVisible = false;
            this.dgvServices.Size = new System.Drawing.Size(568, 336);
            this.dgvServices.TabIndex = 6;
            this.dgvServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellContentClick);
            // 
            // lblTitleCheckout
            // 
            this.lblTitleCheckout.AutoSize = true;
            this.lblTitleCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCheckout.Location = new System.Drawing.Point(138, 15);
            this.lblTitleCheckout.Name = "lblTitleCheckout";
            this.lblTitleCheckout.Size = new System.Drawing.Size(308, 20);
            this.lblTitleCheckout.TabIndex = 0;
            this.lblTitleCheckout.Text = "BẢNG KÊ TIỀN PHÒNG VÀ DỊCH VỤ";
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Location = new System.Drawing.Point(34, 59);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(165, 16);
            this.lblDetailTitle.TabIndex = 1;
            this.lblDetailTitle.Text = "Chi tiết thời gian và dịch vụ:";
            // 
            // lblCheckoutDetail
            // 
            this.lblCheckoutDetail.AutoSize = true;
            this.lblCheckoutDetail.Location = new System.Drawing.Point(215, 59);
            this.lblCheckoutDetail.Name = "lblCheckoutDetail";
            this.lblCheckoutDetail.Size = new System.Drawing.Size(204, 16);
            this.lblCheckoutDetail.TabIndex = 2;
            this.lblCheckoutDetail.Text = "Thời gian: 0 giờ (0 đ) | Dịch vụ: 0 đ";
            this.lblCheckoutDetail.Click += new System.EventHandler(this.lblCheckoutDetail_Click);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Location = new System.Drawing.Point(34, 105);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(175, 16);
            this.lblTotalTitle.TabIndex = 3;
            this.lblTotalTitle.Text = "TỔNG TIỀN THANH TOÁN:";
            // 
            // lblCheckoutTotal
            // 
            this.lblCheckoutTotal.AutoSize = true;
            this.lblCheckoutTotal.Location = new System.Drawing.Point(215, 105);
            this.lblCheckoutTotal.Name = "lblCheckoutTotal";
            this.lblCheckoutTotal.Size = new System.Drawing.Size(45, 16);
            this.lblCheckoutTotal.TabIndex = 4;
            this.lblCheckoutTotal.Text = "0 VNĐ";
            this.lblCheckoutTotal.Click += new System.EventHandler(this.lblCheckoutTotal_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Location = new System.Drawing.Point(187, 149);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(202, 40);
            this.btnCheckOut.TabIndex = 5;
            this.btnCheckOut.Text = "THANH TOÁN VÀ TRẢ PHÒNG";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 498);
            this.Controls.Add(this.SplitContainer);
            this.Name = "Form1";
            this.Text = "HỆ THỐNG QUẢN LÝ TIỆN ÍCH DỊCH VỤ & KHÁCH SẠN";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            this.SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmServiceCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCleanRoom;
        private System.Windows.Forms.DataGridView dgvRooms;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnSearchCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblSelectedRoom;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.NumericUpDown nmServiceCount;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblCheckoutTotal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblCheckoutDetail;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblTitleCheckout;
    }
}


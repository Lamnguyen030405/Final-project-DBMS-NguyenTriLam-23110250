namespace PhoneStore.Forms
{
    partial class frmPromotionAdd
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbPromotionInfo;
        private System.Windows.Forms.Label lblPromotionCode;
        private System.Windows.Forms.TextBox txtPromotionCode;
        private System.Windows.Forms.Label lblPromotionName;
        private System.Windows.Forms.TextBox txtPromotionName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDiscountType;
        private System.Windows.Forms.ComboBox cboDiscountType;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.NumericUpDown nudDiscountValue;
        private System.Windows.Forms.Label lblPercentageSign;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblMinOrderAmount;
        private System.Windows.Forms.NumericUpDown nudMinOrderAmount;
        private System.Windows.Forms.Label lblMaxDiscountAmount;
        private System.Windows.Forms.NumericUpDown nudMaxDiscountAmount;
        private System.Windows.Forms.Label lblUsageLimit;
        private System.Windows.Forms.NumericUpDown nudUsageLimit;
        private System.Windows.Forms.CheckBox chkUnlimitedUsage;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbPromotionInfo = new System.Windows.Forms.GroupBox();
            this.chkUnlimitedUsage = new System.Windows.Forms.CheckBox();
            this.nudUsageLimit = new System.Windows.Forms.NumericUpDown();
            this.lblUsageLimit = new System.Windows.Forms.Label();
            this.nudMaxDiscountAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDiscountAmount = new System.Windows.Forms.Label();
            this.nudMinOrderAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMinOrderAmount = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblPercentageSign = new System.Windows.Forms.Label();
            this.nudDiscountValue = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountValue = new System.Windows.Forms.Label();
            this.cboDiscountType = new System.Windows.Forms.ComboBox();
            this.lblDiscountType = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPromotionName = new System.Windows.Forms.TextBox();
            this.lblPromotionName = new System.Windows.Forms.Label();
            this.txtPromotionCode = new System.Windows.Forms.TextBox();
            this.lblPromotionCode = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.gbPromotionInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsageLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDiscountAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinOrderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountValue)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.gbPromotionInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(600, 650);
            this.pnlMain.TabIndex = 0;
            // 
            // gbPromotionInfo
            // 
            this.gbPromotionInfo.Controls.Add(this.chkUnlimitedUsage);
            this.gbPromotionInfo.Controls.Add(this.nudUsageLimit);
            this.gbPromotionInfo.Controls.Add(this.lblUsageLimit);
            this.gbPromotionInfo.Controls.Add(this.nudMaxDiscountAmount);
            this.gbPromotionInfo.Controls.Add(this.lblMaxDiscountAmount);
            this.gbPromotionInfo.Controls.Add(this.nudMinOrderAmount);
            this.gbPromotionInfo.Controls.Add(this.lblMinOrderAmount);
            this.gbPromotionInfo.Controls.Add(this.dtpEndDate);
            this.gbPromotionInfo.Controls.Add(this.lblEndDate);
            this.gbPromotionInfo.Controls.Add(this.dtpStartDate);
            this.gbPromotionInfo.Controls.Add(this.lblStartDate);
            this.gbPromotionInfo.Controls.Add(this.lblPercentageSign);
            this.gbPromotionInfo.Controls.Add(this.nudDiscountValue);
            this.gbPromotionInfo.Controls.Add(this.lblDiscountValue);
            this.gbPromotionInfo.Controls.Add(this.cboDiscountType);
            this.gbPromotionInfo.Controls.Add(this.lblDiscountType);
            this.gbPromotionInfo.Controls.Add(this.txtDescription);
            this.gbPromotionInfo.Controls.Add(this.lblDescription);
            this.gbPromotionInfo.Controls.Add(this.txtPromotionName);
            this.gbPromotionInfo.Controls.Add(this.lblPromotionName);
            this.gbPromotionInfo.Controls.Add(this.txtPromotionCode);
            this.gbPromotionInfo.Controls.Add(this.lblPromotionCode);
            this.gbPromotionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPromotionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPromotionInfo.Location = new System.Drawing.Point(15, 15);
            this.gbPromotionInfo.Name = "gbPromotionInfo";
            this.gbPromotionInfo.Size = new System.Drawing.Size(570, 560);
            this.gbPromotionInfo.TabIndex = 0;
            this.gbPromotionInfo.TabStop = false;
            this.gbPromotionInfo.Text = "Thông tin khuyến mãi";
            // 
            // lblPromotionCode
            // 
            this.lblPromotionCode.AutoSize = true;
            this.lblPromotionCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPromotionCode.Location = new System.Drawing.Point(20, 35);
            this.lblPromotionCode.Name = "lblPromotionCode";
            this.lblPromotionCode.Size = new System.Drawing.Size(112, 20);
            this.lblPromotionCode.TabIndex = 0;
            this.lblPromotionCode.Text = "Mã khuyến mãi:";
            // 
            // txtPromotionCode
            // 
            this.txtPromotionCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPromotionCode.Location = new System.Drawing.Point(20, 58);
            this.txtPromotionCode.MaxLength = 50;
            this.txtPromotionCode.Name = "txtPromotionCode";
            this.txtPromotionCode.Size = new System.Drawing.Size(200, 27);
            this.txtPromotionCode.TabIndex = 1;
            // 
            // lblPromotionName
            // 
            this.lblPromotionName.AutoSize = true;
            this.lblPromotionName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPromotionName.Location = new System.Drawing.Point(250, 35);
            this.lblPromotionName.Name = "lblPromotionName";
            this.lblPromotionName.Size = new System.Drawing.Size(114, 20);
            this.lblPromotionName.TabIndex = 2;
            this.lblPromotionName.Text = "Tên khuyến mãi:";
            // 
            // txtPromotionName
            // 
            this.txtPromotionName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPromotionName.Location = new System.Drawing.Point(250, 58);
            this.txtPromotionName.MaxLength = 200;
            this.txtPromotionName.Name = "txtPromotionName";
            this.txtPromotionName.Size = new System.Drawing.Size(300, 27);
            this.txtPromotionName.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(20, 100);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(51, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(20, 123);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(530, 60);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDiscountType
            // 
            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountType.Location = new System.Drawing.Point(20, 200);
            this.lblDiscountType.Name = "lblDiscountType";
            this.lblDiscountType.Size = new System.Drawing.Size(97, 20);
            this.lblDiscountType.TabIndex = 6;
            this.lblDiscountType.Text = "Loại giảm giá:";
            // 
            // cboDiscountType
            // 
            this.cboDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiscountType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDiscountType.FormattingEnabled = true;
            this.cboDiscountType.Items.AddRange(new object[] {
            "Phần trăm (%)",
            "Số tiền cố định (đ)"});
            this.cboDiscountType.Location = new System.Drawing.Point(20, 223);
            this.cboDiscountType.Name = "cboDiscountType";
            this.cboDiscountType.Size = new System.Drawing.Size(200, 28);
            this.cboDiscountType.TabIndex = 7;
            this.cboDiscountType.SelectedIndexChanged += new System.EventHandler(this.cboDiscountType_SelectedIndexChanged);
            // 
            // lblDiscountValue
            // 
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountValue.Location = new System.Drawing.Point(250, 200);
            this.lblDiscountValue.Name = "lblDiscountValue";
            this.lblDiscountValue.Size = new System.Drawing.Size(95, 20);
            this.lblDiscountValue.TabIndex = 8;
            this.lblDiscountValue.Text = "Giá trị giảm giá:";
            // 
            // nudDiscountValue
            // 
            this.nudDiscountValue.DecimalPlaces = 2;
            this.nudDiscountValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudDiscountValue.Location = new System.Drawing.Point(250, 223);
            this.nudDiscountValue.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudDiscountValue.Name = "nudDiscountValue";
            this.nudDiscountValue.Size = new System.Drawing.Size(150, 27);
            this.nudDiscountValue.TabIndex = 9;
            // 
            // lblPercentageSign
            // 
            this.lblPercentageSign.AutoSize = true;
            this.lblPercentageSign.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPercentageSign.Location = new System.Drawing.Point(410, 227);
            this.lblPercentageSign.Name = "lblPercentageSign";
            this.lblPercentageSign.Size = new System.Drawing.Size(21, 20);
            this.lblPercentageSign.TabIndex = 10;
            this.lblPercentageSign.Text = "%";
            this.lblPercentageSign.Visible = false;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(20, 270);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(95, 20);
            this.lblStartDate.TabIndex = 11;
            this.lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(20, 293);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 27);
            this.dtpStartDate.TabIndex = 12;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(250, 270);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(92, 20);
            this.lblEndDate.TabIndex = 13;
            this.lblEndDate.Text = "Ngày kết thúc:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(250, 293);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 27);
            this.dtpEndDate.TabIndex = 14;
            // 
            // lblMinOrderAmount
            // 
            this.lblMinOrderAmount.AutoSize = true;
            this.lblMinOrderAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMinOrderAmount.Location = new System.Drawing.Point(20, 340);
            this.lblMinOrderAmount.Name = "lblMinOrderAmount";
            this.lblMinOrderAmount.Size = new System.Drawing.Size(147, 20);
            this.lblMinOrderAmount.TabIndex = 15;
            this.lblMinOrderAmount.Text = "Giá trị đơn hàng tối thiểu:";
            // 
            // nudMinOrderAmount
            // 
            this.nudMinOrderAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudMinOrderAmount.Location = new System.Drawing.Point(20, 363);
            this.nudMinOrderAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMinOrderAmount.Name = "nudMinOrderAmount";
            this.nudMinOrderAmount.Size = new System.Drawing.Size(200, 27);
            this.nudMinOrderAmount.TabIndex = 16;
            this.nudMinOrderAmount.ThousandsSeparator = true;
            // 
            // lblMaxDiscountAmount
            // 
            this.lblMaxDiscountAmount.AutoSize = true;
            this.lblMaxDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaxDiscountAmount.Location = new System.Drawing.Point(250, 340);
            this.lblMaxDiscountAmount.Name = "lblMaxDiscountAmount";
            this.lblMaxDiscountAmount.Size = new System.Drawing.Size(131, 20);
            this.lblMaxDiscountAmount.TabIndex = 17;
            this.lblMaxDiscountAmount.Text = "Giảm giá tối đa (0 = không giới hạn):";
            // 
            // nudMaxDiscountAmount
            // 
            this.nudMaxDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudMaxDiscountAmount.Location = new System.Drawing.Point(250, 363);
            this.nudMaxDiscountAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudMaxDiscountAmount.Name = "nudMaxDiscountAmount";
            this.nudMaxDiscountAmount.Size = new System.Drawing.Size(200, 27);
            this.nudMaxDiscountAmount.TabIndex = 18;
            this.nudMaxDiscountAmount.ThousandsSeparator = true;
            // 
            // lblUsageLimit
            // 
            this.lblUsageLimit.AutoSize = true;
            this.lblUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsageLimit.Location = new System.Drawing.Point(20, 410);
            this.lblUsageLimit.Name = "lblUsageLimit";
            this.lblUsageLimit.Size = new System.Drawing.Size(125, 20);
            this.lblUsageLimit.TabIndex = 19;
            this.lblUsageLimit.Text = "Giới hạn sử dụng:";
            // 
            // nudUsageLimit
            // 
            this.nudUsageLimit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudUsageLimit.Location = new System.Drawing.Point(20, 433);
            this.nudUsageLimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudUsageLimit.Name = "nudUsageLimit";
            this.nudUsageLimit.Size = new System.Drawing.Size(150, 27);
            this.nudUsageLimit.TabIndex = 20;
            this.nudUsageLimit.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // chkUnlimitedUsage
            // 
            this.chkUnlimitedUsage.AutoSize = true;
            this.chkUnlimitedUsage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUnlimitedUsage.Location = new System.Drawing.Point(190, 435);
            this.chkUnlimitedUsage.Name = "chkUnlimitedUsage";
            this.chkUnlimitedUsage.Size = new System.Drawing.Size(125, 24);
            this.chkUnlimitedUsage.TabIndex = 21;
            this.chkUnlimitedUsage.Text = "Không giới hạn";
            this.chkUnlimitedUsage.UseVisualStyleBackColor = true;
            this.chkUnlimitedUsage.CheckedChanged += new System.EventHandler(this.chkUnlimitedUsage_CheckedChanged);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(15, 575);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(570, 60);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(340, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(450, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPromotionAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPromotionAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khuyến mãi mới";
            this.Load += new System.EventHandler(this.frmPromotionAdd_Load);
            this.pnlMain.ResumeLayout(false);
            this.gbPromotionInfo.ResumeLayout(false);
            this.gbPromotionInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUsageLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDiscountAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinOrderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountValue)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
namespace PhoneStore.Forms
{
    partial class frmCustomerAdd
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlButtons;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.GroupBox gbBasicInfo;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.GroupBox gbPersonalInfo;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;

        private System.Windows.Forms.GroupBox gbCustomerType;
        private System.Windows.Forms.RadioButton rbRegular;
        private System.Windows.Forms.RadioButton rbVIP;
        private System.Windows.Forms.Label lblCustomerTypeNote;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();

            this.gbBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.gbPersonalInfo = new System.Windows.Forms.GroupBox();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.gbCustomerType = new System.Windows.Forms.GroupBox();
            this.rbRegular = new System.Windows.Forms.RadioButton();
            this.rbVIP = new System.Windows.Forms.RadioButton();
            this.lblCustomerTypeNote = new System.Windows.Forms.Label();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.pnlMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gbBasicInfo.SuspendLayout();
            this.gbPersonalInfo.SuspendLayout();
            this.gbCustomerType.SuspendLayout();
            this.SuspendLayout();

            // pnlMain
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(500, 650);
            this.pnlMain.TabIndex = 0;

            // pnlHeader
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(470, 50);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm khách hàng mới";

            // pnlContent
            this.pnlContent.Controls.Add(this.gbCustomerType);
            this.pnlContent.Controls.Add(this.gbPersonalInfo);
            this.pnlContent.Controls.Add(this.gbBasicInfo);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 65);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(470, 520);
            this.pnlContent.TabIndex = 1;

            // gbBasicInfo
            this.gbBasicInfo.Controls.Add(this.txtEmail);
            this.gbBasicInfo.Controls.Add(this.lblEmail);
            this.gbBasicInfo.Controls.Add(this.txtPhone);
            this.gbBasicInfo.Controls.Add(this.lblPhone);
            this.gbBasicInfo.Controls.Add(this.txtFullName);
            this.gbBasicInfo.Controls.Add(this.lblFullName);
            this.gbBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasicInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.gbBasicInfo.Name = "gbBasicInfo";
            this.gbBasicInfo.Padding = new System.Windows.Forms.Padding(10);
            this.gbBasicInfo.Size = new System.Drawing.Size(470, 180);
            this.gbBasicInfo.TabIndex = 0;
            this.gbBasicInfo.TabStop = false;
            this.gbBasicInfo.Text = "Thông tin cơ bản (*)";

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.Location = new System.Drawing.Point(20, 35);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(77, 15);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Họ và tên (*):";

            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.Location = new System.Drawing.Point(20, 55);
            this.txtFullName.MaxLength = 100;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(430, 23);
            this.txtFullName.TabIndex = 1;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.Location = new System.Drawing.Point(20, 90);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(107, 15);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Số điện thoại (*):";

            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.Location = new System.Drawing.Point(20, 110);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            this.txtPhone.TabIndex = 3;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.Location = new System.Drawing.Point(250, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(250, 110);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 5;

            // gbPersonalInfo
            this.gbPersonalInfo.Controls.Add(this.txtAddress);
            this.gbPersonalInfo.Controls.Add(this.lblAddress);
            this.gbPersonalInfo.Controls.Add(this.cboGender);
            this.gbPersonalInfo.Controls.Add(this.lblGender);
            this.gbPersonalInfo.Controls.Add(this.dtpDateOfBirth);
            this.gbPersonalInfo.Controls.Add(this.lblDateOfBirth);
            this.gbPersonalInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPersonalInfo.Location = new System.Drawing.Point(0, 180);
            this.gbPersonalInfo.Name = "gbPersonalInfo";
            this.gbPersonalInfo.Padding = new System.Windows.Forms.Padding(10);
            this.gbPersonalInfo.Size = new System.Drawing.Size(470, 220);
            this.gbPersonalInfo.TabIndex = 1;
            this.gbPersonalInfo.TabStop = false;
            this.gbPersonalInfo.Text = "Thông tin cá nhân";

            // lblDateOfBirth
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateOfBirth.Location = new System.Drawing.Point(20, 35);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(67, 15);
            this.lblDateOfBirth.TabIndex = 0;
            this.lblDateOfBirth.Text = "Ngày sinh:";

            this.dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(20, 55);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(150, 23);
            this.dtpDateOfBirth.TabIndex = 1;
            this.dtpDateOfBirth.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);

            // lblGender
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGender.Location = new System.Drawing.Point(200, 35);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(58, 15);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Giới tính:";

            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
                "Nam",
                "Nữ",
                "Khác"});
            this.cboGender.Location = new System.Drawing.Point(200, 55);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(120, 23);
            this.cboGender.TabIndex = 3;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.Location = new System.Drawing.Point(20, 95);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 15);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "Địa chỉ:";

            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.Location = new System.Drawing.Point(20, 115);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(430, 80);
            this.txtAddress.TabIndex = 5;

            // gbCustomerType
            this.gbCustomerType.Controls.Add(this.lblCustomerTypeNote);
            this.gbCustomerType.Controls.Add(this.rbVIP);
            this.gbCustomerType.Controls.Add(this.rbRegular);
            this.gbCustomerType.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCustomerType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbCustomerType.Location = new System.Drawing.Point(0, 400);
            this.gbCustomerType.Name = "gbCustomerType";
            this.gbCustomerType.Padding = new System.Windows.Forms.Padding(10);
            this.gbCustomerType.Size = new System.Drawing.Size(470, 120);
            this.gbCustomerType.TabIndex = 2;
            this.gbCustomerType.TabStop = false;
            this.gbCustomerType.Text = "Loại khách hàng";

            // rbRegular
            this.rbRegular.AutoSize = true;
            this.rbRegular.Checked = true;
            this.rbRegular.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbRegular.Location = new System.Drawing.Point(20, 35);
            this.rbRegular.Name = "rbRegular";
            this.rbRegular.Size = new System.Drawing.Size(125, 19);
            this.rbRegular.TabIndex = 0;
            this.rbRegular.TabStop = true;
            this.rbRegular.Text = "Khách hàng thường";
            this.rbRegular.UseVisualStyleBackColor = true;

            // rbVIP
            this.rbVIP.AutoSize = true;
            this.rbVIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbVIP.Location = new System.Drawing.Point(200, 35);
            this.rbVIP.Name = "rbVIP";
            this.rbVIP.Size = new System.Drawing.Size(106, 19);
            this.rbVIP.TabIndex = 1;
            this.rbVIP.Text = "Khách hàng VIP";
            this.rbVIP.UseVisualStyleBackColor = true;

            // lblCustomerTypeNote
            this.lblCustomerTypeNote.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblCustomerTypeNote.ForeColor = System.Drawing.Color.Gray;
            this.lblCustomerTypeNote.Location = new System.Drawing.Point(20, 65);
            this.lblCustomerTypeNote.Name = "lblCustomerTypeNote";
            this.lblCustomerTypeNote.Size = new System.Drawing.Size(430, 40);
            this.lblCustomerTypeNote.TabIndex = 2;
            this.lblCustomerTypeNote.Text = "Lưu ý: Khách hàng VIP sẽ được hưởng các ưu đãi đặc biệt và tích điểm thưởng. Khách hàng thường có thể nâng cấp thành VIP khi đạt tổng chi tiêu 50.000.000đ.";

            // pnlButtons
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(15, 585);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(470, 50);
            this.pnlButtons.TabIndex = 2;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(280, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(390, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmCustomerAdd
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khách hàng mới";
            this.Load += new System.EventHandler(this.frmCustomerAdd_Load);

            this.pnlMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.gbBasicInfo.ResumeLayout(false);
            this.gbBasicInfo.PerformLayout();
            this.gbPersonalInfo.ResumeLayout(false);
            this.gbPersonalInfo.PerformLayout();
            this.gbCustomerType.ResumeLayout(false);
            this.gbCustomerType.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
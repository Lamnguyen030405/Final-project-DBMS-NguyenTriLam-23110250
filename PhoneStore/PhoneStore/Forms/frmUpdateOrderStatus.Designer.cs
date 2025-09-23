namespace PhoneStore.Forms
{
    partial class frmUpdateOrder
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbOrderInfo;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;

        private System.Windows.Forms.GroupBox gbStatusUpdate;
        private System.Windows.Forms.Label lblCurrentOrderStatus;
        private System.Windows.Forms.TextBox txtCurrentOrderStatus;
        private System.Windows.Forms.Label lblNewOrderStatus;
        private System.Windows.Forms.ComboBox cboNewOrderStatus;
        private System.Windows.Forms.Label lblCurrentPaymentStatus;
        private System.Windows.Forms.TextBox txtCurrentPaymentStatus;
        private System.Windows.Forms.Label lblNewPaymentStatus;
        private System.Windows.Forms.ComboBox cboNewPaymentStatus;

        private System.Windows.Forms.GroupBox gbPaymentInfo;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.NumericUpDown numPaidAmount;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.TextBox txtRemainingAmount;

        private System.Windows.Forms.GroupBox gbNotes;
        private System.Windows.Forms.Label lblUpdateReason;
        private System.Windows.Forms.ComboBox cboUpdateReason;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintReceipt;

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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboUpdateReason = new System.Windows.Forms.ComboBox();
            this.lblUpdateReason = new System.Windows.Forms.Label();
            this.gbPaymentInfo = new System.Windows.Forms.GroupBox();
            this.txtRemainingAmount = new System.Windows.Forms.TextBox();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.numPaidAmount = new System.Windows.Forms.NumericUpDown();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.gbStatusUpdate = new System.Windows.Forms.GroupBox();
            this.cboNewPaymentStatus = new System.Windows.Forms.ComboBox();
            this.lblNewPaymentStatus = new System.Windows.Forms.Label();
            this.txtCurrentPaymentStatus = new System.Windows.Forms.TextBox();
            this.lblCurrentPaymentStatus = new System.Windows.Forms.Label();
            this.cboNewOrderStatus = new System.Windows.Forms.ComboBox();
            this.lblNewOrderStatus = new System.Windows.Forms.Label();
            this.txtCurrentOrderStatus = new System.Windows.Forms.TextBox();
            this.lblCurrentOrderStatus = new System.Windows.Forms.Label();
            this.gbOrderInfo = new System.Windows.Forms.GroupBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.gbNotes.SuspendLayout();
            this.gbPaymentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).BeginInit();
            this.gbStatusUpdate.SuspendLayout();
            this.gbOrderInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Controls.Add(this.gbNotes);
            this.pnlMain.Controls.Add(this.gbPaymentInfo);
            this.pnlMain.Controls.Add(this.gbStatusUpdate);
            this.pnlMain.Controls.Add(this.gbOrderInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.pnlMain.Size = new System.Drawing.Size(743, 747);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnPrintReceipt);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(17, 678);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(709, 53);
            this.pnlButtons.TabIndex = 4;
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReceipt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPrintReceipt.ForeColor = System.Drawing.Color.White;
            this.btnPrintReceipt.Location = new System.Drawing.Point(171, 11);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(114, 37);
            this.btnPrintReceipt.TabIndex = 1;
            this.btnPrintReceipt.Text = "In hóa đơn";
            this.btnPrintReceipt.UseVisualStyleBackColor = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(594, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 37);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(23, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 37);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbNotes
            // 
            this.gbNotes.Controls.Add(this.txtNotes);
            this.gbNotes.Controls.Add(this.lblNotes);
            this.gbNotes.Controls.Add(this.cboUpdateReason);
            this.gbNotes.Controls.Add(this.lblUpdateReason);
            this.gbNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbNotes.Location = new System.Drawing.Point(17, 412);
            this.gbNotes.Name = "gbNotes";
            this.gbNotes.Size = new System.Drawing.Size(709, 160);
            this.gbNotes.TabIndex = 3;
            this.gbNotes.TabStop = false;
            this.gbNotes.Text = "Ghi chú và lý do cập nhật";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(23, 112);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(651, 37);
            this.txtNotes.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(23, 91);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(110, 20);
            this.lblNotes.TabIndex = 2;
            this.lblNotes.Text = "Ghi chú chi tiết:";
            // 
            // cboUpdateReason
            // 
            this.cboUpdateReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUpdateReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboUpdateReason.FormattingEnabled = true;
            this.cboUpdateReason.Items.AddRange(new object[] {
            "Khách hàng thanh toán",
            "Hoàn thành giao hàng",
            "Khách hàng yêu cầu hủy",
            "Hết hàng - không thể giao",
            "Thanh toán một phần",
            "Hoàn tiền cho khách",
            "Sửa lỗi thông tin",
            "Khác"});
            this.cboUpdateReason.Location = new System.Drawing.Point(23, 53);
            this.cboUpdateReason.Name = "cboUpdateReason";
            this.cboUpdateReason.Size = new System.Drawing.Size(342, 28);
            this.cboUpdateReason.TabIndex = 1;
            // 
            // lblUpdateReason
            // 
            this.lblUpdateReason.AutoSize = true;
            this.lblUpdateReason.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUpdateReason.Location = new System.Drawing.Point(23, 32);
            this.lblUpdateReason.Name = "lblUpdateReason";
            this.lblUpdateReason.Size = new System.Drawing.Size(108, 20);
            this.lblUpdateReason.TabIndex = 0;
            this.lblUpdateReason.Text = "Lý do cập nhật:";
            // 
            // gbPaymentInfo
            // 
            this.gbPaymentInfo.Controls.Add(this.txtRemainingAmount);
            this.gbPaymentInfo.Controls.Add(this.lblRemainingAmount);
            this.gbPaymentInfo.Controls.Add(this.numPaidAmount);
            this.gbPaymentInfo.Controls.Add(this.lblPaidAmount);
            this.gbPaymentInfo.Controls.Add(this.txtPaymentMethod);
            this.gbPaymentInfo.Controls.Add(this.lblPaymentMethod);
            this.gbPaymentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPaymentInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaymentInfo.Location = new System.Drawing.Point(17, 305);
            this.gbPaymentInfo.Name = "gbPaymentInfo";
            this.gbPaymentInfo.Size = new System.Drawing.Size(709, 107);
            this.gbPaymentInfo.TabIndex = 2;
            this.gbPaymentInfo.TabStop = false;
            this.gbPaymentInfo.Text = "Thông tin thanh toán";
            // 
            // txtRemainingAmount
            // 
            this.txtRemainingAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtRemainingAmount.ForeColor = System.Drawing.Color.Red;
            this.txtRemainingAmount.Location = new System.Drawing.Point(434, 53);
            this.txtRemainingAmount.Name = "txtRemainingAmount";
            this.txtRemainingAmount.ReadOnly = true;
            this.txtRemainingAmount.Size = new System.Drawing.Size(171, 27);
            this.txtRemainingAmount.TabIndex = 5;
            this.txtRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRemainingAmount.Location = new System.Drawing.Point(434, 32);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.Size = new System.Drawing.Size(93, 20);
            this.lblRemainingAmount.TabIndex = 4;
            this.lblRemainingAmount.Text = "Còn phải trả:";
            // 
            // numPaidAmount
            // 
            this.numPaidAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPaidAmount.Location = new System.Drawing.Point(229, 53);
            this.numPaidAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numPaidAmount.Name = "numPaidAmount";
            this.numPaidAmount.Size = new System.Drawing.Size(171, 27);
            this.numPaidAmount.TabIndex = 3;
            this.numPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPaidAmount.ThousandsSeparator = true;
            this.numPaidAmount.ValueChanged += new System.EventHandler(this.numPaidAmount_ValueChanged);
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaidAmount.Location = new System.Drawing.Point(229, 32);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(80, 20);
            this.lblPaidAmount.TabIndex = 2;
            this.lblPaidAmount.Text = "Số tiền trả:";
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPaymentMethod.Location = new System.Drawing.Point(23, 53);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.ReadOnly = true;
            this.txtPaymentMethod.Size = new System.Drawing.Size(171, 27);
            this.txtPaymentMethod.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(23, 32);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(116, 20);
            this.lblPaymentMethod.TabIndex = 0;
            this.lblPaymentMethod.Text = "Phương thức TT:";
            // 
            // gbStatusUpdate
            // 
            this.gbStatusUpdate.Controls.Add(this.cboNewPaymentStatus);
            this.gbStatusUpdate.Controls.Add(this.lblNewPaymentStatus);
            this.gbStatusUpdate.Controls.Add(this.txtCurrentPaymentStatus);
            this.gbStatusUpdate.Controls.Add(this.lblCurrentPaymentStatus);
            this.gbStatusUpdate.Controls.Add(this.cboNewOrderStatus);
            this.gbStatusUpdate.Controls.Add(this.lblNewOrderStatus);
            this.gbStatusUpdate.Controls.Add(this.txtCurrentOrderStatus);
            this.gbStatusUpdate.Controls.Add(this.lblCurrentOrderStatus);
            this.gbStatusUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStatusUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbStatusUpdate.Location = new System.Drawing.Point(17, 155);
            this.gbStatusUpdate.Name = "gbStatusUpdate";
            this.gbStatusUpdate.Size = new System.Drawing.Size(709, 150);
            this.gbStatusUpdate.TabIndex = 1;
            this.gbStatusUpdate.TabStop = false;
            this.gbStatusUpdate.Text = "Cập nhật trạng thái";
            // 
            // cboNewPaymentStatus
            // 
            this.cboNewPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNewPaymentStatus.FormattingEnabled = true;
            this.cboNewPaymentStatus.Items.AddRange(new object[] {
            "pending|Chưa thanh toán",
            "paid|Đã thanh toán",
            "partial|Thanh toán một phần",
            "refunded|Đã hoàn tiền"});
            this.cboNewPaymentStatus.Location = new System.Drawing.Point(217, 112);
            this.cboNewPaymentStatus.Name = "cboNewPaymentStatus";
            this.cboNewPaymentStatus.Size = new System.Drawing.Size(171, 28);
            this.cboNewPaymentStatus.TabIndex = 7;
            this.cboNewPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cboNewPaymentStatus_SelectedIndexChanged);
            // 
            // lblNewPaymentStatus
            // 
            this.lblNewPaymentStatus.AutoSize = true;
            this.lblNewPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPaymentStatus.Location = new System.Drawing.Point(217, 91);
            this.lblNewPaymentStatus.Name = "lblNewPaymentStatus";
            this.lblNewPaymentStatus.Size = new System.Drawing.Size(133, 20);
            this.lblNewPaymentStatus.TabIndex = 6;
            this.lblNewPaymentStatus.Text = "TT thanh toán mới:";
            // 
            // txtCurrentPaymentStatus
            // 
            this.txtCurrentPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCurrentPaymentStatus.Location = new System.Drawing.Point(23, 112);
            this.txtCurrentPaymentStatus.Name = "txtCurrentPaymentStatus";
            this.txtCurrentPaymentStatus.ReadOnly = true;
            this.txtCurrentPaymentStatus.Size = new System.Drawing.Size(171, 27);
            this.txtCurrentPaymentStatus.TabIndex = 5;
            // 
            // lblCurrentPaymentStatus
            // 
            this.lblCurrentPaymentStatus.AutoSize = true;
            this.lblCurrentPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentPaymentStatus.Location = new System.Drawing.Point(23, 91);
            this.lblCurrentPaymentStatus.Name = "lblCurrentPaymentStatus";
            this.lblCurrentPaymentStatus.Size = new System.Drawing.Size(156, 20);
            this.lblCurrentPaymentStatus.TabIndex = 4;
            this.lblCurrentPaymentStatus.Text = "TT thanh toán hiện tại:";
            // 
            // cboNewOrderStatus
            // 
            this.cboNewOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNewOrderStatus.FormattingEnabled = true;
            this.cboNewOrderStatus.Items.AddRange(new object[] {
            "processing|Đang xử lý",
            "completed|Hoàn thành",
            "cancelled|Đã hủy",
            "returned|Đã trả hàng"});
            this.cboNewOrderStatus.Location = new System.Drawing.Point(217, 53);
            this.cboNewOrderStatus.Name = "cboNewOrderStatus";
            this.cboNewOrderStatus.Size = new System.Drawing.Size(171, 28);
            this.cboNewOrderStatus.TabIndex = 3;
            this.cboNewOrderStatus.SelectedIndexChanged += new System.EventHandler(this.cboNewOrderStatus_SelectedIndexChanged);
            // 
            // lblNewOrderStatus
            // 
            this.lblNewOrderStatus.AutoSize = true;
            this.lblNewOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewOrderStatus.Location = new System.Drawing.Point(217, 32);
            this.lblNewOrderStatus.Name = "lblNewOrderStatus";
            this.lblNewOrderStatus.Size = new System.Drawing.Size(125, 20);
            this.lblNewOrderStatus.TabIndex = 2;
            this.lblNewOrderStatus.Text = "TT đơn hàng mới:";
            // 
            // txtCurrentOrderStatus
            // 
            this.txtCurrentOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCurrentOrderStatus.Location = new System.Drawing.Point(23, 53);
            this.txtCurrentOrderStatus.Name = "txtCurrentOrderStatus";
            this.txtCurrentOrderStatus.ReadOnly = true;
            this.txtCurrentOrderStatus.Size = new System.Drawing.Size(171, 27);
            this.txtCurrentOrderStatus.TabIndex = 1;
            // 
            // lblCurrentOrderStatus
            // 
            this.lblCurrentOrderStatus.AutoSize = true;
            this.lblCurrentOrderStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCurrentOrderStatus.Location = new System.Drawing.Point(23, 32);
            this.lblCurrentOrderStatus.Name = "lblCurrentOrderStatus";
            this.lblCurrentOrderStatus.Size = new System.Drawing.Size(148, 20);
            this.lblCurrentOrderStatus.TabIndex = 0;
            this.lblCurrentOrderStatus.Text = "TT đơn hàng hiện tại:";
            // 
            // gbOrderInfo
            // 
            this.gbOrderInfo.Controls.Add(this.txtTotalAmount);
            this.gbOrderInfo.Controls.Add(this.lblTotalAmount);
            this.gbOrderInfo.Controls.Add(this.txtCustomerName);
            this.gbOrderInfo.Controls.Add(this.lblCustomerName);
            this.gbOrderInfo.Controls.Add(this.txtOrderDate);
            this.gbOrderInfo.Controls.Add(this.lblOrderDate);
            this.gbOrderInfo.Controls.Add(this.txtOrderCode);
            this.gbOrderInfo.Controls.Add(this.lblOrderCode);
            this.gbOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbOrderInfo.Location = new System.Drawing.Point(17, 16);
            this.gbOrderInfo.Name = "gbOrderInfo";
            this.gbOrderInfo.Size = new System.Drawing.Size(709, 139);
            this.gbOrderInfo.TabIndex = 0;
            this.gbOrderInfo.TabStop = false;
            this.gbOrderInfo.Text = "Thông tin đơn hàng";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.txtTotalAmount.Location = new System.Drawing.Point(503, 87);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(171, 27);
            this.txtTotalAmount.TabIndex = 7;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalAmount.Location = new System.Drawing.Point(411, 91);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(75, 20);
            this.lblTotalAmount.TabIndex = 6;
            this.lblTotalAmount.Text = "Tổng tiền:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.Location = new System.Drawing.Point(126, 87);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(228, 27);
            this.txtCustomerName.TabIndex = 5;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(23, 91);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(89, 20);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Khách hàng:";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOrderDate.Location = new System.Drawing.Point(217, 53);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(171, 27);
            this.txtOrderDate.TabIndex = 3;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderDate.Location = new System.Drawing.Point(217, 32);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(73, 20);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Ngày đặt:";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtOrderCode.Location = new System.Drawing.Point(23, 53);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(171, 27);
            this.txtOrderCode.TabIndex = 1;
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderCode.Location = new System.Drawing.Point(23, 32);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(100, 20);
            this.lblOrderCode.TabIndex = 0;
            this.lblOrderCode.Text = "Mã đơn hàng:";
            // 
            // frmUpdateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 747);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật trạng thái đơn hàng";
            this.Load += new System.EventHandler(this.frmUpdateOrder_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.gbNotes.ResumeLayout(false);
            this.gbNotes.PerformLayout();
            this.gbPaymentInfo.ResumeLayout(false);
            this.gbPaymentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPaidAmount)).EndInit();
            this.gbStatusUpdate.ResumeLayout(false);
            this.gbStatusUpdate.PerformLayout();
            this.gbOrderInfo.ResumeLayout(false);
            this.gbOrderInfo.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
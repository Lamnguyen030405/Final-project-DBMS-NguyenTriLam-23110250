namespace PhoneStore.Forms
{
    partial class frmAddPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblPaymentCount = new System.Windows.Forms.Label();
            this.lblRemainingAmount = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.lblAfterPayment = new System.Windows.Forms.Label();
            this.lblAmountInfo = new System.Windows.Forms.Label();
            this.btnPayFull = new System.Windows.Forms.Button();
            this.lblReferenceRequired = new System.Windows.Forms.Label();
            this.btnGenerateReference = new System.Windows.Forms.Button();
            this.txtReferenceNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpOrderInfo.SuspendLayout();
            this.grpPaymentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.grpNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.lblPaymentCount);
            this.grpOrderInfo.Controls.Add(this.lblRemainingAmount);
            this.grpOrderInfo.Controls.Add(this.lblPaidAmount);
            this.grpOrderInfo.Controls.Add(this.lblTotalAmount);
            this.grpOrderInfo.Controls.Add(this.lblOrderCode);
            this.grpOrderInfo.Controls.Add(this.label5);
            this.grpOrderInfo.Controls.Add(this.label4);
            this.grpOrderInfo.Controls.Add(this.label3);
            this.grpOrderInfo.Controls.Add(this.label2);
            this.grpOrderInfo.Controls.Add(this.label1);
            this.grpOrderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderInfo.Location = new System.Drawing.Point(12, 12);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(560, 160);
            this.grpOrderInfo.TabIndex = 0;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Thông tin đơn hàng";
            // 
            // lblPaymentCount
            // 
            this.lblPaymentCount.AutoSize = true;
            this.lblPaymentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPaymentCount.Location = new System.Drawing.Point(20, 135);
            this.lblPaymentCount.Name = "lblPaymentCount";
            this.lblPaymentCount.Size = new System.Drawing.Size(101, 13);
            this.lblPaymentCount.TabIndex = 9;
            this.lblPaymentCount.Text = "Đã có 0 giao dịch";
            // 
            // lblRemainingAmount
            // 
            this.lblRemainingAmount.AutoSize = true;
            this.lblRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingAmount.ForeColor = System.Drawing.Color.Red;
            this.lblRemainingAmount.Location = new System.Drawing.Point(180, 110);
            this.lblRemainingAmount.Name = "lblRemainingAmount";
            this.lblRemainingAmount.Size = new System.Drawing.Size(15, 15);
            this.lblRemainingAmount.TabIndex = 8;
            this.lblRemainingAmount.Text = "0";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Location = new System.Drawing.Point(180, 85);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(14, 15);
            this.lblPaidAmount.TabIndex = 7;
            this.lblPaidAmount.Text = "0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(180, 60);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(14, 15);
            this.lblTotalAmount.TabIndex = 6;
            this.lblTotalAmount.Text = "0";
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCode.Location = new System.Drawing.Point(180, 35);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(15, 15);
            this.lblOrderCode.TabIndex = 5;
            this.lblOrderCode.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Còn lại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đã thanh toán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng tiền đơn hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã đơn hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // grpPaymentInfo
            // 
            this.grpPaymentInfo.Controls.Add(this.lblAfterPayment);
            this.grpPaymentInfo.Controls.Add(this.lblAmountInfo);
            this.grpPaymentInfo.Controls.Add(this.btnPayFull);
            this.grpPaymentInfo.Controls.Add(this.lblReferenceRequired);
            this.grpPaymentInfo.Controls.Add(this.btnGenerateReference);
            this.grpPaymentInfo.Controls.Add(this.txtReferenceNumber);
            this.grpPaymentInfo.Controls.Add(this.label10);
            this.grpPaymentInfo.Controls.Add(this.numAmount);
            this.grpPaymentInfo.Controls.Add(this.label9);
            this.grpPaymentInfo.Controls.Add(this.dtpPaymentDate);
            this.grpPaymentInfo.Controls.Add(this.label8);
            this.grpPaymentInfo.Controls.Add(this.cboPaymentMethod);
            this.grpPaymentInfo.Controls.Add(this.label7);
            this.grpPaymentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentInfo.Location = new System.Drawing.Point(12, 178);
            this.grpPaymentInfo.Name = "grpPaymentInfo";
            this.grpPaymentInfo.Size = new System.Drawing.Size(560, 230);
            this.grpPaymentInfo.TabIndex = 1;
            this.grpPaymentInfo.TabStop = false;
            this.grpPaymentInfo.Text = "Thông tin thanh toán";
            // 
            // lblAfterPayment
            // 
            this.lblAfterPayment.AutoSize = true;
            this.lblAfterPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAfterPayment.ForeColor = System.Drawing.Color.Orange;
            this.lblAfterPayment.Location = new System.Drawing.Point(180, 205);
            this.lblAfterPayment.Name = "lblAfterPayment";
            this.lblAfterPayment.Size = new System.Drawing.Size(159, 13);
            this.lblAfterPayment.TabIndex = 12;
            this.lblAfterPayment.Text = "Còn lại sau thanh toán: 0đ";
            // 
            // lblAmountInfo
            // 
            this.lblAmountInfo.AutoSize = true;
            this.lblAmountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInfo.Location = new System.Drawing.Point(180, 185);
            this.lblAmountInfo.Name = "lblAmountInfo";
            this.lblAmountInfo.Size = new System.Drawing.Size(69, 13);
            this.lblAmountInfo.TabIndex = 11;
            this.lblAmountInfo.Text = "Số tiền: 0đ";
            // 
            // btnPayFull
            // 
            this.btnPayFull.Location = new System.Drawing.Point(445, 115);
            this.btnPayFull.Name = "btnPayFull";
            this.btnPayFull.Size = new System.Drawing.Size(95, 25);
            this.btnPayFull.TabIndex = 10;
            this.btnPayFull.Text = "Thanh toán đủ";
            this.btnPayFull.UseVisualStyleBackColor = true;
            // 
            // lblReferenceRequired
            // 
            this.lblReferenceRequired.AutoSize = true;
            this.lblReferenceRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceRequired.ForeColor = System.Drawing.Color.Red;
            this.lblReferenceRequired.Location = new System.Drawing.Point(180, 168);
            this.lblReferenceRequired.Name = "lblReferenceRequired";
            this.lblReferenceRequired.Size = new System.Drawing.Size(199, 13);
            this.lblReferenceRequired.TabIndex = 9;
            this.lblReferenceRequired.Text = "* Mã tham chiếu là bắt buộc";
            this.lblReferenceRequired.Visible = false;
            // 
            // btnGenerateReference
            // 
            this.btnGenerateReference.Location = new System.Drawing.Point(445, 145);
            this.btnGenerateReference.Name = "btnGenerateReference";
            this.btnGenerateReference.Size = new System.Drawing.Size(95, 25);
            this.btnGenerateReference.TabIndex = 8;
            this.btnGenerateReference.Text = "Tạo mã";
            this.btnGenerateReference.UseVisualStyleBackColor = true;
            // 
            // txtReferenceNumber
            // 
            this.txtReferenceNumber.Location = new System.Drawing.Point(183, 145);
            this.txtReferenceNumber.Name = "txtReferenceNumber";
            this.txtReferenceNumber.Size = new System.Drawing.Size(250, 21);
            this.txtReferenceNumber.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Mã tham chiếu:";
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(183, 118);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(250, 21);
            this.numAmount.TabIndex = 5;
            this.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAmount.ThousandsSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Số tiền thanh toán:";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(183, 85);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(250, 21);
            this.dtpPaymentDate.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ngày thanh toán:";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(183, 52);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(250, 23);
            this.cboPaymentMethod.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Phương thức thanh toán:";
            // 
            // grpNotes
            // 
            this.grpNotes.Controls.Add(this.txtNotes);
            this.grpNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNotes.Location = new System.Drawing.Point(12, 414);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Size = new System.Drawing.Size(560, 100);
            this.grpNotes.TabIndex = 2;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = "Ghi chú";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(15, 25);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(530, 60);
            this.txtNotes.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Location = new System.Drawing.Point(332, 530);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(120, 40);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Thanh toán";
            this.btnProcess.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(458, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 582);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.grpNotes);
            this.Controls.Add(this.grpPaymentInfo);
            this.Controls.Add(this.grpOrderInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm thanh toán";
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            this.grpPaymentInfo.ResumeLayout(false);
            this.grpPaymentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.grpNotes.ResumeLayout(false);
            this.grpNotes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.Label lblPaymentCount;
        private System.Windows.Forms.Label lblRemainingAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblOrderCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPaymentInfo;
        private System.Windows.Forms.Label lblAfterPayment;
        private System.Windows.Forms.Label lblAmountInfo;
        private System.Windows.Forms.Button btnPayFull;
        private System.Windows.Forms.Label lblReferenceRequired;
        private System.Windows.Forms.Button btnGenerateReference;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnCancel;
    }
}
namespace Hugate.Parking
{
    partial class frmDelete
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
            this.txtRFID = new DevExpress.XtraEditors.TextEdit();
            this.teTimeOut = new DevExpress.XtraEditors.TimeEdit();
            this.teTimeIn = new DevExpress.XtraEditors.TimeEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeIn = new DevExpress.XtraEditors.LabelControl();
            this.lblRFID = new DevExpress.XtraEditors.LabelControl();
            this.btnCheckIDCard = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(82, 18);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(221, 20);
            this.txtRFID.TabIndex = 1;
            // 
            // teTimeOut
            // 
            this.teTimeOut.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.teTimeOut.Enabled = false;
            this.teTimeOut.Location = new System.Drawing.Point(83, 121);
            this.teTimeOut.Name = "teTimeOut";
            this.teTimeOut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teTimeOut.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeOut.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeOut.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.teTimeOut.Size = new System.Drawing.Size(220, 20);
            this.teTimeOut.TabIndex = 14;
            // 
            // teTimeIn
            // 
            this.teTimeIn.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.teTimeIn.Enabled = false;
            this.teTimeIn.Location = new System.Drawing.Point(83, 95);
            this.teTimeIn.Name = "teTimeIn";
            this.teTimeIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.teTimeIn.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeIn.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTimeIn.Properties.Mask.EditMask = "dd-MM-yyyy HH:mm";
            this.teTimeIn.Size = new System.Drawing.Size(220, 20);
            this.teTimeIn.TabIndex = 15;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(213, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Đồng ý thoát";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(82, 43);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(221, 20);
            this.txtPrice.TabIndex = 6;
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(82, 69);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(221, 20);
            this.txtNumber.TabIndex = 11;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(12, 47);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Giá xe :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 124);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Thời gian ra";
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(12, 73);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(56, 13);
            this.lblNumber.TabIndex = 12;
            this.lblNumber.Text = "Biển số xe :";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Location = new System.Drawing.Point(12, 98);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(64, 13);
            this.lblTimeIn.TabIndex = 8;
            this.lblTimeIn.Text = "Thời gian vào";
            // 
            // lblRFID
            // 
            this.lblRFID.Location = new System.Drawing.Point(12, 21);
            this.lblRFID.Name = "lblRFID";
            this.lblRFID.Size = new System.Drawing.Size(38, 13);
            this.lblRFID.TabIndex = 10;
            this.lblRFID.Text = "Số thẻ :";
            // 
            // btnCheckIDCard
            // 
            this.btnCheckIDCard.Location = new System.Drawing.Point(12, 182);
            this.btnCheckIDCard.Name = "btnCheckIDCard";
            this.btnCheckIDCard.Size = new System.Drawing.Size(87, 23);
            this.btnCheckIDCard.TabIndex = 16;
            this.btnCheckIDCard.Text = "Kiểm tra Số thẻ";
            this.btnCheckIDCard.Click += new System.EventHandler(this.btnCheckIDCard_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(83, 153);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "thông báo";
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 217);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCheckIDCard);
            this.Controls.Add(this.teTimeOut);
            this.Controls.Add(this.teTimeIn);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.lblRFID);
            this.Controls.Add(this.txtRFID);
            this.Name = "frmDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Huỷ thẻ lỗi";
            this.Load += new System.EventHandler(this.frmDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRFID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTimeIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRFID;
        private DevExpress.XtraEditors.TimeEdit teTimeOut;
        private DevExpress.XtraEditors.TimeEdit teTimeIn;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblNumber;
        private DevExpress.XtraEditors.LabelControl lblTimeIn;
        private DevExpress.XtraEditors.LabelControl lblRFID;
        private DevExpress.XtraEditors.SimpleButton btnCheckIDCard;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
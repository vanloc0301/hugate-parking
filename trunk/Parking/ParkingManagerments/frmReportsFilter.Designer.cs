namespace Hugate.Parking
{
    partial class frmReportsFilter
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeIn = new DevExpress.XtraEditors.LabelControl();
            this.fromDate = new DevExpress.XtraEditors.DateEdit();
            this.toDate = new DevExpress.XtraEditors.DateEdit();
            this.fromTime = new DevExpress.XtraEditors.TimeEdit();
            this.toTime = new DevExpress.XtraEditors.TimeEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Đến ngày";
            // 
            // lblTimeIn
            // 
            this.lblTimeIn.Location = new System.Drawing.Point(31, 16);
            this.lblTimeIn.Name = "lblTimeIn";
            this.lblTimeIn.Size = new System.Drawing.Size(40, 13);
            this.lblTimeIn.TabIndex = 14;
            this.lblTimeIn.Text = "Từ ngày";
            // 
            // fromDate
            // 
            this.fromDate.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.fromDate.Location = new System.Drawing.Point(107, 12);
            this.fromDate.Name = "fromDate";
            this.fromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.fromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.fromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.fromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromDate.Size = new System.Drawing.Size(86, 20);
            this.fromDate.TabIndex = 0;
            // 
            // toDate
            // 
            this.toDate.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.toDate.Location = new System.Drawing.Point(107, 38);
            this.toDate.Name = "toDate";
            this.toDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.toDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.toDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.toDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toDate.Size = new System.Drawing.Size(86, 20);
            this.toDate.TabIndex = 2;
            // 
            // fromTime
            // 
            this.fromTime.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.fromTime.Location = new System.Drawing.Point(199, 12);
            this.fromTime.Name = "fromTime";
            this.fromTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.fromTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.fromTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromTime.Properties.EditFormat.FormatString = "HH:mm";
            this.fromTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fromTime.Properties.Mask.EditMask = "HH:mm";
            this.fromTime.Size = new System.Drawing.Size(70, 20);
            this.fromTime.TabIndex = 1;
            // 
            // toTime
            // 
            this.toTime.EditValue = new System.DateTime(2011, 10, 20, 0, 0, 0, 0);
            this.toTime.Location = new System.Drawing.Point(199, 38);
            this.toTime.Name = "toTime";
            this.toTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.toTime.Properties.DisplayFormat.FormatString = "HH:mm";
            this.toTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toTime.Properties.EditFormat.FormatString = "HH:mm";
            this.toTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.toTime.Properties.Mask.EditMask = "HH:mm";
            this.toTime.Size = new System.Drawing.Size(70, 20);
            this.toTime.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(67, 75);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(158, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            // 
            // frmReportsFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(304, 112);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblTimeIn);
            this.Controls.Add(this.fromDate);
            this.Controls.Add(this.toDate);
            this.Controls.Add(this.fromTime);
            this.Controls.Add(this.toTime);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportsFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lọc báo cáo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportsFilter_FormClosing);
            this.Load += new System.EventHandler(this.frmReportsFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblTimeIn;
        private DevExpress.XtraEditors.DateEdit fromDate;
        private DevExpress.XtraEditors.DateEdit toDate;
        private DevExpress.XtraEditors.TimeEdit fromTime;
        private DevExpress.XtraEditors.TimeEdit toTime;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

    }
}
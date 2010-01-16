namespace FaceIDAppVBEta
{
    partial class ucAttendanceLog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCollectData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAttendanceFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpAttedanceTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAttendanceLog = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnAddNewAttendaceRecord = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCollectData
            // 
            this.btnCollectData.Location = new System.Drawing.Point(23, 26);
            this.btnCollectData.Name = "btnCollectData";
            this.btnCollectData.Size = new System.Drawing.Size(75, 23);
            this.btnCollectData.TabIndex = 0;
            this.btnCollectData.Text = "Collect Data";
            this.btnCollectData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // dtpAttendanceFrom
            // 
            this.dtpAttendanceFrom.Location = new System.Drawing.Point(100, 118);
            this.dtpAttendanceFrom.Name = "dtpAttendanceFrom";
            this.dtpAttendanceFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpAttendanceFrom.TabIndex = 3;
            // 
            // dtpAttedanceTo
            // 
            this.dtpAttedanceTo.Location = new System.Drawing.Point(406, 122);
            this.dtpAttedanceTo.Name = "dtpAttedanceTo";
            this.dtpAttedanceTo.Size = new System.Drawing.Size(200, 20);
            this.dtpAttedanceTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // dgvAttendanceLog
            // 
            this.dgvAttendanceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.AttDate,
            this.AttDetail,
            this.AttSummary,
            this.AttNote});
            this.dgvAttendanceLog.Location = new System.Drawing.Point(23, 154);
            this.dgvAttendanceLog.Name = "dgvAttendanceLog";
            this.dgvAttendanceLog.Size = new System.Drawing.Size(664, 150);
            this.dgvAttendanceLog.TabIndex = 6;
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            // 
            // AttDate
            // 
            this.AttDate.HeaderText = "Date";
            this.AttDate.Name = "AttDate";
            // 
            // AttDetail
            // 
            this.AttDetail.HeaderText = "Attendance Detail";
            this.AttDetail.Name = "AttDetail";
            // 
            // AttSummary
            // 
            this.AttSummary.HeaderText = "Total of Hours";
            this.AttSummary.Name = "AttSummary";
            // 
            // AttNote
            // 
            this.AttNote.HeaderText = "Note";
            this.AttNote.Name = "AttNote";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(111, 326);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(192, 326);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 8;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnAddNewAttendaceRecord
            // 
            this.btnAddNewAttendaceRecord.Location = new System.Drawing.Point(273, 326);
            this.btnAddNewAttendaceRecord.Name = "btnAddNewAttendaceRecord";
            this.btnAddNewAttendaceRecord.Size = new System.Drawing.Size(168, 23);
            this.btnAddNewAttendaceRecord.TabIndex = 9;
            this.btnAddNewAttendaceRecord.Text = "Add new Attendance Record";
            this.btnAddNewAttendaceRecord.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(649, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "View";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Company";
            // 
            // cbxCompany
            // 
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(108, 81);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 12;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(451, 90);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Department";
            // 
            // ucAttendanceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnAddNewAttendaceRecord);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvAttendanceLog);
            this.Controls.Add(this.dtpAttedanceTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpAttendanceFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCollectData);
            this.Name = "ucAttendanceLog";
            this.Size = new System.Drawing.Size(1058, 475);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCollectData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAttendanceFrom;
        private System.Windows.Forms.DateTimePicker dtpAttedanceTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAttendanceLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttNote;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnAddNewAttendaceRecord;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label5;
    }
}

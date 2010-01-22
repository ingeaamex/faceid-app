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
            this.components = new System.ComponentModel.Container();
            this.btnCollectData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAttendanceFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpAttedanceTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnAddNewAttendaceRecord = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAttendanceLog = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalofHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAction.SuspendLayout();
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
            // cmsAction
            // 
            this.cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsAction.Name = "cmsAction";
            this.cmsAction.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(98, 411);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(179, 411);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 8;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnAddNewAttendaceRecord
            // 
            this.btnAddNewAttendaceRecord.Location = new System.Drawing.Point(260, 411);
            this.btnAddNewAttendaceRecord.Name = "btnAddNewAttendaceRecord";
            this.btnAddNewAttendaceRecord.Size = new System.Drawing.Size(168, 23);
            this.btnAddNewAttendaceRecord.TabIndex = 9;
            this.btnAddNewAttendaceRecord.Text = "Add new Attendance Record";
            this.btnAddNewAttendaceRecord.UseVisualStyleBackColor = true;
            this.btnAddNewAttendaceRecord.Click += new System.EventHandler(this.btnAddNewAttendaceRecord_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(649, 111);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
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
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(108, 81);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 12;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Name";
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(451, 90);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 13;
            this.cbxDepartment.ValueMember = "ID";
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
            // dgvAttendanceLog
            // 
            this.dgvAttendanceLog.AllowUserToAddRows = false;
            this.dgvAttendanceLog.AllowUserToDeleteRows = false;
            this.dgvAttendanceLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendanceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.Date,
            this.AttendanceDetail,
            this.TotalofHours,
            this.Note});
            this.dgvAttendanceLog.Location = new System.Drawing.Point(39, 157);
            this.dgvAttendanceLog.Name = "dgvAttendanceLog";
            this.dgvAttendanceLog.ReadOnly = true;
            this.dgvAttendanceLog.Size = new System.Drawing.Size(895, 238);
            this.dgvAttendanceLog.TabIndex = 15;
            this.dgvAttendanceLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAttendanceLog_MouseDown);
            this.dgvAttendanceLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAttendanceLog_CellFormatting);
            this.dgvAttendanceLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAttendanceLog_CellPainting);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // AttendanceDetail
            // 
            this.AttendanceDetail.ContextMenuStrip = this.cmsAction;
            this.AttendanceDetail.HeaderText = "Attendance Detail";
            this.AttendanceDetail.Name = "AttendanceDetail";
            this.AttendanceDetail.ReadOnly = true;
            // 
            // TotalofHours
            // 
            this.TotalofHours.HeaderText = "Total of Hours";
            this.TotalofHours.Name = "TotalofHours";
            this.TotalofHours.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // ucAttendanceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAttendanceLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAddNewAttendaceRecord);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dtpAttedanceTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpAttendanceFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCollectData);
            this.Name = "ucAttendanceLog";
            this.Size = new System.Drawing.Size(1058, 475);
            this.cmsAction.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Button btnAddNewAttendaceRecord;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsAction;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAttendanceLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalofHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}

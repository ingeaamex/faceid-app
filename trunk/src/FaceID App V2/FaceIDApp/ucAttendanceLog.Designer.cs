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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAttendanceFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpAttedanceTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.EmployeeName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddNewRoostedDayOff = new System.Windows.Forms.Button();
            this.cmsAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // dtpAttendanceFrom
            // 
            this.dtpAttendanceFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttendanceFrom.Location = new System.Drawing.Point(63, 49);
            this.dtpAttendanceFrom.Name = "dtpAttendanceFrom";
            this.dtpAttendanceFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpAttendanceFrom.TabIndex = 3;
            this.dtpAttendanceFrom.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // dtpAttedanceTo
            // 
            this.dtpAttedanceTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttedanceTo.Location = new System.Drawing.Point(264, 49);
            this.dtpAttedanceTo.Name = "dtpAttedanceTo";
            this.dtpAttedanceTo.Size = new System.Drawing.Size(121, 20);
            this.dtpAttedanceTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // cmsAction
            // 
            this.cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsAction.Name = "cmsAction";
            this.cmsAction.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
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
            this.btnPrint.Location = new System.Drawing.Point(582, 91);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(662, 91);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToFile.TabIndex = 8;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Visible = false;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnAddNewAttendaceRecord
            // 
            this.btnAddNewAttendaceRecord.Location = new System.Drawing.Point(89, 91);
            this.btnAddNewAttendaceRecord.Name = "btnAddNewAttendaceRecord";
            this.btnAddNewAttendaceRecord.Size = new System.Drawing.Size(168, 23);
            this.btnAddNewAttendaceRecord.TabIndex = 9;
            this.btnAddNewAttendaceRecord.Text = "Add new Attendance Record";
            this.btnAddNewAttendaceRecord.UseVisualStyleBackColor = true;
            this.btnAddNewAttendaceRecord.Click += new System.EventHandler(this.btnAddNewAttendaceRecord_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(6, 91);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View Logs";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
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
            this.cbxCompany.Location = new System.Drawing.Point(63, 9);
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
            this.cbxDepartment.Location = new System.Drawing.Point(264, 9);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 13;
            this.cbxDepartment.ValueMember = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Department";
            // 
            // dgvAttendanceLog
            // 
            this.dgvAttendanceLog.AllowUserToAddRows = false;
            this.dgvAttendanceLog.AllowUserToDeleteRows = false;
            this.dgvAttendanceLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttendanceLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName1,
            this.Date1,
            this.AttendanceDetail,
            this.TotalHours,
            this.Note1});
            this.dgvAttendanceLog.Location = new System.Drawing.Point(3, 120);
            this.dgvAttendanceLog.Name = "dgvAttendanceLog";
            this.dgvAttendanceLog.ReadOnly = true;
            this.dgvAttendanceLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttendanceLog.Size = new System.Drawing.Size(825, 448);
            this.dgvAttendanceLog.TabIndex = 16;
            this.dgvAttendanceLog.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvAttendanceLog_Scroll);
            this.dgvAttendanceLog.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttendanceLog_ColumnHeaderMouseClick);
            this.dgvAttendanceLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAttendanceLog_CellFormatting);
            this.dgvAttendanceLog.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendanceLog_CellMouseEnter);
            this.dgvAttendanceLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAttendanceLog_CellPainting);
            this.dgvAttendanceLog.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttendanceLog_CellMouseDoubleClick);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            this.EmployeeNumber.Width = 118;
            // 
            // EmployeeName1
            // 
            this.EmployeeName1.DataPropertyName = "EmployeeName";
            this.EmployeeName1.HeaderText = "Employee Name";
            this.EmployeeName1.Name = "EmployeeName1";
            this.EmployeeName1.ReadOnly = true;
            this.EmployeeName1.Width = 109;
            // 
            // Date1
            // 
            this.Date1.DataPropertyName = "DateLog";
            dataGridViewCellStyle3.Format = "d MMM yyyy";
            this.Date1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Date1.HeaderText = "Date";
            this.Date1.Name = "Date1";
            this.Date1.ReadOnly = true;
            this.Date1.Width = 55;
            // 
            // AttendanceDetail
            // 
            this.AttendanceDetail.ContextMenuStrip = this.cmsAction;
            this.AttendanceDetail.DataPropertyName = "TimeLog";
            this.AttendanceDetail.HeaderText = "Attendance Detail";
            this.AttendanceDetail.Name = "AttendanceDetail";
            this.AttendanceDetail.ReadOnly = true;
            this.AttendanceDetail.Width = 117;
            // 
            // TotalHours
            // 
            this.TotalHours.DataPropertyName = "TotalHours";
            this.TotalHours.HeaderText = "TotalHours";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.Width = 84;
            // 
            // Note1
            // 
            this.Note1.DataPropertyName = "Note";
            this.Note1.HeaderText = "Note";
            this.Note1.Name = "Note1";
            this.Note1.ReadOnly = true;
            this.Note1.Width = 55;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EmployeeNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "Employee Number";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Employee Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 131;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.Format = "d MMM yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.ContextMenuStrip = this.cmsAction;
            this.dataGridViewTextBoxColumn4.HeaderText = "Attendance Detail";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "TotalHours";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 131;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Note";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // btnAddNewRoostedDayOff
            // 
            this.btnAddNewRoostedDayOff.Location = new System.Drawing.Point(263, 91);
            this.btnAddNewRoostedDayOff.Name = "btnAddNewRoostedDayOff";
            this.btnAddNewRoostedDayOff.Size = new System.Drawing.Size(168, 23);
            this.btnAddNewRoostedDayOff.TabIndex = 9;
            this.btnAddNewRoostedDayOff.Text = "Add new Roosted days off";
            this.btnAddNewRoostedDayOff.UseVisualStyleBackColor = true;
            this.btnAddNewRoostedDayOff.Click += new System.EventHandler(this.btnAddNewRoostedDayOff_Click);
            // 
            // ucAttendanceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.dgvAttendanceLog);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpAttedanceTo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpAttendanceFrom);
            this.Controls.Add(this.btnAddNewAttendaceRecord);
            this.Controls.Add(this.btnAddNewRoostedDayOff);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.label2);
            this.Name = "ucAttendanceLog";
            this.Size = new System.Drawing.Size(831, 580);
            this.Load += new System.EventHandler(this.ucAttendanceLog_Load);
            this.cmsAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Button btnAddNewRoostedDayOff;
    }
}

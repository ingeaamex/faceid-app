namespace FaceIDAppVBEta
{
    partial class ucAttendanceReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.cbxCompany = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnPayrollExport = new System.Windows.Forms.Button();
            this.btnExportToMYOB = new System.Windows.Forms.Button();
            this.dtpAttedanceTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpAttendanceFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAttendanceReport = new System.Windows.Forms.DataGridView();
            this.EmployeeNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Department";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DisplayMember = "Name";
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(276, 17);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(121, 21);
            this.cbxDepartment.TabIndex = 26;
            this.cbxDepartment.ValueMember = "ID";
            // 
            // cbxCompany
            // 
            this.cbxCompany.DisplayMember = "Name";
            this.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCompany.FormattingEnabled = true;
            this.cbxCompany.Location = new System.Drawing.Point(70, 17);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 25;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Company";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(70, 78);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(75, 23);
            this.btnViewReport.TabIndex = 23;
            this.btnViewReport.Text = "View";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnPayrollExport
            // 
            this.btnPayrollExport.Location = new System.Drawing.Point(276, 78);
            this.btnPayrollExport.Name = "btnPayrollExport";
            this.btnPayrollExport.Size = new System.Drawing.Size(168, 23);
            this.btnPayrollExport.TabIndex = 22;
            this.btnPayrollExport.Text = "Print";
            this.btnPayrollExport.UseVisualStyleBackColor = true;
            this.btnPayrollExport.Click += new System.EventHandler(this.btnPayrollExport_Click);
            // 
            // btnExportToMYOB
            // 
            this.btnExportToMYOB.Location = new System.Drawing.Point(156, 78);
            this.btnExportToMYOB.Name = "btnExportToMYOB";
            this.btnExportToMYOB.Size = new System.Drawing.Size(114, 23);
            this.btnExportToMYOB.TabIndex = 20;
            this.btnExportToMYOB.Text = "Export to MYOB";
            this.btnExportToMYOB.UseVisualStyleBackColor = true;
            this.btnExportToMYOB.Click += new System.EventHandler(this.btnExportToMYOB_Click);
            // 
            // dtpAttedanceTo
            // 
            this.dtpAttedanceTo.Location = new System.Drawing.Point(314, 52);
            this.dtpAttedanceTo.Name = "dtpAttedanceTo";
            this.dtpAttedanceTo.Size = new System.Drawing.Size(200, 20);
            this.dtpAttedanceTo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // dtpAttendanceFrom
            // 
            this.dtpAttendanceFrom.Location = new System.Drawing.Point(70, 52);
            this.dtpAttendanceFrom.Name = "dtpAttendanceFrom";
            this.dtpAttendanceFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpAttendanceFrom.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "From";
            // 
            // dgvAttendanceReport
            // 
            this.dgvAttendanceReport.AllowUserToAddRows = false;
            this.dgvAttendanceReport.AllowUserToDeleteRows = false;
            this.dgvAttendanceReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAttendanceReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeNumber,
            this.EmployeeName,
            this.Date,
            this.AttendanceDetail,
            this.TotalHours,
            this.Chart});
            this.dgvAttendanceReport.Location = new System.Drawing.Point(3, 120);
            this.dgvAttendanceReport.Name = "dgvAttendanceReport";
            this.dgvAttendanceReport.ReadOnly = true;
            this.dgvAttendanceReport.Size = new System.Drawing.Size(825, 448);
            this.dgvAttendanceReport.TabIndex = 28;
            this.dgvAttendanceReport.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAttendanceReport_CellPainting);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.MinimumWidth = 10;
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "FullName";
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.MinimumWidth = 10;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "WorkFrom";
            dataGridViewCellStyle4.Format = "d MMM yyyy";
            this.Date.DefaultCellStyle = dataGridViewCellStyle4;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // AttendanceDetail
            // 
            this.AttendanceDetail.HeaderText = "Attendance Detail";
            this.AttendanceDetail.Name = "AttendanceDetail";
            this.AttendanceDetail.ReadOnly = true;
            this.AttendanceDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TotalHours
            // 
            this.TotalHours.DataPropertyName = "TotalHour";
            this.TotalHours.HeaderText = "Total of Hours";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            // 
            // Chart
            // 
            this.Chart.HeaderText = "Chart";
            this.Chart.Name = "Chart";
            this.Chart.ReadOnly = true;
            this.Chart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ucAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvAttendanceReport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDepartment);
            this.Controls.Add(this.cbxCompany);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnPayrollExport);
            this.Controls.Add(this.btnExportToMYOB);
            this.Controls.Add(this.dtpAttedanceTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpAttendanceFrom);
            this.Controls.Add(this.label2);
            this.Name = "ucAttendanceReport";
            this.Size = new System.Drawing.Size(831, 580);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.ComboBox cbxCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnPayrollExport;
        private System.Windows.Forms.Button btnExportToMYOB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpAttendanceFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAttendanceReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chart;
        private System.Windows.Forms.DateTimePicker dtpAttedanceTo;
    }
}

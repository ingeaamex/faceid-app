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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxShowChart = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 13);
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
            this.cbxDepartment.Location = new System.Drawing.Point(264, 9);
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
            this.cbxCompany.Location = new System.Drawing.Point(63, 9);
            this.cbxCompany.Name = "cbxCompany";
            this.cbxCompany.Size = new System.Drawing.Size(121, 21);
            this.cbxCompany.TabIndex = 25;
            this.cbxCompany.ValueMember = "ID";
            this.cbxCompany.SelectedIndexChanged += new System.EventHandler(this.cbxCompany_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Company";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(6, 91);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(90, 23);
            this.btnViewReport.TabIndex = 23;
            this.btnViewReport.Text = "View Reports";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnPayrollExport
            // 
            this.btnPayrollExport.Location = new System.Drawing.Point(218, 91);
            this.btnPayrollExport.Name = "btnPayrollExport";
            this.btnPayrollExport.Size = new System.Drawing.Size(103, 23);
            this.btnPayrollExport.TabIndex = 22;
            this.btnPayrollExport.Text = "View Payroll";
            this.btnPayrollExport.UseVisualStyleBackColor = true;
            this.btnPayrollExport.Visible = false;
            this.btnPayrollExport.Click += new System.EventHandler(this.btnPayrollExport_Click);
            // 
            // btnExportToMYOB
            // 
            this.btnExportToMYOB.Enabled = false;
            this.btnExportToMYOB.Location = new System.Drawing.Point(100, 91);
            this.btnExportToMYOB.Name = "btnExportToMYOB";
            this.btnExportToMYOB.Size = new System.Drawing.Size(114, 23);
            this.btnExportToMYOB.TabIndex = 20;
            this.btnExportToMYOB.Text = "Export to MYOB";
            this.btnExportToMYOB.UseVisualStyleBackColor = true;
            this.btnExportToMYOB.Click += new System.EventHandler(this.btnExportToMYOB_Click);
            // 
            // dtpAttedanceTo
            // 
            this.dtpAttedanceTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttedanceTo.Location = new System.Drawing.Point(264, 49);
            this.dtpAttedanceTo.Name = "dtpAttedanceTo";
            this.dtpAttedanceTo.Size = new System.Drawing.Size(121, 20);
            this.dtpAttedanceTo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "To";
            // 
            // dtpAttendanceFrom
            // 
            this.dtpAttendanceFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAttendanceFrom.Location = new System.Drawing.Point(63, 49);
            this.dtpAttendanceFrom.Name = "dtpAttendanceFrom";
            this.dtpAttendanceFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpAttendanceFrom.TabIndex = 16;
            this.dtpAttendanceFrom.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 53);
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
            this.dgvAttendanceReport.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvAttendanceReport_Scroll);
            this.dgvAttendanceReport.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAttendanceReport_CellPainting);
            // 
            // EmployeeNumber
            // 
            this.EmployeeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmployeeNumber.DataPropertyName = "EmployeeNumber";
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Transparent;
            this.EmployeeNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.EmployeeNumber.FillWeight = 120F;
            this.EmployeeNumber.HeaderText = "Employee Number";
            this.EmployeeNumber.MinimumWidth = 10;
            this.EmployeeNumber.Name = "EmployeeNumber";
            this.EmployeeNumber.ReadOnly = true;
            this.EmployeeNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeNumber.Width = 120;
            // 
            // EmployeeName
            // 
            this.EmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmployeeName.DataPropertyName = "FullName";
            this.EmployeeName.FillWeight = 150F;
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.MinimumWidth = 10;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            this.EmployeeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmployeeName.Width = 150;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Date.DataPropertyName = "DateLog";
            dataGridViewCellStyle6.Format = "d MMM yyyy";
            this.Date.DefaultCellStyle = dataGridViewCellStyle6;
            this.Date.FillWeight = 96F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 96;
            // 
            // AttendanceDetail
            // 
            this.AttendanceDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AttendanceDetail.DataPropertyName = "WorkingHour";
            this.AttendanceDetail.FillWeight = 130F;
            this.AttendanceDetail.HeaderText = "Attendance Detail";
            this.AttendanceDetail.Name = "AttendanceDetail";
            this.AttendanceDetail.ReadOnly = true;
            this.AttendanceDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AttendanceDetail.Width = 130;
            // 
            // TotalHours
            // 
            this.TotalHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TotalHours.DataPropertyName = "TotalHour";
            this.TotalHours.FillWeight = 98F;
            this.TotalHours.HeaderText = "Total Hours";
            this.TotalHours.Name = "TotalHours";
            this.TotalHours.ReadOnly = true;
            this.TotalHours.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TotalHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalHours.Width = 98;
            // 
            // Chart
            // 
            this.Chart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Chart.DataPropertyName = "ChartData";
            this.Chart.FillWeight = 188F;
            this.Chart.HeaderText = "Chart";
            this.Chart.Name = "Chart";
            this.Chart.ReadOnly = true;
            this.Chart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EmployeeNumber";
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.FillWeight = 120F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Employee Number";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn2.FillWeight = 28.23705F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Employee Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 161;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "WorkFrom";
            dataGridViewCellStyle8.Format = "d MMM yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.FillWeight = 96F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 96;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WorkingHour";
            this.dataGridViewTextBoxColumn4.FillWeight = 140F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Attendance Detail";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalHour";
            this.dataGridViewTextBoxColumn5.FillWeight = 98F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Total Hours";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 98;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ChartData";
            this.dataGridViewTextBoxColumn6.FillWeight = 28.23705F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Chart";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 161;
            // 
            // cbxShowChart
            // 
            this.cbxShowChart.AutoSize = true;
            this.cbxShowChart.Location = new System.Drawing.Point(413, 11);
            this.cbxShowChart.Name = "cbxShowChart";
            this.cbxShowChart.Size = new System.Drawing.Size(81, 17);
            this.cbxShowChart.TabIndex = 29;
            this.cbxShowChart.Text = "Show Chart";
            this.cbxShowChart.UseVisualStyleBackColor = true;
            // 
            // ucAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxShowChart);
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
        private System.Windows.Forms.DateTimePicker dtpAttedanceTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chart;
        private System.Windows.Forms.CheckBox cbxShowChart;
    }
}

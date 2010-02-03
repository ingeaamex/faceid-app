namespace FaceIDAppVBEta
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sctMain = new System.Windows.Forms.SplitContainer();
            this.btnAttTest = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.btnReprocess = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnWorkingCalendar = new System.Windows.Forms.Button();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.sctMain.Panel1.SuspendLayout();
            this.sctMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.departmentToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.terminalToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.filesToolStripMenuItem.Text = "Forms";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.companyToolStripMenuItem.Text = "Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.departmentToolStripMenuItem.Text = "Department";
            this.departmentToolStripMenuItem.Click += new System.EventHandler(this.departmentToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // terminalToolStripMenuItem
            // 
            this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            this.terminalToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.terminalToolStripMenuItem.Text = "Terminal";
            this.terminalToolStripMenuItem.Click += new System.EventHandler(this.terminalToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.updateToolStripMenuItem.Text = "Calculated Attendance Record";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // sctMain
            // 
            this.sctMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sctMain.Location = new System.Drawing.Point(0, 24);
            this.sctMain.Name = "sctMain";
            // 
            // sctMain.Panel1
            // 
            this.sctMain.Panel1.AccessibleName = "pnlLeft";
            this.sctMain.Panel1.Controls.Add(this.btnConfiguration);
            this.sctMain.Panel1.Controls.Add(this.btnReprocess);
            this.sctMain.Panel1.Controls.Add(this.btnAttTest);
            this.sctMain.Panel1.Controls.Add(this.btnUser);
            this.sctMain.Panel1.Controls.Add(this.btnAttendance);
            this.sctMain.Panel1.Controls.Add(this.btnWorkingCalendar);
            this.sctMain.Panel1.Controls.Add(this.btnTerminal);
            this.sctMain.Panel1.Controls.Add(this.btnEmployee);
            this.sctMain.Panel1.Controls.Add(this.btnDepartment);
            this.sctMain.Panel1.Controls.Add(this.btnCompany);
            // 
            // sctMain.Panel2
            // 
            this.sctMain.Panel2.AccessibleName = "pnlMain";
            this.sctMain.Size = new System.Drawing.Size(1016, 662);
            this.sctMain.SplitterDistance = 167;
            this.sctMain.TabIndex = 1;
            // 
            // btnAttTest
            // 
            this.btnAttTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttTest.ForeColor = System.Drawing.Color.Red;
            this.btnAttTest.Location = new System.Drawing.Point(2, 609);
            this.btnAttTest.Name = "btnAttTest";
            this.btnAttTest.Size = new System.Drawing.Size(163, 50);
            this.btnAttTest.TabIndex = 7;
            this.btnAttTest.Text = "ATT TEST";
            this.btnAttTest.UseVisualStyleBackColor = true;
            this.btnAttTest.Click += new System.EventHandler(this.btnAttTest_Click);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Image = global::FaceIDAppVBEta.Properties.Resources.Configure;
            this.btnConfiguration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguration.Location = new System.Drawing.Point(2, 451);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(163, 50);
            this.btnConfiguration.TabIndex = 9;
            this.btnConfiguration.Text = "Configuration";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            // 
            // btnReprocess
            // 
            this.btnReprocess.Image = global::FaceIDAppVBEta.Properties.Resources.Refresh;
            this.btnReprocess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprocess.Location = new System.Drawing.Point(2, 395);
            this.btnReprocess.Name = "btnReprocess";
            this.btnReprocess.Size = new System.Drawing.Size(163, 50);
            this.btnReprocess.TabIndex = 8;
            this.btnReprocess.Text = "Reprocess";
            this.btnReprocess.UseVisualStyleBackColor = true;
            this.btnReprocess.Click += new System.EventHandler(this.btnReprocess_Click);
            // 
            // btnUser
            // 
            this.btnUser.Image = global::FaceIDAppVBEta.Properties.Resources.People;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(2, 339);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(163, 50);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "User Management";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Image = global::FaceIDAppVBEta.Properties.Resources.Chart_02;
            this.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.Location = new System.Drawing.Point(2, 283);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(163, 50);
            this.btnAttendance.TabIndex = 5;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnWorkingCalendar
            // 
            this.btnWorkingCalendar.Image = global::FaceIDAppVBEta.Properties.Resources.Calendar;
            this.btnWorkingCalendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWorkingCalendar.Location = new System.Drawing.Point(2, 227);
            this.btnWorkingCalendar.Name = "btnWorkingCalendar";
            this.btnWorkingCalendar.Size = new System.Drawing.Size(163, 50);
            this.btnWorkingCalendar.TabIndex = 4;
            this.btnWorkingCalendar.Text = "Working Calendar";
            this.btnWorkingCalendar.UseVisualStyleBackColor = true;
            this.btnWorkingCalendar.Click += new System.EventHandler(this.btnWorkingCalendar_Click);
            // 
            // btnTerminal
            // 
            this.btnTerminal.Image = global::FaceIDAppVBEta.Properties.Resources.Calculator;
            this.btnTerminal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminal.Location = new System.Drawing.Point(2, 171);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(163, 50);
            this.btnTerminal.TabIndex = 3;
            this.btnTerminal.Text = "Terminal";
            this.btnTerminal.UseVisualStyleBackColor = true;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Image = global::FaceIDAppVBEta.Properties.Resources.UserCard;
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployee.Location = new System.Drawing.Point(2, 115);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(163, 50);
            this.btnEmployee.TabIndex = 2;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Image = global::FaceIDAppVBEta.Properties.Resources.Catalog;
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.Location = new System.Drawing.Point(2, 59);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(163, 50);
            this.btnDepartment.TabIndex = 1;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.Image = global::FaceIDAppVBEta.Properties.Resources.Department;
            this.btnCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompany.Location = new System.Drawing.Point(2, 3);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(163, 50);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.Text = "Company";
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1016, 686);
            this.Controls.Add(this.sctMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaceID Application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.sctMain.Panel1.ResumeLayout(false);
            this.sctMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminalToolStripMenuItem;
        private System.Windows.Forms.SplitContainer sctMain;
        private System.Windows.Forms.Button btnWorkingCalendar;
        private System.Windows.Forms.Button btnTerminal;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.Button btnAttTest;
        private System.Windows.Forms.Button btnReprocess;
        private System.Windows.Forms.Button btnConfiguration;

    }
}
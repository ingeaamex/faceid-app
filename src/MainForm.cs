using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucCompanyForm());
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucDepartmentForm());
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucEmployeeForm());
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucTerminalForm());
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucCompanyForm());
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucDepartmentForm());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucEmployeeForm());
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucTerminalForm());
        }

        private void btnWorkingCalendar_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucWorkingCalendar());
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucAttendance());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucUserManagment());
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucConfigForm());
        }
    }
}

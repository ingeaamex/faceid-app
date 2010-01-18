using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class ucAttendanceReport : UserControl
    {
        public ucAttendanceReport()
        {
            InitializeComponent();
        }

        private void btnPayrollExport_Click(object sender, EventArgs e)
        {
            new frmPayrollExport().Show();
        }
    }
}

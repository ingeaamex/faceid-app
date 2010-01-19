using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class frmPayrollExport : Form
    {
        public frmPayrollExport(DataTable dtAttendanceReport, DateTime dtFrom, DateTime dtTo)
        {
            InitializeComponent();

            MessageBox.Show("This function has not been implemented yet");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class ucWorkingCalendar : UserControl
    {
        private IDataController _dtCtrl = LocalDataController.Instance;

        public ucWorkingCalendar()
        {
            InitializeComponent();

            BindWorkingCalendar();
        }

        private void BindWorkingCalendar()
        {
            dgvWorkingCalendar.AutoGenerateColumns = false;
            dgvWorkingCalendar.DataSource = _dtCtrl.GetWorkingCalendarList();
        }

        private void btnAddWorkingCalendar_Click(object sender, EventArgs e)
        {
            new frmAddUpdateWorkingCalendar().ShowDialog(this);
        }
    }
}

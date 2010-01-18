using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class ucWorkingCalendar : UserControl
    {
        public ucWorkingCalendar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAddUpdateWorkingCalendar().Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FaceIDAppVBEta
{
    public partial class ucReprocess : UserControl
    {
        public ucReprocess()
        {
            InitializeComponent();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            new frmReprocessStatus().ShowDialog(this);
        }
    }
}

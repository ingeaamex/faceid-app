using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta
{
    public partial class frmAddUpdateHoliday : Form
    {
        private Holiday _holiday;

        public frmAddUpdateHoliday(ref Holiday holiday)
        {
            InitializeComponent();

            _holiday = holiday;
            lblDate.Text = holiday.Date.Day + "/" + holiday.Date.Month;
            txtDescription.Text = holiday.Description;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _holiday.Description = txtDescription.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _holiday = null;
            this.Close();
        }
    }
}

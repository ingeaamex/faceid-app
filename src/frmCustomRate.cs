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
    public partial class frmCustomRate : Form
    {
        private ICustomeRateCaller _caller = null;

        public frmCustomRate(ICustomeRateCaller caller)
        {
            _caller = caller;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _caller.ImplementNewRate(null);
            this.Close();
        }

        private void btnAddRate_Click(object sender, EventArgs e)
        {
            if (ValidateRate() == false)
                return;

            double rate = Convert.ToDouble(txtRate.Text);

            Rate newRate = new Rate(0, "");
            newRate.Value = rate;
            newRate.Name = rate + "%";

            _caller.ImplementNewRate(newRate);
            this.Close();
        }

        private bool ValidateRate()
        {
            try
            {
                Convert.ToDouble(txtRate.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("Rate must be a number (without %). Please try again.");
                return false;
            }

            return true;
        }
    }
}

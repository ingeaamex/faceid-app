using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta.Class;
using FaceIDAppVBEta.Data;

namespace FaceIDAppVBEta
{
    public partial class frmAddUpdateShift : Form
    {
        private IDataController _dtCtrl;
        private int _shiftID = -1;

        public frmAddUpdateShift() : this(-1) { }

        public frmAddUpdateShift(int shiftID)
        {
            _dtCtrl = Properties.Settings.Default.IsClient ? RemoteDataController.Instance : LocalDataController.Instance;

            InitializeComponent();

            _shiftID = shiftID;
            SetState(shiftID);
        }

        private void SetState(int shiftID)
        {
            if (shiftID <= 0) //add
            {
                lblAddUpdateShift.Text = "Add Shift";
                this.Text = "Add Shift";
                dtpFrom.Value = DateTime.Today;
                dtpTo.Value = DateTime.Today;
            }
            else
            {
                lblAddUpdateShift.Text = "Update Shift";
                this.Text = "Update Shift";

                Shift shift = _dtCtrl.GetShift(shiftID);
                if (shift == null)
                {
                    MessageBox.Show("Shift not found or has been deleted.");
                    this.Close();
                }
                dtpFrom.Value = shift.From;
                dtpTo.Value = shift.To;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Shift shift = null;
            if (_shiftID <= 0)
            {
                shift = new Shift();
                MessageBox.Show("Shift added.");
            }
            else
            {
                shift = _dtCtrl.GetShift(_shiftID);
                MessageBox.Show("Shift updated.");
            }

            shift.From = dtpFrom.Value;
            shift.To = dtpTo.Value;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(Util.ConfirmCloseForm())
                this.Close();
        }

        private void dtpRegularWorkFrom_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void dtpRegularWorkTo_ValueChanged(object sender, EventArgs e)
        {
            CheckWorkingHour();
        }

        private void CheckWorkingHour()
        {
            DateTime dtFrom = dtpFrom.Value;

            DateTime dtTo = dtpTo.Value;

            lblNextDay.Visible = (dtFrom > dtTo);
        }
    }
}

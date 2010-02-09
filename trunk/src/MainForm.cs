using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using FaceIDAppVBEta.Data;
using System.Runtime.Remoting;
using FaceIDAppVBEta.Class;
using System.Data.OleDb;

namespace FaceIDAppVBEta
{
    public partial class MainForm : Form, IUserLoginCaller
    {
        private Color _originForeColor;

        public MainForm()
        {
            InitializeComponent();
            _originForeColor = btnCompany.ForeColor;
            //client only
            //new frmServerConnect().ShowDialog(this);

            VerifyUser();

            //server only
            RegisterChannel();
            RegisterService();
        }

        private void VerifyUser()
        {
            try
            {
                IDataController dtCtrl = LocalDataController.Instance;
                if (dtCtrl.GetFaceIDUserList().Count != 0)
                {
                    new frmUserLogin(this).ShowDialog(this);
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("Cannot connect to Database. Please check then try again.");
                Application.Exit();
            }
        }

        //http://msdn.microsoft.com/en-us/library/5dxse167%28VS.71%29.aspx
        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;

            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = 9999;

            ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
        }

        private void RegisterService()
        {
            Type registeredType = typeof(LocalDataController);
            RemotingConfiguration.RegisterWellKnownServiceType(registeredType, "DataController", WellKnownObjectMode.Singleton);
        }

        private void RequestService()
        {
            Type lookupType = typeof(IDataController);
            IDataController dtCtrl = (IDataController)Activator.GetObject(lookupType, "tcp://localhost:9999/DataController");

            dtCtrl.AddHoliday(new Holiday());
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

            UnHighlightAllButtons();
            HighlightButton(btnCompany);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucDepartmentForm());

            UnHighlightAllButtons();
            HighlightButton(btnDepartment);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucEmployeeForm());

            UnHighlightAllButtons();
            HighlightButton(btnEmployee);
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucTerminalForm());

            UnHighlightAllButtons();
            HighlightButton(btnTerminal);
        }

        private void btnWorkingCalendar_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucWorkingCalendar());

            UnHighlightAllButtons();
            HighlightButton(btnWorkingCalendar);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucAttendance(0));

            UnHighlightAllButtons();
            HighlightButton(btnAttendance);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucUserManagment());

            UnHighlightAllButtons();
            HighlightButton(btnUser);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucConfigForm());

            UnHighlightAllButtons();
            HighlightButton(btnExport);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FaceIDAppVBEta.Data.LocalDataController dtCtrl = FaceIDAppVBEta.Data.LocalDataController.Instance;
            //dtCtrl.CalculateAttendanceRecord();
        }

        private void btnAttTest_Click(object sender, EventArgs e)
        {
            new FaceIDApp.Test().Show();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucReprocess());

            UnHighlightAllButtons();
            HighlightButton(btnReprocess);
        }

        #region IUserLoginCaller Members

        public void SetUserAccess(FaceIDUser user)
        {
            if (user != null) //not master
            {
                btnAttendance.Enabled = user.AttendanceManagementAccess;
                btnCompany.Enabled = user.CompanyDepartmentManagementAccess;
                btnDepartment.Enabled = user.CompanyDepartmentManagementAccess;
                btnEmployee.Enabled = user.EmployeeManagementAccess;
                btnReprocess.Enabled = user.AttendanceManagementAccess;
                btnTerminal.Enabled = user.TerminalManagementAccess;
                btnUser.Enabled = user.UserManagementAccess;
                btnWorkingCalendar.Enabled = user.WorkingCalendarManagementAccess;
            }
        }

        #endregion

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucSetting());

            UnHighlightAllButtons();
            HighlightButton(btnSetting);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucAttendance(1));

            UnHighlightAllButtons();
            HighlightButton(btnExport);
        }

        private void HighlightButton(Button btn)
        {
            btn.ForeColor = Color.Red;
        }

        private void UnHighlightAllButtons()
        {
            btnCompany.ForeColor = _originForeColor;
            btnDepartment.ForeColor = _originForeColor;
            btnWorkingCalendar.ForeColor = _originForeColor;
            btnTerminal.ForeColor = _originForeColor;
            btnEmployee.ForeColor = _originForeColor;
            btnAttendance.ForeColor = _originForeColor;
            btnExport.ForeColor = _originForeColor;
            btnReprocess.ForeColor = _originForeColor;
            btnUser.ForeColor = _originForeColor;
            btnSetting.ForeColor = _originForeColor;
        }
    }
}

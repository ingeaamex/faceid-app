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
        public MainForm()
        {
            InitializeComponent();

            VerifyUser();

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

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaceIDAppVBEta.Data.LocalDataController dtCtrl = FaceIDAppVBEta.Data.LocalDataController.Instance;
            dtCtrl.CalculateAttendanceRecord();
        }

        private void btnAttTest_Click(object sender, EventArgs e)
        {
            new FaceIDApp.Test().Show();
        }

        private void btnReprocess_Click(object sender, EventArgs e)
        {
            sctMain.Panel2.Controls.Clear();
            sctMain.Panel2.Controls.Add(new ucReprocess());
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
            sctMain.Panel2.Controls.Add(new ucBackup());
        }
    }
}

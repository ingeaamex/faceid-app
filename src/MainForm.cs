﻿using System;
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

            if (Properties.Settings.Default.IsClient)
            {
                //TODO remove later
                RegisterChannel();
                RegisterService();

                //client only
                string serverIP = Properties.Settings.Default.ServerIP;
                if (frmServerConnect.IsServerRunning(serverIP) == false)
                    new frmServerConnect().ShowDialog(this);
            }
            else
            {
                //server only
                RegisterChannel();
                RegisterService();
            }

            if (VerifyUser() == false)
                Application.Exit();

            //TODO do tasks
        }

        private bool VerifyUser()
        {
            try
            {
                IDataController dtCtrl = LocalDataController.Instance;
                if (dtCtrl.GetFaceIDUserList().Count != 0)
                {
                    new frmUserLogin(this).ShowDialog(this);
                }

                return true;
            }
            catch (OleDbException)
            {
                MessageBox.Show("Cannot connect to Database. Please check then try again.");
                return false;
            }
        }

        //http://msdn.microsoft.com/en-us/library/5dxse167%28VS.71%29.aspx
        private void RegisterChannel()
        {
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;

            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = Properties.Settings.Default.ServerPort;

            ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
        }

        private void RegisterService()
        {
            string serviceName = Properties.Settings.Default.ServiceName;
            Type registeredType = typeof(LocalDataController);
            RemotingConfiguration.RegisterWellKnownServiceType(registeredType, serviceName, WellKnownObjectMode.Singleton);
        }

        //private void RequestService()
        //{
        //    Type lookupType = typeof(IDataController);
        //    IDataController dtCtrl = (IDataController)Activator.GetObject(lookupType, "tcp://localhost:9999/DataController");

        //    dtCtrl.AddHoliday(new Holiday());
        //}

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

        private void btnSetting_Click(object sender, EventArgs e)
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

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmHelpContents_Click(object sender, EventArgs e)
        {
            //TODO open CHM file
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            //TODO show frmAbout
            new frmAbout().ShowDialog(this);
        }
    }
}

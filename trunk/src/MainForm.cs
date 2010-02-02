using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using FaceIDAppVBEta.Class;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using FaceIDAppVBEta.Data;
using System.Collections;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

namespace FaceIDAppVBEta
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            RegisterChannel();
            RegisterService();
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

        private void BeClient()
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
    }
}

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

            SetSecurity();

            BeServer();

            //BeClient();
        }

        private void SetSecurity()
        {
            //BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            //serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            ////TcpChannel tcpChannel = new TcpChannel(9998);
            ////ChannelServices.RegisterChannel(tcpChannel, false);

            //BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            //IDictionary props = new Hashtable();
            //props["port"] = 9998;

            //HttpChannel chan = new HttpChannel(props, clientProv, serverProv);
            //ChannelServices.RegisterChannel(chan, false);

            SoapServerFormatterSinkProvider provider = new SoapServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;
            IDictionary props = new Hashtable();
            props["port"] = 9998;
            ChannelServices.RegisterChannel(new TcpChannel(props, null, provider), false);
        }

        private void BeServer()
        {           
            //ChannelServices.RegisterChannel(new TcpChannel(50050), false);

            //// Register an object created by the server
            //LocalDataController dtCtrl = new LocalDataController();

            //ObjRef refGreeter = RemotingServices.Marshal(dtCtrl, "Greeter");

            //LocalDataController dtCtrl2 = (LocalDataController)Activator.GetObject(
            //    typeof(LocalDataController), "tcp://localhost:50050/Greeter");

            //dtCtrl2.AddHoliday(new Holiday());

            Type registeredType = typeof(LocalDataController);
            RemotingConfiguration.RegisterWellKnownServiceType(registeredType, "DataController", WellKnownObjectMode.SingleCall);
        }

        private void BeClient()
        {
            //TcpChannel tcpChannel = new TcpChannel();
            //ChannelServices.RegisterChannel(tcpChannel, false);

            Type lookupType = typeof(IDataController);
            IDataController dtCtrl = (IDataController)Activator.GetObject(lookupType, "http://localhost:9998/DataController");

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

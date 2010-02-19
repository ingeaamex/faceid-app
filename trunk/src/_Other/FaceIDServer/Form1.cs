using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceIDAppVBEta;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using FaceIDAppVBEta.Data;

namespace FaceIDServer
{
    public partial class Form1 : Form
    {
        private TcpChannel _channel = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterChannel();
                RegisterService();
                MessageBox.Show("Server started.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":" + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                UnregisterService();
                MessageBox.Show("Server stopped.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ":" + ex.StackTrace);
            }
        }

        private void RegisterChannel()
        {

            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;

            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = 9999;//Properties.Settings.Default.ServerPort;

            _channel = new TcpChannel(props, null, provider);

            ChannelServices.RegisterChannel(_channel, false);
        }

        private void RegisterService()
        {
            string serviceName = "DataController"; //Properties.Settings.Default.ServiceName
            Type registeredType = typeof(LocalDataController);
            RemotingConfiguration.RegisterWellKnownServiceType(registeredType, serviceName, WellKnownObjectMode.Singleton);
        }

        private void UnregisterService()
        {
            try
            {
                ChannelServices.UnregisterChannel(_channel);
            }
            catch { }
        }
    }
}

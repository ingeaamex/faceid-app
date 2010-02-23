using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Remoting.Channels;
using FaceIDAppVBEta.Data;
using FaceIDAppVBEta.Class;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace FaceIDAppVBEta
{
    public partial class frmServerConnect : Form
    {
        public frmServerConnect()
        {
            InitializeComponent();

            //try
            //{
            //    IsServerRunning(Properties.Settings.Default.ServerIP);
            //    this.Close();
            //}
            //catch { }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string computerName = txtServerComputerName.Text.Trim();
                string ipAddress = ipcServerIPAdress.Text;

                if (computerName != "")
                    ipAddress = GetIPAddress(computerName);

                if (IsServerRunning(ipAddress))
                {
                    SaveServerIPAddress(ipAddress);
                    this.Close();
                }
                else
                {
                    throw new Exception("Server is not running or being blocked.");
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ex);
            }
        }

        public static bool IsServerRunning(string ipAddress)
        {
            if (ipAddress.Trim() == "") return false;

            bool isRunning = false;

            //check ip address
            System.Net.NetworkInformation.Ping pinger = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingReply = pinger.Send(ipAddress);

            if (pingReply.Status != System.Net.NetworkInformation.IPStatus.Success)
            {
                throw new Exception("Server could not be connected.");
            }

            //check service
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = TypeFilterLevel.Full;

            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = Properties.Settings.Default.TestPort;
            props["name"] = "Test" + DateTime.Now.Ticks.ToString();

            TcpChannel channel = new TcpChannel(props, null, provider);

            ChannelServices.RegisterChannel(channel, false);

            int serverPort = Properties.Settings.Default.ServerPort;
            string serviceName = Properties.Settings.Default.ServiceName;

            Type lookupType = typeof(IDataController);
            IDataController serv = (IDataController)Activator.GetObject(lookupType, string.Format("tcp://{0}:{1}/{2}", ipAddress, serverPort, serviceName));

            try
            {
                serv.TestDataController(new Holiday());
                isRunning = true;
            }
            catch
            {
                isRunning = false;
            }
            finally
            {
                ChannelServices.UnregisterChannel(channel);
            }

            return isRunning;
        }

        //copied from http://www.devasp.net/net/articles/display/686.html
        private string GetIPAddress(string computerName)
        {
            IPHostEntry ipHostEntry = Dns.GetHostEntry(computerName);

            if (ipHostEntry.AddressList.Length == 0)
                throw new Exception("Computer " + computerName + " could not be connected.");

            return ipHostEntry.AddressList[0].ToString();
        }

        private void SaveServerIPAddress(string ipAddress)
        {
            MessageBox.Show(Properties.Settings.Default.ServerIP);

            Properties.Settings.Default.ServerIP = ipAddress;
            Properties.Settings.Default.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using FaceIDAppVBEta.Class;

namespace FaceIDAppVBEta.Data
{
    class RemoteDataController
    {
        private static TcpChannel _channel = null;
        private static IDataController _dtCtrl = null;

        public static IDataController Instance
        {
            get
            {
                if (_dtCtrl == null)
                {
                    BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                    provider.TypeFilterLevel = TypeFilterLevel.Full;

                    // Creating the IDictionary to set the port on the channel instance.
                    IDictionary props = new Hashtable();
                    props["port"] = Properties.Settings.Default.ClientPort;
                    props["name"] = "Remote" + DateTime.Now.Ticks.ToString();

                    _channel = new TcpChannel(props, null, provider);

                    ChannelServices.RegisterChannel(_channel, false);

                    string serverIP = Properties.Settings.Default.ServerIP;
                    int serverPort = Properties.Settings.Default.ServerPort;
                    string serviceName = Properties.Settings.Default.ServiceName;

                    Type lookupType = typeof(IDataController);
                    _dtCtrl = (IDataController)Activator.GetObject(lookupType, string.Format("tcp://{0}:{1}/{2}", serverIP, serverPort, serviceName)); //ex: tcp://10.0.0.5:9999/DataController

                    _dtCtrl.TestDataController(new Holiday());
                }

                _dtCtrl.RefreshConnection();
                return _dtCtrl;
            }
        }

        ~RemoteDataController()
        {
            try
            {
                ChannelServices.UnregisterChannel(_channel);
            }
            catch { }

        }
    }
}

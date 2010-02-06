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

        public static IDataController Instance
        {
            get
            {
                BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
                provider.TypeFilterLevel = TypeFilterLevel.Full;

                // Creating the IDictionary to set the port on the channel instance.
                IDictionary props = new Hashtable();
                props["port"] = 29999;
                props["name"] = "Remote" + DateTime.Now.Ticks.ToString();

                _channel = new TcpChannel(props, null, provider);

                ChannelServices.RegisterChannel(_channel, false);

                Type lookupType = typeof(IDataController);
                IDataController dtCtrl = (IDataController)Activator.GetObject(lookupType, "tcp://localhost:9999/DataController");

                dtCtrl.TestDataController(new Holiday());

                return dtCtrl;
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

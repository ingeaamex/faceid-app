using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace FaceIDAppVBEta.Data
{
    class RemoteDataController
    {
        public static IDataController Instance
        {
            get
            {
                ChannelServices.RegisterChannel(new TcpChannel(0), false);

                Type lookupType = typeof(IDataController);
                IDataController dtCtrl = (IDataController)Activator.GetObject(lookupType, "tcp://localhost:9999/DataController");

                return dtCtrl;
            }
        }
    }
}

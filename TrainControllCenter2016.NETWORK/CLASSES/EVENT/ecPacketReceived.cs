using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainControllCenter2016.NETWORK.CLASSES.EVENT
{
    public class ecPacketReceived : EventArgs
    {
        private byte[] _lvPacket = null;

        public byte[] LvPacket
        {
            get { return _lvPacket; }
            set { _lvPacket = value; }
        }

        private ecPacketReceived()
        {

        }

        public ecPacketReceived(byte[] packet)
        {

        }
    }
}

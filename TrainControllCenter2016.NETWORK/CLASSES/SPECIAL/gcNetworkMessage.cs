using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainControllCenter2016.NETWORK.CLASSES.SPECIAL
{
    public class gcNetworkMessage
    {
        private DateTime _LvTimeStamp = new DateTime();
        private bool _IsAnswer = new bool();
        Byte[] _ByteMessage = null;

        public DateTime LvTimeStamp
        {
            get { return _LvTimeStamp; }
            set { _LvTimeStamp = value; }
        }

        public bool IsAnswer
        {
            set { _IsAnswer = value; }
            get { return _IsAnswer; }
        }

        public byte[] ByteMessage
        {
            get { return _ByteMessage; }
            set { _ByteMessage = value; }
        }
    }
}

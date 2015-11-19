using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainControllCenter2016.NETWORK.CLASSES.SPECIAL
{
    public class gcNetworkMessage
    {
        private DateTime lvTimeStamp = new DateTime();
        private bool isAnswer = new bool();

        public DateTime LvTimeStamp
        {
            get { return lvTimeStamp; }
            set { lvTimeStamp = value; }
        }

        public bool IsAnswer
        {
            get { return isAnswer; }
        }
    }
}

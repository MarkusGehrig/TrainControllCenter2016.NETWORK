using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainControllCenter2016.NETWORK.CLASSES.MAIN;
using TrainControllCenter2016.NETWORK.CLASSES.EVENT;
using TrainControllCenter2016.NETWORK.CLASSES.SPECIAL;
using System.Net;

namespace TrainControllCenter2016.NETWORK.CLASSES.MAIN
{
    public class gcTrainControllerNetworkMain
    {
        //Instances of the sender and the receiver for bidirectional communication
        gcTrainControllerNetworkReceiver Receiver = null;
        gcTrainControllerNetworkSender Sender = null;

        // For History which Packet where Received and Send.
        List<List<gcNetworkMessage>> NetworkMessagePackets = new List<List<gcNetworkMessage>>();


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IP">IP of the Host (Central Station)</param>
        public gcTrainControllerNetworkMain(IPAddress IP)
        {
            Receiver = new gcTrainControllerNetworkReceiver(IP);
            Receiver.RaiseEventPacketReceived += Receiver_RaiseEventPacketReceived;
            Sender = new gcTrainControllerNetworkSender();
        }

        /// <summary>
        /// Constructor with other port than standard
        /// </summary>
        /// <param name="IP">IP of the Client (Cnetral Station)</param>
        /// <param name="port">IP of the Client (Your Computer)</param>
        public gcTrainControllerNetworkMain(IPAddress IP, int port)
        {
            Receiver = new gcTrainControllerNetworkReceiver(port, IP);
            Receiver.RaiseEventPacketReceived += Receiver_RaiseEventPacketReceived;
            Sender = new gcTrainControllerNetworkSender(port);        
        }

        private void Receiver_RaiseEventPacketReceived(object sender, ecPacketReceived e)
        {
             
        }

        private void ipv4Reader()
        {

        }

        private void ipv6Reader()
        {

        }
    }
}

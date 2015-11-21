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
        private gcTrainControllerNetworkReceiver Receiver = null;
        private gcTrainControllerNetworkSender Sender = null;

        // For History which Packet where Received and Send.
        private List<List<gcNetworkMessage>> _NetworkMessagePackets = new List<List<gcNetworkMessage>>();

        /// <summary>
        /// Getter NetworkMessagePackets
        /// </summary>
        public List<List<gcNetworkMessage>> NetworkMessagePackets
        {
            get { return _NetworkMessagePackets; }
        }


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
            gcNetworkMessage netMessage = new gcNetworkMessage();
            netMessage.LvTimeStamp = DateTime.Now;
            netMessage.ByteMessage = e.LvPacket;
            
            if (e.LvPacket[3] == 0x01)
            {
                netMessage.IsAnswer = true;
            }
            else
            {
                netMessage.IsAnswer = false;
                sendAnswer(e.LvPacket);
            }
        }

        private void ipv4Reader()
        {

        }

        private void sendAnswer(byte[] answer)
        {
            byte[] lvPacketToSend = answer;
            lvPacketToSend[3] = 0x01;

            Sender.send(lvPacketToSend);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrainControllCenter2016.NETWORK.CLASSES.EVENT;

namespace TrainControllCenter2016.NETWORK.CLASSES.MAIN
{
    public class gcTrainControllerNetworkReceiver
    {
        public event EventHandler<ecPacketReceived> RaiseEventPacketReceived;


        /// <summary>
        /// Default Port of the CS
        /// </summary>
        private int gvDefaultPortReceiver = 15730;
        /// <summary>
        /// Seted Port of the CS
        /// </summary>
        private int gvSetedPortReceiver = 0;
        /// <summary>
        /// UdpClient Socket for Receiver
        /// </summary>
        private UdpClient goUdpClientReceiver = null;

        private IPEndPoint goIPEndPointReceiver = null;

        private IPAddress goIPAdressHost = null;

        private bool gvThreadActive = true;

        private System.Threading.Thread ReceiverThread = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public gcTrainControllerNetworkReceiver(IPAddress IP)
        {
            gvSetedPortReceiver = gvDefaultPortReceiver;
            createUdpClientReceiver(gvDefaultPortReceiver);
            goIPAdressHost = IP;

            ReceiverThread = new System.Threading.Thread(checkEndPoint);
        }

        /// <summary>
        /// Constructor with a other Port than the Default Port
        /// </summary>
        /// <param name="port">Port of the Receiver</param>
        public gcTrainControllerNetworkReceiver(int port, IPAddress IP)
        {
            gvSetedPortReceiver = port;
            createUdpClientReceiver(gvSetedPortReceiver);
            goIPAdressHost = IP;

            ReceiverThread = new System.Threading.Thread(checkEndPoint);
        }

        ~gcTrainControllerNetworkReceiver()
        {
            gvThreadActive = false;
        }

        private void createUdpClientReceiver(int port)
        {
            goUdpClientReceiver = new UdpClient(port);
        }

        private void createIPEndPoint(IPAddress IP)
        {
            goIPEndPointReceiver = new IPEndPoint(IP, gvSetedPortReceiver);
        }



        public void checkEndPoint()
        {
            for ( ; ; )
            {
                if (goUdpClientReceiver.Available > 0)
                {
                    for (int i = 0; i < goUdpClientReceiver.Available; i++)
                    {
                        RaiseEventPacketReceived(goUdpClientReceiver, new ecPacketReceived(receiver()));
                    }
                }

                if (gvThreadActive == false)
                {
                    break;
                }
            }
        }

        private byte[] receiver()
        {
            return goUdpClientReceiver.Receive(ref goIPEndPointReceiver);
        }
    }
}

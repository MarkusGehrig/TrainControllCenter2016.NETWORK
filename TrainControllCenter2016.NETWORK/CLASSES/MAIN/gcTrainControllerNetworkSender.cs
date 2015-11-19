using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrainControllCenter2016.NETWORK.CLASSES.MAIN
{
    public class gcTrainControllerNetworkSender
    {
        /// <summary>
        /// Default Port of the CS
        /// </summary>
        private int gvDefaultPortSender = 15731;
        /// <summary>
        /// Seted Port of the CS
        /// </summary>
        private int gvSetedPortSender = 0;
        /// <summary>
        /// UdpClient Socket for Sender
        /// </summary>
        private UdpClient goUdpClientSender = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public gcTrainControllerNetworkSender()
        {
            gvSetedPortSender = gvDefaultPortSender;
            createUdpClientSender(gvDefaultPortSender);
        }

        /// <summary>
        /// Constructor with a other Port than the Default Port
        /// </summary>
        /// <param name="port">Port of the Receiver</param>
        public gcTrainControllerNetworkSender(int port)
        {
            gvSetedPortSender = port;
            createUdpClientSender(gvSetedPortSender);
        }

        private void createUdpClientSender(int port)
        {
            goUdpClientSender = new UdpClient(port);
        }

        public void send(byte[] Message)
        {
            goUdpClientSender.Send(Message, 13);
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTcpListener
{
    public class Reponse
    {
        public void RetourneReponse(string messageARetourner, NetworkStream stream)
        {
            byte[] reponse = System.Text.Encoding.ASCII.GetBytes(messageARetourner);
            stream.Write(reponse, 0, reponse.Length);
        }
    }
}

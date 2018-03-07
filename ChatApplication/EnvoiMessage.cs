using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.Mail;

using System.Net.Security;


namespace ChatApplication
{
    public class EnvoiMessage
    {
        public string Connect(String server, String message)
        {
            string msgRecu = string.Empty;
            try
            {
                // Crée un tcpClient
                //connecté à la meme adresse et au meme port que le server spécifié
                int port = 1234;
                TcpClient client = new TcpClient(server, port);

                // Traduit le message ascii envoyé dans un Byte tableau
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Crée un NetworkStream pour lire et écrire 

                NetworkStream stream = client.GetStream();

                // Envoi le message au serveur tcp connecté
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Recois la réponse du serveur

                // Buffer pour stocker la réponse du serveur
                data = new Byte[256];

                // string pour stocker la réponse du serveur en ascii
                String responseData = String.Empty;

                // lis la premiere "livraison" du serveur
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                msgRecu = responseData;
                Console.WriteLine("Received: {0}", responseData);

                // Ferme tout
                stream.Close();
                client.Close();


            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            return msgRecu;
        }
    }
}

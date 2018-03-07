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
    class MyTcpListener
    {
        public static void Main()
        {
            User user = new User();
            ConnexionBD connexionBD = new ConnexionBD();
            while (true)
            {
                TcpListener server = null;
                try
                {
                    //Attribution du port et de l'adresse IP
                    int port = 1234;
                    IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                    //Attribution du port et de l'adresse au TcpListener
                    server = new TcpListener(localAddr, port);

                    //On commence à écouter pour des requêtes de clients
                    server.Start();

                    //Buffer pour lire les données
                    //Buffer = zone mémoire de taille limitée servant à stocker des données (généralement de façon temporaire)
                    Byte[] bytes = new byte[256];
                    string data = null;

                    //On entre dans la boucle d'écoute
                    while (true)
                    {
                        Console.WriteLine("En attente de connexion...");

                        //Permet d'accepter les requetes
                        TcpClient client = server.AcceptTcpClient();
                        Console.WriteLine("Connecté!");

                        data = null;

                        //NetworkStream permet de recevoir et d'envoyer des données
                        //L'utilisation de la méthode GetStream() retourne le NetworkStream qui a été utilisé par le TcpClient pour envoyé et recevoir des données
                        NetworkStream stream = client.GetStream();

                        int i;

                        //Boucle qui permet de recevoir toutes les données envoyées par le client
                        //.read(buffer, offset, size) stock les données dans le buffer, l'emplacement dans le buffer pour commencer le stockage de données, le nombre d'octets à lire à partir du networkStream
                        //Ici que je vais effectuer les actions sur les données recues
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            //Traduit les données de bytes en chaine ascii
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);
                            string[] SeparationSwitchDonnes = new string[data.Length];
                            SeparationSwitchDonnes[0] = data.Substring(0, 1);
                            SeparationSwitchDonnes[1] = data.Substring(1, data.Length-1);
                            
                            switch (SeparationSwitchDonnes[0])
                            {
                                //Enregistrement du profil
                                case "1":
                                    int h = 0;
                                    string[] dataUser = SeparationSwitchDonnes[1].Split(',');
                                    foreach(string donnee in dataUser)
                                    {
                                        dataUser[h] = donnee;
                                        h++;
                                    }
                                    user.Pseudo = dataUser[0];
                                    user.MotDePasse = dataUser[1];
                                    user.Nom = dataUser[2];
                                    user.Prenom = dataUser[3];
                                    user.Description = dataUser[4];

                                    connexionBD.ajoutUser(user);

                                    Console.WriteLine("Utilisateur {0} ajouté !", user.Pseudo);
                                    break;

                                    //A VERIFIER PK CELA NE FONCTIONNE PAS ???
                                    //Connexion
                                case "2":
                                    int j = 0;
                                    string[] dataConnexion = SeparationSwitchDonnes[1].Split(',');
                                    foreach(string donnee in dataConnexion)
                                    {
                                        dataConnexion[j] = donnee;
                                        j++;
                                    }
                                    user.Pseudo = dataConnexion[0];
                                    Console.WriteLine("X" + user.Pseudo + "X");

                                    string mdp = connexionBD.DemandeMotDePasse(user);


                                    byte[] mdpDemande = System.Text.Encoding.ASCII.GetBytes(mdp);
                                    stream.Write(mdpDemande, 0, mdp.Length);
                                    Console.WriteLine("Sent: {0}", mdpDemande);
                                    break;

                                default:
                                    break;
                            }
                            /*On met les données en maj pour les renvoyées (pour tester)
                            data = data.ToUpper();

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            //Renvoie une réponse
                            stream.Write(msg, 0, msg.Length);*/
                            
                        }

                        //Coupe et termine la connexion
                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    //Arrête d'écouter pour de nouveaux clients
                    server.Stop();
                }
            }
            
        }
    }
}

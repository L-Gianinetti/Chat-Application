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
                            SeparationSwitchDonnes[1] = data.Substring(1, data.Length - 1);

                            
                            
                            switch (SeparationSwitchDonnes[0])
                            {
                                #region Enregistrement du profil
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
                                #endregion
                                #region connexion
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

                                    string mdp = connexionBD.DemandeMotDePasse(user);


                                    byte[] mdpDemande = System.Text.Encoding.ASCII.GetBytes(mdp);
                                    stream.Write(mdpDemande, 0, mdpDemande.Length);
                                    Console.WriteLine("mdpDemande: {0}", mdpDemande);
                                    break;
                                #endregion
                                #region Chargement du profil
                                case "3":
                                    int k = 0;
                                    string[] dataProfil = SeparationSwitchDonnes[1].Split(',');
                                    foreach(string donnee in dataProfil)
                                    {
                                        dataProfil[k] = donnee;
                                        k++;
                                    }
                                    user.Pseudo = dataProfil[0];
                                    user.Nom = connexionBD.InfoProfilNom(user);
                                    user.Prenom = connexionBD.InfoProfilPrenom(user);
                                    user.Description = connexionBD.InfoProfilDescription(user);

                                    string infosProfil = user.Nom + "," + user.Prenom + "," + user.Description;
                                    byte[] infosProfilARetourner = System.Text.Encoding.ASCII.GetBytes(infosProfil);
                                    stream.Write(infosProfilARetourner, 0, infosProfilARetourner.Length);
                                    Console.WriteLine("Infos profil envoyées : {0}", infosProfilARetourner);

                                    break;
                                #endregion
                                #region Mise à jour du profil
                                case "4":
                                    int l = 0;
                                    string[] dataValidationProfil = SeparationSwitchDonnes[1].Split(',');
                                    foreach(string donnee in dataValidationProfil)
                                    {
                                        dataValidationProfil[l] = donnee;
                                        l++;
                                    }
                                    user.Pseudo = dataValidationProfil[0];
                                    user.Nom = dataValidationProfil[1];
                                    user.Prenom = dataValidationProfil[2];
                                    user.Description = dataValidationProfil[3];

                                    connexionBD.UpdateProfil(user);

                                    string updateReussie = "Reussie";
                                    byte[] reponse = System.Text.Encoding.ASCII.GetBytes(updateReussie);
                                    stream.Write(reponse, 0, reponse.Length);

                                    Console.WriteLine("Update du profil : {0}", updateReussie);

                                    break;
                                #endregion
                                #region Enregistrement pseudoExistant
                                case "5":
                                    user.Pseudo = SeparationSwitchDonnes[1];
                                    string pseudoTrouve = connexionBD.UserExistant(user);
                                    if(pseudoTrouve == "")
                                    {
                                        pseudoTrouve = "PseudoDisponible";
                                    }
                                    Console.WriteLine("Pseudo trouvé : {0}", pseudoTrouve);
                                    byte[] pseudoTrouveRetourne = System.Text.Encoding.ASCII.GetBytes(pseudoTrouve);
                                    stream.Write(pseudoTrouveRetourne, 0, pseudoTrouveRetourne.Length);
                                    break;
                                #endregion
                                #region ajoutContact
                                case "6":
                                    User userContact = new User();
                                    int n = 0;
                                    string[] dataAjoutContact = SeparationSwitchDonnes[1].Split(',');
                                    foreach(string donnee in dataAjoutContact)
                                    {
                                        dataAjoutContact[n] = donnee;
                                        n++;
                                    }
                                    userContact.Pseudo = dataAjoutContact[1];
                                    string pseudoActif = dataAjoutContact[0];
                                    user.Pseudo = pseudoActif;

                                    string contactTrouve = connexionBD.UserExistant(userContact);
                                    if (contactTrouve != "")
                                    {
                                        int idUser = connexionBD.getFkUser(user);
                                        int idUserContact = connexionBD.getFkUser(userContact);
                                        connexionBD.ajoutDemandeContact(user, idUser, idUserContact);
                                        Console.WriteLine("Demande de contact envoyée à {0}", contactTrouve);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Demande de contact n'a pas pu être envoyée, contact inexistant !");
                                    }
                                    byte[] contactTrouveRetourne = System.Text.Encoding.ASCII.GetBytes(contactTrouve);
                                    stream.Write(contactTrouveRetourne, 0, contactTrouveRetourne.Length);
                                    break;
                                #endregion
                                case "7":
                                    int o = 0;
                                    user.Pseudo = SeparationSwitchDonnes[1];
                                    int fkUser = connexionBD.getFkUser(user);
                                    string FKDemandesContacts = connexionBD.getDemandesFkUserContact(fkUser);
                                    FKDemandesContacts = FKDemandesContacts.Substring(0, FKDemandesContacts.Length-1);
                                    string[] fkSplit = FKDemandesContacts.Split(',');
                                    foreach(string donnee in fkSplit)
                                    {
                                        fkSplit[o] = donnee;
                                        fkSplit[o] = connexionBD.getUserPseudo(int.Parse(fkSplit[o]));
                                        i++;
                                    }
                                    //A TERMINER : AJOUTER LES PSEUDOS TROUVES DANS UNE CHAINE A ENVOYER
                                    //RECUPERER LA CHAINE, LA DECONCATENER ET L'AJOUTER A LA LISTE.
                                    Console.WriteLine("FKDemandesContacts : {0}", FKDemandesContacts);
                                    byte[] PseudoDemandesContactsRetourne = System.Text.Encoding.ASCII.GetBytes(FKDemandesContacts);
                                    stream.Write(PseudoDemandesContactsRetourne, 0, PseudoDemandesContactsRetourne.Length);
                                    
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

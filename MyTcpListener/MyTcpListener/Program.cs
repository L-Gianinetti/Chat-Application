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
            User contact = new User();
            
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

                        do
                        {
                            i = stream.Read(bytes, 0, bytes.Length);
                            data += bytes;
                        } while (stream.DataAvailable);
                       


                        //Traduit les données de bytes en chaine ascii
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        string[] SeparationSwitchDonnes = new string[data.Length];
                        SeparationSwitchDonnes[0] = data.Substring(0, 2);
                        SeparationSwitchDonnes[1] = data.Substring(2, data.Length - 2);
                        Console.WriteLine("SEPARATIONSWITCHDONNES[1]" + SeparationSwitchDonnes[1]);
                            
                            
                        switch (SeparationSwitchDonnes[0])
                        {
                            #region Enregistrement du profil
                            //Enregistrement du profil
                            case "01":
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
                            case "02":
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
                            case "03":
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
                            case "04":
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
                            case "05":
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
                            case "06":
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
                                    string envoyee = "Envoyee";
                                    string recue = "Recue";
                                    int idUserRecue = connexionBD.getFkUser(user);
                                    int idUserContact = connexionBD.getFkUser(userContact);
                                    connexionBD.ajoutDemandeContact(idUserRecue, idUserContact, envoyee);
                                    connexionBD.ajoutDemandeContact(idUserContact, idUserRecue, recue);
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
                            #region demandesEnvoyees
                            case "07":
                                //PRENDRE EN COMPTE LES DEMANDES RECUES/ENVOYEES, AJOUTER DS LA BD LES DEMANDES RECUES LORSQU'ON ENVOIE UNE DEMANDE
                                //REGLER LE PROBLEME D'ESPACEMENT DANS LA LISTE DES DEMANDES LORSQUE L'ON EN ENVOIE UNE
                                //NETTOYER TOUS LE CODE, REMPLACER LES NOMS DES VARIABLES ET LES NOMS DE METHODES POUR FACILITER LA LISIBILITE
                                //FAIRE LA DOCUMENTATION, REGROUPER LES DOCUMENTS DANS LA DOCUMENTATION DU PROJET.
                                int o = 0;
                                user.Pseudo = SeparationSwitchDonnes[1];
                                int fkUser = connexionBD.getFkUser(user);
                                string statutEnvoyee = "Envoyee";
                                string FKDemandesContacts = connexionBD.getDemandesFkUserContact(fkUser, statutEnvoyee);
                                if(FKDemandesContacts != string.Empty)
                                {
                                    FKDemandesContacts = FKDemandesContacts.Substring(0, FKDemandesContacts.Length - 1);
                                    string[] fkSplit = FKDemandesContacts.Split(',');
                                    string stringRetournee = string.Empty;
                                    foreach (string donnee in fkSplit)
                                    {
                                        fkSplit[o] = donnee;
                                        fkSplit[o] = connexionBD.getUserPseudo(int.Parse(fkSplit[o]));
                                        stringRetournee += fkSplit[o] + ",";
                                        Console.WriteLine("fkSplit : {0}", fkSplit[o]);
                                        o++;
                                    }

                                    stringRetournee.Substring(0, stringRetournee.Length - 2);

                                    Console.WriteLine("Pseudos demandes contacts trouvés : {0}", stringRetournee);
                                    byte[] stringRetournee2 = System.Text.Encoding.ASCII.GetBytes(stringRetournee);
                                    stream.Write(stringRetournee2, 0, stringRetournee2.Length);
                                }
                                else
                                {
                                    byte[] pasDemandesEnvoyee = System.Text.Encoding.ASCII.GetBytes("PasDemandesEnvoyees");
                                    stream.Write(pasDemandesEnvoyee, 0, pasDemandesEnvoyee.Length);
                                }
                                    
                                break;
                            #endregion
                            #region demandesRecues
                            case "08":
                                int p = 0;
                                user.Pseudo = SeparationSwitchDonnes[1];
                                int idUser = connexionBD.getFkUser(user);
                                string statutRecue = "Recue";
                                string FKDemandesContactsRecues = connexionBD.getDemandesFkUserContact(idUser, statutRecue);
                                if(FKDemandesContactsRecues != string.Empty)
                                {
                                    FKDemandesContactsRecues = FKDemandesContactsRecues.Substring(0, FKDemandesContactsRecues.Length - 1);
                                    string[] fkSplitRecues = FKDemandesContactsRecues.Split(',');
                                    string stringRecuesRetournee = string.Empty;
                                    foreach (string donnee in fkSplitRecues)
                                    {
                                        fkSplitRecues[p] = donnee;
                                        fkSplitRecues[p] = connexionBD.getUserPseudo(int.Parse(fkSplitRecues[p]));
                                        stringRecuesRetournee += fkSplitRecues[p] + ",";
                                        Console.WriteLine("fkSplit : {0}", fkSplitRecues[p]);
                                        p++;
                                    }
                                    stringRecuesRetournee.Substring(0, stringRecuesRetournee.Length - 2);

                                    byte[] stringRecuesRetournee2 = System.Text.Encoding.ASCII.GetBytes(stringRecuesRetournee);
                                    stream.Write(stringRecuesRetournee2, 0, stringRecuesRetournee2.Length);
                                }
                                else
                                {
                                    byte[] pasDemandesRecues = System.Text.Encoding.ASCII.GetBytes("PasDemandesRecues");
                                    stream.Write(pasDemandesRecues, 0, pasDemandesRecues.Length);
                                }

                                break;
                            #endregion
                            #region accepterDemande
                            case "09":
                                int q = 0;
                                string[] donnee9 = SeparationSwitchDonnes[1].Split(',');
                                foreach (string donnee in donnee9)
                                {
                                    donnee9[q] = donnee;
                                    q++;
                                }
                                user.Pseudo = donnee9[0];
                                contact.Pseudo = donnee9[1];
                                int idUser9 = connexionBD.getFkUser(user);
                                int idContact9 = connexionBD.getFkUser(contact);
                                connexionBD.ContactAccepteSupprimerDemandeRecue(idUser9, idContact9);
                                connexionBD.ContactAccepteSupprimerDemandeRecue(idContact9, idUser9);
                                connexionBD.ContactAccepterAjouterContact(idUser9, idContact9);
                                connexionBD.ContactAccepterAjouterContact(idContact9, idUser9);

                                string contactAjoute = "Contact ajouté !";
                                byte[] reponse9 = System.Text.Encoding.ASCII.GetBytes(contactAjoute);
                                stream.Write(reponse9, 0, reponse9.Length);

                                break;
                            #endregion
                            #region ajoutContactListeContact
                            case "10":
                                int r = 0;
                                user.Pseudo = SeparationSwitchDonnes[1];
                                int idUser10 = connexionBD.getFkUser(user);
                                int idContact = 0;
                                byte[] reponse10 = new byte[0];
                                string listeIdContact = connexionBD.SelectionneIdContacts(idUser10);
                                if(listeIdContact != string.Empty)
                                {
                                    listeIdContact = listeIdContact.Substring(0, listeIdContact.Length - 1);
                                    Console.Write("LISTE ID CONTACT : " + listeIdContact);
                                    string[] donnee10 = listeIdContact.Split(',');

                                    string listePseudoContact = string.Empty;
                                    foreach (string donnee in donnee10)
                                    {
                                        donnee10[r] = donnee;
                                        idContact = int.Parse(donnee10[r]);
                                        Console.WriteLine("idContact : " + idContact);
                                        donnee10[r] = connexionBD.getUserPseudo(idContact);
                                        listePseudoContact += donnee10[r] + ",";
                                        r++;
                                    }
                                    listePseudoContact = listePseudoContact.Substring(0, listePseudoContact.Length - 1);
                                    reponse10 = System.Text.Encoding.ASCII.GetBytes(listePseudoContact);
                                    stream.Write(reponse10, 0, reponse10.Length);
                                }
                                reponse10 = System.Text.Encoding.ASCII.GetBytes("Pas de contact a ajouter");
                                stream.Write(reponse10, 0, reponse10.Length);
                                break;
                            #endregion
                            #region refusDemandeContact
                            case "11":
                                int s = 0;
                                string statutRecue11 = "Recue";
                                string statutEnvoyee11 = "Envoyee";
                                string[] donnee11 = SeparationSwitchDonnes[1].Split(',');
                                foreach (string donnee in donnee11)
                                {
                                    donnee11[s] = donnee;
                                    s++;
                                }
                                user.Pseudo = donnee11[0];
                                contact.Pseudo = donnee11[1];

                                int idUser11 = connexionBD.getFkUser(user);
                                int idContact11 = connexionBD.getFkUser(contact);

                                connexionBD.SupprimerDemandeContact(idUser11, idContact11, statutRecue11);
                                connexionBD.SupprimerDemandeContact(idContact11, idUser11, statutEnvoyee11);
                                string demandeSupprimee = "Demande supprimee";
                                byte[] reponse11 = System.Text.Encoding.ASCII.GetBytes(demandeSupprimee);
                                stream.Write(reponse11, 0, reponse11.Length);


                                
                                break;
                            #endregion
                            case "12":
                                int t = 0;
                                string[] donnee12 = SeparationSwitchDonnes[1].Split(',');
                                foreach(string donnee in donnee12)
                                {
                                    donnee12[t] = donnee;
                                    t++;
                                }
                                user.Pseudo = donnee12[0];
                                contact.Pseudo = donnee12[1];

                                int idContact12 = connexionBD.getFkUser(contact);
                                int idUser12 = connexionBD.getFkUser(user);
                                connexionBD.SupprimerContact(idContact12, idUser12);
                                connexionBD.SupprimerContact(idUser12, idContact12);

                                string contactSupprime = "Contact supprime";
                                byte[] reponse12 = System.Text.Encoding.ASCII.GetBytes(contactSupprime);
                                stream.Write(reponse12, 0, reponse12.Length);
                                break;
                            default:
                                break;
                                    
     
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

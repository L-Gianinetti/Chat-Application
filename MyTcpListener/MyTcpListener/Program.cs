﻿using System;
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
            ActionUtilisateur actionUtilisateur = new ActionUtilisateur();
            ActionDiscussion actionDiscussion = new ActionDiscussion();
            
            
            ConnexionBD connexionBD = new ConnexionBD();
            while (true)
            {
                TcpListener server = null;
                Reponse reponse = new Reponse();
                try
                {
                    //Attribution du port et de l'adresse IP
                    int port = 4321;
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
                        
                            
                            
                        switch (SeparationSwitchDonnes[0])
                        {
                            
                            #region Enregistrement du profil
                            //Enregistrement du profil
                            case "01":
                                actionUtilisateur.CreationUtilisateur(SeparationSwitchDonnes);
                                break;
                            #endregion
                            #region connexion
                            //Connexion
                            case "02":
                                string motDePasse = actionUtilisateur.RetourneMotDePasse(SeparationSwitchDonnes);

                                byte[] mdpDemande = System.Text.Encoding.ASCII.GetBytes(motDePasse);
                                stream.Write(mdpDemande, 0, mdpDemande.Length);
                                Console.WriteLine("mdpDemande: {0}", mdpDemande);
                                break;
                            #endregion
                            #region Chargement du profil
                            case "03":
                                string infosProfil = actionUtilisateur.RetourneInfoProfil(SeparationSwitchDonnes);
                                byte[] infosProfilARetourner = System.Text.Encoding.ASCII.GetBytes(infosProfil);
                                stream.Write(infosProfilARetourner, 0, infosProfilARetourner.Length);
                                Console.WriteLine("Infos profil envoyées : {0}", infosProfilARetourner);
                                break;
                            #endregion
                            #region Mise à jour du profil
                            case "04":
                                actionUtilisateur.MiseAJourProfilUtilisateur(SeparationSwitchDonnes);

                                string updateReussie = "Reussie";
                                byte[] reponse4 = System.Text.Encoding.ASCII.GetBytes(updateReussie);
                                stream.Write(reponse4, 0, reponse4.Length);

                                Console.WriteLine("Update du profil : {0}", updateReussie);
                                break;
                            #endregion
                            #region Enregistrement pseudoExistant
                            case "05":
                                string pseudoTrouve = actionUtilisateur.PseudoDejaPris(SeparationSwitchDonnes);

                                Console.WriteLine("Pseudo trouvé : {0}", pseudoTrouve);
                                byte[] pseudoTrouveRetourne = System.Text.Encoding.ASCII.GetBytes(pseudoTrouve);
                                stream.Write(pseudoTrouveRetourne, 0, pseudoTrouveRetourne.Length);
                                break;
                            #endregion
                            #region ajoutContact
                            case "06":
                                string contactTrouve = actionUtilisateur.RetourneContactExistant(SeparationSwitchDonnes);

                                byte[] contactTrouveRetourne = System.Text.Encoding.ASCII.GetBytes(contactTrouve);
                                stream.Write(contactTrouveRetourne, 0, contactTrouveRetourne.Length);
                                break;
                            #endregion
                            #region demandesEnvoyees
                            case "07":
                                string demandesContactEnvoyee = actionUtilisateur.RetourneDemandesContact(SeparationSwitchDonnes, "envoyee");

                                if(demandesContactEnvoyee != string.Empty)
                                {
                                    byte[] reponse7 = System.Text.Encoding.ASCII.GetBytes(demandesContactEnvoyee);
                                    stream.Write(reponse7, 0, reponse7.Length);
                                }
                                else
                                {
                                    byte[] reponse7 = System.Text.Encoding.ASCII.GetBytes("PasDemandesEnvoyees");
                                    stream.Write(reponse7, 0, reponse7.Length);
                                }
                                    
                                break;
                            #endregion
                            #region demandesRecues
                            case "08":
                                string demandesContactRecue = actionUtilisateur.RetourneDemandesContact(SeparationSwitchDonnes, "recue");

                                if (demandesContactRecue != string.Empty)
                                {
                                    byte[] reponse8 = System.Text.Encoding.ASCII.GetBytes(demandesContactRecue);
                                    stream.Write(reponse8, 0, reponse8.Length);
                                }
                                else
                                {
                                    byte[] reponse8 = System.Text.Encoding.ASCII.GetBytes("PasDemandesRecues");
                                    stream.Write(reponse8, 0, reponse8.Length);
                                }

                                break;
                            #endregion
                            #region accepterDemande
                            case "09":
                                actionUtilisateur.AccepterDemandeContact(SeparationSwitchDonnes);
                                string contactAjoute = "Contact ajouté !";
                                byte[] reponse9 = System.Text.Encoding.ASCII.GetBytes(contactAjoute);
                                stream.Write(reponse9, 0, reponse9.Length);
                                break;
                            #endregion
                            #region ajoutContactListeContact
                            case "10":
                                string listePseudosContacts = actionUtilisateur.RetourneContacts(SeparationSwitchDonnes);
                                byte[] reponse10;
                                if(listePseudosContacts != string.Empty)
                                {
                                    reponse10 = System.Text.Encoding.ASCII.GetBytes(listePseudosContacts);
                                    stream.Write(reponse10, 0, reponse10.Length);
                                }
                                else
                                {
                                    reponse10 = System.Text.Encoding.ASCII.GetBytes("Pas de contact a ajouter");
                                    stream.Write(reponse10, 0, reponse10.Length);
                                }
                                break;
                            #endregion
                            #region refusDemandeContact
                            case "11":
                                actionUtilisateur.SupprimerDemandeContact(SeparationSwitchDonnes);
                                string demandeSupprimee = "Demande supprimee";
                                byte[] reponse11 = System.Text.Encoding.ASCII.GetBytes(demandeSupprimee);
                                stream.Write(reponse11, 0, reponse11.Length);    
                                break;
                            #endregion
                            #region supprimerContact
                            case "12":
                                actionUtilisateur.SupprimerContact(SeparationSwitchDonnes);
                                string contactSupprime = "Contact supprime";
                                byte[] reponse12 = System.Text.Encoding.ASCII.GetBytes(contactSupprime);
                                stream.Write(reponse12, 0, reponse12.Length);
                                break;
                            #endregion  
                            case "13":
                                actionUtilisateur.ModificationContact(SeparationSwitchDonnes);
                                break;
                            case "14":
                                string infosProfilContact = actionUtilisateur.RetourneInfoProfilContact(SeparationSwitchDonnes);
                                string annotation = actionUtilisateur.RetourneAnnotationContact(SeparationSwitchDonnes);
                                string infosContact = infosProfilContact + "," + annotation;                                                                                                                                                                                     
                                byte[] reponse14= System.Text.Encoding.ASCII.GetBytes(infosContact);
                                stream.Write(reponse14, 0, reponse14.Length);
                                break;
                            case "15":
                                string participants = SeparationSwitchDonnes[1].Substring(0, SeparationSwitchDonnes[1].Length - 2);
                                string stringNbrParticipants = SeparationSwitchDonnes[1].Substring(SeparationSwitchDonnes[1].Length -2,2);
                                int test = int.Parse(stringNbrParticipants.Substring(0, 1));
                                int test2 = int.Parse(stringNbrParticipants.Substring(1, 1));
                                int nbrParticipants;
                                if(test == 0)
                                {
                                    nbrParticipants = test2;
                                }
                                else
                                {
                                    nbrParticipants = int.Parse(stringNbrParticipants);
                                }
                                
                                byte[] reponse15;
                                string discussion = actionDiscussion.CreerDiscussion(SeparationSwitchDonnes, nbrParticipants);
                                if(discussion == "Discussion creee")
                                {
                                    actionDiscussion.CreerParticipationDiscussionCreateur(SeparationSwitchDonnes, nbrParticipants);
                                    actionDiscussion.CreerParticipationDiscussionParticipant(SeparationSwitchDonnes, nbrParticipants);
                                    reponse15 = System.Text.Encoding.ASCII.GetBytes(discussion);
                                    stream.Write(reponse15, 0, reponse15.Length);
                                }
                                else
                                {
                                    reponse15 = System.Text.Encoding.ASCII.GetBytes(discussion);
                                    stream.Write(reponse15, 0, reponse15.Length);
                                }


                                break;
                            case "16":
                                user.Pseudo = SeparationSwitchDonnes[1];
                                string nomsDiscussionEnAttente = actionDiscussion.DemandeRecueNomDiscussion(user.Pseudo);
                                if(nomsDiscussionEnAttente != string.Empty)
                                {
                                    byte[] reponse16 = System.Text.Encoding.ASCII.GetBytes(nomsDiscussionEnAttente);
                                    stream.Write(reponse16, 0, reponse16.Length);
                                }
                                else
                                {
                                    byte[] reponse16 = System.Text.Encoding.ASCII.GetBytes(nomsDiscussionEnAttente);
                                    stream.Write(reponse16, 0, reponse16.Length);
                                }
                                break;
                            case "17":
                                user.Pseudo = SeparationSwitchDonnes[1];
                                string test17 = actionDiscussion.DemandeEnvoyeePseudoParticipantNomDiscussion(user.Pseudo);
                                if(test17 != string.Empty)
                                {
                                    byte[] reponse17 = System.Text.Encoding.ASCII.GetBytes(test17);
                                    stream.Write(reponse17, 0, reponse17.Length);
                                    //RESTE A RECUPERER LE STRING ET L'AJOUTER A LA CMB DANS DISCUSSION ET SUPPRIMER LE CODE INUTILE DE LA JOURNEE
                                }
                                else
                                {
                                    byte[] reponse17 = System.Text.Encoding.ASCII.GetBytes(test17);
                                    stream.Write(reponse17, 0, reponse17.Length);
                                }
                                break;
                            case "18":
                                string[] donnees18 = SeparationSwitchDonnes[1].Split(',');
                                user.Pseudo = donnees18[0];
                                string nomDiscussion18 = donnees18[1];
                                actionDiscussion.ChangerEtatParticipationDiscussion(nomDiscussion18, user.Pseudo);
                                break;
                            case "19":
                                string[] donnees19 = SeparationSwitchDonnes[1].Split(',');
                                user.Pseudo = donnees19[0];
                                string nomDiscussion19 = donnees19[1];
                                actionDiscussion.ChangerEtatParticipationDiscussion(nomDiscussion19, user.Pseudo);
                                break;
                            case "20":
                                string[] donnees20 = SeparationSwitchDonnes[1].Split(',');
                                user.Pseudo = donnees20[0];
                                string nomDiscussion20 = donnees20[1];
                                actionDiscussion.SupprimerParticipationDiscussion(nomDiscussion20, user.Pseudo);
                                break;
                            case "21":
                                string[] donnees21 = SeparationSwitchDonnes[1].Split(',');
                                user.Pseudo = donnees21[0];
                                string nomDiscussion21 = donnees21[1];
                                actionDiscussion.SupprimerParticipationDiscussion(nomDiscussion21, user.Pseudo);
                                break;
                            case "22":
                                user.Pseudo = SeparationSwitchDonnes[1];
                                string test22 = actionDiscussion.DiscussionParticipe(user.Pseudo);
                                byte[] reponse22 = System.Text.Encoding.ASCII.GetBytes(test22);
                                stream.Write(reponse22, 0, reponse22.Length);
                                break;

                            default:
                                break;
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

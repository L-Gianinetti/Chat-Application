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
    public class ActionDiscussion
    {
        User administrateur = new User();
        User utilisateur = new User();
        ConnexionBD connexionBD = new ConnexionBD();

        public string[] SeparerElements(string[] donneesASeparer)
        {
            //int pour séparer les données
            int i = 0;
            //tableau contenant les données séparement
            string[] donnee = donneesASeparer[1].Split(',');
            foreach (string element in donnee)
            {
                donnee[i] = element;
                i++;
            }

            return donnee;
        }
        public string[] SeparerElementsString(string donneesASeparer)
        {
            int i = 0;
            string[] donnee = donneesASeparer.Split(',');
            foreach(string element in donnee)
            {
                donnee[i] = element;
                i++;
            }
            return donnee;
        }

        //TODO verifier si classe discussion est nécessaire , surement ?
        //nbrParticipants ne contient pas le createur
        /// <summary>
        /// Permet de créer une discussion, une categorie et le lien entre les deux
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="nbrParticipants"></param>
        /// <param name="categorie"></param>
        /// <param name="publique"></param>
        /// <returns></returns>
        public string CreerDiscussion(string[] donnee, int nbrParticipants, string categorie, bool publique)
        {
            string nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
            string reponse = string.Empty;
            //Vérifie si le nom est disponible
            if (VerifierNomDiscussionExistant(nomDiscussion) == true)
            {
                reponse = "Nom deja existant";
            }
            //Si il est disponible
            else
            {
                //Ajout de la discussion dans la base de données
                connexionBD.CreerDiscussion(nomDiscussion, publique);
                //Si la categorie n'existe pas encore
                if(connexionBD.VerifieCategorie(categorie) != categorie)
                {
                    //Ajout de la categorie dans la base de données
                    connexionBD.AjoutCategorie(categorie);
                }
                int idCategory = int.Parse(connexionBD.SelectionneIdCategory(categorie));
                int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
                connexionBD.AjoutLienCategorieDiscussion(idDiscussion, idCategory);
                reponse = "Discussion creee";
            }
            return reponse;
        }

        /// <summary>
        /// Supprime définitivement une discussion archivée en fonction d'un pseudo et d'un nom d'archive
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="nom"></param>
        public void SupprimerArchive(string pseudo, string nom)
        {
            utilisateur.Pseudo = pseudo;
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nom));
            connexionBD.SupprimerArchive(idUtilisateur, idDiscussion);
        }


        /// <summary>
        /// Selectionne les noms d'archives en fonction d'un pseudo utilisateur
        /// </summary>
        /// <param name="pseudoUtilisateur"></param>
        /// <returns></returns>
        public string SelectionneArchives(string pseudoUtilisateur)
        {
            string nomsArchives = connexionBD.SelectionneArchive(pseudoUtilisateur);
            if(nomsArchives != string.Empty)
            {
                nomsArchives = nomsArchives.Substring(0, nomsArchives.Length - 1);
            }

            return nomsArchives;
        }

        /// <summary>
        /// Retourne les noms de discussions auquel l'utilisateur participe séparés par des virgules
        /// </summary>
        /// <param name="pseudoUtilisateur"></param>
        /// <returns></returns>
        public string QuellesDiscussionsParticipe(string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            string reponse = connexionBD.SelectionneNomDiscussion(idUtilisateur, "Participe");
            return reponse;
        }

        /// <summary>
        /// Vérifie si le nom de la discussion existe deja ou pas
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public bool VerifierNomDiscussionExistant(string nom)
        {
            bool nomExiste;
            if (nom == connexionBD.VerifieNomDiscussion(nom))
            {
                nomExiste = true;
            }
            else
            {
                nomExiste = false;
            }
            return nomExiste;
        }

        /// <summary>
        /// Retourne les demandes de discussion recues pour un utilisateur
        /// </summary>
        /// <param name="pseudoUtilisateur"></param>
        /// <returns></returns>
        public string DemandeRecueNomDiscussion(string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            //string contenant tous les idDiscussion  des demandes en attente
            string idDiscussions = connexionBD.SelectionneIdDiscussion(idUtilisateur, "En attente");
            //string contenant tous les noms des discussions des demandes en attente
            string nomsDiscussion = connexionBD.SelectionneNomDiscussion(idUtilisateur, "En attente");
            string reponse = string.Empty;
            //Si il y a des demandes en attente
            if (idDiscussions != string.Empty)
            {
                string[] idDiscussion = idDiscussions.Split(',');
                string[] nomDiscussion = nomsDiscussion.Split(',');
                string nbrParticipants = string.Empty;
                for (int i = 0; i < idDiscussion.Count(); i++)
                {
                    nbrParticipants = connexionBD.CompteNombreEnAttenteParDiscussion(int.Parse(idDiscussion[i]));
                    //Ajout du nombre de participant, pour que le client sache si c'est une discussion de groupe ou "normale"
                    reponse += nomDiscussion[i] + "/" + nbrParticipants + ",";
                }
                reponse = reponse.Substring(0, reponse.Length - 1);
            }
            return reponse;
        }

        /// <summary>
        /// Retourne le nom de la discussion et le nom du contact, séparé par des virgules pour chaque demande de discussione envoyée
        /// </summary>
        /// <param name="pseudoAdministrateur"></param>
        /// <returns></returns>
        public string DemandeEnvoyeePseudoParticipantNomDiscussion(string pseudoAdministrateur)
        {
            administrateur.Pseudo = pseudoAdministrateur;
            int idAdministrateur = connexionBD.retourneIdUser(administrateur);
            string reponse = string.Empty;
            //string contenant le nom de la discussion et le nom du contact, séparé par des virgules pour chaque demande de discussione envoyée
            string PseudosNomsDiscussions = connexionBD.SelectionnePseudoUserNomDiscussionEnattente(idAdministrateur);
            if(PseudosNomsDiscussions != string.Empty)
            {
                PseudosNomsDiscussions = PseudosNomsDiscussions.Substring(0, PseudosNomsDiscussions.Length - 1);
            }

            
            return PseudosNomsDiscussions;
        }

        /// <summary>
        /// Permet de récupérer le nom de la discussion lors de sa création
        /// </summary>
        /// Utilisé pour insérer les participationDiscussion
        /// <param name="donnee"></param>
        /// <param name="nbrParticipants"></param>
        /// <returns></returns>
        public string SeparerNomDiscussion(string[] donnee, int nbrParticipants)
        {
            //On sépare la chaine de caractères par les virgules
            string[] donneesDiscussion = SeparerElements(donnee);

            //La numero de case du tableau correspondant au nom de la discussion sera le nombre du participant +1 sachant que le nombre de participant ne contient pas le créateur
            string nomDiscussionAvecChiffres = donneesDiscussion[nbrParticipants + 1];
            string nomDiscussion = nomDiscussionAvecChiffres.Substring(0, nomDiscussionAvecChiffres.Length - 2);

            return nomDiscussion;
        }

        /// <summary>
        /// Crée la participationDiscussion du créateur de la discussion et un administrateur qui est le créateur
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="nbrParticipants"></param>
        public void CreerParticipationDiscussionCreateur(string[] donnee, int nbrParticipants)
        {
            //On sépare la chaine de caractères par les virgules
            string[] donneesDiscussion = SeparerElements(donnee);

            //Attribution du pseudo + statut du createur de la discussion
            utilisateur.Pseudo = donneesDiscussion[0];
            string statut = "Participe";

            //Recuperation de l'idUser
            int idUser = connexionBD.retourneIdUser(utilisateur);


            //Recuperation de l'idDiscussion
            string nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));

            connexionBD.CreerParticipationDisucssion(idUser, idDiscussion, idUser,statut);
            
        }

        /// <summary>
        /// Permet de mettre un etat de participation à "Participe"
        /// </summary>
        /// Utilisé lorsqu'une demande de discussion est acceptée
        /// <param name="nomDiscussion"></param>
        /// <param name="pseudoUtilisateur"></param>
        public void ChangerEtatParticipationDiscussion(string nomDiscussion, string pseudoUtilisateur)
        {
            string idDiscussion = connexionBD.SelectionneIdDiscussion(nomDiscussion);
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            connexionBD.UpdateParticipationDiscussions(int.Parse(idDiscussion), idUtilisateur);
        }

        /// <summary>
        /// Permet de supprimer une participation à la discusison
        /// </summary>
        /// Est utilisé lorsqu'une demande de discussion est refusée ou lorsqu'un utilisateur est supprimé d'une discussion
        /// <param name="nomDiscussion"></param>
        /// <param name="pseudoUtilisateur"></param>
        public void SupprimerParticipationDiscussion(string nomDiscussion, string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            connexionBD.SupprimerParticipationDiscussion(idDiscussion, idUtilisateur);
        }



        public string SelectionneCategoriesRecherchees(string categoriesRecherchees)
        {
           string categoriesTrouvees = connexionBD.SelectionneCategoriesRecherchees(categoriesRecherchees);
            return categoriesTrouvees;

        }

        public string SelectionneCategorieProposee()
        {
            string reponse = connexionBD.SelectionnCategorieProposee();
            return reponse;
        }

        public void CreerInvitationDiscussion(string nomUtilisateur, string nomDiscussion, string nomAdministrateur)
        {
            administrateur.Pseudo = nomAdministrateur;
            utilisateur.Pseudo = nomUtilisateur;
            int idAdmin = connexionBD.retourneIdUser(administrateur);
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            string statut = "En attente";
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
            connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdmin, statut);

        }
        /// <summary>
        /// Crée la participation à la discussion pour un participant
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="nbrParticipants"></param>
        public void CreerParticipationDiscussionParticipant(string[] donnee, int nbrParticipants)
        {
            //On sépare la chaine de caractères par les virgules
            string[] donneesDiscussion = SeparerElements(donnee);
            string statut = "En attente";
            int idUtilisateur;
            int idDiscussion;
            administrateur.Pseudo = donneesDiscussion[0];
            int idAdministrateur = connexionBD.retourneIdUser(administrateur);
            string nomDiscussion = string.Empty;
            //Pour chaque participant on crée une participation à la discussion
            for (int i = 1; i < nbrParticipants+1; i++)
            {
                utilisateur.Pseudo = donneesDiscussion[i];
                idUtilisateur = connexionBD.retourneIdUser(utilisateur);
                nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
                idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
                connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdministrateur, statut);

            }
        }


        /// <summary>
        /// Retourne les noms des participants à une discussion séparés par des virgules
        /// </summary>
        /// <param name="nomDiscussion"></param>
        /// <returns></returns>
        public string RetourneNomsParticipantsDiscussion(string nomDiscussion)
        {
            string nomsParticipants = connexionBD.SelectionneNomParticipantsDiscussion(nomDiscussion);
            return nomsParticipants;
        }

        /// <summary>
        /// Permet d'ajouter un message dans la BD
        /// </summary>
        /// Est utilisé chaque fois qu'un message est envoyé
        /// <param name="pseudo"></param>
        /// <param name="message"></param>
        /// <param name="date"></param>
        /// <param name="nomDiscussion"></param>
        public void EnvoiMessage(string pseudo, string message, string date, string nomDiscussion)
        {
            utilisateur.Pseudo = pseudo;
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));

            DateTime dateTime = DateTime.Parse(date);
            connexionBD.ajouterMessage(message, dateTime, idDiscussion, idUtilisateur);
        }

        /// <summary>
        /// Retourne les messages d'une discussion
        /// </summary>
        /// Est appelé chaque fois que le timer tick (toutes les secondes) pour avoir les messages de la discussion instantanément
        /// <param name="nomDiscussion"></param>
        /// <returns></returns>
        public string actualiserMessages(string nomDiscussion)
        {
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
            string messages = connexionBD.SelectionneMessages(idDiscussion);
            return messages;
        }

        /// <summary>
        /// Retourne le pseudo de l'administrateur d'une discussion en fonction de son nom
        /// </summary>
        /// Est utilisé pour activer les boutons réservés à l'administrateur dans une discussion
        /// <param name="nomDiscussion"></param>
        /// <returns></returns>
        public string selectionnePseudoAdministrateur(string nomDiscussion)
        {
            /*string idDiscussion = connexionBD.SelectionneIdDiscussion(nomDiscussion);
            int idAdmin = int.Parse(connexionBD.GetIdAdminParticipantsDiscussion(idDiscussion));

            utilisateur.Pseudo = connexionBD.getUserPseudo(idAdmin);*/
            string pseudoAdmin = connexionBD.selectionnePseudoAdministrateur(nomDiscussion);
            return pseudoAdmin;
        }

        /// <summary>
        /// Ajoute un participant à une discussion publique --> statut = participe
        /// </summary>
        /// <param name="nomDisc"></param>
        /// <param name="participants"></param>
        public void AjouteParticipationDiscussionRecherche(string nomDisc, string participant)
        {
            utilisateur.Pseudo = participant;
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDisc));
            int idAdmin = int.Parse(connexionBD.SelectionneIdAdministrateur(idDiscussion.ToString()));
            string statut = "Participe";
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdmin, statut);
        }

        /// <summary>
        /// Envoi les demandes de participation a une discussion lorsqu'un admin ajoute des contacts dans une discussion
        /// </summary>
        /// <param name="nomDisc"></param>
        /// <param name="participants"></param>
        public void AjouteParticipationDiscussion(string nomDisc, string participants)
        {
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDisc));
            
            int idAdmin = int.Parse(connexionBD.SelectionneIdAdministrateur(idDiscussion.ToString()));
            string statut = "En attente";
            string[] nomParticipant = participants.Split('$');
            for(int i =0; i < nomParticipant.Length; i++)
            {
                utilisateur.Pseudo = nomParticipant[i];
                int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
                connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdmin, statut);
            }

        }

        public string SelectionneDiscussionsExistantesParCategorie(string categorie, string pseudo)
        {
            int idCategorie = int.Parse(connexionBD.SelectionneIdCategory(categorie));
            string idDiscussions = connexionBD.SelectionneIdDiscussionParIdCategorie(idCategorie);
            string nomDiscussionDejaParticipant = string.Empty;
            if (idDiscussions != string.Empty)
            {
                idDiscussions = idDiscussions.Substring(0, idDiscussions.Length - 1);
                string[] idDiscussion = idDiscussions.Split(',');

                utilisateur.Pseudo = pseudo;
                int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
                for (int i = 0; i < idDiscussion.Length; i++)
                {
                    string idDiscussionDejaParticipant = connexionBD.SelectionneIdDiscussionDejaParticipant(idDiscussion[i], idUtilisateur);
                    if (idDiscussionDejaParticipant != string.Empty)
                    {
                        nomDiscussionDejaParticipant += connexionBD.GetNomDiscussion(int.Parse(idDiscussionDejaParticipant)) + ",";
                    }

                }
                if(nomDiscussionDejaParticipant != string.Empty)
                {
                    nomDiscussionDejaParticipant = nomDiscussionDejaParticipant.Substring(0, nomDiscussionDejaParticipant.Length - 1);
                }

                
            }
            return nomDiscussionDejaParticipant;
        }

        public string SelectionneDiscussionsParCategorie(string categorie)
        {
            string nomDiscussions = connexionBD.SelectionneNomDiscussionParCategorie(categorie);
            if(nomDiscussions != string.Empty)
            {
                nomDiscussions = nomDiscussions.Substring(0, nomDiscussions.Length - 1);
            }

            return nomDiscussions;
        }

        /// <summary>
        /// Ajoute une discusison en archive en fonction d'un nom et du pseudo de l'utilisateur actif
        /// </summary>
        /// <param name="nomDisc"></param>
        /// <param name="pseudoUtilisateur"></param>
        public void AjouterArchive(string nomDisc, string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDisc));
            int idAdmin = int.Parse(connexionBD.SelectionneIdAdministrateur(idDiscussion.ToString()));
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            connexionBD.AjouterArchive(idDiscussion, idAdmin, idUtilisateur);
        }

        /// <summary>
        /// Importe une discussion archivée dans les discussions courantes
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="nom"></param>
        public void ImporterArchive(string pseudo, string nom)
        {
            utilisateur.Pseudo = pseudo;

            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nom));
            int idAdministrateur = int.Parse(connexionBD.SelectionneIdAdministrateur(idDiscussion.ToString()));
            connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdministrateur, "Participe");
        }
    }
}

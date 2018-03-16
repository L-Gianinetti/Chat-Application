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
        public string CreerDiscussion(string[] donnee, int nbrParticipants)
        {
            string nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
            string reponse = string.Empty;
            if (VerifierNomDiscussionExistant(nomDiscussion) == true)
            {
                reponse = "Nom deja existant";
            }
            else
            {
                //Ajout de la discussion dans la base de données
                connexionBD.CreerDiscussion(nomDiscussion);
                reponse = "Discussion creee";
            }
            return reponse;
        }

        public string DiscussionParticipe(string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            string idDiscussions = connexionBD.SelectionneNomDiscussion(idUtilisateur);
            string reponse = string.Empty;
            string[] idDiscussion = idDiscussions.Split(',');
            for(int i =0; i < idDiscussion.Count(); i++)
            {
                idDiscussion[i] = connexionBD.GetNomDiscussion(int.Parse(idDiscussion[i]));
                reponse += idDiscussion[i] + ",";
            }
            if(reponse != string.Empty)
            {
                reponse = reponse.Substring(0, reponse.Length - 1);
            }
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
        public string DemandeRecueNomDiscussion(string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            string idDiscussions = connexionBD.SelectionneNomDiscussion(idUtilisateur);
            string nomsDiscussion = string.Empty;
            if (idDiscussions != string.Empty)
            {
                string[] idDiscussion = idDiscussions.Split(',');
                
                string nbrParticipants = string.Empty;
                for (int i = 0; i < idDiscussion.Count(); i++)
                {
                    nbrParticipants = connexionBD.CompteNombreEnAttenteParDiscussion(int.Parse(idDiscussion[i]));
                    idDiscussion[i] = connexionBD.GetNomDiscussion(int.Parse(idDiscussion[i]));
                    nomsDiscussion += idDiscussion[i] + "/" + nbrParticipants + ",";
                }
                nomsDiscussion = nomsDiscussion.Substring(0, nomsDiscussion.Length - 1);
            }


            return nomsDiscussion;
        }
        /// <summary>
        /// Retourne les users par discussions
        /// </summary>
        /// <param name="pseudoAdministrateur"></param>
        /// <returns></returns>
        public string DemandeEnvoyeePseudoParticipantNomDiscussion(string pseudoAdministrateur)
        {
            administrateur.Pseudo = pseudoAdministrateur;
            int idAdministrateur = connexionBD.getFkUser(administrateur);
            string reponse = string.Empty;
           string idPseudosIdDiscussions = connexionBD.SelectionneIdUserNomDiscussionEnAttente(idAdministrateur);
            if(idPseudosIdDiscussions != string.Empty)
            {
                int count = idPseudosIdDiscussions.TakeWhile(c => c == ',').Count();
                string[] idPseudoIdDiscussion = idPseudosIdDiscussions.Split(',');
                for (int i = 0; i < idPseudoIdDiscussion.Count(); i++)
                {
                    string[] idPseudo = idPseudoIdDiscussion[i].Split('/');
                    if (idPseudo[0] != string.Empty)
                    {
                        string pseudo = connexionBD.getUserPseudo(int.Parse(idPseudo[0]));
                        string nomDisc = connexionBD.GetNomDiscussion(int.Parse(idPseudo[1]));
                        idPseudoIdDiscussion[i] = pseudo + "/" + nomDisc;
                        reponse += idPseudoIdDiscussion[i] + ",";
                    }


                }
                reponse = reponse.Substring(0, reponse.Length - 1);
            }

            
            return reponse;
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

            //On récupère la partie qui contient le nom de la discussion et le nombre de participants
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
            int idUser = connexionBD.getFkUser(utilisateur);


            //Recuperation de l'idDiscussion
            string nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));

            connexionBD.CreerParticipationDisucssion(idUser, idDiscussion, idUser,statut);
            
        }

        public void ChangerEtatParticipationDiscussion(string nomDiscussion, string pseudoUtilisateur)
        {
            string idDiscussion = connexionBD.SelectionneIdDiscussion(nomDiscussion);
            utilisateur.Pseudo = pseudoUtilisateur;
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            connexionBD.UpdateParticipationDiscussions(int.Parse(idDiscussion), idUtilisateur);
        }

        public void SupprimerParticipationDiscussion(string nomDiscussion, string pseudoUtilisateur)
        {
            utilisateur.Pseudo = pseudoUtilisateur;
            int idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            connexionBD.SupprimerParticipationDiscussion(idDiscussion, idUtilisateur);
        }

        public void CreerParticipationDiscussionParticipant(string[] donnee, int nbrParticipants)
        {
            //On sépare la chaine de caractères par les virgules
            string[] donneesDiscussion = SeparerElements(donnee);
            string statut = "En attente";
            int idUtilisateur;
            int idDiscussion;
            administrateur.Pseudo = donneesDiscussion[0];
            int idAdministrateur = connexionBD.getFkUser(administrateur);
            string nomDiscussion = string.Empty;
            for (int i = 1; i < nbrParticipants+1; i++)
            {
                utilisateur.Pseudo = donneesDiscussion[i];
                idUtilisateur = connexionBD.getFkUser(utilisateur);
                nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
                idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
                connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, idAdministrateur, statut);

            }
        }

    }
}

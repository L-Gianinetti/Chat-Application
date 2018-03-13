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
    class ActionUtilisateur
    {
        User utilisateur = new User();
        User contact = new User();
        ConnexionBD connexionBD = new ConnexionBD();

        /// <summary>
        /// Sépare les éléments contenu dans une case d'un tableau string dans différentes case d'un autre tableau string
        /// </summary>
        /// <param name="donneesASeparer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Crée un User contenant les informations de l'utilisateur
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public User AttribueInformationsUtilisateur(string[] donnee, bool motDePasse)
        {
            string[] donneesUtilisateur;
            if (motDePasse)
            {
                donneesUtilisateur = SeparerElements(donnee);

                utilisateur.Pseudo = donneesUtilisateur[0];
                utilisateur.MotDePasse = donneesUtilisateur[1];
                utilisateur.Nom = donneesUtilisateur[2];
                utilisateur.Prenom = donneesUtilisateur[3];
                utilisateur.Description = donneesUtilisateur[4];
            }
            else
            {
                donneesUtilisateur = SeparerElements(donnee);

                utilisateur.Pseudo = donneesUtilisateur[0];
                utilisateur.Nom = donneesUtilisateur[1];
                utilisateur.Prenom = donneesUtilisateur[2];
                utilisateur.Description = donneesUtilisateur[3];
            }

            return utilisateur;
        }

        /// <summary>
        /// Retourne un User contenant seulement un pseudo
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public User RetournePseudoUtilisateur(string[] donnee)
        {
            string[] donneesUtilisateur = SeparerElements(donnee);
            utilisateur.Pseudo = donneesUtilisateur[0];



            return utilisateur;
        }
        /// <summary>
        /// Retourne un User contenant seulement le pseudo
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public User RetournePseudoContact(string[] donnee)
        {
            string[] donneesUtilisateur = SeparerElements(donnee);
            contact.Pseudo = donneesUtilisateur[1];
            return contact;
        }

        //TODO verifier si classe discussion est nécessaire , surement ?
        //nbrParticipants ne contient pas le createur
        public void CreerDiscussion(string[] donnee, int nbrParticipants)
        {
            string nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);

            //Ajout de la discussion dans la base de données
            connexionBD.CreerDiscussion(nomDiscussion);
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
        /// Crée la participationDiscussion du créateur de la discussion
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

            connexionBD.CreerParticipationDisucssion(idUser, idDiscussion, statut);
        }

        public void CreerParticipationDiscussionParticipant(string[] donnee, int nbrParticipants)
        {
            //On sépare la chaine de caractères par les virgules
            string[] donneesDiscussion = SeparerElements(donnee);
            string statut = "En attente";
            int idUtilisateur;
            int idDiscussion;
            string nomDiscussion = string.Empty;
            for(int i = 0; i < nbrParticipants; i++)
            {
                utilisateur.Pseudo = donneesDiscussion[i];
                idUtilisateur = connexionBD.getFkUser(utilisateur);
                nomDiscussion = SeparerNomDiscussion(donnee, nbrParticipants);
                idDiscussion = int.Parse(connexionBD.SelectionneIdDiscussion(nomDiscussion));
                connexionBD.CreerParticipationDisucssion(idUtilisateur, idDiscussion, statut);
                
            }
        }

        /// <summary>
        /// Ajoute le profil de l'utilisateur dans la base de données
        /// </summary>
        /// <param name="donnee"></param>
        public void CreationUtilisateur(string[] donnee)
        {
            bool mdp = true;
            utilisateur = AttribueInformationsUtilisateur(donnee, mdp);
            connexionBD.ajoutUser(utilisateur);
        }
        /// <summary>
        /// Va chercher le mdp dans la base de données en fonction d'un pseudo
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string RetourneMotDePasse(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            string motDePasse = connexionBD.GetMotDePasse(utilisateur);

            return motDePasse;
        }
        /// <summary>
        /// Va chercher les informations d'un User dans la base de données en fonction d'un pseudo
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string RetourneInfoProfil(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            utilisateur.Nom = connexionBD.InfoProfilNom(utilisateur);
            utilisateur.Prenom = connexionBD.InfoProfilPrenom(utilisateur);
            utilisateur.Description = connexionBD.InfoProfilDescription(utilisateur);

            string infosProfil = utilisateur.Nom + "," + utilisateur.Prenom + "," + utilisateur.Description;

            return infosProfil;

        }
        public string RetourneInfoProfilContact(string[] donnee)
        {
            contact = RetournePseudoContact(donnee);
            contact.Nom = connexionBD.InfoProfilNom(contact);
            contact.Prenom = connexionBD.InfoProfilPrenom(contact);
            contact.Description = connexionBD.InfoProfilDescription(contact);

            string infosProfil = contact.Nom + "," + contact.Prenom + "," + contact.Description;

            return infosProfil;
        }
        /// <summary>
        /// Met a jour le profil 
        /// </summary>
        /// <param name="donnee"></param>
        public void MiseAJourProfilUtilisateur(string[] donnee)
        {
            bool mdp = false;
            utilisateur = AttribueInformationsUtilisateur(donnee, mdp);
            connexionBD.UpdateProfil(utilisateur);
        }
        /// <summary>
        /// Retourne "PseudoDisponible" si le pseudo est disponible 
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string PseudoDejaPris(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            string pseudoTrouve = connexionBD.UserExistant(utilisateur);

            //Si il le pseudo n'est pas dans la BD
            if (pseudoTrouve == "")
            {
                pseudoTrouve = "PseudoDisponible";
            }

            return pseudoTrouve;

        }
        /// <summary>
        /// Retourne le pseudo du contact si celui-ci existe.
        /// Ajoute la demande chez les 2 utilisateurs
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string RetourneContactExistant(string[] donnee)
        {
            utilisateur= RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);

            string contactExistant = connexionBD.UserExistant(contact);
            if(contactExistant != string.Empty)
            {
                string envoyee = "Envoyee";
                string recue = "Recue";
                int idUser = connexionBD.getFkUser(utilisateur);
                int idContact = connexionBD.getFkUser(contact);
                connexionBD.ajoutDemandeContact(idUser, idContact, envoyee);
                connexionBD.ajoutDemandeContact(idContact, idUser, recue);
            }

            return contactExistant;
        }
        /// <summary>
        /// Retourne les demandes de contact
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
        public string RetourneDemandesContact(string[] donnee, string statut)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            string fkDemandesContact = string.Empty;
            string pseudosDemandesContact = string.Empty;
            int i = 0;

            if (statut == "envoyee")
            {
                fkDemandesContact = connexionBD.getDemandesFkUserContact(idUtilisateur, statut);
                

            }
            else
            {
                fkDemandesContact = connexionBD.getDemandesFkUserContact(idUtilisateur, statut);
            }

            if(fkDemandesContact != string.Empty)
            {
                fkDemandesContact = fkDemandesContact.Substring(0, fkDemandesContact.Length - 1);
                string[] fkDemandesContactSeparees = fkDemandesContact.Split(',');
                foreach(string element in fkDemandesContactSeparees)
                {
                    fkDemandesContactSeparees[i] = element;
                    fkDemandesContactSeparees[i] = connexionBD.getUserPseudo(int.Parse(fkDemandesContactSeparees[i]));
                    pseudosDemandesContact += fkDemandesContactSeparees[i] + ",";
                    i++;
                }
                pseudosDemandesContact = pseudosDemandesContact.Substring(0, pseudosDemandesContact.Length - 1);
            }
            

            return pseudosDemandesContact;
        }
        /// <summary>
        /// Ajoute le contact pour les 2 utilisateurs et supprime les demandes de contact correspondantes
        /// </summary>
        /// <param name="donnee"></param>
        public void AccepterDemandeContact(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = connexionBD.getFkUser(contact);

            connexionBD.SupprimerDemandeContact(idUtilisateur, idContact);
            connexionBD.ContactAccepterAjouterContact(idUtilisateur, idContact);

            connexionBD.SupprimerDemandeContact(idContact, idUtilisateur);
            connexionBD.ContactAccepterAjouterContact(idContact, idUtilisateur);
        }

        /// <summary>
        /// Retourne les contacts
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string  RetourneContacts(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = 0;
            int i = 0;
            string listePseudosContacts = string.Empty;
            //contient les fkUserContact séparés par des virgules
            string listeFkUserContact = connexionBD.SelectionneIdContacts(idUtilisateur);
            
            if(listeFkUserContact != string.Empty)
            {
                listeFkUserContact = listeFkUserContact.Substring(0, listeFkUserContact.Length - 1);
                string[] tableauFkUserContact = listeFkUserContact.Split(',');
                foreach(string element in tableauFkUserContact)
                {
                    tableauFkUserContact[i] = element;
                    idContact = int.Parse(tableauFkUserContact[i]);
                    tableauFkUserContact[i] = connexionBD.getUserPseudo(idContact);
                    listePseudosContacts += tableauFkUserContact[i] + ",";
                    i++;
                }
                listePseudosContacts = listePseudosContacts.Substring(0, listePseudosContacts.Length - 1);
                
            }
            return listePseudosContacts;
        }
        /// <summary>
        /// Supprime la demande chez les 2 utilisateurs
        /// </summary>
        /// <param name="donnee"></param>
        public void SupprimerDemandeContact(string[]donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = connexionBD.getFkUser(contact);

            //connexionBD.ContactAccepteSupprimerDemandeRecue(idUtilisateur, idContact, statutRecu);
            //connexionBD.ContactAccepteSupprimerDemandeRecue(idContact, idUtilisateur, statutEnvoyee);
            connexionBD.SupprimerDemandeContact(idUtilisateur, idContact);
            connexionBD.SupprimerDemandeContact(idContact, idUtilisateur);
        }
        /// <summary>
        /// Supprime le contact chez les 2 utilisateurs
        /// </summary>
        /// <param name="donnee"></param>
        public void SupprimerContact(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = connexionBD.getFkUser(contact);

            connexionBD.SupprimerContact(idUtilisateur, idContact);
            connexionBD.SupprimerContact(idContact, idUtilisateur);
        }
        public void MiseAJourProfilContact(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);


        }
        public void ModificationContact(string[] donnees)
        {
            
            
            //int pour séparer les données
            int i = 0;
            //int j = 0;
            //tableau contenant les données séparement
            string[] donnee = donnees[1].Split(',');
            foreach (string element in donnee)
            {
                if (i > 1)
                {
                    donnee[2] += element;
                    i++;
                }
                else
                {
                    donnee[i] = element;
                    i++;
                }
            }
            utilisateur = RetournePseudoUtilisateur(donnees);
            contact = RetournePseudoContact(donnees);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = connexionBD.getFkUser(contact);
            string annotation = donnee[2];
            annotation = annotation.Substring(0, annotation.Length / 2);
            connexionBD.MettreAJourContact(idUtilisateur, idContact, annotation);

        }
        public string RetourneAnnotationContact(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.getFkUser(utilisateur);
            int idContact = connexionBD.getFkUser(contact);
            string annotation = connexionBD.InfoContactAnnotation(idUtilisateur, idContact);
            return annotation;


        }
    }
}

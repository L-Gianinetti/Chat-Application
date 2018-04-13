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
            //creation 
            if (motDePasse)
            {
                donneesUtilisateur = SeparerElements(donnee);

                utilisateur.Pseudo = donneesUtilisateur[0];
                utilisateur.MotDePasse = donneesUtilisateur[1];
                utilisateur.Nom = donneesUtilisateur[2];
                utilisateur.Prenom = donneesUtilisateur[3];
                utilisateur.Description = donneesUtilisateur[4];
            }
            //update
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
        public string RetourneInfoProfil(User user)
        {
            //utilisateur = RetournePseudoUtilisateur(donnee);
            utilisateur.Nom = connexionBD.RetourneInfoProfilNom(user);
            utilisateur.Prenom = connexionBD.RetourneInfoProfilPrenom(user);
            utilisateur.Description = connexionBD.RetourneInfoProfilDescription(user);

            string infosProfil = utilisateur.Nom + "," + utilisateur.Prenom + "," + utilisateur.Description;

            return infosProfil;

        }

        /// <summary>
        /// Attribution informations à un objet User + Met a jour le profil correspondant
        /// </summary>
        /// <param name="donnee"></param>
        public void MiseAJourProfilUtilisateur(string[] donnee)
        {
            bool mdp = false;
            //attribue les informations du tableau de string à un objet User
            utilisateur = AttribueInformationsUtilisateur(donnee, mdp);
            connexionBD.UpdateProfil(utilisateur);
        }
        /// <summary>
        /// Retourne "PseudoDisponible" si le pseudo est disponible 
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string PseudoDejaPris(User user)
        {
            string pseudoTrouve = connexionBD.UserExisteIl(user);
            //Si il le pseudo n'est pas dans la BD
            if (pseudoTrouve == "")
            {
                pseudoTrouve = "PseudoDisponible";
            }

            return pseudoTrouve;

        }
        /// <summary>
        /// Retourne le pseudo du contact si celui-ci existe et ajoute la demande chez les 2 utilisateurs.
        /// Ou retourne une erreur
        /// </summary>
        /// <param name="donnee"></param>
        /// <returns></returns>
        public string RetourneContactExistant(string[] donnee)
        {
            utilisateur= RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);

            string contactExistant = connexionBD.UserExisteIl(contact);
            //Si le contact est un utilisateur existant
            if(contactExistant != string.Empty)
            {
                string envoyee = "Envoyee";
                string recue = "Recue";
                int idUser = connexionBD.retourneIdUser(utilisateur);
                int idContact = connexionBD.retourneIdUser(contact);

                string contactDejaAjoute = connexionBD.SelectionneContactDejaAjoute(idContact,idUser);
                //Si le contact n'est pas deja dans la liste de contact de l'utilisateur et si le contact n'est pas l'utilisateur lui même
                if(contactDejaAjoute == string.Empty && idUser != idContact)
                {
                    //ajout des demandes de contact
                    connexionBD.ajoutDemandeContact(idUser, idContact, envoyee);
                    connexionBD.ajoutDemandeContact(idContact, idUser, recue);
                }
                else if(idUser == idContact)
                {
                    contactExistant = "Vous ne pouvez pas vous ajouter vous meme";
                }
                else
                {
                    contactExistant = "L'utilisateur fait deja parti de vos contacts";
                }

            }

            return contactExistant;
        }

        /// <summary>
        /// Retourne les pseudos des contacts correspondant aux demandes en fonction du statut
        /// </summary>
        /// <param name="donnee"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
        public string RetourneDemandesPseudosContact(User user, string statut)
        {  
            int idUtilisateur = connexionBD.retourneIdUser(user);
            string fkDemandesContact = string.Empty;
            string pseudosDemandesContact = string.Empty;


            if (statut == "envoyee")
            {
                pseudosDemandesContact = connexionBD.RetourneDemandesPseudosContacts(idUtilisateur, statut);
            }
            else
            {
                pseudosDemandesContact = connexionBD.RetourneDemandesPseudosContacts(idUtilisateur, statut);
            }

            if(pseudosDemandesContact != string.Empty)
            {
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
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idContact = connexionBD.retourneIdUser(contact);

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
        public string  RetourneContacts(User user)
        {
            int idUtilisateur = connexionBD.retourneIdUser(user);
            string listePseudosContacts = string.Empty;
            //contient les pseudos des contacts existants séparés par des virgules
            string listePseudosContact = connexionBD.SelectionnePseudoContact(idUtilisateur);
            if(listePseudosContact != string.Empty)
            {
                listePseudosContact = listePseudosContact.Substring(0, listePseudosContact.Length - 1);
            }
            return listePseudosContact;
        }
        /// <summary>
        /// Supprime la demande chez les 2 utilisateurs
        /// </summary>
        /// <param name="donnee"></param>
        public void SupprimerDemandeContact(string[]donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idContact = connexionBD.retourneIdUser(contact);

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
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idContact = connexionBD.retourneIdUser(contact);

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
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idContact = connexionBD.retourneIdUser(contact);
            string annotation = donnee[2];
            annotation = annotation.Substring(0, annotation.Length / 2);
            connexionBD.MettreAJourContact(idUtilisateur, idContact, annotation);

        }
        public string RetourneAnnotationContact(string[] donnee)
        {
            utilisateur = RetournePseudoUtilisateur(donnee);
            contact = RetournePseudoContact(donnee);
            int idUtilisateur = connexionBD.retourneIdUser(utilisateur);
            int idContact = connexionBD.retourneIdUser(contact);
            string annotation = connexionBD.InfoContactAnnotation(idUtilisateur, idContact);
            return annotation;


        }
    }
}

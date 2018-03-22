﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
//Librairie MySQL ajoutée dans les références
using MySql.Data.MySqlClient;
namespace MyTcpListener
{
    public class ConnexionBD
    {
        private MySqlConnection connection;

        public ConnexionBD()
        {
            this.InitConnexion();
        }

        private void InitConnexion()
        {
            string connectionString = "SERVER=127.0.0.1;DATABASE=chatApplication;UID=root;PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }

        #region CONSTRUCTEURS

        public void UpdateOrDelete(string requete)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = requete;

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
        public string SelectSimple(string requete)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = requete;


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string reponse = string.Empty;

            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                reponse = String.Format("{0}", cmdReader[0]);
            }


            this.connection.Close();

            return reponse;
        }
        public string SelectDoubleWhile(string requete)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = requete;
            string reponse = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse += String.Format("{0}", cmdReader[0]) + "/"+ string.Format("{0}", cmdReader[1]) + ",";
            }

            this.connection.Close();
            return reponse;
        }

        public string SelectDoubleWhile2(string requete)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = requete;
            string reponse = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse += String.Format("{0}",cmdReader[0])  + " "+ "$" + string.Format("{0}", cmdReader[1]) + "*";
            }

            this.connection.Close();
            return reponse;
        }

        public string SelectSimpleWhile(string requete)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = requete;
            string reponse = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse += String.Format("{0}", cmdReader[0]) + ",";
            }

            this.connection.Close();
            return reponse;
        }
        #endregion

        #region UPDATE

        public void UpdateParticipationDiscussions(int idDiscussion, int idUtilisateur)
        {
            string statut = "Participe";
            string requete = "UPDATE participationdiscussions SET fkUser =\"" +idUtilisateur +"\", fkDiscussion =\"" + idDiscussion +"\" ,statut =\"" + statut + "\" where fkDiscussion =\"" +idDiscussion + "\" and fkUser =\"" + idUtilisateur + "\"";
            UpdateOrDelete(requete);
        }

        /// <summary>
        /// Met a jour la table contact
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <param name="idContact"></param>
        /// <param name="annotation"></param>
        public void MettreAJourContact(int idUtilisateur, int idContact, string annotation)
        {
            string requete = "UPDATE contact SET fkUser =\"" + idUtilisateur + "\", fkUserContact =\"" + idContact + "\", contactNote =\"" + annotation + "\" where fkUser =\"" + idUtilisateur + "\" and fkUserContact =\"" + idContact + "\"";
            UpdateOrDelete(requete);
        }

        /// <summary>
        /// Met a jour la table user
        /// </summary>
        /// <param name="user"></param>
        public void UpdateProfil(User user)
        {
            string requete = "UPDATE User SET userName =\"" + user.Nom + "\", userFirstName =\"" + user.Prenom + "\", userDescription =\"" + user.Description + "\", userPhoto =\"" + user.Photo + "\" where userPseudonym =\"" + user.Pseudo + "\"";
            UpdateOrDelete(requete);
        }
        #endregion

        #region DELETE

        /// <summary>
        /// Supprime une demande de contact
        /// </summary>
        /// Est utilisé lorsqu'une demande de contact est acceptée
        /// <param name="idUser"></param>
        /// <param name="idContact"></param>
        public void SupprimerDemandeContact(int idUser, int idContact)
        {

            string requete = "DELETE FROM demandescontacts WHERE fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"";
            UpdateOrDelete(requete);
        }

        /// <summary>
        /// Supprime un contact
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idContact"></param>
        public void SupprimerContact(int idUser, int idContact)
        {
            string requete = "DELETE FROM contact WHERE fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"";
            UpdateOrDelete(requete);
        }

        public void SupprimerParticipationDiscussion(int idDiscussion, int idUtilisateur)
        {
            string requete = "DELETE FROM participationDiscussions WHERE fkUser =\"" + idUtilisateur + "\" and fkDiscussion =\"" + idDiscussion + "\"";
            UpdateOrDelete(requete);
        }
        #endregion

        #region SELECT

        /// <summary>
        /// Sélectionne le champ contactNote de la table contact
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <param name="idContact"></param>
        /// <returns></returns>
        public string InfoContactAnnotation(int idUtilisateur, int idContact)
        {
            string requete = "SELECT contactNote from contact where fkUser =\"" + idUtilisateur + "\" and fkUserContact =\"" + idContact + "\"";
            string annotation = SelectSimple(requete);
            return annotation;
        }

        public string SelectionneIdUserMessages(int idDiscussion)
        {
            string requete = "SELECT fkUser from message where fkDiscussion =\"" + idDiscussion + "\" ORDER BY sendTime";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }

        public string SelectionneMessages(int idDiscussion)
        {
            string requete = "SELECT sendTime, messageContent from message where fkDiscussion =\"" + idDiscussion + "\" ORDER BY sendTime";
            string reponse = SelectDoubleWhile2(requete);
            if(reponse != string.Empty)
            {
                reponse = reponse.Substring(0, reponse.Length - 1);
            }
            
            return reponse;
        }

        /// <summary>
        /// Selectionne le champ userPseudonym de la table user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string InfoProfilPseudo(User user)
        {
            string requete = "SELECT userPseudonym from user where userPseudonym =\"" + user.Pseudo + "\"";
            string pseudo = SelectSimple(requete);
            return pseudo;
        }

        public string GetNomDiscussion(int idDiscussion)
        {
            string requete = "SELECT discussionName from discussion where idDiscussion =\"" + idDiscussion + "\"";
            string nomTrouve = SelectSimple(requete);
            return nomTrouve;
        }

        public string VerifieNomDiscussion(string nom)
        {
            string requete = "SELECT discussionName from discussion where discussionName =\"" + nom + "\"";
            string nomTrouve = SelectSimple(requete);
            return nomTrouve;
        }

        /// <summary>
        /// Selectionne le champ userFirstName de la table user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string InfoProfilPrenom(User user)
        {
            string requete = "SELECT userFirstName from user where userPseudonym =\"" + user.Pseudo + "\"";
            string prenom = SelectSimple(requete);
            return prenom;
        }

        /// <summary>
        /// Selectionne le champ userName de la table user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string InfoProfilNom(User user)
        {
            string requete = "SELECT userName from user where userPseudonym =\"" + user.Pseudo + "\"";
            string nom = SelectSimple(requete);
            return nom;
        }


        public string InfoProfilDescription(User user)
        {
            string requete = "SELECT userDescription from user where userPseudonym =\"" + user.Pseudo + "\"";
            string description = SelectSimple(requete);
            return description;
        }


        public string InfoProfilPhoto(User user)
        {
            string requete = "SELECT userPhoto from user where userPseudonym =\"" + user.Pseudo + "\"";
            string photo = SelectSimple(requete);
            return photo;
        }


        public string CheminDocumentation()
        {
            string requete = "SELECT path from Documentation";
            string path = SelectSimple(requete);
            return path;
        }


        public string GetMotDePasse(User user)
        {
            string requete = "SELECT userPassword from user where userPseudonym =\"" + user.Pseudo + "\"";
            string mdp = SelectSimple(requete);
            return mdp;
        }


        public int getFkUser(User user)
        {
            string requete = "SELECT idUser from user where userPseudonym =\"" + user.Pseudo + "\"";
            string id = SelectSimple(requete);
            int idUtilisateur = int.Parse(id);
            return idUtilisateur;
        }


        public string getPseudoDemandes(int id)
        {
            string requete = "SELECT userPseudonym from user where idUser =\"" + id + "\"";
            string pseudo = SelectSimple(requete);
            return pseudo;
        }


        public string getUserPseudo(int fk)
        {
            string requete = "SELECT userPseudonym from user where idUser =\"" + fk + "\"";
            string pseudo = SelectSimple(requete);
            return pseudo;
        }

        /// <summary>
        /// Utilisé pour ajouter l'administrateur ou les participants a une discussion
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public string SelectionneIdDiscussion(string nom)
        {
            string requete = "SELECT idDiscussion from discussion where discussionName =\"" + nom + "\"";
            string idDiscussion = SelectSimple(requete);
            return idDiscussion;
        }

        public string SelectionneIdContacts(int idUser)
        {
            string requete = "SELECT fkUserContact from contact where fkUser =\"" + idUser + "\"";
            string idList = SelectSimpleWhile(requete);
            return idList;
        }


        //Il faut que la requête retourne tous les resultats pas seulement le premier
        //Ne prend que 1 seul fk en paramètres, peut donc pas retourner plusieurs resultats
        public string getDemandesFkUserContact(int fk, string statut)
        {
            string requete = "SELECT fkUserContact from demandescontacts where fkUser =\"" + fk + "\" and Statut =\"" + statut + "\"";
            string id = SelectSimpleWhile(requete);
            return id;
        }

        public string SelectionneIdArchive(int idUtilisateur)
        {
            string requete = "SELECT fkDiscussion from archives where fkUser =\"" + idUtilisateur + "\"";
            string idDiscussion = SelectSimpleWhile(requete);
            if (idDiscussion != string.Empty)
            {
                idDiscussion = idDiscussion.Substring(0, idDiscussion.Length - 1);
            }

            return idDiscussion;
        }
        public string SelectionneIdDiscussion(int idUtilisateur, string statut)
        {
            
            string requete = "SELECT fkDiscussion from participationdiscussions where fkUser =\"" + idUtilisateur + "\" and statut =\"" + statut + "\"";
            string idDiscussion = SelectSimpleWhile(requete);
            if(idDiscussion != string.Empty)
            {
                idDiscussion = idDiscussion.Substring(0, idDiscussion.Length - 1);
            }

            return idDiscussion;
        }

        public string SelectionneIdUserNomDiscussionEnAttente(int idAdministrateur)
        {
            string statut = "En attente";
            string requete = "SELECT fkUser, fkDiscussion from participationdiscussions where fkAdministrateur =\"" + idAdministrateur + "\" and statut =\"" + statut + "\"";
            string reponse = SelectDoubleWhile(requete);
            return reponse;
        }

        public string CompteNombreEnAttenteParDiscussion(int idDiscussion)
        {
            string requete = "SELECT COUNT(fkDiscussion) from participationdiscussions where fkDiscussion =\"" + idDiscussion + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        public string GetIdParticipantsDiscussion(string idDiscussion)
        {
            string requete = "SELECT fkUser from participationdiscussions where fkDiscussion = \"" + idDiscussion + "\"";
            string reponse = SelectSimpleWhile(requete);
            reponse = reponse.Substring(0, reponse.Length - 1);
            return reponse;
        }

        public string GetIdAdminParticipantsDiscussion(string idDiscussion)
        {
            string requete = "SELECT fkAdministrateur from participationdiscussions where fkDiscussion = \"" + idDiscussion + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        public string UserExistant(User user)
        {
            string _pseudoTrouve = "";
            string _pseudoRetourne = "";
            try
            {
                //ouverture de la connexion SQL
                this.connection.Open();

                //Création d'une commande SQL en fonction de l'object connection
                MySqlCommand cmd = this.connection.CreateCommand();

                //Requête SQL
                cmd.CommandText = "SELECT userPseudonym from user where userPseudonym =\"" + user.Pseudo + "\"";

                //Exécution de la commande SQL
                cmd.ExecuteNonQuery();



                var cmdReader = cmd.ExecuteReader();
                while (cmdReader.Read())
                {
                    for (int i = 0; i < cmdReader.FieldCount; i++)
                    {
                        _pseudoTrouve = cmdReader.GetString(0);

                        if (_pseudoTrouve == user.Pseudo)
                        {
                            _pseudoRetourne = _pseudoTrouve;
                        }
                    }

                }
                //Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {

            }
            return _pseudoRetourne;

        }



        public bool connexionUser(User user)
        {
            bool userExistant;

            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();



            //Requête SQL
            cmd.CommandText = "SELECT userPassword from user where userPseudonym =\"" + user.Pseudo + "\"";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string mdp = string.Empty;


            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                mdp = String.Format("{0}", cmdReader[0]);
            }
            if (VerifMotDePasse(mdp, user))
            {
                userExistant = true;
            }
            else
            {
                userExistant = false;
            }

            this.connection.Close();

            return userExistant;
        }
        #endregion

        #region INSERT
        
        //TODO REDONDANCE DANS LA BASE DE DONNEE SUPPRIMER LA TABLE DEMANDECONTACT ET AJOUTE UN CHAMP STATUT A LA TABLE CONTACT
        //TODO AJOUTER LES DEMANDES DE DISCUSSIONS
        //TODO CHANGER LE STATUT QUAND ILS ACCEPTENT LA DEMANDE
        //TODO SUPPRIMER LA PARTICIPATIONDISCUSSION QUAND ILS REFUSENT LA DEMANDE
        //TODO CREER UN ADMINISTRATEUR POUR CHAQUE DISCUSSION, L'ADMIN SERA LE CREATEUR
        //TODO AJOUTER LES DISCUSSION QUAND ILS ACCEPTENT LA DEMANDE
        //TODO SUPPRIMER LES DISCUSSIONS QUAND ILS LES SUPPRIMENT
        //TODO AJOUTER DANS ARCHIVES QUAND ILS LES ARCHIVENT
        //TODO AJOUTER DANS DISCUSSION QUAND ILS LES ACTUALISENT
        public void CreerParticipationDisucssion(int idUser, int idDiscussion, int idAdministrateur, string statut)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO participationdiscussions(fkUser,fkDiscussion,fkAdministrateur,statut) VALUES(@fkUser,@fkDiscussion,@fkAdministrateur,@statut)";
            cmd.Parameters.AddWithValue("@fkUser", idUser);
            cmd.Parameters.AddWithValue("@fkDiscussion", idDiscussion);
            cmd.Parameters.AddWithValue("@fkAdministrateur", idAdministrateur);
            cmd.Parameters.AddWithValue("@statut", statut);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public void AjouterArchive(int idDiscussion, int idAdministrateur, int idUtilisateur)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO archives(fkDiscussion,fkUser,fkAdministrateur) VALUES(@fkDiscussion,@fkUser,@fkAdministrateur)";
            cmd.Parameters.AddWithValue("@fkDiscussion", idDiscussion);
            cmd.Parameters.AddWithValue("@fkUser", idUtilisateur);
            cmd.Parameters.AddWithValue("@fkAdministrateur", idAdministrateur);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public void CreerDiscussion(string nom)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO discussion(discussionName) VALUES(@discussionName)";
            cmd.Parameters.AddWithValue("@discussionName", nom);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }
     
        
        public void ajouterMessage(string message, DateTime date, int idDiscussion, int idUser)
        {
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO message(messageContent,sendTime,fkDiscussion,fkUser) VALUES(@messageContent,@sendTime,@fkDiscussion,@fkUser)";

            cmd.Parameters.AddWithValue("@messageContent", message);
            cmd.Parameters.AddWithValue("@sendTime", date);
            cmd.Parameters.AddWithValue("@fkDiscussion", idDiscussion);
            cmd.Parameters.AddWithValue("@fkUser", idUser);

            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public void ajoutUser(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "INSERT INTO user(userName,userFirstName,userPseudonym,userDescription,userPassword,userPhoto) VALUES(@userName,@userFirstName,@userPseudonym,@userDescription,@userPassword,@userPhoto)";

            // utilisation de l'objet user passé en paramètre
            cmd.Parameters.AddWithValue("@userName", user.Nom);
            cmd.Parameters.AddWithValue("@userFirstName", user.Prenom);
            cmd.Parameters.AddWithValue("@userPseudonym", user.Pseudo);
            cmd.Parameters.AddWithValue("@userDescription", user.Description);
            cmd.Parameters.AddWithValue("@userPassword", user.MotDePasse);
            cmd.Parameters.AddWithValue("@userPhoto", user.Photo);
            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            this.connection.Close();
        }


        public void ajoutDemandeContact(int fkUser, int fkUserContact, string statut)
        {

            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "INSERT INTO demandescontacts(fkUser,fkUserContact, Statut) VALUES(@fkUser, @fkUserContact,@Statut)";

            //utilisation de l'objet contact passé en paramètre
            cmd.Parameters.AddWithValue("@Statut", statut);
            cmd.Parameters.AddWithValue("@fkUser", fkUser);
            cmd.Parameters.AddWithValue("@fkUserContact", fkUserContact);

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            this.connection.Close();

        }


        public void ContactAccepterAjouterContact(int idUser, int idContact)
        {
            this.connection.Open();

            MySqlCommand cmd2 = this.connection.CreateCommand();

            cmd2.CommandText = "INSERT INTO contact(contactNote, fkUser, fkUserContact) VALUES (@contactNote, @fkUser, @fkUserContact)";
            cmd2.Parameters.AddWithValue("@ContactNote", string.Empty);
            cmd2.Parameters.AddWithValue("@fkUser", idUser);
            cmd2.Parameters.AddWithValue("@fkUserContact", idContact);

            cmd2.ExecuteNonQuery();
            this.connection.Close();
        }
        #endregion

        #region MOT DE PASSE
        //MOT DE PASSE SUREMENT RIEN A FAIRE LA


        public string HashMotDePasse(User user)
        {
            //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
            string savedPasswordHash;
            // Création du sel
            byte[] sel;
            new RNGCryptoServiceProvider().GetBytes(sel = new byte[16]);

            //
            var pbkdf2 = new Rfc2898DeriveBytes(user.MotDePasse, sel, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            //
            byte[] hashBytes = new byte[36];
            Array.Copy(sel, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //
            return savedPasswordHash = Convert.ToBase64String(hashBytes);
        }


        public bool VerifMotDePasse(string motDePasse, User user)
        {
            bool motsDePasseCorrects = false;
            try
            {
                //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
                string motDePasseHash = motDePasse;

                byte[] hashBytes = Convert.FromBase64String(motDePasseHash);

                byte[] sel = new byte[16];
                Array.Copy(hashBytes, 0, sel, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(user.MotDePasse, sel, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        motsDePasseCorrects = false;
                    }
                    else
                    {
                        motsDePasseCorrects = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur" + e.Message);
            }

            Console.WriteLine(motsDePasseCorrects);
            return motsDePasseCorrects;
        }
        #endregion








    }
}
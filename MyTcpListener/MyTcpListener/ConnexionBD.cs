using System;
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
        /// <summary>
        /// Pour tous les update ou delete
        /// </summary>
        /// <param name="requete"></param>
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

        /// <summary>
        /// Selectionne 1 seul champ 1 seul fois
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Selectionne deux champs "plusieurs" fois
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Selectionne 3 champs "plusieurs" fois
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
        public string SelectTripleWhile(string requete)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = requete;
            string reponse = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse += String.Format("{0}", cmdReader[0]) + " " + "$" + string.Format("{0}", cmdReader[1]) + " " + "$" + string.Format("{0}", cmdReader[2])+ "*";
            }

            this.connection.Close();
            return reponse;
        }

        /// <summary>
        /// Selectionne un champ "plusieurs" fois + like
        /// </summary>
        /// <param name="requete"></param>
        /// <param name="param"></param>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public string SelectSimpleWhileLike(string requete, string param, string valeur)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = requete;
            cmd.Parameters.AddWithValue(param, valeur + "%");
            string reponse = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                reponse += String.Format("{0}", cmdReader[0]) + ",";
            }

            this.connection.Close();
            return reponse;
        }

        /// <summary>
        /// Selectionne 1 champ "plusieurs" fois
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update le champ statut de participationdiscussions de "En attente" à "Participe"
        /// </summary>
        /// Utilisé lorsqu'une demande de discussion est acceptée
        /// <param name="idDiscussion"></param>
        /// <param name="idUtilisateur"></param>
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
        /// Est utilisé lorsqu'une demande de contact est acceptée ou refusée
        /// <param name="idUser"></param>
        /// <param name="idContact"></param>
        public void SupprimerDemandeContact(int idUser, int idContact)
        {
            string requete = "DELETE FROM demandescontacts WHERE fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"";
            UpdateOrDelete(requete);
        }

        /// <summary>
        /// Supprime une archive
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idDiscussion"></param>
        public void SupprimerArchive(int idUser, int idDiscussion)
        {
            string requete = "DELETE FROM archives WHERE fkUser =\"" + idUser + "\" and fkDiscussion =\"" + idDiscussion + "\"";
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

        /// <summary>
        /// Supprime une demande de participation à une discussion
        /// </summary>
        /// Est utilisé lorsqu'une demande de discussion est refusée
        /// <param name="idDiscussion"></param>
        /// <param name="idUtilisateur"></param>
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
        public string SelectionneInfoContactAnnotation(int idUtilisateur, int idContact)
        {
            string requete = "SELECT contactNote from contact where fkUser =\"" + idUtilisateur + "\" and fkUserContact =\"" + idContact + "\"";
            string annotation = SelectSimple(requete);
            return annotation;
        }

        /// <summary>
        /// Selectionne les idDiscussion auquel participe un user
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <param name="idPseudo"></param>
        /// <returns></returns>
        public string SelectionneIdDiscussionDejaParticipant(string idDiscussion, int idPseudo)
        {
            string statut = "Participe";
            string requete = "SELECT fkDiscussion from participationdiscussions where fkDiscussion =\"" + idDiscussion + "\" and fkUser =\"" + idPseudo + "\" and statut =\"" + statut + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne les noms des discussions correspondants à une categorie
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public string SelectionneNomDiscussionParCategorie(string categorie)
        {
            string requete = "SELECT discussionName from discussion_has_category inner join discussion on idDiscussion = discussion_has_category.fkDiscussion inner join category on idCategory = discussion_has_category.fkCategory where categoryName =\"" + categorie + "\"";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne les ids des discussions correspondants à une categorie
        /// </summary>
        /// <param name="idCategory"></param>
        /// <returns></returns>
        public string SelectionneIdDiscussionParIdCategorie(int idCategory)
        {
            string requete = "SELECT fkDiscussion from discussion_has_category where fkCategory =\"" + idCategory + "\"";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne les categories correspondants a la chaine de caractère categoriesRecherchees
        /// </summary>
        /// <param name="categoriesRecherchees"></param>
        /// <returns></returns>
        public string SelectionneCategoriesRecherchees(string categoriesRecherchees)
        {
            string requete =  "SELECT categoryName from category where categoryName LIKE @categoriesRecherchees";
           
            string reponse = SelectSimpleWhileLike(requete, "@categoriesRecherchees", categoriesRecherchees);
            return reponse;
        }

        /// <summary>
        /// Selectionne les catégories proposées = les 10 premières catégories
        /// </summary>
        /// <returns></returns>
        public string SelectionnCategorieProposee()
        {
            string requete = "SELECT categoryName from category where idCategory < 11";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne le pseudo de l'administrateur correspondant à un nom de discussion
        /// </summary>
        /// <param name="nomDiscussion"></param>
        /// <returns></returns>
        public string selectionnePseudoAdministrateur(string nomDiscussion)
        {
            string requete = "SELECT distinct userPseudonym from participationdiscussions inner join user on idUser = fkAdministrateur inner join discussion on idDiscussion = fkDiscussion where discussionName =\"" + nomDiscussion + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        /// <summary>
        /// Retourne tous les messages d'une discussion dans l'ordre d'envoi
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <returns></returns>
        public string SelectionneMessages(int idDiscussion)
        {
            string requete = "SELECT userPseudonym, sendTime, messageContent from message inner join user on idUser = fkUser where fkDiscussion =\"" + idDiscussion + "\" ORDER BY sendTime";
            string reponse = SelectTripleWhile(requete);
            if(reponse != string.Empty)
            {
                reponse = reponse.Substring(0, reponse.Length - 1);
            }
            return reponse;
        }

        /// <summary>
        /// Selectionne le nom d'une discussion correspondant à un idDiscussion
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <returns></returns>
        public string SelectionneNomDiscussion(int idDiscussion)
        {
            string requete = "SELECT discussionName from discussion where idDiscussion =\"" + idDiscussion + "\"";
            string nomTrouve = SelectSimple(requete);
            return nomTrouve;
        }

        /// <summary>
        /// Selectionne le nom d'une discussion correspondant à un DiscussionName
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public string VerifieNomDiscussion(string nom)
        {
            string requete = "SELECT discussionName from discussion where discussionName =\"" + nom + "\"";
            string nomTrouve = SelectSimple(requete);
            return nomTrouve;
        }

        /// <summary>
        /// Selectionne le prenom d'un utilisateur correspondant à un pseudo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string RetourneInfoProfilPrenom(User user)
        {
            string requete = "SELECT userFirstName from user where userPseudonym =\"" + user.Pseudo + "\"";
            string prenom = SelectSimple(requete);
            return prenom;
        }

        /// <summary>
        /// Selectionne le nom d'un utilisateur correspondant à un pseudo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string RetourneInfoProfilNom(User user)
        {
            string requete = "SELECT userName from user where userPseudonym =\"" + user.Pseudo + "\"";
            string nom = SelectSimple(requete);
            return nom;
        }

        /// <summary>
        /// Selectionne la description d'un utilisateur correspondant à un pseudo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string RetourneInfoProfilDescription(User user)
        {
            string requete = "SELECT userDescription from user where userPseudonym =\"" + user.Pseudo + "\"";
            string description = SelectSimple(requete);
            return description;
        }

        /// <summary>
        /// Selectionne le mot de passe d'un utilisateur correspondant à un pseudo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string SelectionneMotDePasse(User user)
        {
            string requete = "SELECT userPassword from user where userPseudonym =\"" + user.Pseudo + "\"";
            string mdp = SelectSimple(requete);
            return mdp;
        }

        /// <summary>
        /// Selectionne l'id d'un utilisateur correspondant à un pseudo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int SelectionneIdUser(User user)
        {
            string requete = "SELECT idUser from user where userPseudonym =\"" + user.Pseudo + "\"";
            string id = SelectSimple(requete);
            int idUtilisateur = int.Parse(id);
            return idUtilisateur;
        }

        /// <summary>
        /// Selectionne l'id d'une catégorie correspondant à un nom de catégorie
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public string SelectionneIdCategory(string nom)
        {
            string requete = "SELECT idCategory from category where categoryName = \"" + nom + "\"";
            string idCategory = SelectSimple(requete);
            return idCategory;
        }

        /// <summary>
        /// Selectionne l'id d'une discussion correspondant à un nom de discussion
        /// </summary>
        /// Utilisé pour ajouter l'administrateur ou les participants a une discussion
        /// <param name="nom"></param>
        /// <returns></returns>
        public string SelectionneIdDiscussion(string nom)
        {
            string requete = "SELECT idDiscussion from discussion where discussionName =\"" + nom + "\"";
            string idDiscussion = SelectSimple(requete);
            return idDiscussion;
        }

        /// <summary>
        /// Selectionne idContact en fonction de fkUser et fkUserContact
        /// </summary>
        /// <param name="idContact"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public string SelectionneContactDejaAjoute(int idContact, int idUser)
        {
            string requete = "SELECT idContact from contact where fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne les pseudos des contacts en fonction d'un idUtilisateur
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public string SelectionnePseudoContact(int idUser)
        {
            string requete = "SELECT userPseudonym from contact INNER JOIN user ON fkUserContact = idUser where fkUser =\"" + idUser + "\"";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }


        /// <summary>
        /// Selectionne les pseudos des contacts en fonction des demandes (recues ou envoyees)
        /// </summary>
        /// <param name="fk"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
        public string RetourneDemandesPseudosContacts(int fk, string statut)
        {
            //string requete = "SELECT fkUserContact from demandescontacts where fkUser =\"" + fk + "\" and Statut =\"" + statut + "\"";
            string requete = "SELECT userPseudonym from demandescontacts INNER JOIN user ON fkUserContact = idUser where fkUser =\"" + fk + "\" and Statut =\"" + statut + "\"";
            string id = SelectSimpleWhile(requete);
            return id;
        }

        /// <summary>
        /// Selectionne le nom d'une categorie en fonction d'un nom de categorie
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public string SelectionneICategorie(string categorie)
        {
            string requete = "SELECT categoryName from category where categoryName =\"" + categorie + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne les pseudos des utilisateurs participants à une discussion correspondant à un nom de discussion
        /// </summary>
        /// <param name="nomDiscussion"></param>
        /// <returns></returns>
        public string SelectionneNomParticipantsDiscussion(string nomDiscussion)
        {
            string statut = "Participe";
            string requete = "SELECT userPseudonym from participationdiscussions inner join user on idUser = fkUser inner join discussion on idDiscussion = fkDiscussion where statut =\"" + statut + "\" and discussionName =\"" + nomDiscussion + "\"";
            string reponse = SelectSimpleWhile(requete);
            reponse = reponse.Substring(0, reponse.Length - 1);
            return reponse;
        }

        /// <summary>
        /// Selectionne le nom de la discussion auquel participe ou va participer un user
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
        public string SelectionneNomDiscussion(int idUtilisateur, string statut)
        {
            string requete = "SELECT discussionName from participationdiscussions inner join discussion on idDiscussion = fkDiscussion where fkUser =\"" + idUtilisateur + "\" and statut =\"" + statut + "\"";
            string idDiscussion = SelectSimpleWhile(requete);
            if (idDiscussion != string.Empty)
            {
                idDiscussion = idDiscussion.Substring(0, idDiscussion.Length - 1);
            }
            return idDiscussion;
        }

        /// <summary>
        /// Selectionne les ids des discussions correspondant à un utilisateur et un statut
        /// </summary>
        /// <param name="idUtilisateur"></param>
        /// <param name="statut"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Selectionne les noms des utilisateurs et des discussions correpsondant à un administrateur
        /// </summary>
        /// <param name="idAdministrateur"></param>
        /// <returns></returns>
        public string SelectionnePseudoUserNomDiscussionEnattente(int idAdministrateur)
        {
            string statut = "En attente";
            string requete = "SELECT userPseudonym, discussionName from participationdiscussions inner join user on fkUser = idUser inner join discussion on idDiscussion = fkDiscussion where fkAdministrateur =\"" + idAdministrateur + "\" and statut =\"" + statut + "\"";
            string reponse = SelectDoubleWhile(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne le nom des archives correspondant à un utilisateur
        /// </summary>
        /// <param name="pseudoUtilisateur"></param>
        /// <returns></returns>
        public string SelectionneArchive(string pseudoUtilisateur)
        {
            string requete = "SELECT discussionName from archives inner join discussion on idDiscussion = archives.fkDiscussion inner join user on idUser = archives.fkUser where userPseudonym =\"" + pseudoUtilisateur + "\"";
            string reponse = SelectSimpleWhile(requete);
            return reponse;
        }

        /// <summary>
        /// Selectionne le nombre de personne participants à une discussion correspondant à un idDiscussion
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <returns></returns>
        public string CompteNombreParDiscussion(int idDiscussion)
        {
            string requete = "SELECT COUNT(fkDiscussion) from participationdiscussions where fkDiscussion =\"" + idDiscussion + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }


        /// <summary>
        /// Selectionne l'id de l'administrateur d'une discussion en fonction de l'idDiscussion
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <returns></returns>
        public string SelectionneIdAdministrateur(string idDiscussion)
        {
            string requete = "SELECT fkAdministrateur from participationdiscussions where fkDiscussion = \"" + idDiscussion + "\"";
            string reponse = SelectSimple(requete);
            return reponse;
        }

        /// <summary>
        /// Sert a verifier si un pseudo est deja utilisé ou non
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string UserExisteIl(User user)
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

        #endregion

        #region INSERT
        

        /// <summary>
        /// Crée la participation à la discussion
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idDiscussion"></param>
        /// <param name="idAdministrateur"></param>
        /// <param name="statut"></param>
        public void AjouterParticipationDisucssion(int idUser, int idDiscussion, int idAdministrateur, string statut)
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

        /// <summary>
        /// Crée une archive
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <param name="idAdministrateur"></param>
        /// <param name="idUtilisateur"></param>
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

        /// <summary>
        /// Crée le  lien entre la categorie et la discussion
        /// </summary>
        /// <param name="idDiscussion"></param>
        /// <param name="idCategory"></param>
        public void AjouterLienCategorieDiscussion(int idDiscussion, int idCategory)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Discussion_has_Category(fkDiscussion, fkCategory) VALUES (@fkDiscussion,@fkCategory)";
            cmd.Parameters.AddWithValue("@fkDiscussion", idDiscussion);
            cmd.Parameters.AddWithValue("@fkCategory", idCategory);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        /// <summary>
        /// Crée une catégorie
        /// </summary>
        /// <param name="categorie"></param>
        public void AjouterDiscussion(string categorie)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO category(categoryName) VALUES (@categoryName)";
            cmd.Parameters.AddWithValue("@categoryName", categorie);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        /// <summary>
        /// Crée une discussion
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="publique"></param>
        public void AjouterDiscussion(string nom, bool publique)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "INSERT INTO discussion(discussionName, publique) VALUES(@discussionName,@publique)";
            cmd.Parameters.AddWithValue("@discussionName", nom);
            cmd.Parameters.AddWithValue("@publique", publique);
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }
     
        /// <summary>
        /// Crée un message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="date"></param>
        /// <param name="idDiscussion"></param>
        /// <param name="idUser"></param>
        public void AjouterMessage(string message, DateTime date, int idDiscussion, int idUser)
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

        /// <summary>
        /// Crée un utilisateur
        /// </summary>
        /// <param name="user"></param>
        public void AjouterUser(User user)
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

        /// <summary>
        /// Crée une demande de contact
        /// </summary>
        /// <param name="fkUser"></param>
        /// <param name="fkUserContact"></param>
        /// <param name="statut"></param>
        public void AjouterDemandeContact(int fkUser, int fkUserContact, string statut)
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

        /// <summary>
        /// Crée un contact
        /// </summary>
        /// Utilisé lorsqu'une demande de contact est acceptée
        /// <param name="idUser"></param>
        /// <param name="idContact"></param>
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

        /// <summary>
        /// Permet de hasher le mdp
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Permet de verifier que le mot de passe entré correpsond à celui de l'utilisateur
        /// </summary>
        /// <param name="motDePasse"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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
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
        public int getFkUser(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT idUser from user where userPseudonym =\"" + user.Pseudo + "\"";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string id = string.Empty;
            int idUser;

            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                id = String.Format("{0}", cmdReader[0]);
            }
            idUser = int.Parse(id);

            this.connection.Close();

            return idUser;
        }
        public string getPseudoDemandes(int id)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userPseudonym from user where idUser =\"" + id + "\"";

            string pseudo = string.Empty;
            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();
            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                pseudo = string.Format("{0}", cmdReader[0]);
            }

            this.connection.Close();
            return pseudo;
        }

        public string getUserPseudo (int fk)
        {
            
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userPseudonym from user where idUser =\"" + fk + "\"";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string pseudo = string.Empty;


            var cmdReader = cmd.ExecuteReader();

            if(cmdReader.Read())
            {
                pseudo = String.Format("{0}", cmdReader[0]);
            }
            Console.WriteLine("Demandes de contacts trouvées : {0}", pseudo);

            this.connection.Close();
            return pseudo;
        }

        //Il faut que la requête retourne tous les resultats pas seulement le premier
        //Ne prend que 1 seul fk en paramètres, peut donc pas retourner plusieurs resultats
        public string getDemandesFkUserContact(int fk, string statut)
        {
            
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT fkUserContact from demandescontacts where fkUser =\"" + fk + "\" and Statut =\"" + statut +"\"";


            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string id = string.Empty;
        

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                id += String.Format("{0}", cmdReader[0]) + ",";
                
            }
            Console.WriteLine("Demandes de contacts trouvées : {0}", id);
            this.connection.Close();
            Console.WriteLine("Retour sql : {0}", id);
            return id;
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
        public string CheminDocumentation()
        {

            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT path from Documentation";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string path = "";

            var cmdReader = cmd.ExecuteReader();
            if (cmdReader.Read())
            {
                path = String.Format("{0}", cmdReader[0]);
            }

            this.connection.Close();

            return path;
        }

        public string DemandeMotDePasse(User user)
        {
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

            this.connection.Close();

            return mdp;
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

        public string InfoProfilPseudo(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userPseudonym from user where userPseudonym =\"" + user.Pseudo + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string pseudo = "";

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                pseudo = cmdReader.GetString(0);
            }

            this.connection.Close();

            return pseudo;
        }

        public string InfoProfilPrenom(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userFirstName from user where userPseudonym =\"" + user.Pseudo + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string prenom = "";

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                prenom = cmdReader.GetString(0);
            }

            this.connection.Close();

            return prenom;
        }

        public string InfoProfilNom(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userName from user where userPseudonym =\"" + user.Pseudo + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string nom = "";

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                nom = cmdReader.GetString(0);
            }
            this.connection.Close();

            return nom;
        }

        public string InfoProfilDescription(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userDescription from user where userPseudonym =\"" + user.Pseudo + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string description = "";

            var cmdReader = cmd.ExecuteReader();

            while (cmdReader.Read())
            {
                description = cmdReader.GetString(0);
            }
            this.connection.Close();

            return description;
        }

        public string InfoProfilPhoto(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "SELECT userPhoto from user where userPseudonym =\"" + user.Pseudo + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            string photo = "";

            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                photo = cmdReader.GetString(0);
            }

            this.connection.Close();

            return photo;
        }

        public void UpdateProfil(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "UPDATE User SET userName =\"" + user.Nom + "\", userFirstName =\"" + user.Prenom + "\", userDescription =\"" + user.Description + "\", userPhoto =\"" + user.Photo + "\" where userPseudonym =\"" + user.Pseudo + "\"";

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

        public void ContactAccepteSupprimerDemandeRecue(int idUser, int idContact)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "DELETE FROM demandescontacts WHERE fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact +"\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }
        public void SupprimerContact(int idUser, int idContact)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "DELETE FROM contact WHERE fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"";

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

        public string SelectionneIdContacts(int idUser)
        {
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "SELECT fkUserContact from contact where fkUser =\"" + idUser + "\"";

            string idList = string.Empty;
            var cmdReader = cmd.ExecuteReader();
            while (cmdReader.Read())
            {
                idList += String.Format("{0}", cmdReader[0]) + ",";
            }
            
            this.connection.Close();
            return idList;
        }
        public void SupprimerDemandeContact(int idUser, int idContact, string statut)
        {
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            cmd.CommandText = "DELETE FROM demandescontacts where fkUser =\"" + idUser + "\" and fkUserContact =\"" + idContact + "\"and Statut =\"" + statut +"\"";

            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}
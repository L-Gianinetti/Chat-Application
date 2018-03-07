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
            //string motDePasse = HashMotDePasse(user);


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
    }
}
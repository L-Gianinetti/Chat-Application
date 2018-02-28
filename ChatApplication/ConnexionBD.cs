using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Librairie MySQL ajoutée dans les références
using MySql.Data.MySqlClient;
namespace ChatApplication
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
                    for(int i = 0; i < cmdReader.FieldCount; i++)
                    {
                        _pseudoTrouve = cmdReader.GetString(0);

                        if(_pseudoTrouve == user.Pseudo)
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

        public void ajoutUser(User user)
        {
            //ouverture de la connexion SQL
            this.connection.Open();

            //Création d'une commande SQL en fonction de l'object connection
            MySqlCommand cmd = this.connection.CreateCommand();

            //Requête SQL
            cmd.CommandText = "INSERT INTO user(userName,userFirstName,userPseudonym,userDescription,userPassword) VALUES(@userName,@userFirstName,@userPseudonym,@userDescription,@userPassword)";

            // utilisation de l'objet user passé en paramètre
            cmd.Parameters.AddWithValue("@userName", user.Nom);
            cmd.Parameters.AddWithValue("@userFirstName", user.Prenom);
            cmd.Parameters.AddWithValue("@userPseudonym", user.Pseudo);
            cmd.Parameters.AddWithValue("@userDescription", user.Description);
            cmd.Parameters.AddWithValue("@userPassword", user.MotDePasse);

            //Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            this.connection.Close();
        }
    }
}

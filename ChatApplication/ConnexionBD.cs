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
            string connectionString = "SERVER=127.0.0.1;DATABASE=quizz;UID=root;PASSWORD=";
            this.connection = new MySqlConnection(connectionString);
        }

        public string UserExistant(User user)
        {
            string _pseudoTrouve = "";
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
                if (cmdReader.Read())
                {
                    _pseudoTrouve = cmdReader.GetString(0);
                }
                //Fermeture de la connexion
                this.connection.Close();
            }
            catch
            {

            }
            return _pseudoTrouve;
        }
    }
}

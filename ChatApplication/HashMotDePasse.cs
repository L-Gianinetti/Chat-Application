using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace ChatApplication
{
    class HashMotDePasse
    {
        public string HashMDP(User user)
        {
            //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
            string savedPasswordHash;
            // Création du sel
            byte[] sel;
            new RNGCryptoServiceProvider().GetBytes(sel = new byte[16]);

            //
            var pbkdf2 = new Rfc2898DeriveBytes(user.MotDePasse, sel, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            //
            byte[] hashBytes = new byte[36];
            Array.Copy(sel, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //
            return savedPasswordHash = Convert.ToBase64String(hashBytes);
        }

        public bool connexionUser(string mdpEntre, string mdp)
        {
            bool userExistant;

            if (VerifMotDePasse(mdp, mdpEntre) == true)
            {
                userExistant = true;
            }
            else
            {
                userExistant = false;
            }

            return userExistant;
        }

        public bool VerifMotDePasse(string motDePasse, string motDePassEntre)
        {
            bool motsDePasseCorrects = false;
            try
            {
                //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
                

                byte[] hashBytes = Convert.FromBase64String(motDePasse);

                byte[] sel = new byte[16];
                Array.Copy(hashBytes, 0, sel, 0, 16);

                var pbkdf2 = new Rfc2898DeriveBytes(motDePassEntre, sel, 1000);
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

            Console.WriteLine("Les mdp sont : "+motsDePasseCorrects);
            return motsDePasseCorrects;
        }
    }
}

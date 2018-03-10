using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.Mail;
using System.Net.Security;


namespace ChatApplication
{
    public partial class frmEnregistrement2 : Form
    {
        User userEnregistrement = new User();
        //ConnexionBD connexionBD = new ConnexionBD();
        EnvoiMessage envoiMessage = new EnvoiMessage();
        HashMotDePasse hashMotDePasse = new HashMotDePasse();
        string motPasse;
        string motPasseApresHash;
        byte[] imageBytes;

        //Constructeur qui permet de récupérer les infos rentrées lors de frmEnregistrement1
        public frmEnregistrement2(string pseudonym, string motDePasse)
        {
            InitializeComponent();
            txtPseudo.Text = pseudonym;
            motPasse = motDePasse;
        }
        public frmEnregistrement2()
        {
            InitializeComponent();
        }


        private void cmdPhoto_Click(object sender, EventArgs e)
        {
            string fichier;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    fichier = openFileDialog1.FileName;
                    Console.WriteLine(fichier);
                    ptbPhoto.Image = Image.FromFile(fichier);
                    imageBytes = File.ReadAllBytes(fichier);
                }
                catch (IOException)
                {

                }


            }
        }



        private void cmdValider_Click(object sender, EventArgs e)
        {
            //Attribution des différents champs à l'utilisateur
            userEnregistrement.Nom = txtNom.Text;
            userEnregistrement.Prenom = txtPrenom.Text;
            userEnregistrement.Pseudo = txtPseudo.Text;
            userEnregistrement.Description = txtDescription.Text;
            //On attribue à l'utilisateur le mdp qu'il a rentré sur frmEnregistrement
            userEnregistrement.MotDePasse = motPasse;

            //Hashage du mdp et reattribution a l'utilisateur
            motPasseApresHash = hashMotDePasse.HashMDP(userEnregistrement);
            userEnregistrement.MotDePasse = motPasseApresHash;
            
            //Sera utile pour implémenter la photo de profil
            //bool photoExiste = ptbPhoto == null || ptbPhoto.Image == null;


            //Concaténation et envoi du message au serveur
            //Utilisation d'un nombre au début de la string pour que le serveur sache quelle(s) action(s) il doit effectuer
            string data = "01" + userEnregistrement.Pseudo + "," + userEnregistrement.MotDePasse + "," + userEnregistrement.Nom + "," + userEnregistrement.Prenom + "," + userEnregistrement.Description;
            envoiMessage.Connect("127.0.0.1", data);

        }

    }
}

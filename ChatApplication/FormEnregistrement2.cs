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
        ConnexionBD connexionBD = new ConnexionBD();
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
            userEnregistrement.Nom = txtNom.Text;
            userEnregistrement.Prenom = txtPrenom.Text;
            userEnregistrement.Pseudo = txtPseudo.Text;
            userEnregistrement.Description = txtDescription.Text;
            //A VERIFIER
            userEnregistrement.MotDePasse = motPasse;

            motPasseApresHash = hashMotDePasse.HashMDP(userEnregistrement);
            userEnregistrement.MotDePasse = motPasseApresHash;
            //motPasseApresHash = HashTest.Hash(userEnregistrement.MotDePasse);
            //userEnregistrement.MotDePasse = motPasseApresHash;
            Console.WriteLine(userEnregistrement.ToString());
            //string cheminImage = connexionBD.CheminDocumentation() + userEnregistrement.Photo;
            /*try
            {
                ptbPhoto.Image.Save(cheminImage);
            }
            catch(Exception er)
            {
                MessageBox.Show("Erreur" + er.Message);
            }*/

            //connexionBD.ajoutUser(userEnregistrement);
            bool photoExiste = ptbPhoto == null || ptbPhoto.Image == null;
            /*if (!photoExiste)
            {
                userEnregistrement.Photo = imageBytes;
            }*/


            string data = "1" + userEnregistrement.Pseudo + "," + userEnregistrement.MotDePasse + "," + userEnregistrement.Nom + "," + userEnregistrement.Prenom + "," + userEnregistrement.Description;
            //Send the message
            envoiMessage.Connect("127.0.0.1", data);

        }

        private void frmEnregistrement2_Load(object sender, EventArgs e)
        {

        }
    }
}

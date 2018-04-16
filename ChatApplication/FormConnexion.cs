using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ChatApplication
{
    public partial class frmConnexion : Form
    {
        User user = new User();
        HashMotDePasse hashMotDePasse = new HashMotDePasse();
        EnvoiMessage envoiMessage = new EnvoiMessage();
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Permet de remplir txtIdentifiant.Text avec le pseudo de l'utilisateur a la prochaine utilisation
            //fonctionne pas pour l'instant
            if (Properties.Settings.Default.Identifiant != string.Empty)
            {
                txtIdentifiant.Text = Properties.Settings.Default.Identifiant;
            }
        }

        /// <summary>
        /// Ouvre frmEnregistrement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSEnregistrer_Click(object sender, EventArgs e)
        {
            frmEnregistrement frmEnregistrement = new frmEnregistrement();
            frmEnregistrement.ShowDialog();
            DialogResult res = frmEnregistrement.DialogResult;
            if (res == DialogResult.OK)
            {
                frmEnregistrement.Close();
                frmEnregistrement.Dispose();
            }   
        }

        /// <summary>
        /// Ouvre le formulaire général si les identifiants rentrés sont corrects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnexion_Click(object sender, EventArgs e)
        {

            user.Pseudo = txtIdentifiant.Text;
            user.MotDePasse = txtPassword.Text;
            string data = "02" + user.Pseudo;
            //le serveur retourne le mdp correspondant a l'utilisateur
            string reponse = envoiMessage.Connect(data);  

            //Si le mdp rentré correspond a celui de la BD
            if (hashMotDePasse.connexionUser(txtPassword.Text, reponse) == true)
            {
                //Ouvre le formulaire général
                frmDiscussions frmDiscussions = new frmDiscussions(txtIdentifiant.Text);
                frmDiscussions.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mauvais identifiants !");
            }
            //https://social.msdn.microsoft.com/Forums/en-US/3f2877ab-0bce-4201-9acb-58df601345dc/how-to-do-remember-me-functionality-in-c-windows-application?forum=netfx64bit

            //Se souvenir du nom d'utilisateur a la prochaine connexion
            if (chkSeSouvenirDeMoi.Checked == true)
            {
                Properties.Settings.Default.Identifiant = txtIdentifiant.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}

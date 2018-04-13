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
        //ConnexionBD connexionBD = new ConnexionBD();
        User user = new User();
        HashMotDePasse hashMotDePasse = new HashMotDePasse();
        EnvoiMessage envoiMessage = new EnvoiMessage();
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Identifiant != string.Empty)
            {
                txtIdentifiant.Text = Properties.Settings.Default.Identifiant;
            }
        }


        private void cmdSEnregistrer_Click(object sender, EventArgs e)
        {
            frmEnregistrement frmEnregistrement = new frmEnregistrement();
            frmEnregistrement.ShowDialog();

            //frmEnregistrement2 frmEnregistrement2 = new frmEnregistrement2();

            //DialogResult res = frmEnregistrement2.DialogResult;
            DialogResult res = frmEnregistrement.DialogResult;
            if (res == DialogResult.OK)
            {
                frmEnregistrement.Close();
                //frmEnregistrement2.Close();
            }
            frmEnregistrement.Dispose();
        }

        private void cmdConnexion_Click(object sender, EventArgs e)
        {

            user.Pseudo = txtIdentifiant.Text;
            user.MotDePasse = txtPassword.Text;
            //string mdpHash = hashMotDePasse.HashMDP(user);
            string data = "02" + user.Pseudo;
            string reponse = envoiMessage.Connect(data);
            Console.WriteLine(reponse);

            if (hashMotDePasse.connexionUser(txtPassword.Text, reponse) == true)
            //if(HashTest.Verify(txtPassword.Text, reponse) == true)
            //if(txtPassword.Text == reponse)
            {

                Properties.Settings.Default.UserActif = txtIdentifiant.Text;
                Properties.Settings.Default.Save();
                frmDiscussions frmDiscussions = new frmDiscussions();
                frmDiscussions.ShowDialog();
            }
            else
            {
                MessageBox.Show("Mauvais identifiants !");
            }


            //https://social.msdn.microsoft.com/Forums/en-US/3f2877ab-0bce-4201-9acb-58df601345dc/how-to-do-remember-me-functionality-in-c-windows-application?forum=netfx64bit

            if (chkSeSouvenirDeMoi.Checked == true)
            {
                Properties.Settings.Default.Identifiant = txtIdentifiant.Text;
                Properties.Settings.Default.Save();
            }


        }
    }
}

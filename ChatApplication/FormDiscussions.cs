using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class frmDiscussions : Form
    {
        User user = new User();
        EnvoiMessage envoiMessage = new EnvoiMessage();
        public frmDiscussions()
        {
            InitializeComponent();
        }

        private void cmdProfil_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlProfil);
        }

        private void frmDiscussions_Load(object sender, EventArgs e)
        {
            montrerPannel(pnlDiscussions);
            chargerProfil();
            
        }
        public void chargerDemandes()
        {
            int i = 0;
            string demande = "7" + txtPseudo.Text;
            string reponse = envoiMessage.Connect("127.0.0.1", demande);
            string[] reponsesSeparees = reponse.Split(',');
            foreach(string donnee in reponsesSeparees)
            {
                reponsesSeparees[i] = donnee;
                lstEnvoyees.Items.Add(reponsesSeparees[i]);
                i++;
            }
            
        }
        public void montrerPannel(Panel panelActif)
        {
            pnlArchives.Visible = false;
            pnlContact.Visible = false;
            pnlDiscussions.Visible = false;
            pnlProfil.Visible = false;
            panelActif.Visible = true;
            
        }

        private void cmdContacts_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlContact);
            pnlContactsListe.Visible = true;
            pnlContactsDemandes.Visible = false;
            
        }

        private void cmdDiscussions_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlDiscussions);
        }

        private void cmdArchives_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlArchives);
        }
        public void chargerProfil()
        {
            user.Pseudo = Properties.Settings.Default.UserActif;
            string msgProfil = "3" + user.Pseudo;
            string reponse = envoiMessage.Connect("127.0.0.1", msgProfil);
            string[] reponses = reponse.Split(',');

            user.Nom = reponses[0];
            user.Prenom = reponses[1];
            user.Description = reponses[2];

            txtPseudo.Text = user.Pseudo;
            txtNom.Text = user.Nom;
            txtPrenom.Text = user.Prenom;
            txtDescription.Text = user.Description;
        }

        private void cmdValiderProfil_Click(object sender, EventArgs e)
        {
            user.Nom = txtNom.Text;
            user.Prenom = txtPrenom.Text;
            user.Description = txtDescription.Text;
            user.Pseudo = txtPseudo.Text;
            string msgValidationProfil = "4" + user.Pseudo + "," + user.Nom + "," + user.Prenom + "," + user.Description;
            string reponse = envoiMessage.Connect("127.0.0.1", msgValidationProfil);
            if (reponse == "Reussie")
            {
                MessageBox.Show("Le profil a été mis à jour");
            }
        }

        private void cmdAAjouterContacts_Click(object sender, EventArgs e)
        {
            FrmContactsAjouter frmContactsAjouter = new FrmContactsAjouter(txtPseudo.Text);
            frmContactsAjouter.Show();
            DialogResult res = frmContactsAjouter.DialogResult;

            if(res == DialogResult.OK)
            {
                frmContactsAjouter.Close();
            }
        }

        private void cmdADemandesContacts_Click(object sender, EventArgs e)
        {
            pnlContactsListe.Visible = false;
            pnlContactsDemandes.Visible = true;
            chargerDemandes();
        }


    }
}

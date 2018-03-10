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
            lstEnvoyees.Enabled = false;
            
        }
        public void chargerDemandesRecues()
        {
            int i = 0;
            string demandeRecue = "08" + txtPseudo.Text;
            string reponseDemandeRecue = envoiMessage.Connect("127.0.0.1", demandeRecue);
            if(reponseDemandeRecue != "PasDemandesRecues")
            {
                string[] reponsesDemandeRecueSeparee = reponseDemandeRecue.Split(',');
                foreach (string donnee in reponsesDemandeRecueSeparee)
                {
                    reponsesDemandeRecueSeparee[i] = donnee;
                    if (!lstRecues.Items.Contains(reponsesDemandeRecueSeparee[i]))
                    {
                        lstRecues.Items.Add(reponsesDemandeRecueSeparee[i]);
                    }
                    i++;
                }
            }

        }
        public void chargerDemandesEnvoyees()
        {
            int i = 0;
            string demande = "07" + txtPseudo.Text;
            string reponse = envoiMessage.Connect("127.0.0.1", demande);
            if(reponse != "PasDemandesEnvoyees")
            {
                string[] reponsesSeparees = reponse.Split(',');
                foreach (string donnee in reponsesSeparees)
                {
                    reponsesSeparees[i] = donnee;
                    if (!lstEnvoyees.Items.Contains(reponsesSeparees[i]))
                    {
                        lstEnvoyees.Items.Add(reponsesSeparees[i]);
                    }

                    i++;
                }
            }
            else
            {
                lstEnvoyees.Enabled = true;
                lstEnvoyees.Items.Clear();
                lstEnvoyees.Enabled = false;
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
            int i = 0;
            string message = "10" + txtPseudo.Text;
            
            string reponse = envoiMessage.Connect("127.0.0.1", message);
            
            if(reponse != "Pas de contact a ajouter")
            {
                string[] reponseSeparee = reponse.Split(',');
                foreach (string donnee in reponseSeparee)
                {
                    reponseSeparee[i] = donnee;
                    Console.WriteLine("REPONSE ATTENDUE :" + reponseSeparee[i]);
                    if (lstContacts.Items.Contains(reponseSeparee[i]) == false)
                    {
                        lstContacts.Items.Add(reponseSeparee[i]);
                    }
                }
            }

            
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
            string msgProfil = "03" + user.Pseudo;
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
            string msgValidationProfil = "04" + user.Pseudo + "," + user.Nom + "," + user.Prenom + "," + user.Description;
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
            chargerDemandesEnvoyees();
            chargerDemandesRecues();
        }

        private void cmdAccepter_Click(object sender, EventArgs e)
        {


            string selectedItem = lstRecues.GetItemText(lstRecues.SelectedItem);
            string message = "09" + txtPseudo.Text + "," + selectedItem;
            string reponse = envoiMessage.Connect("127.0.0.1", message);

            MessageBox.Show(reponse);
            lstContacts.Items.Add(selectedItem);
            lstRecues.Items.Remove(lstRecues.SelectedItem);


        }

        private void cmdRefuser_Click(object sender, EventArgs e)
        {
            string selectedItem = lstRecues.GetItemText(lstRecues.SelectedItem);
            string message = "11" + txtPseudo.Text + "," + selectedItem;

            string reponse = envoiMessage.Connect("127.0.0.1", message);
            if(reponse == "Demande supprimee")
            {
                lstRecues.Items.Remove(selectedItem);
                MessageBox.Show("La demande de contact a été supprimée !");
            }
            
        }

        private void cmdASupprimerContacts_Click(object sender, EventArgs e)
        {
            if(lstContacts.SelectedIndex != -1)
            {
                string selectedItem = lstContacts.GetItemText(lstContacts.SelectedItem);
                string message = "12" + txtPseudo.Text + "," + selectedItem;

                string reponse = envoiMessage.Connect("127.0.0.1", message);

                if(reponse == "Contact supprime")
                {
                    MessageBox.Show("Contact supprimé !");
                    lstContacts.Items.Remove(lstContacts.SelectedItem);
                }
            }

        }
    }
}

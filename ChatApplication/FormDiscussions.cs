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
        //FrmDisucssionCreer frmDiscussionCreer;
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
            pnlDiscussionAffichage.Visible = true;
            pnlDiscussionDemande.Visible = false;
            chargerProfil();
            lstEnvoyees.Enabled = false;
            
        }
        public void chargerDemandesRecues()
        {
            int i = 0;
            string demandeRecue = "08" + txtPseudo.Text;
            string reponseDemandeRecue = envoiMessage.Connect(demandeRecue);
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
            string reponse = envoiMessage.Connect(demande);
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
            
            string reponse = envoiMessage.Connect(message);
            
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
            pnlDiscussionAffichage.Visible = true;
            pnlDiscussionDemande.Visible = false;

            string message = "22" + txtPseudo.Text;
            string reponse = envoiMessage.Connect(message);
            string[] nomDiscussion = reponse.Split(',');
            for(int i = 0; i < nomDiscussion.Count(); i++)
            {
                if (!lstDiscussions.Items.Contains(nomDiscussion[i]))
                {
                    lstDiscussions.Items.Add(nomDiscussion[i]);
                }

            }
            
        }

        private void cmdArchives_Click(object sender, EventArgs e)
        {
            //TODO LES ARCHIVES A FINIR, le chargement des archives fonctionne
            montrerPannel(pnlArchives);
            string message31 = "31" + txtPseudo.Text;
            string reponse31 = envoiMessage.Connect(message31);
            string[] nomDiscussion = reponse31.Split(',');
            for(int i = 0; i < nomDiscussion.Length; i++)
            {
                if (!lstArchives.Items.Contains(nomDiscussion[i]))
                {
                    lstArchives.Items.Add(nomDiscussion[i]);
                }
            }
        }
        public void chargerProfil()
        {
            user.Pseudo = Properties.Settings.Default.UserActif;
            string msgProfil = "03" + user.Pseudo;
            string reponse = envoiMessage.Connect(msgProfil);
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
            string reponse = envoiMessage.Connect(msgValidationProfil);
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
            string reponse = envoiMessage.Connect(message);

            MessageBox.Show(reponse);
            lstContacts.Items.Add(selectedItem);
            lstRecues.Items.Remove(lstRecues.SelectedItem);


        }

        private void cmdRefuser_Click(object sender, EventArgs e)
        {
            string selectedItem = lstRecues.GetItemText(lstRecues.SelectedItem);
            string message = "11" + txtPseudo.Text + "," + selectedItem;

            string reponse = envoiMessage.Connect(message);
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

                string reponse = envoiMessage.Connect( message);

                if(reponse == "Contact supprime")
                {
                    MessageBox.Show("Contact supprimé !");
                    lstContacts.Items.Remove(lstContacts.SelectedItem);
                }
            }

        }

        private void cmdAModifierContacts_Click(object sender, EventArgs e)
        {
            if(lstContacts.SelectedIndex != -1)
            {
                
                
                FrmContactsModifier frmContactsModifier = new FrmContactsModifier(txtPseudo.Text, lstContacts.GetItemText(lstContacts.SelectedItem));
                frmContactsModifier.ShowDialog();
                DialogResult res = new DialogResult();
                if(res == DialogResult.OK)
                {
                    frmContactsModifier.Close();
                }
            }
        }

        private void cmdACreer_Click(object sender, EventArgs e)
        {
            FrmDisucssionCreer frmDiscussionCreer = new FrmDisucssionCreer(txtPseudo.Text);
            frmDiscussionCreer.Show();
            DialogResult res = new DialogResult();
            if(res == DialogResult.OK)
            {
                frmDiscussionCreer.Close();
            }
        }

        private void cmdADemandes_Click(object sender, EventArgs e)
        {

            pnlDiscussionDemande.Visible = true;
            pnlDiscussionAffichage.Visible = false;
            string message17 = "17" + txtPseudo.Text;
            string reponse17 = envoiMessage.Connect(message17);
            if(reponse17 != string.Empty)
            {
                string[] reponseParParticipant = reponse17.Split(',');
                for (int i = 0; i < reponseParParticipant.Count(); i++)
                {
                    string PseudoParticipantNomDiscussion = reponseParParticipant[i].Replace("/", "-");
                    cmbDemandesDisucssionsEnvoyees.Items.Add(PseudoParticipantNomDiscussion);
                }
            }


            string message16 = "16" + txtPseudo.Text;
            string reponse16 = envoiMessage.Connect(message16);
            if(reponse16 != string.Empty)
            {
                            string[] nomsDiscussionEnAttente = reponse16.Split(',');
            for(int y =0; y < nomsDiscussionEnAttente.Count(); y++)
            {
                    string[] separerNomNombreParticipant = nomsDiscussionEnAttente[y].Split('/');
                    if(int.Parse(separerNomNombreParticipant[1]) > 2)
                    {
                        
                        if (!cboGroupes.Items.Contains(separerNomNombreParticipant[0]))
                        {
                            cboGroupes.Items.Add(separerNomNombreParticipant[0]);
                        }

                    }
                    else
                    {
                        if (!cboDiscussions.Items.Contains(separerNomNombreParticipant[0]))
                        {
                            cboDiscussions.Items.Add(separerNomNombreParticipant[0]);
                        }
                        
                    }
                    
            }
            }

            /*frmDiscussionCreer = new FrmDisucssionCreer(txtPseudo.Text);
            string temp = FrmDisucssionCreer.Temporaire;
            int count = temp.TakeWhile(c => c == ',').Count();
            string[] stock = new string[count+1];
            stock = temp.Split(',');
            for(int i = 0; i < stock.Count(); i++)
            {
                cmbDemandesDisucssionsEnvoyees.Items.Add(stock[i]);
            }*/
        }

        private void cmdADiscussions_Click(object sender, EventArgs e)
        {
            pnlDiscussionDemande.Visible = false;
            pnlDiscussionAffichage.Visible = true;
            montrerPannel(pnlDiscussions);
            pnlDiscussionAffichage.Visible = true;
            pnlDiscussionDemande.Visible = false;

            string message = "22" + txtPseudo.Text;
            string reponse = envoiMessage.Connect(message);
            string[] nomDiscussion = reponse.Split(',');
            for (int i = 0; i < nomDiscussion.Count(); i++)
            {
                if (!lstDiscussions.Items.Contains(nomDiscussion[i]))
                {
                    lstDiscussions.Items.Add(nomDiscussion[i]);
                }

            }
        }

        private void cmdAccepterDiscussion_Click(object sender, EventArgs e)
        {
            if(cboDiscussions.SelectedIndex > -1)
            {
                string message = "18" + txtPseudo.Text + "," + cboDiscussions.SelectedItem.ToString();
                string reponse = envoiMessage.Connect(message);
                cboDiscussions.Items.Remove(cboDiscussions.SelectedItem);
            }
        }

        private void cmdAccepterGroupe_Click(object sender, EventArgs e)
        {
            if (cboGroupes.SelectedIndex > -1)
            {
                string message = "19" + txtPseudo.Text + "," + cboGroupes.SelectedItem.ToString();
                string reponse = envoiMessage.Connect(message);
                cboGroupes.Items.Remove(cboGroupes.SelectedItem);
            }
        }

        private void cmdRefuserDiscussion_Click(object sender, EventArgs e)
        {
            if(cboDiscussions.SelectedIndex > -1)
            {
                string message = "20" + txtPseudo.Text + "," + cboDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboDiscussions.Items.Remove(cboDiscussions.SelectedItem);
            }
        }

        private void cmdRefuserGroupe_Click(object sender, EventArgs e)
        {
            if (cboGroupes.SelectedIndex > -1)
            {
                string message = "21" + txtPseudo.Text + "," + cboGroupes.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboGroupes.Items.Remove(cboGroupes.SelectedItem);
            }
        }

        private void cmdOuvrir_Click(object sender, EventArgs e)
        {
            string nomDiscussion = lstDiscussions.SelectedItem.ToString();
            FrmMessage frmMessage = new FrmMessage(nomDiscussion, txtPseudo.Text);
            frmMessage.Show();
            DialogResult res = new DialogResult();
            if(res == DialogResult.OK)
            {
                frmMessage.Close();
            }

        }

        private void cmdSupprimerDiscussions_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                
            }
        }

        private void cmdArchiverDiscussions_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                string message30 = "30" + txtPseudo.Text + "," + lstDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message30);
                lstDiscussions.Items.Remove(lstDiscussions.SelectedItem);
            }


        }
    }
}

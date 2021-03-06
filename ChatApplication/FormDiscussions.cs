﻿using System;
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
        string pseudo = string.Empty;

        public frmDiscussions()
        {
            InitializeComponent();
        }

        public frmDiscussions(string identifiant)
        {
            InitializeComponent();
            pseudo = identifiant;
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
            //Le serveur retourne les demandes de contact recues
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

        /// <summary>
        /// Permet d'afficher les demandes de contact envoyées
        /// </summary>
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

        /// <summary>
        /// Affiche le pannel contact + ajoute les contacts dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdContacts_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlContact);

            pnlTest.Visible = true;
            pnlContactsDemandes.Visible = false;
            int i = 0;
            string message = "10" + txtPseudo.Text;
            
            //Le serveur retourne les contacts séparés par des virgules
            string reponse = envoiMessage.Connect(message);
            
            if(reponse != "Pas de contact a ajouter")
            {
                string[] reponseSeparee = reponse.Split(',');
                foreach (string donnee in reponseSeparee)
                {
                    reponseSeparee[i] = donnee;
                    Console.WriteLine("REPONSE ATTENDUE :" + reponseSeparee[i]);
                    if (lstTest.Items.Contains(reponseSeparee[i]) == false)
                    {
                        lstTest.Items.Add(reponseSeparee[i]);
                    }
                }
            }

            
        }

        /// <summary>
        /// Affiche la liste de discussions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDiscussions_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlDiscussions);
            pnlDiscussionAffichage.Visible = true;
            pnlDiscussionDemande.Visible = false;

            string message = "22" + txtPseudo.Text;
            //Le serveur retourne les discussions auxquelles participe l'utilisateur séparés par des virgules
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

        /// <summary>
        /// Affiche les archives
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdArchives_Click(object sender, EventArgs e)
        {
            montrerPannel(pnlArchives);
            string message31 = "31" + txtPseudo.Text;
            //Le serveur retourne le nom de toutes les archives séparés par des virgules
            string reponse31 = envoiMessage.Connect(message31);
            string[] nomArchive = reponse31.Split(',');
            for(int i = 0; i < nomArchive.Length; i++)
            {
                if (!lstArchives.Items.Contains(nomArchive[i]))
                {
                    lstArchives.Items.Add(nomArchive[i]);
                }
            }
        }

        /// <summary>
        /// Charge le profil de l'utilisateur actif
        /// </summary>
        public void chargerProfil()
        {
            user.Pseudo = pseudo;
            string msgProfil = "03" + user.Pseudo;

            //Réception d'un string contenant les infos de profil de l'utilisateur séparé par des virgules
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

        /// <summary>
        /// Mise à jour du profil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValiderProfil_Click(object sender, EventArgs e)
        {
            user.Nom = txtNom.Text;
            user.Prenom = txtPrenom.Text;
            user.Description = txtDescription.Text;
            user.Pseudo = txtPseudo.Text;
            //Envoi des nouvelles informations rentrées au serveur
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
                frmContactsAjouter.Dispose();
            }
        }

        private void cmdADemandesContacts_Click(object sender, EventArgs e)
        {
            pnlTest.Visible = false;
            pnlContactsDemandes.Visible = true;
            chargerDemandesEnvoyees();
            chargerDemandesRecues();
        }

        /// <summary>
        /// Accepte la demande de contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAccepter_Click(object sender, EventArgs e)
        {
            if(lstRecues.SelectedIndex > -1)
            {
                string selectedItem = lstRecues.GetItemText(lstRecues.SelectedItem);
                string message = "09" + txtPseudo.Text + "," + selectedItem;
                string reponse = envoiMessage.Connect(message);
                lstTest.Items.Add(selectedItem);
                lstRecues.Items.Remove(lstRecues.SelectedItem);
                MessageBox.Show("Le contact a été ajouté !");
            }

        }

        /// <summary>
        /// Refus d'une demande de contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRefuser_Click(object sender, EventArgs e)
        {
            if(lstRecues.SelectedIndex > -1)
            {
                string selectedItem = lstRecues.GetItemText(lstRecues.SelectedItem);
                string message = "11" + txtPseudo.Text + "," + selectedItem;

                string reponse = envoiMessage.Connect(message);
                if (reponse == "Demande supprimee")
                {
                    lstRecues.Items.Remove(selectedItem);
                    MessageBox.Show("La demande de contact a été supprimée !");
                }
            }

        }

        /// <summary>
        /// Permet de supprimer le contact sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdASupprimerContacts_Click(object sender, EventArgs e)
        {
            //Si un contact est sélectionné, on envoi au serveur son pseudo ainsi que celui de l'utilisateur actif pour supprimer le contact
            if(lstTest.SelectedIndex != -1)
            {
                string selectedItem = lstTest.GetItemText(lstTest.SelectedItem);
                string message = "12" + txtPseudo.Text + "," + selectedItem;

                string reponse = envoiMessage.Connect( message);

                if(reponse == "Contact supprime")
                {
                    MessageBox.Show("Contact supprimé !");
                    lstTest.Items.Remove(lstTest.SelectedItem);
                }
            }

        }

        private void cmdAModifierContacts_Click(object sender, EventArgs e)
        {
            if(lstTest.SelectedIndex != -1)
            {
                FrmContactsModifier frmContactsModifier = new FrmContactsModifier(txtPseudo.Text, lstTest.GetItemText(lstTest.SelectedItem));
                frmContactsModifier.ShowDialog();
                DialogResult res =  frmContactsModifier.DialogResult;
                if(res == DialogResult.OK)
                {
                    frmContactsModifier.Close();
                    frmContactsModifier.Dispose();
                }
            }
        }

        private void cmdACreer_Click(object sender, EventArgs e)
        {
            FrmDisucssionCreer frmDiscussionCreer = new FrmDisucssionCreer(txtPseudo.Text);
            frmDiscussionCreer.Show();
            DialogResult res = frmDiscussionCreer.DialogResult;
            if(res == DialogResult.OK)
            {
                frmDiscussionCreer.Close();
                frmDiscussionCreer.Dispose();
            }
        }

        private void cmdADemandes_Click(object sender, EventArgs e)
        {

            pnlDiscussionDemande.Visible = true;
            pnlDiscussionAffichage.Visible = false;
            //Demandes discussion envoyées
            string message17 = "17" + txtPseudo.Text;
            //Le serveur retourne les pseudos + noms discussions des demandes de discussion envoyées
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

            //Demandes discussion recues
            string message16 = "16" + txtPseudo.Text;
            string reponse16 = envoiMessage.Connect(message16);
            //Si il y a des demandes recues
            if (reponse16 != string.Empty)
            {
                string[] nomsDiscussionEnAttente = reponse16.Split(',');
                //Pour chaque demande recue
                for (int y =0; y < nomsDiscussionEnAttente.Count(); y++)
                {
                        string[] separerNomNombreParticipant = nomsDiscussionEnAttente[y].Split('/');
                        //Si il y a plus de 2 participants --> discussion de groupe
                        if (int.Parse(separerNomNombreParticipant[1]) > 2)
                        {
                            if (!cboGroupes.Items.Contains(separerNomNombreParticipant[0]))
                            {
                                cboGroupes.Items.Add(separerNomNombreParticipant[0]);
                            }
                        }
                        // --> discussion "normale"
                        else
                        {
                            if (!cboDiscussions.Items.Contains(separerNomNombreParticipant[0]))
                            {
                                cboDiscussions.Items.Add(separerNomNombreParticipant[0]);
                            }
                        }
                }
            }
        }



        /// <summary>
        /// Accepte une discussion "normale"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAccepterDiscussion_Click(object sender, EventArgs e)
        {
            if(cboDiscussions.SelectedIndex > -1)
            {
                string message = "18" + txtPseudo.Text + "," + cboDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboDiscussions.Items.Remove(cboDiscussions.SelectedItem);
                cboDiscussions.Text = "";
            }
        }

        /// <summary>
        /// Accepte une discussion de groupe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAccepterGroupe_Click(object sender, EventArgs e)
        {
            if (cboGroupes.SelectedIndex > -1)
            {
                string message = "19" + txtPseudo.Text + "," + cboGroupes.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboGroupes.Items.Remove(cboGroupes.SelectedItem);
                cboGroupes.Text = "";
            }
        }

        private void cmdRefuserDiscussion_Click(object sender, EventArgs e)
        {
            if(cboDiscussions.SelectedIndex > -1)
            {
                string message = "20" + txtPseudo.Text + "," + cboDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboDiscussions.Items.Remove(cboDiscussions.SelectedItem);
                cboDiscussions.Text = "";
            }
        }

        private void cmdRefuserGroupe_Click(object sender, EventArgs e)
        {
            if (cboGroupes.SelectedIndex > -1)
            {
                string message = "21" + txtPseudo.Text + "," + cboGroupes.SelectedItem.ToString();
                envoiMessage.Connect(message);
                cboGroupes.Items.Remove(cboGroupes.SelectedItem);
                cboGroupes.Text = "";
            }
        }

        private void cmdOuvrir_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                string nomDiscussion = lstDiscussions.SelectedItem.ToString();
                FrmMessage frmMessage = new FrmMessage(nomDiscussion, txtPseudo.Text);
                frmMessage.Show();
                DialogResult res = frmMessage.DialogResult;
                if (res == DialogResult.OK)
                {
                    frmMessage.Close();
                }
            }
        }

        //TODO A FAIRE C'EST PAS CODE
        private void cmdSupprimerDiscussions_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                string message20 = "20" + txtPseudo.Text + "," + lstDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message20);
                lstDiscussions.Items.Remove(lstDiscussions.SelectedItem);
            }
        }

        /// <summary>
        /// Archive une discussion
        /// </summary>
        /// Supprime la discussion et Ajoute une archive
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdArchiverDiscussions_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                string message30 = "30" + txtPseudo.Text + "," + lstDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message30);
                lstDiscussions.Items.Remove(lstDiscussions.SelectedItem);
            }
        }

        /// <summary>
        /// Supprime définitvement une conversation qui était archivée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSupprimerArchives_Click(object sender, EventArgs e)
        {
            if(lstArchives.SelectedIndex > -1)
            {
                string message32 = "32" + txtPseudo.Text + "," + lstArchives.SelectedItem.ToString();
                envoiMessage.Connect(message32);
                lstArchives.Items.Remove(lstArchives.SelectedItem);
            }
        }

        /// <summary>
        /// Remet la discussion archivée dans les discussions courantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReimporterArchives_Click(object sender, EventArgs e)
        {
            if(lstArchives.SelectedIndex > -1)
            {
                string message33 = "33" + txtPseudo.Text + "," + lstArchives.SelectedItem.ToString();
                envoiMessage.Connect(message33);
                lstArchives.Items.Remove(lstArchives.SelectedItem);
            }
        }

        private void cmdARechercher_Click(object sender, EventArgs e)
        {
            FrmDiscussionRecherche frmDiscussionRecherche = new FrmDiscussionRecherche(txtPseudo.Text);
            frmDiscussionRecherche.Show();
            DialogResult res = frmDiscussionRecherche.DialogResult;
            if(res == DialogResult.OK)
            {
                frmDiscussionRecherche.Close();
            }
        }

        private void cmdQuitter_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Voulez-vous vraiment quitter ?", "Quitter l'application", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }       
        }
    }
}

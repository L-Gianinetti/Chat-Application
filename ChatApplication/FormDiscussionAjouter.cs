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
    public partial class FrmDiscussionAjouter : Form
    {
        EnvoiMessage envoiMessage = new EnvoiMessage();
        User utilisateur = new User();
        string nomDiscussion = string.Empty;
        public FrmDiscussionAjouter()
        {
            InitializeComponent();
        }

        public FrmDiscussionAjouter(string pseudoUtilisateur, string nomDisc)
        {
            InitializeComponent();
            utilisateur.Pseudo = pseudoUtilisateur;
            nomDiscussion = nomDisc;
        }

        private void FrmDiscussionAjouter_Load(object sender, EventArgs e)
        {
            string message = "10" + utilisateur.Pseudo;
            string message23 = "23" + nomDiscussion;
            string reponse23 = envoiMessage.Connect(message23);
            string[] nomsParticipants = reponse23.Split(',');
            string reponse = envoiMessage.Connect(message);

            //Si on a des contacts existants
            if (reponse != "Pas de contact a ajouter")
            {
                string[] reponseSeparee = reponse.Split(',');
                //Pour chaque contact
                foreach (string donnee in reponseSeparee)
                {
                    
                    for(int y =0; y< nomsParticipants.Length; y++)
                    {      
                        {
                            //Ajout du contact dans la liste des contacts disponible si il n'y est pas deja
                            if (cboContacts.Items.Contains(donnee) == false)
                            {
                                cboContacts.Items.Add(donnee);
                            }
                            //Si la liste des contacts disponibles contient un des participants à la discussion, on le supprime de la liste
                            else if(cboContacts.Items.Contains(nomsParticipants[y]) == true)
                            {
                                cboContacts.Items.Remove(nomsParticipants[y]);
                            }
                            //Si la liste contient l'utilisateur actif, on le supprime de la liste
                            else if (cboContacts.Items.Contains(utilisateur.Pseudo) == true)
                            {
                                cboContacts.Items.Remove(utilisateur.Pseudo);
                            }
                        }
                    }
                }
            }
        }
    

        private void cmdAnnuler_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Lorsque l'on valide l'ajout de contact dans la discussion --> demande de participationDiscussion envoyées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValider_Click(object sender, EventArgs e)
        {
            string listeParticipants = string.Empty;
            for (int i = 0; i < lstParticipants.Items.Count; i++)
            {
                //Pseudos séparés par des "$" car j'utilise les "," pour séparer les différents éléments du message
                listeParticipants += lstParticipants.Items[i] + "$";
            }
            listeParticipants = listeParticipants.Substring(0, listeParticipants.Length - 1);
            string message28 = "28" + nomDiscussion + "," + listeParticipants;
            envoiMessage.Connect(message28);
        }

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            if (cboContacts.SelectedIndex > -1)
            {
                if (!lstParticipants.Items.Contains(cboContacts.SelectedItem))
                {
                    lstParticipants.Items.Add(cboContacts.SelectedItem);
                }
            }
        }

        private void cmdRetirer_Click(object sender, EventArgs e)
        {
            if (lstParticipants.SelectedIndex > -1)
            {
                lstParticipants.Items.Remove(lstParticipants.SelectedItem);
            }
            if (lstParticipants.Items.Count == 0)
            {
                cmdRetirer.Enabled = false;
            }
        }
    }
}

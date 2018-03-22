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
            int i = 0;
            string message = "10" + utilisateur.Pseudo;
            string message27 = "27" + nomDiscussion;
            string reponse27 = envoiMessage.Connect(message27);
            string[] nomsParticipants = reponse27.Split(',');
            string reponse = envoiMessage.Connect(message);

            if (reponse != "Pas de contact a ajouter")
            {
                string[] reponseSeparee = reponse.Split(',');
                foreach (string donnee in reponseSeparee)
                {
                    reponseSeparee[i] = donnee;
                    Console.WriteLine("REPONSE ATTENDUE :" + reponseSeparee[i]);

                    for(int y =0; y< nomsParticipants.Length; y++)
                    {
                        
                        {
                            if (cboContacts.Items.Contains(reponseSeparee[i]) == false)
                            {
                                cboContacts.Items.Add(reponseSeparee[i]);
                            }
                            else if(cboContacts.Items.Contains(nomsParticipants[y]) == true)
                            {
                                cboContacts.Items.Remove(nomsParticipants[y]);
                            }
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

        private void cmdValider_Click(object sender, EventArgs e)
        {
            string listeParticipants = string.Empty;
            for (int i = 0; i < lstParticipants.Items.Count; i++)
            {
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

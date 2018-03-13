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
    public partial class FrmDisucssionCreer : Form
    {
        EnvoiMessage envoiMessage = new EnvoiMessage();
        User utilisateur = new User();
        public FrmDisucssionCreer()
        {
            InitializeComponent();
        }
        public FrmDisucssionCreer(string pseudo)
        {
            utilisateur.Pseudo = pseudo;  
            InitializeComponent();
        }
        private void cmdCreer_Click(object sender, EventArgs e)
        {
            //creation d'une string contenant les participants à la discussion
            string participants = string.Empty;
            for(int i = 0; i < lstParticipants.Items.Count; i++)
            {
                participants += lstParticipants.Items[i].ToString() + ",";
            }
            participants = participants.Substring(0, participants.Length - 2);
            string nbrParticipants = string.Empty;
            //Gérer le nombre de participant
            if(lstParticipants.Items.Count > 9)
            {
                nbrParticipants = lstParticipants.Items.Count.ToString();
            }
            else
            {
                nbrParticipants = "0" + lstParticipants.Items.Count.ToString();
            }

            string creerDiscussion = "15" + utilisateur.Pseudo + "," + participants + nbrParticipants;

            string reponseCreerDiscussion = envoiMessage.Connect("127.0.0.1", creerDiscussion);

        }

        private void FrmDisucssionCreer_Load(object sender, EventArgs e)
        {
            ckbNom.Checked = false;
            ckbNom.Enabled = false;
            cmdCreer.Enabled = false;
            int i = 0;
            string message = "10" + utilisateur.Pseudo;

            string reponse = envoiMessage.Connect("127.0.0.1", message);

            if (reponse != "Pas de contact a ajouter")
            {
                string[] reponseSeparee = reponse.Split(',');
                foreach (string donnee in reponseSeparee)
                {
                    reponseSeparee[i] = donnee;
                    Console.WriteLine("REPONSE ATTENDUE :" + reponseSeparee[i]);
                    if (cboContacts.Items.Contains(reponseSeparee[i]) == false)
                    {
                        cboContacts.Items.Add(reponseSeparee[i]);
                    }
                }
            }
        }

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            if(cboContacts.SelectedIndex > -1)
            {
                if (!lstParticipants.Items.Contains(cboContacts.SelectedItem))
                {
                    lstParticipants.Items.Add(cboContacts.SelectedItem);
                }
            }
        }

        private void cmdRetirer_Click(object sender, EventArgs e)
        {
            if(lstParticipants.SelectedIndex > -1)
            {
                lstParticipants.Items.Remove(lstParticipants.SelectedItem);
            }
            if(lstParticipants.Items.Count == 0)
            {
                cmdCreer.Enabled = false;
            }
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {
            if(txtNom.Text == string.Empty)
            {
                ckbNom.Checked = false;
                cmdCreer.Enabled = false;
            }
            else
            {
                ckbNom.Checked = true;
            }
        }

        private void cmdVerifier_Click(object sender, EventArgs e)
        {
            if(lstParticipants.Items.Count > 0 && ckbNom.Checked == true)
            {
                cmdCreer.Enabled = true;
            }
            else
            {
                cmdCreer.Enabled = false;
            }
        }
    }
}

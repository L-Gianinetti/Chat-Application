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
        private static string _temporaire = string.Empty;
        public static string Temporaire
        {
            get { return _temporaire; }
            set { _temporaire = value; }
        }

        EnvoiMessage envoiMessage = new EnvoiMessage();
        User utilisateur = new User();
        public FrmDisucssionCreer()
        {
            InitializeComponent();
            ckbCategorie.Checked = true;
        }
        public FrmDisucssionCreer(string pseudo)
        {
            utilisateur.Pseudo = pseudo;  
            InitializeComponent();
            ckbCategorie.Checked = true;
        }

        /// <summary>
        /// Creer une discussion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreer_Click(object sender, EventArgs e)
        {
            //creation d'une string contenant les participants à la discussion
            string participants = string.Empty;
            for(int i = 0; i < lstParticipants.Items.Count; i++)
            {
                participants += lstParticipants.Items[i].ToString() + ",";
            }
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

            string reponseCreerDiscussion = string.Empty;

            //Envoit au serveur le pseudo de l'utilisateur actif, la categorie, les pseudos des participants, le nom de la dscussion et le nombre de participant
            if(ckbPublique.Checked == true)
            {
                string creerDiscussion = "151" + utilisateur.Pseudo + "$" + txtCategorie.Text + "$" + participants + txtNom.Text + nbrParticipants;
                reponseCreerDiscussion = envoiMessage.Connect(creerDiscussion);
            }
            //Si la discussion n'est pas publique
            else
            {
                string creerDiscussion = "15" + utilisateur.Pseudo + "$" + txtCategorie.Text + "$" + participants + txtNom.Text + nbrParticipants;
                reponseCreerDiscussion = envoiMessage.Connect(creerDiscussion);
            }


            if(reponseCreerDiscussion == "Discussion creee")
            {
                MessageBox.Show("La discussion a été crée et les demandes de discussion envoyées");
            }
            else
            {
                MessageBox.Show("Le nom de la discussion existe deja");
            }
            this.Close();
        }

        private void FrmDisucssionCreer_Load(object sender, EventArgs e)
        {
            ckbNom.Checked = false;
            ckbNom.Enabled = false;
            cmdCreer.Enabled = false;
            int i = 0;
            string message = "10" + utilisateur.Pseudo;
            string reponse = envoiMessage.Connect(message);

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
            if(lstParticipants.Items.Count > 0 && ckbNom.Checked == true && ckbCategorie.Checked == true)
            {
                cmdCreer.Enabled = true;
            }
            else
            {
                cmdCreer.Enabled = false;
            }
        }

        private void txtCategorie_TextChanged(object sender, EventArgs e)
        {
            if(txtCategorie.Text != string.Empty)
            {
                ckbCategorie.Checked = true;
            }
            else
            {
                ckbCategorie.Checked = false;
            }
        }

        private void cmdAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

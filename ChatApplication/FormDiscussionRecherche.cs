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
    public partial class FrmDiscussionRecherche : Form
    {
        User utilisateur = new User();
        EnvoiMessage envoieMessage = new EnvoiMessage();
        public FrmDiscussionRecherche()
        {
            InitializeComponent();
        }
        public FrmDiscussionRecherche(string pseudo)
        {
            InitializeComponent();
            utilisateur.Pseudo = pseudo;
        }
        private void FrmDiscussionRecherche_Load(object sender, EventArgs e)
        {
            string message = "34";
            string reponse = envoieMessage.Connect(message);
            if(reponse != string.Empty)
            {
                string[] categorie = reponse.Split(',');
                for(int i =0; i < categorie.Length; i++)
                {
                    if (!lstProposee.Items.Contains(categorie[i]))
                    {
                        lstProposee.Items.Add(categorie[i]);
                    }
                }
            }

        }

        private void cmdRechercher_Click(object sender, EventArgs e)
        {
            if(lstProposee.SelectedIndex >-1 || lstResultats.SelectedIndex > -1)
            {
                string categorie = string.Empty;
                if(lstResultats.SelectedIndex > -1)
                {
                    categorie = lstResultats.SelectedItem.ToString();
                }
                else
                {
                    categorie = lstProposee.SelectedItem.ToString();
                }
                FrmRechercheDiscussionCategorie frmRechercheDiscussionCategorie = new FrmRechercheDiscussionCategorie(categorie,utilisateur.Pseudo);
                frmRechercheDiscussionCategorie.Show();
                DialogResult res = new DialogResult();
                if(res == DialogResult.OK)
                {
                    frmRechercheDiscussionCategorie.Close();
                }
            }
        }

        private void txtRechercher_TextChanged(object sender, EventArgs e)
        {
            if(txtRechercher.Text == string.Empty)
            {
                lstResultats.Items.Clear();
            }
            else
            {
                lstResultats.Items.Clear();
                string message = "35" + txtRechercher.Text;
                string reponse = envoieMessage.Connect(message);
                string[] retour = reponse.Split(',');
                for (int i = 0; i < retour.Length; i++)
                {
                    if (!lstResultats.Items.Contains(retour[i]))
                    {
                        lstResultats.Items.Add(retour[i]);
                    }
                }
            }

        }

        private void lstResultats_SelectedIndexChanged(object sender, EventArgs e)
        {
                lstProposee.ClearSelected();
        }

        private void lstProposee_SelectedIndexChanged(object sender, EventArgs e)
        {
                lstResultats.ClearSelected();
        }
    }
}

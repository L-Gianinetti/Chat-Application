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
    public partial class FrmContactsModifier : Form
    {
        EnvoiMessage envoiMessage = new EnvoiMessage();
        User utilisateur = new User();
        string pseudoUtilisateurActif = string.Empty;
        public FrmContactsModifier()
        {
            InitializeComponent();
        }
        public FrmContactsModifier(string pseudoUtilisateur, string pseudoContact)
        {
            InitializeComponent();
            txtPseudo.Text = pseudoContact;
            pseudoUtilisateurActif = pseudoUtilisateur;

            txtDescription.Enabled = false;
            txtNom.Enabled = false;
            txtPrenom.Enabled = false;
            txtPseudo.Enabled = false;
            txtAnnotation.Enabled = true;
        }

        /// <summary>
        /// Affiche les informations du contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmContactsModifier_Load(object sender, EventArgs e)
        {
            //Envoit au serveur le pseudo de l'utilisateur actif et du contact
            string message = "14" + pseudoUtilisateurActif+ "," + txtPseudo.Text;
            //Le serveur retourne les infos du contact
            string reponse = envoiMessage.Connect(message);

            string[] reponses = reponse.Split(',');

            utilisateur.Nom = reponses[0];
            utilisateur.Prenom = reponses[1];
            utilisateur.Description = reponses[2];

            txtAnnotation.Text = reponses[3];
            txtNom.Text = utilisateur.Nom;
            txtPrenom.Text = utilisateur.Prenom;
            txtDescription.Text = utilisateur.Description;

        }

        /// <summary>
        /// Permet de validier la modification du profil d'un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdValider_Click(object sender, EventArgs e)
        {
            string message = "13" +  pseudoUtilisateurActif + "," +txtPseudo.Text + "," + txtAnnotation.Text;
            envoiMessage.Connect(message);
        }
    }
}

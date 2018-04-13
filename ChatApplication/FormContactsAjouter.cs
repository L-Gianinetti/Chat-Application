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
    public partial class FrmContactsAjouter : Form
    {
        EnvoiMessage envoiMessage = new EnvoiMessage();
        string pseudoActif;
        User user = new User();

        public FrmContactsAjouter()
        {
            InitializeComponent();
        }
        public FrmContactsAjouter(string pseudo)
        {
            InitializeComponent();
            pseudoActif = pseudo;
        }

        /// <summary>
        /// Ajoute le contact si celui ci est un utilisateur existant et n'est pas deja un contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            string contactExistant = "06" + pseudoActif + "," + txtPseudo.Text;

            string contactExistantTrouve = envoiMessage.Connect(contactExistant);
            if(contactExistantTrouve == txtPseudo.Text)
            {
                MessageBox.Show("Demande de contact envoyée!");
                
            }
            else if(contactExistantTrouve == "L'utilisateur fait deja parti de vos contacts")
            {
                MessageBox.Show("L'utilisateur fait deja parti de vos contacts !");
            }
            else if(contactExistantTrouve == "Vous ne pouvez pas vous ajouter vous meme")
            {
                MessageBox.Show("Vous ne pouvez pas vous ajouter vous meme !");
            }
            else
            {
                MessageBox.Show("Contact inexistant!");
                user = null;
                
            }
        }

        public User ajoutDemande()
        {
            user.Pseudo = txtPseudo.Text;
            return user;
        }
    }
}

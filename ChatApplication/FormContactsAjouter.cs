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

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            string contactExistant = "06" + pseudoActif + "," + txtPseudo.Text;

            string contactExistantTrouve = envoiMessage.Connect(contactExistant);
            if(contactExistantTrouve == txtPseudo.Text)
            {
                MessageBox.Show("Demande de contact envoyée!");
                
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

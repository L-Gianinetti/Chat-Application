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
    public partial class frmEnregistrement : Form
    {
        User user = new User();
        EnvoiMessage envoiMessage = new EnvoiMessage();

        public frmEnregistrement()
        {
            InitializeComponent();
        }

        private void pseudoCorrect()
        {
            bool chiffreLettre = true;

            //Vérifie si le pseudo contient uniquement des chiffres et des lettres
            foreach (char c in txtIdentifiant.Text)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    chiffreLettre = false;
                }
            }
            string pseudoAVerifier = "05" + txtIdentifiant.Text;
            string pseudoTrouve = envoiMessage.Connect(pseudoAVerifier);
            if (pseudoTrouve == txtIdentifiant.Text)
            {
                lblRemarque.Text = "Pseudo déjà existant !";
                chkIdentifiant.Checked = false;
            }
            else if(pseudoTrouve == "PseudoDisponible")
            {
                chkIdentifiant.Checked = true;
                lblRemarque.Text = "";
            }
            //L'implémentation du foreach qui vérifie que le pseudo contient uniquement des chiffres et des lettres rempli deja ce role
            /*else if (txtIdentifiant.Text.Substring(txtIdentifiant.Text.Length-1, 1) == " ")
            {
                lblRemarque.Text = "Votre pseudo ne peut finir par un espace !";
                chkIdentifiant.Checked = false;
            }*/
            else if (txtIdentifiant.Text.Length < 3)
            {
                lblRemarque.Text = "Votre pseudo doit contenir au moins 3 caractères !";
                chkIdentifiant.Checked = false;
            }
            else if (chiffreLettre == false)
            {
                lblRemarque.Text = "Votre pseudo doit être constituer uniquement de chiffres et de lettres !";
                chiffreLettre = true;
                chkIdentifiant.Checked = false;
            }
            else
            {
                lblRemarque.Text = "";
                chkIdentifiant.Checked = true;
            }
        }

        private void motDePasseConforme()
        {
            bool _majuscule = false;
            bool _chiffre = false;

            if (txtMotDePasse.Text.Any(char.IsUpper))
            {
                _majuscule = true;
            }

            if (txtMotDePasse.Text.Any(char.IsDigit))
            {
                _chiffre = true;
            }

            if (txtMotDePasse.Text.Length < 8)
            {
                lblRemarqueMDP.Text = "Votre mot de passe doit contenir au moins 8 caractères !";
                chkMotDePasse.Checked = false;
            }
            else if (_majuscule == false && _chiffre == false)
            {
                lblRemarqueMDP.Text = "Votre mot de passe doit contenir au moins une majuscule et un chiffre !";
                chkMotDePasse.Checked = false;
                _majuscule = false;
                _chiffre = false;
            }
            else if (_majuscule == false)
            {
                lblRemarqueMDP.Text = "Votre mot de passe doit contenir au moins une majuscule !";
                chkMotDePasse.Checked = false;
                _majuscule = false;
            }
            else if (_chiffre == false)
            {
                lblRemarqueMDP.Text = "Votre mot de passe doit contenir au moins un chiffre !";
                chkMotDePasse.Checked = false;
                _chiffre = false;
            }
            else
            {
                lblRemarqueMDP.Text = "";
                chkMotDePasse.Checked = true;
            }
        }

        private void motsDePasseIdentiques()
        {
            if (txtMotDePasseConfirme.Text == txtMotDePasse.Text)
            {
                chkMotDePasseConfirme.Checked = true;
            }
            else
            {
                chkMotDePasseConfirme.Checked = false;
            }
        }

        private void champsRemplisCorrectement()
        {
            if (chkIdentifiant.Checked == true && chkMotDePasse.Checked == true && chkMotDePasseConfirme.Checked == true)
            {
                cmdSuivant.Enabled = true;
            }
            else
            {
                cmdSuivant.Enabled = false;
            }
        }

        private void cmdSuivant_Click(object sender, EventArgs e)
        {
            frmEnregistrement2 frmEnregistrement2 = new frmEnregistrement2(txtIdentifiant.Text, txtMotDePasse.Text);
            frmEnregistrement2.ShowDialog();
            DialogResult res = frmEnregistrement2.DialogResult;

            if(res == DialogResult.OK)
            {
                frmEnregistrement2.Close();
            }
            frmEnregistrement2.Dispose();
        }

        private void txtMotDePasseConfirme_TextChanged(object sender, EventArgs e)
        {
            motsDePasseIdentiques();
        }

        private void txtIdentifiant_TextChanged(object sender, EventArgs e)
        {

            // champsRemplisCorrectement();
        }

        private void txtMotDePasse_TextChanged(object sender, EventArgs e)
        {
            motDePasseConforme();
            motsDePasseIdentiques();

        }

        private void cmdVerifier_Click(object sender, EventArgs e)
        {
            pseudoCorrect();
            champsRemplisCorrectement();
        }

        private void frmEnregistrement_Load(object sender, EventArgs e)
        {
            cmdSuivant.Enabled = false;
        }
    }
}

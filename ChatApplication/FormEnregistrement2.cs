using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChatApplication
{
    public partial class frmEnregistrement2 : Form
    {
        User userEnregistrement = new User();
        ConnexionBD connexionBD = new ConnexionBD();

        string motPasse;

        public frmEnregistrement2(string pseudonym, string motDePasse)
        {
            InitializeComponent();
            txtPseudo.Text = pseudonym;
            motPasse = motDePasse;
        }
        public frmEnregistrement2()
        {
            InitializeComponent();
        }


        private void cmdPhoto_Click(object sender, EventArgs e)
        {
            string fichier;
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                try
                {
                    fichier = openFileDialog1.FileName;
                    Console.WriteLine(fichier);
                    ptbPhoto.Image = Image.FromFile(fichier);
                }
                catch (IOException)
                {

                }

                
            }
            Console.WriteLine(result);
        }


        private void cmdValider_Click(object sender, EventArgs e)
        {
            userEnregistrement.Nom = txtNom.Text;
            userEnregistrement.Prenom = txtPrenom.Text;
            userEnregistrement.Pseudo = txtPseudo.Text;
            userEnregistrement.Description = txtDescription.Text;
            userEnregistrement.MotDePasse = motPasse;
            userEnregistrement.Photo = txtPseudo.Text + ".png";

            string cheminImage = connexionBD.CheminDocumentation() + userEnregistrement.Photo;
            ptbPhoto.Image.Save(cheminImage);

            connexionBD.ajoutUser(userEnregistrement);
        }
    }
}

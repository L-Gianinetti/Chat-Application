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
    public partial class frmProfil : Form
    {
        ConnexionBD connexionBD = new ConnexionBD();
        User user = new User();
        
        public frmProfil()
        {
            InitializeComponent();
        }

        private void frmProfil_Load(object sender, EventArgs e)
        {

            user.Pseudo = Properties.Settings.Default.UserActif;
            txtPseudo.Text = connexionBD.InfoProfilPseudo(user);
            txtNom.Text = connexionBD.InfoProfilNom(user);
            txtPrenom.Text = connexionBD.InfoProfilPrenom(user);
            txtDescription.Text = connexionBD.InfoProfilDescription(user);

            string cheminPhoto = connexionBD.CheminDocumentation() + connexionBD.InfoProfilPhoto(user);

            //https://stackoverflow.com/questions/17193825/loading-picturebox-image-from-resource-file-with-path-part-3
            ptbPhoto.Image = Image.FromFile(cheminPhoto);
        }

        private void cmdPhoto_Click(object sender, EventArgs e)
        {
            string fichier;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
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
        }

        private void cmdValider_Click(object sender, EventArgs e)
        {
            user.Nom = txtNom.Text;
            user.Prenom = txtPrenom.Text;
            user.Description = txtDescription.Text;
            user.Pseudo = txtPseudo.Text;
            user.Photo = txtPseudo.Text + ".png";
            connexionBD.UpdateProfil(user);

            string cheminImage = connexionBD.CheminDocumentation() + user.Photo;
            System.IO.File.Delete(cheminImage);
            ptbPhoto.Image.Save(cheminImage);
        }
    }
}

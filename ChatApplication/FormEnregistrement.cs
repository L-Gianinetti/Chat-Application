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
        ConnexionBD connexionBD = new ConnexionBD();
        public frmEnregistrement()
        {
            InitializeComponent();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdSuivant_Click(object sender, EventArgs e)
        {
            frmEnregistrement2 frmEnregistrement2 = new frmEnregistrement2();
            frmEnregistrement2.ShowDialog();
        }

        private void txtIdentifiant_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            user.Pseudo = txtIdentifiant.Text;
            if (connexionBD.UserExistant(user) == user.Pseudo)
            {
                lblPseudoExistant.Visible = true;
                chkIdentifiant.Checked = false;
            }
            else
            {
                lblPseudoExistant.Visible = false;
                chkIdentifiant.Checked = true;
            }
        }
    }
}

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
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdSEnregistrer_Click(object sender, EventArgs e)
        {
            frmEnregistrement frmEnregistrement = new frmEnregistrement();
            frmEnregistrement.ShowDialog();

            frmEnregistrement2 frmEnregistrement2 = new frmEnregistrement2();

            DialogResult res = frmEnregistrement2.DialogResult;
            if( res == DialogResult.OK)
            {

            }
        }
    }
}

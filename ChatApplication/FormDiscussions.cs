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
    public partial class frmDiscussions : Form
    {
        public frmDiscussions()
        {
            InitializeComponent();
        }

        private void cmdProfil_Click(object sender, EventArgs e)
        {
            frmProfil frmProfil = new frmProfil();
            frmProfil.ShowDialog();
        }
    }
}

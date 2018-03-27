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
        EnvoiMessage envoieMessage = new EnvoiMessage();
        public FrmDiscussionRecherche()
        {
            InitializeComponent();
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
    }
}

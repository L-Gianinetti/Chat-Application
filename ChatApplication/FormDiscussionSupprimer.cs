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
    public partial class FrmDiscussionSupprimer : Form
    {
        string nomDiscussion = string.Empty;
        EnvoiMessage envoiMessage = new EnvoiMessage();
        public FrmDiscussionSupprimer()
        {
            InitializeComponent();
        }
        public FrmDiscussionSupprimer(string nomDisc)
        {
            InitializeComponent();
            nomDiscussion = nomDisc;
        }

        private void FrmDiscussionSupprimer_Load(object sender, EventArgs e)
        {
            string message23 = "23" + nomDiscussion;
            //Le serveur retourne les noms des participants a une discussion séparés par des virgules
            string reponse23 = envoiMessage.Connect(message23);
            string[] nomsParticipants = reponse23.Split(',');
            for(int i =0; i < nomsParticipants.Length; i++)
            {
                if (!lstParticipants.Items.Contains(nomsParticipants[i]))
                {
                    lstParticipants.Items.Add(nomsParticipants[i]);
                }
            }
        }

        /// <summary>
        /// Suppresion par l'administrateur d'un des membres d'une discussion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSupprimer_Click(object sender, EventArgs e)
        {
            if(lstParticipants.SelectedIndex > -1)
            {
                string message29 = "29" + nomDiscussion +","+lstParticipants.SelectedItem.ToString() ;
                envoiMessage.Connect(message29);
                lstParticipants.Items.Remove(lstParticipants.SelectedItem);
            }
        }

    }
}

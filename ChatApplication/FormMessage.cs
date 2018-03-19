using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ChatApplication
{
    public partial class FrmMessage : Form
    {
        User utilisateur = new User();
        string nomDiscussion = string.Empty;
        EnvoiMessage envoiMessage = new EnvoiMessage();
        public FrmMessage()
        {
            InitializeComponent();
        }
        public FrmMessage(string nom,string pseudo)
        {
            InitializeComponent();
            nomDiscussion = nom;
            utilisateur.Pseudo = pseudo;
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            
            string message23 = "23" + nomDiscussion;
            //string reponse = envoiMessage.Connect(message23);
            lblParticipants.Text = envoiMessage.Connect(message23);

        }

        private void grbParticipants_Enter(object sender, EventArgs e)
        {

        }

        private void cmdEnvoyer_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            MessageBox.Show(dateTime.ToString());
            txtMessageEnvoi.Text = txtMessageEnvoi.Text.Replace(',', '§');
            string message = "24" + utilisateur.Pseudo + "," + txtMessageEnvoi.Text + "," + dateTime.ToString() + "," + nomDiscussion;
            string reponse = envoiMessage.Connect(message);
        }

        public void OnTimed(object sender, ElapsedEventHandler e)
        {

        }

        public  void timerTest()
        {
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Interval = 1000;
            myTimer.Elapsed += new ElapsedEventHandler(OnTimed);
            myTimer.Enabled = true;
        }
    }
}

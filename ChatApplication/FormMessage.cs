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
    public partial class FrmMessage : Form
    {
        User utilisateur = new User();
        string nomDiscussion = string.Empty;
        EnvoiMessage envoiMessage = new EnvoiMessage();
        static Timer myTimer = new Timer();
        //static int myCounter = 0;
        public FrmMessage()
        {
            InitializeComponent();

            myTimer.Tick += new EventHandler(myTimerTick);
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        public FrmMessage(string nom,string pseudo)
        {
            InitializeComponent();
            nomDiscussion = nom;
            utilisateur.Pseudo = pseudo;

            myTimer.Tick += new EventHandler(myTimerTick);
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        public void myTimerTick(object sender, System.EventArgs e)
        {
            string message = "25" + nomDiscussion;
            string reponse = envoiMessage.Connect(message);
            
            if(reponse != string.Empty)
            {
                reponse = reponse.Substring(0, reponse.Length - 1);
                string[] messageRecu = reponse.Split('*');
                string[] test;
                for (int i = 0; i < messageRecu.Length; i++)
                {
                    test = messageRecu[i].Split('$');
                    string messageListe = string.Empty;
                    if(test[0].Length > 10)
                    {
                        messageListe = test[0] + " : " + test[1];

                    }
                    
                    if (!lstMessages.Items.Contains(messageListe) && messageListe != string.Empty)
                    {
                        lstMessages.Items.Add(messageListe);
                    }
                    
                }
            }

        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            
            string message23 = "23" + nomDiscussion;
            //string reponse = envoiMessage.Connect(message23);
            lblParticipants.Text = envoiMessage.Connect(message23);

        }



        private void cmdEnvoyer_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            MessageBox.Show(dateTime.ToString());
            txtMessageEnvoi.Text = txtMessageEnvoi.Text.Replace(',', '§');
            string message = "24" + utilisateur.Pseudo + "," + txtMessageEnvoi.Text + "," + dateTime.ToString() + "," + nomDiscussion;
            string reponse = envoiMessage.Connect(message);
        }




    }
}

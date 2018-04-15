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
                //Les messages sont séparés par des "*"
                string[] messageRecu = reponse.Split('*');
                string[] test;
                for (int i = 0; i < messageRecu.Length; i++)
                {
                    //Les différents éléments du message sont séparés par un "§"
                    test = messageRecu[i].Split('$');
                    string messageListe = string.Empty;
                    //Nombre de caractères "minimum" (pseudo, date) avant le début du message
                    if(test[0].Length > 2 && test[1].Length > 18)
                    {
                        messageListe = test[0] + " - " + test[1] + " : " + test[2];
                    }
                    //afficher une seule fois chaque message
                    if (!lstMessages.Items.Contains(messageListe) && messageListe != string.Empty)
                    {
                        lstMessages.Items.Add(messageListe);
                    }  
                }
            }
        }


        private void FrmMessage_Load(object sender, EventArgs e)
        {
            //Pour afficher la liste des participants
            string message23 = "23" + nomDiscussion;
            lblParticipants.Text = envoiMessage.Connect(message23);

            //Pour activer les boutons ajouter et supprimer si l'utilisateur est l'admin de la discussion
            string message26 = "26" + nomDiscussion;
            string reponse26 = envoiMessage.Connect(message26);
            if(reponse26 == utilisateur.Pseudo)
            {
                cmdAAjouter.Enabled = true;
                cmdASupprimer.Enabled = true;
            }
            else
            {
                cmdAAjouter.Enabled = false;
                cmdASupprimer.Enabled = false;
            }
        }

        private void cmdEnvoyer_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            MessageBox.Show(dateTime.ToString());
            //Remplace les "," par des "§" car je différencie les éléments par une virgule
            txtMessageEnvoi.Text = txtMessageEnvoi.Text.Replace(',', '§');
            //Envoi du message au serveur pseudo + message + date +nom discussion
            string message = "24" + utilisateur.Pseudo + "," + txtMessageEnvoi.Text + "," + dateTime.ToString() + "," + nomDiscussion;
            envoiMessage.Connect(message);
        }

        private void cmdAAjouter_Click(object sender, EventArgs e)
        {
            FrmDiscussionAjouter frmDiscussionAjouter = new FrmDiscussionAjouter(utilisateur.Pseudo, nomDiscussion);

            frmDiscussionAjouter.Show();
            DialogResult res = new DialogResult();
            if(res == DialogResult.OK)
            {
                frmDiscussionAjouter.Close();
            }
        }

        private void cmdASupprimer_Click(object sender, EventArgs e)
        {
            FrmDiscussionSupprimer frmDiscussionSupprimer = new FrmDiscussionSupprimer(nomDiscussion);
            frmDiscussionSupprimer.Show();
            DialogResult res = new DialogResult();
            if (res == DialogResult.OK)
            {
                frmDiscussionSupprimer.Close();
            }
        }
    }
}

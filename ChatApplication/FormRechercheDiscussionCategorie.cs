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
    public partial class FrmRechercheDiscussionCategorie : Form
    {
        EnvoiMessage envoiMessage = new EnvoiMessage();
        string categorie = string.Empty;
        User utilisateur = new User();
        public FrmRechercheDiscussionCategorie()
        {
            InitializeComponent();
        }
        public FrmRechercheDiscussionCategorie(string category, string pseudo)
        {
            InitializeComponent();
            categorie = category;
            utilisateur.Pseudo = pseudo;
        }

        private void FrmRechercheDiscussionCategorie_Load(object sender, EventArgs e)
        {
            string message = "36" + categorie;
            //Retourne les noms de discussions appartenant a une catégorie
            string reponse = envoiMessage.Connect(message);
            string message38 = "38" + utilisateur.Pseudo + "," +categorie;
            //Retourne les discussions auxquelles l'utilisateurs participe deja selon une catégorie
            string reponse38 = envoiMessage.Connect(message38);
            string[] retour38 = reponse38.Split(',');
            if(reponse != string.Empty)
            {
                string[] retour = reponse.Split(',');
                for(int i = 0; i < retour.Length; i++)
                {
                    //Si la liste ne contient pas encore la discussion
                    if (!lstDiscussions.Items.Contains(retour[i]))
                    {
                        for(int y = 0; y < retour38.Length; y++)
                        {
                            //Si l'utilisateur ne participe pas deja a cette discussion
                            if(retour38[y] != retour[i])
                            {
                                if (!lstDiscussions.Items.Contains(retour[i]))
                                {
                                    lstDiscussions.Items.Add(retour[i]);
                                }
                            }
                            else
                            {
                                i++;
                            }
                        }
                        i--;

                    }
                }
            }
            
        }

        private void cmdRejoindre_Click(object sender, EventArgs e)
        {
            if(lstDiscussions.SelectedIndex > -1)
            {
                //Pour rejoindre une discussion publique
                string message = "37" + utilisateur.Pseudo + ","+lstDiscussions.SelectedItem.ToString();
                envoiMessage.Connect(message);
                this.Close();
            }
            
        }
    }
}

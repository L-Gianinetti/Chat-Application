namespace ChatApplication
{
    partial class frmDiscussions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbMenu = new System.Windows.Forms.GroupBox();
            this.cmdQuitter = new System.Windows.Forms.Button();
            this.cmdDiscussions = new System.Windows.Forms.Button();
            this.cmdDeconnexion = new System.Windows.Forms.Button();
            this.cmdArchives = new System.Windows.Forms.Button();
            this.cmdProfil = new System.Windows.Forms.Button();
            this.cmdContacts = new System.Windows.Forms.Button();
            this.grbActions = new System.Windows.Forms.GroupBox();
            this.cmdADemandes = new System.Windows.Forms.Button();
            this.cmdARechercher = new System.Windows.Forms.Button();
            this.cmdACreer = new System.Windows.Forms.Button();
            this.cmdADiscussions = new System.Windows.Forms.Button();
            this.lstDiscussions = new System.Windows.Forms.ListBox();
            this.cmdArchiver = new System.Windows.Forms.Button();
            this.cmdSupprimer = new System.Windows.Forms.Button();
            this.grbMenu.SuspendLayout();
            this.grbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMenu
            // 
            this.grbMenu.Controls.Add(this.cmdQuitter);
            this.grbMenu.Controls.Add(this.cmdDiscussions);
            this.grbMenu.Controls.Add(this.cmdDeconnexion);
            this.grbMenu.Controls.Add(this.cmdArchives);
            this.grbMenu.Controls.Add(this.cmdProfil);
            this.grbMenu.Controls.Add(this.cmdContacts);
            this.grbMenu.Location = new System.Drawing.Point(12, 12);
            this.grbMenu.Name = "grbMenu";
            this.grbMenu.Size = new System.Drawing.Size(111, 466);
            this.grbMenu.TabIndex = 1;
            this.grbMenu.TabStop = false;
            this.grbMenu.Text = "Menu";
            // 
            // cmdQuitter
            // 
            this.cmdQuitter.Location = new System.Drawing.Point(6, 299);
            this.cmdQuitter.Name = "cmdQuitter";
            this.cmdQuitter.Size = new System.Drawing.Size(89, 23);
            this.cmdQuitter.TabIndex = 4;
            this.cmdQuitter.Text = "Quitter";
            this.cmdQuitter.UseVisualStyleBackColor = true;
            // 
            // cmdDiscussions
            // 
            this.cmdDiscussions.Location = new System.Drawing.Point(7, 136);
            this.cmdDiscussions.Name = "cmdDiscussions";
            this.cmdDiscussions.Size = new System.Drawing.Size(88, 23);
            this.cmdDiscussions.TabIndex = 5;
            this.cmdDiscussions.Text = "Discussions";
            this.cmdDiscussions.UseVisualStyleBackColor = true;
            // 
            // cmdDeconnexion
            // 
            this.cmdDeconnexion.Location = new System.Drawing.Point(7, 243);
            this.cmdDeconnexion.Name = "cmdDeconnexion";
            this.cmdDeconnexion.Size = new System.Drawing.Size(88, 23);
            this.cmdDeconnexion.TabIndex = 2;
            this.cmdDeconnexion.Text = "Déconnexion";
            this.cmdDeconnexion.UseVisualStyleBackColor = true;
            // 
            // cmdArchives
            // 
            this.cmdArchives.Location = new System.Drawing.Point(7, 195);
            this.cmdArchives.Name = "cmdArchives";
            this.cmdArchives.Size = new System.Drawing.Size(88, 23);
            this.cmdArchives.TabIndex = 3;
            this.cmdArchives.Text = "Archives";
            this.cmdArchives.UseVisualStyleBackColor = true;
            // 
            // cmdProfil
            // 
            this.cmdProfil.Location = new System.Drawing.Point(6, 36);
            this.cmdProfil.Name = "cmdProfil";
            this.cmdProfil.Size = new System.Drawing.Size(89, 23);
            this.cmdProfil.TabIndex = 0;
            this.cmdProfil.Text = "Mon profil";
            this.cmdProfil.UseVisualStyleBackColor = true;
            this.cmdProfil.Click += new System.EventHandler(this.cmdProfil_Click);
            // 
            // cmdContacts
            // 
            this.cmdContacts.Location = new System.Drawing.Point(6, 88);
            this.cmdContacts.Name = "cmdContacts";
            this.cmdContacts.Size = new System.Drawing.Size(89, 23);
            this.cmdContacts.TabIndex = 1;
            this.cmdContacts.Text = "Contacts";
            this.cmdContacts.UseVisualStyleBackColor = true;
            // 
            // grbActions
            // 
            this.grbActions.Controls.Add(this.cmdADemandes);
            this.grbActions.Controls.Add(this.cmdARechercher);
            this.grbActions.Controls.Add(this.cmdACreer);
            this.grbActions.Controls.Add(this.cmdADiscussions);
            this.grbActions.Location = new System.Drawing.Point(130, 13);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(603, 87);
            this.grbActions.TabIndex = 2;
            this.grbActions.TabStop = false;
            this.grbActions.Text = "Actions";
            // 
            // cmdADemandes
            // 
            this.cmdADemandes.Location = new System.Drawing.Point(401, 28);
            this.cmdADemandes.Name = "cmdADemandes";
            this.cmdADemandes.Size = new System.Drawing.Size(181, 36);
            this.cmdADemandes.TabIndex = 3;
            this.cmdADemandes.Text = "Mes demandes de discussion";
            this.cmdADemandes.UseVisualStyleBackColor = true;
            // 
            // cmdARechercher
            // 
            this.cmdARechercher.Location = new System.Drawing.Point(241, 28);
            this.cmdARechercher.Name = "cmdARechercher";
            this.cmdARechercher.Size = new System.Drawing.Size(141, 36);
            this.cmdARechercher.TabIndex = 2;
            this.cmdARechercher.Text = "Rechercher un sujet de discussion";
            this.cmdARechercher.UseVisualStyleBackColor = true;
            // 
            // cmdACreer
            // 
            this.cmdACreer.Location = new System.Drawing.Point(110, 28);
            this.cmdACreer.Name = "cmdACreer";
            this.cmdACreer.Size = new System.Drawing.Size(114, 36);
            this.cmdACreer.TabIndex = 1;
            this.cmdACreer.Text = "Créer une discussion";
            this.cmdACreer.UseVisualStyleBackColor = true;
            // 
            // cmdADiscussions
            // 
            this.cmdADiscussions.Location = new System.Drawing.Point(15, 28);
            this.cmdADiscussions.Name = "cmdADiscussions";
            this.cmdADiscussions.Size = new System.Drawing.Size(75, 36);
            this.cmdADiscussions.TabIndex = 0;
            this.cmdADiscussions.Text = "Discussions";
            this.cmdADiscussions.UseVisualStyleBackColor = true;
            // 
            // lstDiscussions
            // 
            this.lstDiscussions.FormattingEnabled = true;
            this.lstDiscussions.Location = new System.Drawing.Point(130, 107);
            this.lstDiscussions.Name = "lstDiscussions";
            this.lstDiscussions.Size = new System.Drawing.Size(521, 368);
            this.lstDiscussions.TabIndex = 3;
            // 
            // cmdArchiver
            // 
            this.cmdArchiver.Location = new System.Drawing.Point(658, 116);
            this.cmdArchiver.Name = "cmdArchiver";
            this.cmdArchiver.Size = new System.Drawing.Size(75, 23);
            this.cmdArchiver.TabIndex = 4;
            this.cmdArchiver.Text = "Archiver";
            this.cmdArchiver.UseVisualStyleBackColor = true;
            // 
            // cmdSupprimer
            // 
            this.cmdSupprimer.Location = new System.Drawing.Point(658, 147);
            this.cmdSupprimer.Name = "cmdSupprimer";
            this.cmdSupprimer.Size = new System.Drawing.Size(75, 23);
            this.cmdSupprimer.TabIndex = 5;
            this.cmdSupprimer.Text = "Supprimer";
            this.cmdSupprimer.UseVisualStyleBackColor = true;
            // 
            // frmDiscussions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 487);
            this.Controls.Add(this.cmdSupprimer);
            this.Controls.Add(this.cmdArchiver);
            this.Controls.Add(this.lstDiscussions);
            this.Controls.Add(this.grbActions);
            this.Controls.Add(this.grbMenu);
            this.Name = "frmDiscussions";
            this.Text = "Mes demandes de discussion";
            this.grbMenu.ResumeLayout(false);
            this.grbActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMenu;
        private System.Windows.Forms.Button cmdQuitter;
        private System.Windows.Forms.Button cmdDiscussions;
        private System.Windows.Forms.Button cmdDeconnexion;
        private System.Windows.Forms.Button cmdArchives;
        private System.Windows.Forms.Button cmdProfil;
        private System.Windows.Forms.Button cmdContacts;
        private System.Windows.Forms.GroupBox grbActions;
        private System.Windows.Forms.Button cmdADemandes;
        private System.Windows.Forms.Button cmdARechercher;
        private System.Windows.Forms.Button cmdACreer;
        private System.Windows.Forms.Button cmdADiscussions;
        private System.Windows.Forms.ListBox lstDiscussions;
        private System.Windows.Forms.Button cmdArchiver;
        private System.Windows.Forms.Button cmdSupprimer;
    }
}
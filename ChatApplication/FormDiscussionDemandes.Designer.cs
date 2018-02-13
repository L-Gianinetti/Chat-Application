namespace ChatApplication
{
    partial class FrmDiscussionDemandes
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
            this.grbDemandes = new System.Windows.Forms.GroupBox();
            this.lblRemarque = new System.Windows.Forms.Label();
            this.lblDiscussions = new System.Windows.Forms.Label();
            this.lblGroupes = new System.Windows.Forms.Label();
            this.cmbDiscussions = new System.Windows.Forms.ComboBox();
            this.cmbGroupes = new System.Windows.Forms.ComboBox();
            this.cmdAccepterDiscussion = new System.Windows.Forms.Button();
            this.cmdRefuserDiscussion = new System.Windows.Forms.Button();
            this.cmdAccepterGroupe = new System.Windows.Forms.Button();
            this.cmdRefuserGroupe = new System.Windows.Forms.Button();
            this.grbMenu.SuspendLayout();
            this.grbActions.SuspendLayout();
            this.grbDemandes.SuspendLayout();
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
            this.grbMenu.TabIndex = 2;
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
            this.grbActions.Location = new System.Drawing.Point(129, 12);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(603, 87);
            this.grbActions.TabIndex = 3;
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
            // grbDemandes
            // 
            this.grbDemandes.Controls.Add(this.cmdRefuserGroupe);
            this.grbDemandes.Controls.Add(this.cmdAccepterGroupe);
            this.grbDemandes.Controls.Add(this.cmdRefuserDiscussion);
            this.grbDemandes.Controls.Add(this.cmdAccepterDiscussion);
            this.grbDemandes.Controls.Add(this.cmbGroupes);
            this.grbDemandes.Controls.Add(this.cmbDiscussions);
            this.grbDemandes.Controls.Add(this.lblGroupes);
            this.grbDemandes.Controls.Add(this.lblDiscussions);
            this.grbDemandes.Controls.Add(this.lblRemarque);
            this.grbDemandes.Location = new System.Drawing.Point(129, 105);
            this.grbDemandes.Name = "grbDemandes";
            this.grbDemandes.Size = new System.Drawing.Size(598, 373);
            this.grbDemandes.TabIndex = 4;
            this.grbDemandes.TabStop = false;
            this.grbDemandes.Text = "Demandes";
            // 
            // lblRemarque
            // 
            this.lblRemarque.AutoSize = true;
            this.lblRemarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarque.Location = new System.Drawing.Point(6, 32);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(553, 13);
            this.lblRemarque.TabIndex = 0;
            this.lblRemarque.Text = "Vous avez été ajouté aux discussions suivantes, veuillez les accepter pour pouvoi" +
    "r y participer :";
            // 
            // lblDiscussions
            // 
            this.lblDiscussions.AutoSize = true;
            this.lblDiscussions.Location = new System.Drawing.Point(6, 82);
            this.lblDiscussions.Name = "lblDiscussions";
            this.lblDiscussions.Size = new System.Drawing.Size(69, 13);
            this.lblDiscussions.TabIndex = 1;
            this.lblDiscussions.Text = "Discussions :";
            // 
            // lblGroupes
            // 
            this.lblGroupes.AutoSize = true;
            this.lblGroupes.Location = new System.Drawing.Point(12, 216);
            this.lblGroupes.Name = "lblGroupes";
            this.lblGroupes.Size = new System.Drawing.Size(53, 13);
            this.lblGroupes.TabIndex = 2;
            this.lblGroupes.Text = "Groupes :";
            // 
            // cmbDiscussions
            // 
            this.cmbDiscussions.FormattingEnabled = true;
            this.cmbDiscussions.Location = new System.Drawing.Point(26, 104);
            this.cmbDiscussions.Name = "cmbDiscussions";
            this.cmbDiscussions.Size = new System.Drawing.Size(399, 21);
            this.cmbDiscussions.TabIndex = 3;
            // 
            // cmbGroupes
            // 
            this.cmbGroupes.FormattingEnabled = true;
            this.cmbGroupes.Location = new System.Drawing.Point(26, 253);
            this.cmbGroupes.Name = "cmbGroupes";
            this.cmbGroupes.Size = new System.Drawing.Size(399, 21);
            this.cmbGroupes.TabIndex = 4;
            // 
            // cmdAccepterDiscussion
            // 
            this.cmdAccepterDiscussion.Location = new System.Drawing.Point(401, 150);
            this.cmdAccepterDiscussion.Name = "cmdAccepterDiscussion";
            this.cmdAccepterDiscussion.Size = new System.Drawing.Size(75, 23);
            this.cmdAccepterDiscussion.TabIndex = 5;
            this.cmdAccepterDiscussion.Text = "Accepter";
            this.cmdAccepterDiscussion.UseVisualStyleBackColor = true;
            // 
            // cmdRefuserDiscussion
            // 
            this.cmdRefuserDiscussion.Location = new System.Drawing.Point(507, 150);
            this.cmdRefuserDiscussion.Name = "cmdRefuserDiscussion";
            this.cmdRefuserDiscussion.Size = new System.Drawing.Size(75, 23);
            this.cmdRefuserDiscussion.TabIndex = 6;
            this.cmdRefuserDiscussion.Text = "Refuser";
            this.cmdRefuserDiscussion.UseVisualStyleBackColor = true;
            // 
            // cmdAccepterGroupe
            // 
            this.cmdAccepterGroupe.Location = new System.Drawing.Point(401, 297);
            this.cmdAccepterGroupe.Name = "cmdAccepterGroupe";
            this.cmdAccepterGroupe.Size = new System.Drawing.Size(75, 23);
            this.cmdAccepterGroupe.TabIndex = 7;
            this.cmdAccepterGroupe.Text = "Accepter";
            this.cmdAccepterGroupe.UseVisualStyleBackColor = true;
            // 
            // cmdRefuserGroupe
            // 
            this.cmdRefuserGroupe.Location = new System.Drawing.Point(507, 297);
            this.cmdRefuserGroupe.Name = "cmdRefuserGroupe";
            this.cmdRefuserGroupe.Size = new System.Drawing.Size(75, 23);
            this.cmdRefuserGroupe.TabIndex = 8;
            this.cmdRefuserGroupe.Text = "Refuser";
            this.cmdRefuserGroupe.UseVisualStyleBackColor = true;
            // 
            // FrmDiscussionDemandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 481);
            this.Controls.Add(this.grbDemandes);
            this.Controls.Add(this.grbActions);
            this.Controls.Add(this.grbMenu);
            this.Name = "FrmDiscussionDemandes";
            this.Text = "Demandes de discussion";
            this.grbMenu.ResumeLayout(false);
            this.grbActions.ResumeLayout(false);
            this.grbDemandes.ResumeLayout(false);
            this.grbDemandes.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbDemandes;
        private System.Windows.Forms.Label lblGroupes;
        private System.Windows.Forms.Label lblDiscussions;
        private System.Windows.Forms.Label lblRemarque;
        private System.Windows.Forms.ComboBox cmbDiscussions;
        private System.Windows.Forms.Button cmdRefuserGroupe;
        private System.Windows.Forms.Button cmdAccepterGroupe;
        private System.Windows.Forms.Button cmdRefuserDiscussion;
        private System.Windows.Forms.Button cmdAccepterDiscussion;
        private System.Windows.Forms.ComboBox cmbGroupes;
    }
}
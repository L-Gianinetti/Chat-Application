namespace ChatApplication
{
    partial class FrmMessage
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
            this.grbParticipants = new System.Windows.Forms.GroupBox();
            this.grbMessages = new System.Windows.Forms.GroupBox();
            this.cmdARetour = new System.Windows.Forms.Button();
            this.cmdAAjouter = new System.Windows.Forms.Button();
            this.cmdASupprimer = new System.Windows.Forms.Button();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.cmdEnvoyer = new System.Windows.Forms.Button();
            this.cmdSmiley = new System.Windows.Forms.Button();
            this.cmdImage = new System.Windows.Forms.Button();
            this.cmdVocal = new System.Windows.Forms.Button();
            this.grbMenu.SuspendLayout();
            this.grbActions.SuspendLayout();
            this.grbParticipants.SuspendLayout();
            this.grbMessages.SuspendLayout();
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
            this.grbMenu.TabIndex = 3;
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
            this.grbActions.Controls.Add(this.cmdASupprimer);
            this.grbActions.Controls.Add(this.cmdAAjouter);
            this.grbActions.Controls.Add(this.cmdARetour);
            this.grbActions.Location = new System.Drawing.Point(129, 12);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(597, 59);
            this.grbActions.TabIndex = 4;
            this.grbActions.TabStop = false;
            this.grbActions.Text = "Actions";
            // 
            // grbParticipants
            // 
            this.grbParticipants.Controls.Add(this.lblParticipants);
            this.grbParticipants.Location = new System.Drawing.Point(129, 77);
            this.grbParticipants.Name = "grbParticipants";
            this.grbParticipants.Size = new System.Drawing.Size(597, 46);
            this.grbParticipants.TabIndex = 5;
            this.grbParticipants.TabStop = false;
            this.grbParticipants.Text = "Participants";
            // 
            // grbMessages
            // 
            this.grbMessages.Controls.Add(this.cmdVocal);
            this.grbMessages.Controls.Add(this.cmdImage);
            this.grbMessages.Controls.Add(this.cmdSmiley);
            this.grbMessages.Controls.Add(this.cmdEnvoyer);
            this.grbMessages.Controls.Add(this.txtMessages);
            this.grbMessages.Location = new System.Drawing.Point(129, 130);
            this.grbMessages.Name = "grbMessages";
            this.grbMessages.Size = new System.Drawing.Size(597, 341);
            this.grbMessages.TabIndex = 5;
            this.grbMessages.TabStop = false;
            this.grbMessages.Text = "Messages";
            // 
            // cmdARetour
            // 
            this.cmdARetour.Location = new System.Drawing.Point(44, 20);
            this.cmdARetour.Name = "cmdARetour";
            this.cmdARetour.Size = new System.Drawing.Size(75, 23);
            this.cmdARetour.TabIndex = 0;
            this.cmdARetour.Text = "Retour";
            this.cmdARetour.UseVisualStyleBackColor = true;
            // 
            // cmdAAjouter
            // 
            this.cmdAAjouter.Location = new System.Drawing.Point(195, 20);
            this.cmdAAjouter.Name = "cmdAAjouter";
            this.cmdAAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAAjouter.TabIndex = 1;
            this.cmdAAjouter.Text = "Ajouter";
            this.cmdAAjouter.UseVisualStyleBackColor = true;
            // 
            // cmdASupprimer
            // 
            this.cmdASupprimer.Location = new System.Drawing.Point(371, 18);
            this.cmdASupprimer.Name = "cmdASupprimer";
            this.cmdASupprimer.Size = new System.Drawing.Size(75, 23);
            this.cmdASupprimer.TabIndex = 2;
            this.cmdASupprimer.Text = "Supprimer";
            this.cmdASupprimer.UseVisualStyleBackColor = true;
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticipants.Location = new System.Drawing.Point(17, 23);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(161, 13);
            this.lblParticipants.TabIndex = 0;
            this.lblParticipants.Text = "Vous - Contact1 - Contact2";
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(35, 278);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(364, 46);
            this.txtMessages.TabIndex = 0;
            // 
            // cmdEnvoyer
            // 
            this.cmdEnvoyer.Location = new System.Drawing.Point(324, 91);
            this.cmdEnvoyer.Name = "cmdEnvoyer";
            this.cmdEnvoyer.Size = new System.Drawing.Size(75, 23);
            this.cmdEnvoyer.TabIndex = 1;
            this.cmdEnvoyer.Text = "Envoyer";
            this.cmdEnvoyer.UseVisualStyleBackColor = true;
            // 
            // cmdSmiley
            // 
            this.cmdSmiley.Location = new System.Drawing.Point(422, 91);
            this.cmdSmiley.Name = "cmdSmiley";
            this.cmdSmiley.Size = new System.Drawing.Size(75, 23);
            this.cmdSmiley.TabIndex = 2;
            this.cmdSmiley.Text = "Smiley...";
            this.cmdSmiley.UseVisualStyleBackColor = true;
            // 
            // cmdImage
            // 
            this.cmdImage.Location = new System.Drawing.Point(324, 125);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(75, 23);
            this.cmdImage.TabIndex = 3;
            this.cmdImage.Text = "Image...";
            this.cmdImage.UseVisualStyleBackColor = true;
            // 
            // cmdVocal
            // 
            this.cmdVocal.Location = new System.Drawing.Point(422, 125);
            this.cmdVocal.Name = "cmdVocal";
            this.cmdVocal.Size = new System.Drawing.Size(141, 23);
            this.cmdVocal.TabIndex = 4;
            this.cmdVocal.Text = "Enregistrement vocal...";
            this.cmdVocal.UseVisualStyleBackColor = true;
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 483);
            this.Controls.Add(this.grbParticipants);
            this.Controls.Add(this.grbMessages);
            this.Controls.Add(this.grbActions);
            this.Controls.Add(this.grbMenu);
            this.Name = "FrmMessage";
            this.Text = "Message";
            this.grbMenu.ResumeLayout(false);
            this.grbActions.ResumeLayout(false);
            this.grbParticipants.ResumeLayout(false);
            this.grbParticipants.PerformLayout();
            this.grbMessages.ResumeLayout(false);
            this.grbMessages.PerformLayout();
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
        private System.Windows.Forms.Button cmdASupprimer;
        private System.Windows.Forms.Button cmdAAjouter;
        private System.Windows.Forms.Button cmdARetour;
        private System.Windows.Forms.GroupBox grbParticipants;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.GroupBox grbMessages;
        private System.Windows.Forms.Button cmdVocal;
        private System.Windows.Forms.Button cmdImage;
        private System.Windows.Forms.Button cmdSmiley;
        private System.Windows.Forms.Button cmdEnvoyer;
        private System.Windows.Forms.TextBox txtMessages;
    }
}
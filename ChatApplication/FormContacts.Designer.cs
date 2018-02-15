namespace ChatApplication
{
    partial class FrmContacts
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
            this.cmdASupprimer = new System.Windows.Forms.Button();
            this.cmdAModifier = new System.Windows.Forms.Button();
            this.cmdAAjouter = new System.Windows.Forms.Button();
            this.lstContacts = new System.Windows.Forms.ListBox();
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
            this.grbMenu.TabIndex = 4;
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
            this.grbActions.Controls.Add(this.cmdASupprimer);
            this.grbActions.Controls.Add(this.cmdAModifier);
            this.grbActions.Controls.Add(this.cmdAAjouter);
            this.grbActions.Location = new System.Drawing.Point(129, 12);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(603, 87);
            this.grbActions.TabIndex = 5;
            this.grbActions.TabStop = false;
            this.grbActions.Text = "Actions";
            // 
            // cmdADemandes
            // 
            this.cmdADemandes.Location = new System.Drawing.Point(401, 28);
            this.cmdADemandes.Name = "cmdADemandes";
            this.cmdADemandes.Size = new System.Drawing.Size(181, 36);
            this.cmdADemandes.TabIndex = 3;
            this.cmdADemandes.Text = "Demandes";
            this.cmdADemandes.UseVisualStyleBackColor = true;
            // 
            // cmdASupprimer
            // 
            this.cmdASupprimer.Location = new System.Drawing.Point(241, 28);
            this.cmdASupprimer.Name = "cmdASupprimer";
            this.cmdASupprimer.Size = new System.Drawing.Size(141, 36);
            this.cmdASupprimer.TabIndex = 2;
            this.cmdASupprimer.Text = "Supprimer";
            this.cmdASupprimer.UseVisualStyleBackColor = true;
            // 
            // cmdAModifier
            // 
            this.cmdAModifier.Location = new System.Drawing.Point(110, 28);
            this.cmdAModifier.Name = "cmdAModifier";
            this.cmdAModifier.Size = new System.Drawing.Size(114, 36);
            this.cmdAModifier.TabIndex = 1;
            this.cmdAModifier.Text = "Modifier";
            this.cmdAModifier.UseVisualStyleBackColor = true;
            // 
            // cmdAAjouter
            // 
            this.cmdAAjouter.Location = new System.Drawing.Point(15, 28);
            this.cmdAAjouter.Name = "cmdAAjouter";
            this.cmdAAjouter.Size = new System.Drawing.Size(75, 36);
            this.cmdAAjouter.TabIndex = 0;
            this.cmdAAjouter.Text = "Ajouter";
            this.cmdAAjouter.UseVisualStyleBackColor = true;
            // 
            // lstContacts
            // 
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Location = new System.Drawing.Point(129, 116);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(570, 355);
            this.lstContacts.TabIndex = 16;
            // 
            // FrmContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 485);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.grbActions);
            this.Controls.Add(this.grbMenu);
            this.Name = "FrmContacts";
            this.Text = "Contacts";
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
        private System.Windows.Forms.Button cmdASupprimer;
        private System.Windows.Forms.Button cmdAModifier;
        private System.Windows.Forms.Button cmdAAjouter;
        private System.Windows.Forms.ListBox lstContacts;
    }
}
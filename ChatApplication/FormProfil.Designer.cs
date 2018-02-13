namespace ChatApplication
{
    partial class frmProfil
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
            this.grbProfil = new System.Windows.Forms.GroupBox();
            this.cmdProfil = new System.Windows.Forms.Button();
            this.cmdContacts = new System.Windows.Forms.Button();
            this.cmdDeconnexion = new System.Windows.Forms.Button();
            this.cmdArchives = new System.Windows.Forms.Button();
            this.cmdQuitter = new System.Windows.Forms.Button();
            this.cmdDiscussions = new System.Windows.Forms.Button();
            this.grbPhoto = new System.Windows.Forms.GroupBox();
            this.ptbPhoto = new System.Windows.Forms.PictureBox();
            this.grbInformations = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.cmdValider = new System.Windows.Forms.Button();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdPhoto = new System.Windows.Forms.Button();
            this.grbMenu.SuspendLayout();
            this.grbProfil.SuspendLayout();
            this.grbPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhoto)).BeginInit();
            this.grbInformations.SuspendLayout();
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
            this.grbMenu.Location = new System.Drawing.Point(12, 25);
            this.grbMenu.Name = "grbMenu";
            this.grbMenu.Size = new System.Drawing.Size(111, 466);
            this.grbMenu.TabIndex = 0;
            this.grbMenu.TabStop = false;
            this.grbMenu.Text = "Menu";
            // 
            // grbProfil
            // 
            this.grbProfil.Controls.Add(this.grbInformations);
            this.grbProfil.Controls.Add(this.grbPhoto);
            this.grbProfil.Location = new System.Drawing.Point(129, 25);
            this.grbProfil.Name = "grbProfil";
            this.grbProfil.Size = new System.Drawing.Size(572, 508);
            this.grbProfil.TabIndex = 1;
            this.grbProfil.TabStop = false;
            this.grbProfil.Text = "Mon profil";
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
            // grbPhoto
            // 
            this.grbPhoto.Controls.Add(this.cmdPhoto);
            this.grbPhoto.Controls.Add(this.ptbPhoto);
            this.grbPhoto.Location = new System.Drawing.Point(6, 19);
            this.grbPhoto.Name = "grbPhoto";
            this.grbPhoto.Size = new System.Drawing.Size(560, 160);
            this.grbPhoto.TabIndex = 0;
            this.grbPhoto.TabStop = false;
            this.grbPhoto.Text = "Photo";
            // 
            // ptbPhoto
            // 
            this.ptbPhoto.Location = new System.Drawing.Point(6, 19);
            this.ptbPhoto.Name = "ptbPhoto";
            this.ptbPhoto.Size = new System.Drawing.Size(150, 135);
            this.ptbPhoto.TabIndex = 0;
            this.ptbPhoto.TabStop = false;
            // 
            // grbInformations
            // 
            this.grbInformations.Controls.Add(this.txtDescription);
            this.grbInformations.Controls.Add(this.txtPseudo);
            this.grbInformations.Controls.Add(this.txtPrenom);
            this.grbInformations.Controls.Add(this.txtNom);
            this.grbInformations.Controls.Add(this.lblNom);
            this.grbInformations.Controls.Add(this.lblPrenom);
            this.grbInformations.Controls.Add(this.cmdValider);
            this.grbInformations.Controls.Add(this.lblPseudo);
            this.grbInformations.Controls.Add(this.lblDescription);
            this.grbInformations.Location = new System.Drawing.Point(12, 185);
            this.grbInformations.Name = "grbInformations";
            this.grbInformations.Size = new System.Drawing.Size(554, 317);
            this.grbInformations.TabIndex = 10;
            this.grbInformations.TabStop = false;
            this.grbInformations.Text = "Informations";
            this.grbInformations.Enter += new System.EventHandler(this.grbInformations_Enter);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(175, 161);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(174, 106);
            this.txtDescription.TabIndex = 11;
            // 
            // txtPseudo
            // 
            this.txtPseudo.Enabled = false;
            this.txtPseudo.Location = new System.Drawing.Point(175, 111);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(100, 20);
            this.txtPseudo.TabIndex = 10;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(175, 70);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 20);
            this.txtPrenom.TabIndex = 9;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(175, 34);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 8;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(6, 37);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(6, 73);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(49, 13);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom :";
            // 
            // cmdValider
            // 
            this.cmdValider.Location = new System.Drawing.Point(436, 244);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(100, 23);
            this.cmdValider.TabIndex = 7;
            this.cmdValider.Text = "Valider mon profil";
            this.cmdValider.UseVisualStyleBackColor = true;
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(6, 114);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(74, 13);
            this.lblPseudo.TabIndex = 3;
            this.lblPseudo.Text = "Pseudonyme :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 164);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description :";
            // 
            // cmdPhoto
            // 
            this.cmdPhoto.Location = new System.Drawing.Point(442, 117);
            this.cmdPhoto.Name = "cmdPhoto";
            this.cmdPhoto.Size = new System.Drawing.Size(75, 23);
            this.cmdPhoto.TabIndex = 1;
            this.cmdPhoto.Text = "Parcourir...";
            this.cmdPhoto.UseVisualStyleBackColor = true;
            // 
            // frmProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 545);
            this.Controls.Add(this.grbProfil);
            this.Controls.Add(this.grbMenu);
            this.Name = "frmProfil";
            this.Text = "Mon profil";
            this.grbMenu.ResumeLayout(false);
            this.grbProfil.ResumeLayout(false);
            this.grbPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhoto)).EndInit();
            this.grbInformations.ResumeLayout(false);
            this.grbInformations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMenu;
        private System.Windows.Forms.GroupBox grbProfil;
        private System.Windows.Forms.Button cmdQuitter;
        private System.Windows.Forms.Button cmdDiscussions;
        private System.Windows.Forms.Button cmdDeconnexion;
        private System.Windows.Forms.Button cmdArchives;
        private System.Windows.Forms.Button cmdProfil;
        private System.Windows.Forms.Button cmdContacts;
        private System.Windows.Forms.GroupBox grbPhoto;
        private System.Windows.Forms.PictureBox ptbPhoto;
        private System.Windows.Forms.GroupBox grbInformations;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Button cmdValider;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button cmdPhoto;
    }
}
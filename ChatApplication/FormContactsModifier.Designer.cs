namespace ChatApplication
{
    partial class FrmContactsModifier
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
            this.grbInformations = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.grbAnnotation = new System.Windows.Forms.GroupBox();
            this.cmdValider = new System.Windows.Forms.Button();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.txtAnnotation = new System.Windows.Forms.TextBox();
            this.lblRemarque2 = new System.Windows.Forms.Label();
            this.lblRemarque = new System.Windows.Forms.Label();
            this.grbMenu.SuspendLayout();
            this.grbInformations.SuspendLayout();
            this.grbAnnotation.SuspendLayout();
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
            this.grbMenu.TabIndex = 7;
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
            // grbInformations
            // 
            this.grbInformations.Controls.Add(this.txtDescription);
            this.grbInformations.Controls.Add(this.lblDescription);
            this.grbInformations.Controls.Add(this.txtPseudo);
            this.grbInformations.Controls.Add(this.txtPrenom);
            this.grbInformations.Controls.Add(this.txtNom);
            this.grbInformations.Controls.Add(this.lblNom);
            this.grbInformations.Controls.Add(this.lblPrenom);
            this.grbInformations.Controls.Add(this.lblPseudo);
            this.grbInformations.Location = new System.Drawing.Point(130, 13);
            this.grbInformations.Name = "grbInformations";
            this.grbInformations.Size = new System.Drawing.Size(604, 265);
            this.grbInformations.TabIndex = 8;
            this.grbInformations.TabStop = false;
            this.grbInformations.Text = "Informations";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 126);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(174, 106);
            this.txtDescription.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 129);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Description :";
            // 
            // txtPseudo
            // 
            this.txtPseudo.Enabled = false;
            this.txtPseudo.Location = new System.Drawing.Point(400, 37);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(100, 20);
            this.txtPseudo.TabIndex = 17;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(106, 65);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 20);
            this.txtPrenom.TabIndex = 16;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(106, 35);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 15;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 35);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 12;
            this.lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(12, 68);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(49, 13);
            this.lblPrenom.TabIndex = 13;
            this.lblPrenom.Text = "Prénom :";
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(306, 37);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(74, 13);
            this.lblPseudo.TabIndex = 14;
            this.lblPseudo.Text = "Pseudonyme :";
            // 
            // grbAnnotation
            // 
            this.grbAnnotation.Controls.Add(this.cmdValider);
            this.grbAnnotation.Controls.Add(this.cmdAnnuler);
            this.grbAnnotation.Controls.Add(this.txtAnnotation);
            this.grbAnnotation.Controls.Add(this.lblRemarque2);
            this.grbAnnotation.Controls.Add(this.lblRemarque);
            this.grbAnnotation.Location = new System.Drawing.Point(130, 285);
            this.grbAnnotation.Name = "grbAnnotation";
            this.grbAnnotation.Size = new System.Drawing.Size(604, 193);
            this.grbAnnotation.TabIndex = 9;
            this.grbAnnotation.TabStop = false;
            this.grbAnnotation.Text = "Annotation";
            // 
            // cmdValider
            // 
            this.cmdValider.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValider.Location = new System.Drawing.Point(507, 156);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(75, 23);
            this.cmdValider.TabIndex = 8;
            this.cmdValider.Text = "Valider";
            this.cmdValider.UseVisualStyleBackColor = true;
            this.cmdValider.Click += new System.EventHandler(this.cmdValider_Click);
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAnnuler.Location = new System.Drawing.Point(425, 157);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 7;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            // 
            // txtAnnotation
            // 
            this.txtAnnotation.Location = new System.Drawing.Point(12, 52);
            this.txtAnnotation.Multiline = true;
            this.txtAnnotation.Name = "txtAnnotation";
            this.txtAnnotation.Size = new System.Drawing.Size(544, 92);
            this.txtAnnotation.TabIndex = 6;
            // 
            // lblRemarque2
            // 
            this.lblRemarque2.AutoSize = true;
            this.lblRemarque2.Location = new System.Drawing.Point(6, 157);
            this.lblRemarque2.Name = "lblRemarque2";
            this.lblRemarque2.Size = new System.Drawing.Size(362, 13);
            this.lblRemarque2.TabIndex = 1;
            this.lblRemarque2.Text = "Les contacts annotés seront marqués d\'un double astérisque sur le côté (**)";
            // 
            // lblRemarque
            // 
            this.lblRemarque.AutoSize = true;
            this.lblRemarque.Location = new System.Drawing.Point(12, 20);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(169, 13);
            this.lblRemarque.TabIndex = 0;
            this.lblRemarque.Text = "Ajouter une note pour ce contact :";
            // 
            // FrmContactsModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 483);
            this.Controls.Add(this.grbAnnotation);
            this.Controls.Add(this.grbInformations);
            this.Controls.Add(this.grbMenu);
            this.Name = "FrmContactsModifier";
            this.Text = "Modifier un contact";
            this.Load += new System.EventHandler(this.FrmContactsModifier_Load);
            this.grbMenu.ResumeLayout(false);
            this.grbInformations.ResumeLayout(false);
            this.grbInformations.PerformLayout();
            this.grbAnnotation.ResumeLayout(false);
            this.grbAnnotation.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbInformations;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox grbAnnotation;
        private System.Windows.Forms.Button cmdValider;
        private System.Windows.Forms.Button cmdAnnuler;
        private System.Windows.Forms.TextBox txtAnnotation;
        private System.Windows.Forms.Label lblRemarque2;
        private System.Windows.Forms.Label lblRemarque;
    }
}
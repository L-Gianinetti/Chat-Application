namespace ChatApplication
{
    partial class FrmDisucssionCreer
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
            this.lblParticipants = new System.Windows.Forms.Label();
            this.lblContacts = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lstParticipants = new System.Windows.Forms.ListBox();
            this.cboContacts = new System.Windows.Forms.ComboBox();
            this.cmdAjouter = new System.Windows.Forms.Button();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.cmdCreer = new System.Windows.Forms.Button();
            this.ckbNom = new System.Windows.Forms.CheckBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.cmdRetirer = new System.Windows.Forms.Button();
            this.cmdVerifier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategorie = new System.Windows.Forms.TextBox();
            this.ckbCategorie = new System.Windows.Forms.CheckBox();
            this.ckbPublique = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Location = new System.Drawing.Point(35, 59);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(140, 13);
            this.lblParticipants.TabIndex = 0;
            this.lblParticipants.Text = "Participants à la discussion :";
            // 
            // lblContacts
            // 
            this.lblContacts.AutoSize = true;
            this.lblContacts.Location = new System.Drawing.Point(35, 180);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(116, 13);
            this.lblContacts.TabIndex = 1;
            this.lblContacts.Text = "Liste de mes contacts :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(38, 265);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(113, 13);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom de la discussion :";
            // 
            // lstParticipants
            // 
            this.lstParticipants.FormattingEnabled = true;
            this.lstParticipants.Location = new System.Drawing.Point(404, 59);
            this.lstParticipants.Name = "lstParticipants";
            this.lstParticipants.Size = new System.Drawing.Size(120, 95);
            this.lstParticipants.TabIndex = 3;
            // 
            // cboContacts
            // 
            this.cboContacts.FormattingEnabled = true;
            this.cboContacts.Location = new System.Drawing.Point(404, 177);
            this.cboContacts.Name = "cboContacts";
            this.cboContacts.Size = new System.Drawing.Size(121, 21);
            this.cboContacts.TabIndex = 4;
            // 
            // cmdAjouter
            // 
            this.cmdAjouter.Location = new System.Drawing.Point(450, 204);
            this.cmdAjouter.Name = "cmdAjouter";
            this.cmdAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouter.TabIndex = 5;
            this.cmdAjouter.Text = "Ajouter";
            this.cmdAjouter.UseVisualStyleBackColor = true;
            this.cmdAjouter.Click += new System.EventHandler(this.cmdAjouter_Click);
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.Location = new System.Drawing.Point(404, 371);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 6;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            // 
            // cmdCreer
            // 
            this.cmdCreer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdCreer.Location = new System.Drawing.Point(518, 371);
            this.cmdCreer.Name = "cmdCreer";
            this.cmdCreer.Size = new System.Drawing.Size(75, 23);
            this.cmdCreer.TabIndex = 7;
            this.cmdCreer.Text = "Créer";
            this.cmdCreer.UseVisualStyleBackColor = true;
            this.cmdCreer.Click += new System.EventHandler(this.cmdCreer_Click);
            // 
            // ckbNom
            // 
            this.ckbNom.AutoSize = true;
            this.ckbNom.Location = new System.Drawing.Point(546, 265);
            this.ckbNom.Name = "ckbNom";
            this.ckbNom.Size = new System.Drawing.Size(78, 17);
            this.ckbNom.TabIndex = 8;
            this.ckbNom.Text = "Nom rentré";
            this.ckbNom.UseVisualStyleBackColor = true;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(404, 262);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 20);
            this.txtNom.TabIndex = 9;
            this.txtNom.TextChanged += new System.EventHandler(this.txtNom_TextChanged);
            // 
            // cmdRetirer
            // 
            this.cmdRetirer.Location = new System.Drawing.Point(559, 59);
            this.cmdRetirer.Name = "cmdRetirer";
            this.cmdRetirer.Size = new System.Drawing.Size(75, 23);
            this.cmdRetirer.TabIndex = 10;
            this.cmdRetirer.Text = "Retirer";
            this.cmdRetirer.UseVisualStyleBackColor = true;
            this.cmdRetirer.Click += new System.EventHandler(this.cmdRetirer_Click);
            // 
            // cmdVerifier
            // 
            this.cmdVerifier.Location = new System.Drawing.Point(278, 371);
            this.cmdVerifier.Name = "cmdVerifier";
            this.cmdVerifier.Size = new System.Drawing.Size(75, 23);
            this.cmdVerifier.TabIndex = 11;
            this.cmdVerifier.Text = "Verifier";
            this.cmdVerifier.UseVisualStyleBackColor = true;
            this.cmdVerifier.Click += new System.EventHandler(this.cmdVerifier_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Categorie de la discussion :";
            // 
            // txtCategorie
            // 
            this.txtCategorie.Location = new System.Drawing.Point(404, 304);
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(100, 20);
            this.txtCategorie.TabIndex = 13;
            this.txtCategorie.Text = "Par defaut";
            this.txtCategorie.TextChanged += new System.EventHandler(this.txtCategorie_TextChanged);
            // 
            // ckbCategorie
            // 
            this.ckbCategorie.AutoSize = true;
            this.ckbCategorie.Enabled = false;
            this.ckbCategorie.Location = new System.Drawing.Point(546, 304);
            this.ckbCategorie.Name = "ckbCategorie";
            this.ckbCategorie.Size = new System.Drawing.Size(107, 17);
            this.ckbCategorie.TabIndex = 14;
            this.ckbCategorie.Text = "Catégorie rentrée";
            this.ckbCategorie.UseVisualStyleBackColor = true;
            // 
            // ckbPublique
            // 
            this.ckbPublique.AutoSize = true;
            this.ckbPublique.Location = new System.Drawing.Point(546, 338);
            this.ckbPublique.Name = "ckbPublique";
            this.ckbPublique.Size = new System.Drawing.Size(121, 17);
            this.ckbPublique.TabIndex = 15;
            this.ckbPublique.Text = "Discussion Publique";
            this.ckbPublique.UseVisualStyleBackColor = true;
            // 
            // FrmDisucssionCreer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 436);
            this.Controls.Add(this.ckbPublique);
            this.Controls.Add(this.ckbCategorie);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdVerifier);
            this.Controls.Add(this.cmdRetirer);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.ckbNom);
            this.Controls.Add(this.cmdCreer);
            this.Controls.Add(this.cmdAnnuler);
            this.Controls.Add(this.cmdAjouter);
            this.Controls.Add(this.cboContacts);
            this.Controls.Add(this.lstParticipants);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblContacts);
            this.Controls.Add(this.lblParticipants);
            this.Name = "FrmDisucssionCreer";
            this.Text = "Créer une discussion";
            this.Load += new System.EventHandler(this.FrmDisucssionCreer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.ListBox lstParticipants;
        private System.Windows.Forms.ComboBox cboContacts;
        private System.Windows.Forms.Button cmdAjouter;
        private System.Windows.Forms.Button cmdAnnuler;
        private System.Windows.Forms.Button cmdCreer;
        private System.Windows.Forms.CheckBox ckbNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Button cmdRetirer;
        private System.Windows.Forms.Button cmdVerifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategorie;
        private System.Windows.Forms.CheckBox ckbCategorie;
        private System.Windows.Forms.CheckBox ckbPublique;
    }
}
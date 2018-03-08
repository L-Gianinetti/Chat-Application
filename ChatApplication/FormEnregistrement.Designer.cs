namespace ChatApplication
{
    partial class frmEnregistrement
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
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.lblMotDePasseConfirme = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.txtMotDePasseConfirme = new System.Windows.Forms.TextBox();
            this.chkIdentifiant = new System.Windows.Forms.CheckBox();
            this.chkMotDePasse = new System.Windows.Forms.CheckBox();
            this.chkMotDePasseConfirme = new System.Windows.Forms.CheckBox();
            this.grbEnregistrement = new System.Windows.Forms.GroupBox();
            this.cmdVerifier = new System.Windows.Forms.Button();
            this.lblRemarqueMDP = new System.Windows.Forms.Label();
            this.lblRemarque = new System.Windows.Forms.Label();
            this.cmdSuivant = new System.Windows.Forms.Button();
            this.grbEnregistrement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Location = new System.Drawing.Point(27, 49);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(59, 13);
            this.lblIdentifiant.TabIndex = 0;
            this.lblIdentifiant.Text = "Identifiant :";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(27, 103);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(77, 13);
            this.lblMotDePasse.TabIndex = 1;
            this.lblMotDePasse.Text = "Mot de passe :";
            // 
            // lblMotDePasseConfirme
            // 
            this.lblMotDePasseConfirme.AutoSize = true;
            this.lblMotDePasseConfirme.Location = new System.Drawing.Point(27, 209);
            this.lblMotDePasseConfirme.Name = "lblMotDePasseConfirme";
            this.lblMotDePasseConfirme.Size = new System.Drawing.Size(152, 13);
            this.lblMotDePasseConfirme.TabIndex = 2;
            this.lblMotDePasseConfirme.Text = "Confirmation du mot de passe :";
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(211, 46);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(100, 20);
            this.txtIdentifiant.TabIndex = 3;
            this.txtIdentifiant.TextChanged += new System.EventHandler(this.txtIdentifiant_TextChanged);
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(211, 100);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtMotDePasse.TabIndex = 4;
            this.txtMotDePasse.TextChanged += new System.EventHandler(this.txtMotDePasse_TextChanged);
            // 
            // txtMotDePasseConfirme
            // 
            this.txtMotDePasseConfirme.Location = new System.Drawing.Point(211, 206);
            this.txtMotDePasseConfirme.Name = "txtMotDePasseConfirme";
            this.txtMotDePasseConfirme.PasswordChar = '*';
            this.txtMotDePasseConfirme.Size = new System.Drawing.Size(100, 20);
            this.txtMotDePasseConfirme.TabIndex = 5;
            this.txtMotDePasseConfirme.TextChanged += new System.EventHandler(this.txtMotDePasseConfirme_TextChanged);
            // 
            // chkIdentifiant
            // 
            this.chkIdentifiant.AutoSize = true;
            this.chkIdentifiant.Enabled = false;
            this.chkIdentifiant.Location = new System.Drawing.Point(371, 48);
            this.chkIdentifiant.Name = "chkIdentifiant";
            this.chkIdentifiant.Size = new System.Drawing.Size(131, 17);
            this.chkIdentifiant.TabIndex = 6;
            this.chkIdentifiant.Text = "Ce login est disponible";
            this.chkIdentifiant.UseVisualStyleBackColor = true;
            // 
            // chkMotDePasse
            // 
            this.chkMotDePasse.AutoSize = true;
            this.chkMotDePasse.Enabled = false;
            this.chkMotDePasse.Location = new System.Drawing.Point(371, 102);
            this.chkMotDePasse.Name = "chkMotDePasse";
            this.chkMotDePasse.Size = new System.Drawing.Size(280, 17);
            this.chkMotDePasse.TabIndex = 7;
            this.chkMotDePasse.Text = "Le mot de passe est conforme aux normes de sécurité";
            this.chkMotDePasse.UseVisualStyleBackColor = true;
            // 
            // chkMotDePasseConfirme
            // 
            this.chkMotDePasseConfirme.AutoSize = true;
            this.chkMotDePasseConfirme.Enabled = false;
            this.chkMotDePasseConfirme.Location = new System.Drawing.Point(371, 208);
            this.chkMotDePasseConfirme.Name = "chkMotDePasseConfirme";
            this.chkMotDePasseConfirme.Size = new System.Drawing.Size(188, 17);
            this.chkMotDePasseConfirme.TabIndex = 8;
            this.chkMotDePasseConfirme.Text = "Les mots de passe sont identiques";
            this.chkMotDePasseConfirme.UseVisualStyleBackColor = true;
            // 
            // grbEnregistrement
            // 
            this.grbEnregistrement.Controls.Add(this.cmdVerifier);
            this.grbEnregistrement.Controls.Add(this.lblRemarqueMDP);
            this.grbEnregistrement.Controls.Add(this.lblRemarque);
            this.grbEnregistrement.Controls.Add(this.cmdSuivant);
            this.grbEnregistrement.Controls.Add(this.lblIdentifiant);
            this.grbEnregistrement.Controls.Add(this.chkIdentifiant);
            this.grbEnregistrement.Controls.Add(this.chkMotDePasse);
            this.grbEnregistrement.Controls.Add(this.chkMotDePasseConfirme);
            this.grbEnregistrement.Controls.Add(this.lblMotDePasse);
            this.grbEnregistrement.Controls.Add(this.lblMotDePasseConfirme);
            this.grbEnregistrement.Controls.Add(this.txtMotDePasseConfirme);
            this.grbEnregistrement.Controls.Add(this.txtIdentifiant);
            this.grbEnregistrement.Controls.Add(this.txtMotDePasse);
            this.grbEnregistrement.Location = new System.Drawing.Point(12, 30);
            this.grbEnregistrement.Name = "grbEnregistrement";
            this.grbEnregistrement.Size = new System.Drawing.Size(760, 317);
            this.grbEnregistrement.TabIndex = 9;
            this.grbEnregistrement.TabStop = false;
            this.grbEnregistrement.Text = "Enregistrement";
            // 
            // cmdVerifier
            // 
            this.cmdVerifier.Location = new System.Drawing.Point(418, 270);
            this.cmdVerifier.Name = "cmdVerifier";
            this.cmdVerifier.Size = new System.Drawing.Size(75, 23);
            this.cmdVerifier.TabIndex = 14;
            this.cmdVerifier.Text = "Vérifier ";
            this.cmdVerifier.UseVisualStyleBackColor = true;
            this.cmdVerifier.Click += new System.EventHandler(this.cmdVerifier_Click);
            // 
            // lblRemarqueMDP
            // 
            this.lblRemarqueMDP.AutoSize = true;
            this.lblRemarqueMDP.Location = new System.Drawing.Point(211, 127);
            this.lblRemarqueMDP.Name = "lblRemarqueMDP";
            this.lblRemarqueMDP.Size = new System.Drawing.Size(0, 13);
            this.lblRemarqueMDP.TabIndex = 13;
            // 
            // lblRemarque
            // 
            this.lblRemarque.AutoSize = true;
            this.lblRemarque.Location = new System.Drawing.Point(211, 73);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(0, 13);
            this.lblRemarque.TabIndex = 10;
            // 
            // cmdSuivant
            // 
            this.cmdSuivant.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSuivant.Location = new System.Drawing.Point(518, 270);
            this.cmdSuivant.Name = "cmdSuivant";
            this.cmdSuivant.Size = new System.Drawing.Size(75, 23);
            this.cmdSuivant.TabIndex = 9;
            this.cmdSuivant.Text = "Suivant";
            this.cmdSuivant.UseVisualStyleBackColor = true;
            this.cmdSuivant.Click += new System.EventHandler(this.cmdSuivant_Click);
            // 
            // frmEnregistrement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 369);
            this.Controls.Add(this.grbEnregistrement);
            this.Name = "frmEnregistrement";
            this.Text = "Enregistrement";
            this.Load += new System.EventHandler(this.frmEnregistrement_Load);
            this.grbEnregistrement.ResumeLayout(false);
            this.grbEnregistrement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.Label lblMotDePasseConfirme;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.TextBox txtMotDePasseConfirme;
        private System.Windows.Forms.CheckBox chkIdentifiant;
        private System.Windows.Forms.CheckBox chkMotDePasse;
        private System.Windows.Forms.CheckBox chkMotDePasseConfirme;
        private System.Windows.Forms.GroupBox grbEnregistrement;
        private System.Windows.Forms.Button cmdSuivant;
        private System.Windows.Forms.Label lblRemarque;
        private System.Windows.Forms.Label lblRemarqueMDP;
        private System.Windows.Forms.Button cmdVerifier;
    }
}
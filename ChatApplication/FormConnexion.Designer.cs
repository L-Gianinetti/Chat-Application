namespace ChatApplication
{
    partial class frmConnexion
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
            this.chkSeSouvenirDeMoi = new System.Windows.Forms.CheckBox();
            this.grbConnexion = new System.Windows.Forms.GroupBox();
            this.cmdConnexion = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.grbEnregistrement = new System.Windows.Forms.GroupBox();
            this.cmdSEnregistrer = new System.Windows.Forms.Button();
            this.grbConnexion.SuspendLayout();
            this.grbEnregistrement.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Location = new System.Drawing.Point(6, 28);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(59, 13);
            this.lblIdentifiant.TabIndex = 0;
            this.lblIdentifiant.Text = "Identifiant :";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(6, 60);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(77, 13);
            this.lblMotDePasse.TabIndex = 1;
            this.lblMotDePasse.Text = "Mot de passe :";
            // 
            // chkSeSouvenirDeMoi
            // 
            this.chkSeSouvenirDeMoi.AutoSize = true;
            this.chkSeSouvenirDeMoi.Location = new System.Drawing.Point(9, 94);
            this.chkSeSouvenirDeMoi.Name = "chkSeSouvenirDeMoi";
            this.chkSeSouvenirDeMoi.Size = new System.Drawing.Size(116, 17);
            this.chkSeSouvenirDeMoi.TabIndex = 2;
            this.chkSeSouvenirDeMoi.Text = "Se souvenir de moi";
            this.chkSeSouvenirDeMoi.UseVisualStyleBackColor = true;
            // 
            // grbConnexion
            // 
            this.grbConnexion.Controls.Add(this.cmdConnexion);
            this.grbConnexion.Controls.Add(this.txtPassword);
            this.grbConnexion.Controls.Add(this.txtIdentifiant);
            this.grbConnexion.Controls.Add(this.lblIdentifiant);
            this.grbConnexion.Controls.Add(this.chkSeSouvenirDeMoi);
            this.grbConnexion.Controls.Add(this.lblMotDePasse);
            this.grbConnexion.Location = new System.Drawing.Point(28, 73);
            this.grbConnexion.Name = "grbConnexion";
            this.grbConnexion.Size = new System.Drawing.Size(325, 129);
            this.grbConnexion.TabIndex = 3;
            this.grbConnexion.TabStop = false;
            this.grbConnexion.Text = "Connexion";
            // 
            // cmdConnexion
            // 
            this.cmdConnexion.Location = new System.Drawing.Point(195, 94);
            this.cmdConnexion.Name = "cmdConnexion";
            this.cmdConnexion.Size = new System.Drawing.Size(100, 23);
            this.cmdConnexion.TabIndex = 5;
            this.cmdConnexion.Text = "Connexion";
            this.cmdConnexion.UseVisualStyleBackColor = true;
            this.cmdConnexion.Click += new System.EventHandler(this.cmdConnexion_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(195, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(195, 28);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(100, 20);
            this.txtIdentifiant.TabIndex = 3;
            // 
            // grbEnregistrement
            // 
            this.grbEnregistrement.Controls.Add(this.cmdSEnregistrer);
            this.grbEnregistrement.Location = new System.Drawing.Point(28, 227);
            this.grbEnregistrement.Name = "grbEnregistrement";
            this.grbEnregistrement.Size = new System.Drawing.Size(325, 56);
            this.grbEnregistrement.TabIndex = 4;
            this.grbEnregistrement.TabStop = false;
            this.grbEnregistrement.Text = "Enregistrement";
            // 
            // cmdSEnregistrer
            // 
            this.cmdSEnregistrer.Location = new System.Drawing.Point(195, 19);
            this.cmdSEnregistrer.Name = "cmdSEnregistrer";
            this.cmdSEnregistrer.Size = new System.Drawing.Size(100, 23);
            this.cmdSEnregistrer.TabIndex = 0;
            this.cmdSEnregistrer.Text = "S\'enregistrer";
            this.cmdSEnregistrer.UseVisualStyleBackColor = true;
            this.cmdSEnregistrer.Click += new System.EventHandler(this.cmdSEnregistrer_Click);
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 322);
            this.Controls.Add(this.grbEnregistrement);
            this.Controls.Add(this.grbConnexion);
            this.Name = "frmConnexion";
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbConnexion.ResumeLayout(false);
            this.grbConnexion.PerformLayout();
            this.grbEnregistrement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.CheckBox chkSeSouvenirDeMoi;
        private System.Windows.Forms.GroupBox grbConnexion;
        private System.Windows.Forms.Button cmdConnexion;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.GroupBox grbEnregistrement;
        private System.Windows.Forms.Button cmdSEnregistrer;
    }
}


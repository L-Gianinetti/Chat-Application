namespace ChatApplication
{
    partial class frmEnregistrement2
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
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmdPhoto = new System.Windows.Forms.Button();
            this.cmdValider = new System.Windows.Forms.Button();
            this.grbPhoto = new System.Windows.Forms.GroupBox();
            this.ptbPhoto = new System.Windows.Forms.PictureBox();
            this.grbInformations = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.grbPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhoto)).BeginInit();
            this.grbInformations.SuspendLayout();
            this.SuspendLayout();
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
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(6, 114);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(74, 13);
            this.lblPseudo.TabIndex = 3;
            this.lblPseudo.Text = "Pseudonyme :";
            this.lblPseudo.Click += new System.EventHandler(this.lblPseudo_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 164);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description :";
            this.lblDescription.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmdPhoto
            // 
            this.cmdPhoto.Location = new System.Drawing.Point(286, 59);
            this.cmdPhoto.Name = "cmdPhoto";
            this.cmdPhoto.Size = new System.Drawing.Size(75, 23);
            this.cmdPhoto.TabIndex = 6;
            this.cmdPhoto.Text = "Parcourir...";
            this.cmdPhoto.UseVisualStyleBackColor = true;
            // 
            // cmdValider
            // 
            this.cmdValider.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValider.Location = new System.Drawing.Point(286, 281);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(100, 23);
            this.cmdValider.TabIndex = 7;
            this.cmdValider.Text = "Valider mon profil";
            this.cmdValider.UseVisualStyleBackColor = true;
            // 
            // grbPhoto
            // 
            this.grbPhoto.Controls.Add(this.ptbPhoto);
            this.grbPhoto.Controls.Add(this.cmdPhoto);
            this.grbPhoto.Location = new System.Drawing.Point(21, 16);
            this.grbPhoto.Name = "grbPhoto";
            this.grbPhoto.Size = new System.Drawing.Size(392, 124);
            this.grbPhoto.TabIndex = 8;
            this.grbPhoto.TabStop = false;
            this.grbPhoto.Text = "Photo de profil";
            // 
            // ptbPhoto
            // 
            this.ptbPhoto.Location = new System.Drawing.Point(9, 19);
            this.ptbPhoto.Name = "ptbPhoto";
            this.ptbPhoto.Size = new System.Drawing.Size(102, 99);
            this.ptbPhoto.TabIndex = 7;
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
            this.grbInformations.Location = new System.Drawing.Point(21, 146);
            this.grbInformations.Name = "grbInformations";
            this.grbInformations.Size = new System.Drawing.Size(392, 318);
            this.grbInformations.TabIndex = 9;
            this.grbInformations.TabStop = false;
            this.grbInformations.Text = "Informations du profil";
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
            // frmEnregistrement2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 503);
            this.Controls.Add(this.grbInformations);
            this.Controls.Add(this.grbPhoto);
            this.Name = "frmEnregistrement2";
            this.Text = "Enregistrement";
            this.grbPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhoto)).EndInit();
            this.grbInformations.ResumeLayout(false);
            this.grbInformations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button cmdPhoto;
        private System.Windows.Forms.Button cmdValider;
        private System.Windows.Forms.GroupBox grbPhoto;
        private System.Windows.Forms.GroupBox grbInformations;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.PictureBox ptbPhoto;
    }
}
namespace ChatApplication
{
    partial class FrmArchives
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
            this.grbArchives = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cmdReimporter = new System.Windows.Forms.Button();
            this.cmdSupprimer = new System.Windows.Forms.Button();
            this.grbMenu.SuspendLayout();
            this.grbArchives.SuspendLayout();
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
            // grbArchives
            // 
            this.grbArchives.Controls.Add(this.cmdSupprimer);
            this.grbArchives.Controls.Add(this.cmdReimporter);
            this.grbArchives.Controls.Add(this.listBox1);
            this.grbArchives.Location = new System.Drawing.Point(129, 12);
            this.grbArchives.Name = "grbArchives";
            this.grbArchives.Size = new System.Drawing.Size(476, 473);
            this.grbArchives.TabIndex = 3;
            this.grbArchives.TabStop = false;
            this.grbArchives.Text = "Archives";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(386, 433);
            this.listBox1.TabIndex = 0;
            // 
            // cmdReimporter
            // 
            this.cmdReimporter.Location = new System.Drawing.Point(395, 36);
            this.cmdReimporter.Name = "cmdReimporter";
            this.cmdReimporter.Size = new System.Drawing.Size(75, 23);
            this.cmdReimporter.TabIndex = 1;
            this.cmdReimporter.Text = "Réimporter";
            this.cmdReimporter.UseVisualStyleBackColor = true;
            // 
            // cmdSupprimer
            // 
            this.cmdSupprimer.Location = new System.Drawing.Point(395, 76);
            this.cmdSupprimer.Name = "cmdSupprimer";
            this.cmdSupprimer.Size = new System.Drawing.Size(75, 23);
            this.cmdSupprimer.TabIndex = 2;
            this.cmdSupprimer.Text = "Supprimer";
            this.cmdSupprimer.UseVisualStyleBackColor = true;
            // 
            // FrmArchives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 497);
            this.Controls.Add(this.grbArchives);
            this.Controls.Add(this.grbMenu);
            this.Name = "FrmArchives";
            this.Text = "Archives";
            this.grbMenu.ResumeLayout(false);
            this.grbArchives.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grbArchives;
        private System.Windows.Forms.Button cmdSupprimer;
        private System.Windows.Forms.Button cmdReimporter;
        private System.Windows.Forms.ListBox listBox1;
    }
}
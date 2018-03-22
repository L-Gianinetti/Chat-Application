namespace ChatApplication
{
    partial class FrmDiscussionAjouter
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
            this.cmdAjouter = new System.Windows.Forms.Button();
            this.cboContacts = new System.Windows.Forms.ComboBox();
            this.lstParticipants = new System.Windows.Forms.ListBox();
            this.lblContacts = new System.Windows.Forms.Label();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.cmdValider = new System.Windows.Forms.Button();
            this.cmdRetirer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdAjouter
            // 
            this.cmdAjouter.Location = new System.Drawing.Point(223, 195);
            this.cmdAjouter.Name = "cmdAjouter";
            this.cmdAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouter.TabIndex = 10;
            this.cmdAjouter.Text = "Ajouter";
            this.cmdAjouter.UseVisualStyleBackColor = true;
            this.cmdAjouter.Click += new System.EventHandler(this.cmdAjouter_Click);
            // 
            // cboContacts
            // 
            this.cboContacts.FormattingEnabled = true;
            this.cboContacts.Location = new System.Drawing.Point(223, 168);
            this.cboContacts.Name = "cboContacts";
            this.cboContacts.Size = new System.Drawing.Size(121, 21);
            this.cboContacts.TabIndex = 9;
            // 
            // lstParticipants
            // 
            this.lstParticipants.FormattingEnabled = true;
            this.lstParticipants.Location = new System.Drawing.Point(223, 47);
            this.lstParticipants.Name = "lstParticipants";
            this.lstParticipants.Size = new System.Drawing.Size(120, 95);
            this.lstParticipants.TabIndex = 8;
            // 
            // lblContacts
            // 
            this.lblContacts.AutoSize = true;
            this.lblContacts.Location = new System.Drawing.Point(12, 171);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(116, 13);
            this.lblContacts.TabIndex = 7;
            this.lblContacts.Text = "Liste de mes contacts :";
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Location = new System.Drawing.Point(12, 47);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(140, 13);
            this.lblParticipants.TabIndex = 6;
            this.lblParticipants.Text = "Participants à la discussion :";
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.Location = new System.Drawing.Point(347, 280);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 11;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            this.cmdAnnuler.Click += new System.EventHandler(this.cmdAnnuler_Click);
            // 
            // cmdValider
            // 
            this.cmdValider.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdValider.Location = new System.Drawing.Point(428, 280);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(75, 23);
            this.cmdValider.TabIndex = 12;
            this.cmdValider.Text = "Valider";
            this.cmdValider.UseVisualStyleBackColor = true;
            this.cmdValider.Click += new System.EventHandler(this.cmdValider_Click);
            // 
            // cmdRetirer
            // 
            this.cmdRetirer.Location = new System.Drawing.Point(366, 42);
            this.cmdRetirer.Name = "cmdRetirer";
            this.cmdRetirer.Size = new System.Drawing.Size(75, 23);
            this.cmdRetirer.TabIndex = 13;
            this.cmdRetirer.Text = "Retirer";
            this.cmdRetirer.UseVisualStyleBackColor = true;
            this.cmdRetirer.Click += new System.EventHandler(this.cmdRetirer_Click);
            // 
            // FrmDiscussionAjouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 328);
            this.Controls.Add(this.cmdRetirer);
            this.Controls.Add(this.cmdValider);
            this.Controls.Add(this.cmdAnnuler);
            this.Controls.Add(this.cmdAjouter);
            this.Controls.Add(this.cboContacts);
            this.Controls.Add(this.lstParticipants);
            this.Controls.Add(this.lblContacts);
            this.Controls.Add(this.lblParticipants);
            this.Name = "FrmDiscussionAjouter";
            this.Text = "Ajouter des contacts à la discussion";
            this.Load += new System.EventHandler(this.FrmDiscussionAjouter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAjouter;
        private System.Windows.Forms.ComboBox cboContacts;
        private System.Windows.Forms.ListBox lstParticipants;
        private System.Windows.Forms.Label lblContacts;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.Button cmdAnnuler;
        private System.Windows.Forms.Button cmdValider;
        private System.Windows.Forms.Button cmdRetirer;
    }
}
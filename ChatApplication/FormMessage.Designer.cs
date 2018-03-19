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
            this.grbActions = new System.Windows.Forms.GroupBox();
            this.cmdASupprimer = new System.Windows.Forms.Button();
            this.cmdAAjouter = new System.Windows.Forms.Button();
            this.cmdARetour = new System.Windows.Forms.Button();
            this.grbParticipants = new System.Windows.Forms.GroupBox();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.grbMessages = new System.Windows.Forms.GroupBox();
            this.txtMessageAffichage = new System.Windows.Forms.TextBox();
            this.cmdVocal = new System.Windows.Forms.Button();
            this.cmdImage = new System.Windows.Forms.Button();
            this.cmdSmiley = new System.Windows.Forms.Button();
            this.cmdEnvoyer = new System.Windows.Forms.Button();
            this.txtMessageEnvoi = new System.Windows.Forms.TextBox();
            this.grbActions.SuspendLayout();
            this.grbParticipants.SuspendLayout();
            this.grbMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbActions
            // 
            this.grbActions.Controls.Add(this.cmdASupprimer);
            this.grbActions.Controls.Add(this.cmdAAjouter);
            this.grbActions.Controls.Add(this.cmdARetour);
            this.grbActions.Location = new System.Drawing.Point(12, 12);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(617, 59);
            this.grbActions.TabIndex = 4;
            this.grbActions.TabStop = false;
            this.grbActions.Text = "Actions";
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
            // cmdAAjouter
            // 
            this.cmdAAjouter.Location = new System.Drawing.Point(195, 20);
            this.cmdAAjouter.Name = "cmdAAjouter";
            this.cmdAAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAAjouter.TabIndex = 1;
            this.cmdAAjouter.Text = "Ajouter";
            this.cmdAAjouter.UseVisualStyleBackColor = true;
            // 
            // cmdARetour
            // 
            this.cmdARetour.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdARetour.Location = new System.Drawing.Point(44, 20);
            this.cmdARetour.Name = "cmdARetour";
            this.cmdARetour.Size = new System.Drawing.Size(75, 23);
            this.cmdARetour.TabIndex = 0;
            this.cmdARetour.Text = "Retour";
            this.cmdARetour.UseVisualStyleBackColor = true;
            // 
            // grbParticipants
            // 
            this.grbParticipants.Controls.Add(this.lblParticipants);
            this.grbParticipants.Location = new System.Drawing.Point(12, 78);
            this.grbParticipants.Name = "grbParticipants";
            this.grbParticipants.Size = new System.Drawing.Size(617, 46);
            this.grbParticipants.TabIndex = 5;
            this.grbParticipants.TabStop = false;
            this.grbParticipants.Text = "Participants";
            this.grbParticipants.Enter += new System.EventHandler(this.grbParticipants_Enter);
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
            // grbMessages
            // 
            this.grbMessages.Controls.Add(this.txtMessageAffichage);
            this.grbMessages.Controls.Add(this.cmdVocal);
            this.grbMessages.Controls.Add(this.cmdImage);
            this.grbMessages.Controls.Add(this.cmdSmiley);
            this.grbMessages.Controls.Add(this.cmdEnvoyer);
            this.grbMessages.Controls.Add(this.txtMessageEnvoi);
            this.grbMessages.Location = new System.Drawing.Point(12, 130);
            this.grbMessages.Name = "grbMessages";
            this.grbMessages.Size = new System.Drawing.Size(617, 356);
            this.grbMessages.TabIndex = 5;
            this.grbMessages.TabStop = false;
            this.grbMessages.Text = "Messages";
            // 
            // txtMessageAffichage
            // 
            this.txtMessageAffichage.Location = new System.Drawing.Point(7, 20);
            this.txtMessageAffichage.Multiline = true;
            this.txtMessageAffichage.Name = "txtMessageAffichage";
            this.txtMessageAffichage.Size = new System.Drawing.Size(604, 274);
            this.txtMessageAffichage.TabIndex = 5;
            this.txtMessageAffichage.TextChanged += new System.EventHandler(this.txtMessageAffichage_TextChanged);
            // 
            // cmdVocal
            // 
            this.cmdVocal.Location = new System.Drawing.Point(470, 300);
            this.cmdVocal.Name = "cmdVocal";
            this.cmdVocal.Size = new System.Drawing.Size(141, 23);
            this.cmdVocal.TabIndex = 4;
            this.cmdVocal.Text = "Enregistrement vocal...";
            this.cmdVocal.UseVisualStyleBackColor = true;
            // 
            // cmdImage
            // 
            this.cmdImage.Location = new System.Drawing.Point(389, 300);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(75, 23);
            this.cmdImage.TabIndex = 3;
            this.cmdImage.Text = "Image...";
            this.cmdImage.UseVisualStyleBackColor = true;
            // 
            // cmdSmiley
            // 
            this.cmdSmiley.Location = new System.Drawing.Point(389, 325);
            this.cmdSmiley.Name = "cmdSmiley";
            this.cmdSmiley.Size = new System.Drawing.Size(75, 23);
            this.cmdSmiley.TabIndex = 2;
            this.cmdSmiley.Text = "Smiley...";
            this.cmdSmiley.UseVisualStyleBackColor = true;
            // 
            // cmdEnvoyer
            // 
            this.cmdEnvoyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnvoyer.Location = new System.Drawing.Point(470, 325);
            this.cmdEnvoyer.Name = "cmdEnvoyer";
            this.cmdEnvoyer.Size = new System.Drawing.Size(141, 23);
            this.cmdEnvoyer.TabIndex = 1;
            this.cmdEnvoyer.Text = "Envoyer";
            this.cmdEnvoyer.UseVisualStyleBackColor = true;
            this.cmdEnvoyer.Click += new System.EventHandler(this.cmdEnvoyer_Click);
            // 
            // txtMessageEnvoi
            // 
            this.txtMessageEnvoi.Location = new System.Drawing.Point(6, 302);
            this.txtMessageEnvoi.Multiline = true;
            this.txtMessageEnvoi.Name = "txtMessageEnvoi";
            this.txtMessageEnvoi.Size = new System.Drawing.Size(364, 46);
            this.txtMessageEnvoi.TabIndex = 0;
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 526);
            this.Controls.Add(this.grbParticipants);
            this.Controls.Add(this.grbMessages);
            this.Controls.Add(this.grbActions);
            this.Name = "FrmMessage";
            this.Text = "Message";
            this.Load += new System.EventHandler(this.FrmMessage_Load);
            this.grbActions.ResumeLayout(false);
            this.grbParticipants.ResumeLayout(false);
            this.grbParticipants.PerformLayout();
            this.grbMessages.ResumeLayout(false);
            this.grbMessages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TextBox txtMessageEnvoi;
        private System.Windows.Forms.TextBox txtMessageAffichage;
    }
}
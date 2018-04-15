namespace ChatApplication
{
    partial class FrmDiscussionRecherche
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
            this.lblRemarque = new System.Windows.Forms.Label();
            this.lblRechercher = new System.Windows.Forms.Label();
            this.lblResultats = new System.Windows.Forms.Label();
            this.lblProposee = new System.Windows.Forms.Label();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.cmdRechercher = new System.Windows.Forms.Button();
            this.txtRechercher = new System.Windows.Forms.TextBox();
            this.lstResultats = new System.Windows.Forms.ListBox();
            this.lstProposee = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblRemarque
            // 
            this.lblRemarque.AutoSize = true;
            this.lblRemarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarque.Location = new System.Drawing.Point(12, 9);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(395, 13);
            this.lblRemarque.TabIndex = 0;
            this.lblRemarque.Text = "Veuillez taper le nom de la discussion que vous souhaitez rejoindre :";
            // 
            // lblRechercher
            // 
            this.lblRechercher.AutoSize = true;
            this.lblRechercher.Location = new System.Drawing.Point(21, 51);
            this.lblRechercher.Name = "lblRechercher";
            this.lblRechercher.Size = new System.Drawing.Size(69, 13);
            this.lblRechercher.TabIndex = 1;
            this.lblRechercher.Text = "Rechercher :";
            // 
            // lblResultats
            // 
            this.lblResultats.AutoSize = true;
            this.lblResultats.Location = new System.Drawing.Point(21, 137);
            this.lblResultats.Name = "lblResultats";
            this.lblResultats.Size = new System.Drawing.Size(57, 13);
            this.lblResultats.TabIndex = 2;
            this.lblResultats.Text = "Résultats :";
            // 
            // lblProposee
            // 
            this.lblProposee.AutoSize = true;
            this.lblProposee.Location = new System.Drawing.Point(307, 137);
            this.lblProposee.Name = "lblProposee";
            this.lblProposee.Size = new System.Drawing.Size(82, 13);
            this.lblProposee.TabIndex = 3;
            this.lblProposee.Text = "Liste proposée :";
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAnnuler.Location = new System.Drawing.Point(332, 364);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 4;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            this.cmdAnnuler.Click += new System.EventHandler(this.cmdAnnuler_Click);
            // 
            // cmdRechercher
            // 
            this.cmdRechercher.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdRechercher.Location = new System.Drawing.Point(455, 364);
            this.cmdRechercher.Name = "cmdRechercher";
            this.cmdRechercher.Size = new System.Drawing.Size(75, 23);
            this.cmdRechercher.TabIndex = 5;
            this.cmdRechercher.Text = "Rechercher";
            this.cmdRechercher.UseVisualStyleBackColor = true;
            this.cmdRechercher.Click += new System.EventHandler(this.cmdRechercher_Click);
            // 
            // txtRechercher
            // 
            this.txtRechercher.Location = new System.Drawing.Point(166, 51);
            this.txtRechercher.Name = "txtRechercher";
            this.txtRechercher.Size = new System.Drawing.Size(100, 20);
            this.txtRechercher.TabIndex = 6;
            this.txtRechercher.TextChanged += new System.EventHandler(this.txtRechercher_TextChanged);
            // 
            // lstResultats
            // 
            this.lstResultats.FormattingEnabled = true;
            this.lstResultats.Location = new System.Drawing.Point(119, 137);
            this.lstResultats.Name = "lstResultats";
            this.lstResultats.Size = new System.Drawing.Size(120, 95);
            this.lstResultats.TabIndex = 7;
            this.lstResultats.SelectedIndexChanged += new System.EventHandler(this.lstResultats_SelectedIndexChanged);
            // 
            // lstProposee
            // 
            this.lstProposee.FormattingEnabled = true;
            this.lstProposee.Location = new System.Drawing.Point(455, 137);
            this.lstProposee.Name = "lstProposee";
            this.lstProposee.Size = new System.Drawing.Size(120, 95);
            this.lstProposee.TabIndex = 8;
            this.lstProposee.SelectedIndexChanged += new System.EventHandler(this.lstProposee_SelectedIndexChanged);
            // 
            // FrmDiscussionRecherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 434);
            this.Controls.Add(this.lstProposee);
            this.Controls.Add(this.lstResultats);
            this.Controls.Add(this.txtRechercher);
            this.Controls.Add(this.cmdRechercher);
            this.Controls.Add(this.cmdAnnuler);
            this.Controls.Add(this.lblProposee);
            this.Controls.Add(this.lblResultats);
            this.Controls.Add(this.lblRechercher);
            this.Controls.Add(this.lblRemarque);
            this.Name = "FrmDiscussionRecherche";
            this.Text = "Recherche d\'un sujet de discussion";
            this.Load += new System.EventHandler(this.FrmDiscussionRecherche_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemarque;
        private System.Windows.Forms.Label lblRechercher;
        private System.Windows.Forms.Label lblResultats;
        private System.Windows.Forms.Label lblProposee;
        private System.Windows.Forms.Button cmdAnnuler;
        private System.Windows.Forms.Button cmdRechercher;
        private System.Windows.Forms.TextBox txtRechercher;
        private System.Windows.Forms.ListBox lstResultats;
        private System.Windows.Forms.ListBox lstProposee;
    }
}
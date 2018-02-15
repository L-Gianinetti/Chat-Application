namespace ChatApplication
{
    partial class FrmContactsAjouter
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
            this.lblPseudo = new System.Windows.Forms.Label();
            this.txtPseudo = new System.Windows.Forms.TextBox();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.cmdAjouter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRemarque
            // 
            this.lblRemarque.AutoSize = true;
            this.lblRemarque.Location = new System.Drawing.Point(12, 24);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(301, 13);
            this.lblRemarque.TabIndex = 0;
            this.lblRemarque.Text = "Veuillez rentrer le pseudo du contact que vous voulez ajouter :";
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Location = new System.Drawing.Point(15, 99);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(74, 13);
            this.lblPseudo.TabIndex = 1;
            this.lblPseudo.Text = "Pseudonyme :";
            // 
            // txtPseudo
            // 
            this.txtPseudo.Location = new System.Drawing.Point(177, 99);
            this.txtPseudo.Name = "txtPseudo";
            this.txtPseudo.Size = new System.Drawing.Size(100, 20);
            this.txtPseudo.TabIndex = 2;
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.Location = new System.Drawing.Point(12, 264);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 3;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            // 
            // cmdAjouter
            // 
            this.cmdAjouter.Location = new System.Drawing.Point(223, 264);
            this.cmdAjouter.Name = "cmdAjouter";
            this.cmdAjouter.Size = new System.Drawing.Size(75, 23);
            this.cmdAjouter.TabIndex = 4;
            this.cmdAjouter.Text = "Ajouter";
            this.cmdAjouter.UseVisualStyleBackColor = true;
            // 
            // FrmContactsAjouter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 299);
            this.Controls.Add(this.cmdAjouter);
            this.Controls.Add(this.cmdAnnuler);
            this.Controls.Add(this.txtPseudo);
            this.Controls.Add(this.lblPseudo);
            this.Controls.Add(this.lblRemarque);
            this.Name = "FrmContactsAjouter";
            this.Text = "Ajouter un contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRemarque;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.TextBox txtPseudo;
        private System.Windows.Forms.Button cmdAnnuler;
        private System.Windows.Forms.Button cmdAjouter;
    }
}
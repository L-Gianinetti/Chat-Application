namespace ChatApplication
{
    partial class FrmRechercheDiscussionCategorie
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
            this.lstDiscussions = new System.Windows.Forms.ListBox();
            this.lblDiscussionsCorrespondantes = new System.Windows.Forms.Label();
            this.cmdRejoindre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDiscussions
            // 
            this.lstDiscussions.FormattingEnabled = true;
            this.lstDiscussions.Location = new System.Drawing.Point(76, 83);
            this.lstDiscussions.Name = "lstDiscussions";
            this.lstDiscussions.Size = new System.Drawing.Size(120, 95);
            this.lstDiscussions.TabIndex = 0;
            // 
            // lblDiscussionsCorrespondantes
            // 
            this.lblDiscussionsCorrespondantes.AutoSize = true;
            this.lblDiscussionsCorrespondantes.Location = new System.Drawing.Point(23, 41);
            this.lblDiscussionsCorrespondantes.Name = "lblDiscussionsCorrespondantes";
            this.lblDiscussionsCorrespondantes.Size = new System.Drawing.Size(151, 13);
            this.lblDiscussionsCorrespondantes.TabIndex = 1;
            this.lblDiscussionsCorrespondantes.Text = "Discussions correspondantes :";
            // 
            // cmdRejoindre
            // 
            this.cmdRejoindre.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdRejoindre.Location = new System.Drawing.Point(187, 222);
            this.cmdRejoindre.Name = "cmdRejoindre";
            this.cmdRejoindre.Size = new System.Drawing.Size(75, 23);
            this.cmdRejoindre.TabIndex = 2;
            this.cmdRejoindre.Text = "Rejoindre";
            this.cmdRejoindre.UseVisualStyleBackColor = true;
            this.cmdRejoindre.Click += new System.EventHandler(this.cmdRejoindre_Click);
            // 
            // FrmRechercheDiscussionCategorie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 276);
            this.Controls.Add(this.cmdRejoindre);
            this.Controls.Add(this.lblDiscussionsCorrespondantes);
            this.Controls.Add(this.lstDiscussions);
            this.Name = "FrmRechercheDiscussionCategorie";
            this.Text = "FormRechercheDiscussionCategorie";
            this.Load += new System.EventHandler(this.FrmRechercheDiscussionCategorie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDiscussions;
        private System.Windows.Forms.Label lblDiscussionsCorrespondantes;
        private System.Windows.Forms.Button cmdRejoindre;
    }
}
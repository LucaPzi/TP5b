namespace CombatServeurSocketElfe
{
    partial class frmServeurSocketElfe
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.btnAttente = new System.Windows.Forms.Button();
            this.lblSortElfe = new System.Windows.Forms.Label();
            this.lblArmeNain = new System.Windows.Forms.Label();
            this.lblForceElfe = new System.Windows.Forms.Label();
            this.lblForceNain = new System.Windows.Forms.Label();
            this.lblVieElfe = new System.Windows.Forms.Label();
            this.lblVieNain = new System.Windows.Forms.Label();
            this.picElfe = new System.Windows.Forms.PictureBox();
            this.picNain = new System.Windows.Forms.PictureBox();
            this.lstReception = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picElfe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(281, 286);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 28);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(281, 250);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(136, 28);
            this.btnFermer.TabIndex = 20;
            this.btnFermer.Text = "FERMER";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // btnAttente
            // 
            this.btnAttente.Location = new System.Drawing.Point(280, 27);
            this.btnAttente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAttente.Name = "btnAttente";
            this.btnAttente.Size = new System.Drawing.Size(136, 28);
            this.btnAttente.TabIndex = 19;
            this.btnAttente.Text = "Attente d\'un client";
            this.btnAttente.UseVisualStyleBackColor = true;
            this.btnAttente.Click += new System.EventHandler(this.btnAttente_Click);
            // 
            // lblSortElfe
            // 
            this.lblSortElfe.AccessibleDescription = "";
            this.lblSortElfe.AutoSize = true;
            this.lblSortElfe.Location = new System.Drawing.Point(444, 292);
            this.lblSortElfe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSortElfe.Name = "lblSortElfe";
            this.lblSortElfe.Size = new System.Drawing.Size(42, 17);
            this.lblSortElfe.TabIndex = 18;
            this.lblSortElfe.Text = "Sort: ";
            // 
            // lblArmeNain
            // 
            this.lblArmeNain.AutoSize = true;
            this.lblArmeNain.Location = new System.Drawing.Point(47, 294);
            this.lblArmeNain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArmeNain.Name = "lblArmeNain";
            this.lblArmeNain.Size = new System.Drawing.Size(49, 17);
            this.lblArmeNain.TabIndex = 17;
            this.lblArmeNain.Text = "Arme: ";
            // 
            // lblForceElfe
            // 
            this.lblForceElfe.AutoSize = true;
            this.lblForceElfe.Location = new System.Drawing.Point(444, 265);
            this.lblForceElfe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForceElfe.Name = "lblForceElfe";
            this.lblForceElfe.Size = new System.Drawing.Size(52, 17);
            this.lblForceElfe.TabIndex = 16;
            this.lblForceElfe.Text = "Force: ";
            // 
            // lblForceNain
            // 
            this.lblForceNain.AutoSize = true;
            this.lblForceNain.Location = new System.Drawing.Point(47, 267);
            this.lblForceNain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForceNain.Name = "lblForceNain";
            this.lblForceNain.Size = new System.Drawing.Size(48, 17);
            this.lblForceNain.TabIndex = 15;
            this.lblForceNain.Text = "Force:";
            // 
            // lblVieElfe
            // 
            this.lblVieElfe.AutoSize = true;
            this.lblVieElfe.Location = new System.Drawing.Point(444, 238);
            this.lblVieElfe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVieElfe.Name = "lblVieElfe";
            this.lblVieElfe.Size = new System.Drawing.Size(36, 17);
            this.lblVieElfe.TabIndex = 14;
            this.lblVieElfe.Text = "Vie: ";
            // 
            // lblVieNain
            // 
            this.lblVieNain.AutoSize = true;
            this.lblVieNain.Location = new System.Drawing.Point(47, 240);
            this.lblVieNain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVieNain.Name = "lblVieNain";
            this.lblVieNain.Size = new System.Drawing.Size(36, 17);
            this.lblVieNain.TabIndex = 13;
            this.lblVieNain.Text = "Vie: ";
            // 
            // picElfe
            // 
            this.picElfe.Location = new System.Drawing.Point(425, 27);
            this.picElfe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picElfe.Name = "picElfe";
            this.picElfe.Size = new System.Drawing.Size(240, 197);
            this.picElfe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picElfe.TabIndex = 12;
            this.picElfe.TabStop = false;
            // 
            // picNain
            // 
            this.picNain.Location = new System.Drawing.Point(32, 27);
            this.picNain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picNain.Name = "picNain";
            this.picNain.Size = new System.Drawing.Size(240, 197);
            this.picNain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNain.TabIndex = 11;
            this.picNain.TabStop = false;
            // 
            // lstReception
            // 
            this.lstReception.FormattingEnabled = true;
            this.lstReception.ItemHeight = 16;
            this.lstReception.Location = new System.Drawing.Point(705, 27);
            this.lstReception.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstReception.Name = "lstReception";
            this.lstReception.Size = new System.Drawing.Size(309, 292);
            this.lstReception.TabIndex = 22;
            // 
            // frmServeurSocketElfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 357);
            this.Controls.Add(this.lstReception);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnAttente);
            this.Controls.Add(this.lblSortElfe);
            this.Controls.Add(this.lblArmeNain);
            this.Controls.Add(this.lblForceElfe);
            this.Controls.Add(this.lblForceNain);
            this.Controls.Add(this.lblVieElfe);
            this.Controls.Add(this.lblVieNain);
            this.Controls.Add(this.picElfe);
            this.Controls.Add(this.picNain);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmServeurSocketElfe";
            this.Text = "SERVEUR socket ELFE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServeurSocketElfe_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picElfe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Button btnAttente;
        private System.Windows.Forms.Label lblSortElfe;
        private System.Windows.Forms.Label lblArmeNain;
        private System.Windows.Forms.Label lblForceElfe;
        private System.Windows.Forms.Label lblForceNain;
        private System.Windows.Forms.Label lblVieElfe;
        private System.Windows.Forms.Label lblVieNain;
        private System.Windows.Forms.PictureBox picElfe;
        private System.Windows.Forms.PictureBox picNain;
        private System.Windows.Forms.ListBox lstReception;
    }
}


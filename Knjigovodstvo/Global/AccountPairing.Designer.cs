
namespace Knjigovodstvo.Global
{
    partial class AccountPairing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxUpariKonto = new System.Windows.Forms.GroupBox();
            this.buttonKontniPlan = new System.Windows.Forms.Button();
            this.buttonPartneri = new System.Windows.Forms.Button();
            this.groupBoxUpariKonto.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUpariKonto
            // 
            this.groupBoxUpariKonto.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxUpariKonto.Controls.Add(this.buttonKontniPlan);
            this.groupBoxUpariKonto.Controls.Add(this.buttonPartneri);
            this.groupBoxUpariKonto.Location = new System.Drawing.Point(9, 5);
            this.groupBoxUpariKonto.Name = "groupBoxUpariKonto";
            this.groupBoxUpariKonto.Size = new System.Drawing.Size(188, 66);
            this.groupBoxUpariKonto.TabIndex = 14;
            this.groupBoxUpariKonto.TabStop = false;
            this.groupBoxUpariKonto.Text = "Upari konto";
            // 
            // buttonKontniPlan
            // 
            this.buttonKontniPlan.Location = new System.Drawing.Point(6, 26);
            this.buttonKontniPlan.Name = "buttonKontniPlan";
            this.buttonKontniPlan.Size = new System.Drawing.Size(85, 23);
            this.buttonKontniPlan.TabIndex = 13;
            this.buttonKontniPlan.Text = "Kontni plan";
            this.buttonKontniPlan.UseVisualStyleBackColor = true;
            this.buttonKontniPlan.Click += new System.EventHandler(this.ButtonKontniPlan_Click);
            // 
            // buttonPartneri
            // 
            this.buttonPartneri.Location = new System.Drawing.Point(97, 26);
            this.buttonPartneri.Name = "buttonPartneri";
            this.buttonPartneri.Size = new System.Drawing.Size(85, 23);
            this.buttonPartneri.TabIndex = 12;
            this.buttonPartneri.Text = "Partneri";
            this.buttonPartneri.UseVisualStyleBackColor = true;
            this.buttonPartneri.Click += new System.EventHandler(this.ButtonPartneri_Click);
            // 
            // AccountPairing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxUpariKonto);
            this.Name = "AccountPairing";
            this.Size = new System.Drawing.Size(206, 82);
            this.groupBoxUpariKonto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUpariKonto;
        private System.Windows.Forms.Button buttonKontniPlan;
        private System.Windows.Forms.Button buttonPartneri;
    }
}

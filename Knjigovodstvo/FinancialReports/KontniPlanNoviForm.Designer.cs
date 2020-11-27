
namespace Knjigovodstvo.FinancialReports
{
    partial class KontniPlanNoviForm
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
            this.labelKonto = new System.Windows.Forms.Label();
            this.labelOpis = new System.Windows.Forms.Label();
            this.textBoxKonto = new System.Windows.Forms.TextBox();
            this.textBoxOpis = new System.Windows.Forms.TextBox();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelKonto
            // 
            this.labelKonto.AutoSize = true;
            this.labelKonto.Location = new System.Drawing.Point(12, 24);
            this.labelKonto.Name = "labelKonto";
            this.labelKonto.Size = new System.Drawing.Size(39, 15);
            this.labelKonto.TabIndex = 0;
            this.labelKonto.Text = "Konto";
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(12, 55);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(31, 15);
            this.labelOpis.TabIndex = 1;
            this.labelOpis.Text = "Opis";
            // 
            // textBoxKonto
            // 
            this.textBoxKonto.Location = new System.Drawing.Point(57, 21);
            this.textBoxKonto.Name = "textBoxKonto";
            this.textBoxKonto.PlaceholderText = "Unesite broj konta (max 8 brojeva)";
            this.textBoxKonto.Size = new System.Drawing.Size(205, 23);
            this.textBoxKonto.TabIndex = 2;
            // 
            // textBoxOpis
            // 
            this.textBoxOpis.Location = new System.Drawing.Point(57, 52);
            this.textBoxOpis.Name = "textBoxOpis";
            this.textBoxOpis.PlaceholderText = "Kratki opis konta (min 5 znakova)";
            this.textBoxOpis.Size = new System.Drawing.Size(466, 23);
            this.textBoxOpis.TabIndex = 3;
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(12, 106);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 4;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // KontniPlanNoviForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 166);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.textBoxOpis);
            this.Controls.Add(this.textBoxKonto);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.labelKonto);
            this.Name = "KontniPlanNoviForm";
            this.Text = "Unesi novi konto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKonto;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.TextBox textBoxKonto;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.Button buttonSpremi;
    }
}
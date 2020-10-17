namespace Knjigovodstvo.Payroll
{
    partial class PlacaIzracunForm
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
            this.comboBoxZaposlenik = new System.Windows.Forms.ComboBox();
            this.labelOdabirZaposlenika = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxZaposlenik
            // 
            this.comboBoxZaposlenik.FormattingEnabled = true;
            this.comboBoxZaposlenik.Location = new System.Drawing.Point(12, 12);
            this.comboBoxZaposlenik.Name = "comboBoxZaposlenik";
            this.comboBoxZaposlenik.Size = new System.Drawing.Size(258, 23);
            this.comboBoxZaposlenik.TabIndex = 0;
            // 
            // labelOdabirZaposlenika
            // 
            this.labelOdabirZaposlenika.AutoSize = true;
            this.labelOdabirZaposlenika.Location = new System.Drawing.Point(276, 15);
            this.labelOdabirZaposlenika.Name = "labelOdabirZaposlenika";
            this.labelOdabirZaposlenika.Size = new System.Drawing.Size(107, 15);
            this.labelOdabirZaposlenika.TabIndex = 1;
            this.labelOdabirZaposlenika.Text = "Odabir zaposlenika";
            // 
            // PlacaIzracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 556);
            this.Controls.Add(this.labelOdabirZaposlenika);
            this.Controls.Add(this.comboBoxZaposlenik);
            this.Name = "PlacaIzracunForm";
            this.Text = "Izračun plaće";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxZaposlenik;
        private System.Windows.Forms.Label labelOdabirZaposlenika;
    }
}
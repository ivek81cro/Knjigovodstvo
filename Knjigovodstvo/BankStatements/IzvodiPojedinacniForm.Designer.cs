﻿
namespace Knjigovodstvo.BankStatements
{
    partial class IzvodiPojedinacniForm
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
            this.labelDatumIzvoda = new System.Windows.Forms.Label();
            this.labelRedniBroj = new System.Windows.Forms.Label();
            this.labelStanjeZavrsno = new System.Windows.Forms.Label();
            this.dataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.buttonUpariKonto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDatumIzvoda
            // 
            this.labelDatumIzvoda.AutoSize = true;
            this.labelDatumIzvoda.Location = new System.Drawing.Point(13, 13);
            this.labelDatumIzvoda.Name = "labelDatumIzvoda";
            this.labelDatumIzvoda.Size = new System.Drawing.Size(38, 15);
            this.labelDatumIzvoda.TabIndex = 0;
            this.labelDatumIzvoda.Text = "label1";
            // 
            // labelRedniBroj
            // 
            this.labelRedniBroj.AutoSize = true;
            this.labelRedniBroj.Location = new System.Drawing.Point(13, 40);
            this.labelRedniBroj.Name = "labelRedniBroj";
            this.labelRedniBroj.Size = new System.Drawing.Size(38, 15);
            this.labelRedniBroj.TabIndex = 1;
            this.labelRedniBroj.Text = "label1";
            // 
            // labelStanjeZavrsno
            // 
            this.labelStanjeZavrsno.AutoSize = true;
            this.labelStanjeZavrsno.Location = new System.Drawing.Point(13, 66);
            this.labelStanjeZavrsno.Name = "labelStanjeZavrsno";
            this.labelStanjeZavrsno.Size = new System.Drawing.Size(38, 15);
            this.labelStanjeZavrsno.TabIndex = 2;
            this.labelStanjeZavrsno.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(646, 519);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(13, 92);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 11;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // buttonUpariKonto
            // 
            this.buttonUpariKonto.Location = new System.Drawing.Point(573, 92);
            this.buttonUpariKonto.Name = "buttonUpariKonto";
            this.buttonUpariKonto.Size = new System.Drawing.Size(85, 23);
            this.buttonUpariKonto.TabIndex = 12;
            this.buttonUpariKonto.Text = "Upari Konto";
            this.buttonUpariKonto.UseVisualStyleBackColor = true;
            this.buttonUpariKonto.Click += new System.EventHandler(this.ButtonUpariKonto_Click);
            // 
            // IzvodiPojedinacniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 652);
            this.Controls.Add(this.buttonUpariKonto);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelStanjeZavrsno);
            this.Controls.Add(this.labelRedniBroj);
            this.Controls.Add(this.labelDatumIzvoda);
            this.Name = "IzvodiPojedinacniForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izvod";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDatumIzvoda;
        private System.Windows.Forms.Label labelRedniBroj;
        private System.Windows.Forms.Label labelStanjeZavrsno;
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSpremi;
        private System.Windows.Forms.Button buttonUpariKonto;
    }
}
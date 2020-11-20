﻿
namespace Knjigovodstvo.URA
{
    partial class UraKnjigaForm
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
            this.dataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonUcitaj = new System.Windows.Forms.Button();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.buttonTroskovi = new System.Windows.Forms.Button();
            this.textBoxFilterNaziv = new System.Windows.Forms.TextBox();
            this.groupBoxFilteri = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxFilteri.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1241, 466);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // buttonUcitaj
            // 
            this.buttonUcitaj.Location = new System.Drawing.Point(12, 13);
            this.buttonUcitaj.Name = "buttonUcitaj";
            this.buttonUcitaj.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitaj.TabIndex = 11;
            this.buttonUcitaj.Text = "Učitaj";
            this.buttonUcitaj.UseVisualStyleBackColor = true;
            this.buttonUcitaj.Click += new System.EventHandler(this.ButtonUcitaj_Click);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(93, 13);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 12;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // buttonTroskovi
            // 
            this.buttonTroskovi.Location = new System.Drawing.Point(174, 12);
            this.buttonTroskovi.Name = "buttonTroskovi";
            this.buttonTroskovi.Size = new System.Drawing.Size(75, 23);
            this.buttonTroskovi.TabIndex = 13;
            this.buttonTroskovi.Text = "Troškovi";
            this.buttonTroskovi.UseVisualStyleBackColor = true;
            this.buttonTroskovi.Click += new System.EventHandler(this.ButtonTroskovi_Click);
            // 
            // textBoxFilterNaziv
            // 
            this.textBoxFilterNaziv.Location = new System.Drawing.Point(742, 18);
            this.textBoxFilterNaziv.Name = "textBoxFilterNaziv";
            this.textBoxFilterNaziv.PlaceholderText = "Filter po nazivu";
            this.textBoxFilterNaziv.Size = new System.Drawing.Size(175, 23);
            this.textBoxFilterNaziv.TabIndex = 14;
            this.textBoxFilterNaziv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterNaziv_KeyUp);
            // 
            // groupBoxFilteri
            // 
            this.groupBoxFilteri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilteri.Controls.Add(this.textBoxFilterNaziv);
            this.groupBoxFilteri.Location = new System.Drawing.Point(12, 86);
            this.groupBoxFilteri.Name = "groupBoxFilteri";
            this.groupBoxFilteri.Size = new System.Drawing.Size(1241, 47);
            this.groupBoxFilteri.TabIndex = 15;
            this.groupBoxFilteri.TabStop = false;
            this.groupBoxFilteri.Text = "Filteri";
            // 
            // UraKnjigaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 617);
            this.Controls.Add(this.groupBoxFilteri);
            this.Controls.Add(this.buttonTroskovi);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.buttonUcitaj);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UraKnjigaForm";
            this.Text = "Knjiga ulaznih računa";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFilteri.ResumeLayout(false);
            this.groupBoxFilteri.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUcitaj;
        private System.Windows.Forms.Button buttonSpremi;
        private System.Windows.Forms.Button buttonTroskovi;
        private System.Windows.Forms.TextBox textBoxFilterNaziv;
        private System.Windows.Forms.GroupBox groupBoxFilteri;
    }
}
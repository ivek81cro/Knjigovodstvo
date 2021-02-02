﻿using Knjigovodstvo.Global;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    partial class TemeljnicaPripremaForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.buttonBrisiRed = new System.Windows.Forms.Button();
            this.buttonDodajRed = new System.Windows.Forms.Button();
            this.labelDugovna = new System.Windows.Forms.Label();
            this.labelPotrazna = new System.Windows.Forms.Label();
            this.buttonUpariKonto = new System.Windows.Forms.Button();
            this.kontoDescription = new Knjigovodstvo.Global.KontoDescription();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeight = 50;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 32);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(991, 293);
            this.dbDataGridView1.TabIndex = 0;
            this.dbDataGridView1.TabStop = false;
            this.dbDataGridView1.Text = "dataGridView1";
            this.dbDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbDataGridView1_CellDoubleClick);
            this.dbDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbDataGridView1_CellValueChanged);
            this.dbDataGridView1.SelectionChanged += new System.EventHandler(this.DbDataGridView1_SelectionChanged);
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonKnjizi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonKnjizi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonKnjizi.Location = new System.Drawing.Point(12, 378);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 11;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = false;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // buttonBrisiRed
            // 
            this.buttonBrisiRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBrisiRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonBrisiRed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBrisiRed.Location = new System.Drawing.Point(12, 331);
            this.buttonBrisiRed.Name = "buttonBrisiRed";
            this.buttonBrisiRed.Size = new System.Drawing.Size(75, 23);
            this.buttonBrisiRed.TabIndex = 12;
            this.buttonBrisiRed.Text = "Briši red";
            this.buttonBrisiRed.UseVisualStyleBackColor = false;
            this.buttonBrisiRed.Click += new System.EventHandler(this.ButtonBrisiRed_Click);
            // 
            // buttonDodajRed
            // 
            this.buttonDodajRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDodajRed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonDodajRed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDodajRed.Location = new System.Drawing.Point(93, 331);
            this.buttonDodajRed.Name = "buttonDodajRed";
            this.buttonDodajRed.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajRed.TabIndex = 13;
            this.buttonDodajRed.Text = "Dodaj red";
            this.buttonDodajRed.UseVisualStyleBackColor = false;
            this.buttonDodajRed.Click += new System.EventHandler(this.ButtonDodajRed_Click);
            // 
            // labelDugovna
            // 
            this.labelDugovna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDugovna.AutoSize = true;
            this.labelDugovna.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDugovna.Location = new System.Drawing.Point(484, 340);
            this.labelDugovna.Name = "labelDugovna";
            this.labelDugovna.Size = new System.Drawing.Size(80, 21);
            this.labelDugovna.TabIndex = 0;
            this.labelDugovna.Text = "Dugovna: ";
            // 
            // labelPotrazna
            // 
            this.labelPotrazna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPotrazna.AutoSize = true;
            this.labelPotrazna.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPotrazna.Location = new System.Drawing.Point(720, 340);
            this.labelPotrazna.Name = "labelPotrazna";
            this.labelPotrazna.Size = new System.Drawing.Size(77, 21);
            this.labelPotrazna.TabIndex = 1;
            this.labelPotrazna.Text = "Potražna: ";
            // 
            // buttonUpariKonto
            // 
            this.buttonUpariKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpariKonto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonUpariKonto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpariKonto.Location = new System.Drawing.Point(174, 331);
            this.buttonUpariKonto.Name = "buttonUpariKonto";
            this.buttonUpariKonto.Size = new System.Drawing.Size(84, 23);
            this.buttonUpariKonto.TabIndex = 14;
            this.buttonUpariKonto.Text = "Upari konto";
            this.buttonUpariKonto.UseVisualStyleBackColor = false;
            this.buttonUpariKonto.Click += new System.EventHandler(this.ButtonUpariKonto_Click);
            // 
            // kontoDescription1
            // 
            this.kontoDescription.Location = new System.Drawing.Point(12, 0);
            this.kontoDescription.Name = "kontoDescription1";
            this.kontoDescription.Size = new System.Drawing.Size(510, 26);
            this.kontoDescription.TabIndex = 15;
            // 
            // TemeljnicaPripremaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1015, 413);
            this.Controls.Add(this.kontoDescription);
            this.Controls.Add(this.buttonUpariKonto);
            this.Controls.Add(this.labelDugovna);
            this.Controls.Add(this.labelPotrazna);
            this.Controls.Add(this.buttonDodajRed);
            this.Controls.Add(this.buttonBrisiRed);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.dbDataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "TemeljnicaPripremaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Knjiženje na temeljnicu";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonKnjizi;
        private System.Windows.Forms.Button buttonBrisiRed;
        private System.Windows.Forms.Button buttonDodajRed;
        private System.Windows.Forms.Label labelPotrazna;
        private System.Windows.Forms.Label labelDugovna;
        private System.Windows.Forms.Button buttonUpariKonto;
        private KontoDescription kontoDescription;
    }
}
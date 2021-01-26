using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Employee
{
    partial class ZaposleniciTableForm
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
            this.textBoxZaposlenikFilter = new System.Windows.Forms.TextBox();
            this.labelPartnerName = new System.Windows.Forms.Label();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonNewZaposlenik = new System.Windows.Forms.Button();
            this.buttonEditZaposlenik = new System.Windows.Forms.Button();
            this.buttonDeleteZaposlenik = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxZaposlenikFilter
            // 
            this.textBoxZaposlenikFilter.Location = new System.Drawing.Point(128, 51);
            this.textBoxZaposlenikFilter.Name = "textBoxZaposlenikFilter";
            this.textBoxZaposlenikFilter.Size = new System.Drawing.Size(147, 23);
            this.textBoxZaposlenikFilter.TabIndex = 1;
            this.textBoxZaposlenikFilter.TextChanged += new System.EventHandler(this.TextBoxFilterZaposlenik_TextChanged);
            // 
            // labelPartnerName
            // 
            this.labelPartnerName.AutoSize = true;
            this.labelPartnerName.Location = new System.Drawing.Point(9, 54);
            this.labelPartnerName.Name = "labelPartnerName";
            this.labelPartnerName.Size = new System.Drawing.Size(113, 15);
            this.labelPartnerName.TabIndex = 2;
            this.labelPartnerName.Text = "Prezime zaposlenika";
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dbDataGridView1.TabIndex = 4;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // buttonNewZaposlenik
            // 
            this.buttonNewZaposlenik.Location = new System.Drawing.Point(12, 12);
            this.buttonNewZaposlenik.Name = "buttonNewZaposlenik";
            this.buttonNewZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.buttonNewZaposlenik.TabIndex = 5;
            this.buttonNewZaposlenik.Text = "Novi";
            this.buttonNewZaposlenik.UseVisualStyleBackColor = true;
            this.buttonNewZaposlenik.Click += new System.EventHandler(this.ButtonNewZaposlenik_Click);
            // 
            // buttonEditZaposlenik
            // 
            this.buttonEditZaposlenik.Location = new System.Drawing.Point(93, 12);
            this.buttonEditZaposlenik.Name = "buttonEditZaposlenik";
            this.buttonEditZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.buttonEditZaposlenik.TabIndex = 6;
            this.buttonEditZaposlenik.Text = "Izmijeni";
            this.buttonEditZaposlenik.UseVisualStyleBackColor = true;
            this.buttonEditZaposlenik.Click += new System.EventHandler(this.ButtonEditZaposlenik_Click);
            // 
            // buttonDeleteZaposlenik
            // 
            this.buttonDeleteZaposlenik.Location = new System.Drawing.Point(174, 12);
            this.buttonDeleteZaposlenik.Name = "buttonDeleteZaposlenik";
            this.buttonDeleteZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteZaposlenik.TabIndex = 6;
            this.buttonDeleteZaposlenik.Text = "Briši";
            this.buttonDeleteZaposlenik.UseVisualStyleBackColor = true;
            this.buttonDeleteZaposlenik.Click += new System.EventHandler(this.ButtonDeleteZaposlenik_Click);
            // 
            // ZaposleniciTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.buttonDeleteZaposlenik);
            this.Controls.Add(this.buttonEditZaposlenik);
            this.Controls.Add(this.buttonNewZaposlenik);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.labelPartnerName);
            this.Controls.Add(this.textBoxZaposlenikFilter);
            this.Name = "ZaposleniciTableForm";
            this.Text = "Zaposlenici";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxZaposlenikFilter;
        private System.Windows.Forms.Label labelPartnerName;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonNewZaposlenik;
        private System.Windows.Forms.Button buttonEditZaposlenik;
        private System.Windows.Forms.Button buttonDeleteZaposlenik;
    }
}
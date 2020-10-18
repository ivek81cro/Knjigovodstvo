using System;

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
            this.textBoxFilterZaposlenik = new System.Windows.Forms.TextBox();
            this.namePartnerLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNewZaposlenik = new System.Windows.Forms.Button();
            this.btnEditZaposlenik = new System.Windows.Forms.Button();
            this.btnDeleteZaposlenik = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilterZaposlenik
            // 
            this.textBoxFilterZaposlenik.Location = new System.Drawing.Point(128, 51);
            this.textBoxFilterZaposlenik.Name = "textBoxFilterZaposlenik";
            this.textBoxFilterZaposlenik.Size = new System.Drawing.Size(147, 23);
            this.textBoxFilterZaposlenik.TabIndex = 1;
            this.textBoxFilterZaposlenik.TextChanged += new System.EventHandler(this.TextBoxFilterZaposlenik_TextChanged);
            // 
            // namePartnerLabel
            // 
            this.namePartnerLabel.AutoSize = true;
            this.namePartnerLabel.Location = new System.Drawing.Point(9, 54);
            this.namePartnerLabel.Name = "namePartnerLabel";
            this.namePartnerLabel.Size = new System.Drawing.Size(113, 15);
            this.namePartnerLabel.TabIndex = 2;
            this.namePartnerLabel.Text = "Prezime zaposlenika";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // btnNewZaposlenik
            // 
            this.btnNewZaposlenik.Location = new System.Drawing.Point(12, 12);
            this.btnNewZaposlenik.Name = "btnNewZaposlenik";
            this.btnNewZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.btnNewZaposlenik.TabIndex = 5;
            this.btnNewZaposlenik.Text = "Novi";
            this.btnNewZaposlenik.UseVisualStyleBackColor = true;
            this.btnNewZaposlenik.Click += new System.EventHandler(this.BtnNewZaposlenik_Click);
            // 
            // btnEditZaposlenik
            // 
            this.btnEditZaposlenik.Location = new System.Drawing.Point(93, 12);
            this.btnEditZaposlenik.Name = "btnEditZaposlenik";
            this.btnEditZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.btnEditZaposlenik.TabIndex = 6;
            this.btnEditZaposlenik.Text = "Izmijeni";
            this.btnEditZaposlenik.UseVisualStyleBackColor = true;
            this.btnEditZaposlenik.Click += new System.EventHandler(this.BtnEditZaposlenik_Click);
            // 
            // btnDeleteZaposlenik
            // 
            this.btnDeleteZaposlenik.Location = new System.Drawing.Point(174, 12);
            this.btnDeleteZaposlenik.Name = "btnDeleteZaposlenik";
            this.btnDeleteZaposlenik.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteZaposlenik.TabIndex = 6;
            this.btnDeleteZaposlenik.Text = "Briši";
            this.btnDeleteZaposlenik.UseVisualStyleBackColor = true;
            this.btnDeleteZaposlenik.Click += new System.EventHandler(this.BtnDeleteZaposlenik_Click);
            // 
            // ZaposleniciTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.btnDeleteZaposlenik);
            this.Controls.Add(this.btnEditZaposlenik);
            this.Controls.Add(this.btnNewZaposlenik);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.textBoxFilterZaposlenik);
            this.Name = "ZaposleniciTableForm";
            this.Text = "Zaposlenici";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterZaposlenik;
        private System.Windows.Forms.Label namePartnerLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewZaposlenik;
        private System.Windows.Forms.Button btnEditZaposlenik;
        private System.Windows.Forms.Button btnDeleteZaposlenik;
    }
}
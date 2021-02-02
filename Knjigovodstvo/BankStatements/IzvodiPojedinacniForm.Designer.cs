
using Knjigovodstvo.Global;

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
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.kontoDescription = new Knjigovodstvo.Global.KontoDescription();
            this.accountPairing = new AccountPairing(dbDataGridView1);
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
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
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dbDataGridView1.MultiSelect = false;
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(646, 519);
            this.dbDataGridView1.TabIndex = 10;
            this.dbDataGridView1.Text = "dataGridView1";
            this.dbDataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
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
            // accountPairing
            // 
            this.accountPairing.Location = new System.Drawing.Point(452, 33);
            this.accountPairing.Name = "accountPairing";
            this.accountPairing.Size = new System.Drawing.Size(206, 82);
            this.accountPairing.TabIndex = 12;
            // 
            // kontoDescription
            // 
            this.kontoDescription.Location = new System.Drawing.Point(94, 92);
            this.kontoDescription.Name = "kontoDescription";
            this.kontoDescription.Size = new System.Drawing.Size(365, 23);
            this.kontoDescription.TabIndex = 13;
            // 
            // IzvodiPojedinacniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 652);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.labelStanjeZavrsno);
            this.Controls.Add(this.labelRedniBroj);
            this.Controls.Add(this.labelDatumIzvoda);
            this.Controls.Add(this.accountPairing);
            this.Controls.Add(this.kontoDescription);
            this.Name = "IzvodiPojedinacniForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izvod";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void CustomiseColumns()
        {
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns["Id_izvod"].Visible = false;
            dbDataGridView1.Columns["Oznaka"].Visible = false;
            dbDataGridView1.Columns["Opis"].ReadOnly = true;
            dbDataGridView1.Columns["Naziv"].ReadOnly = true;
        }

        private System.Windows.Forms.Label labelDatumIzvoda;
        private System.Windows.Forms.Label labelRedniBroj;
        private System.Windows.Forms.Label labelStanjeZavrsno;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonSpremi;
        private AccountPairing accountPairing;
        private KontoDescription kontoDescription;
    }
}
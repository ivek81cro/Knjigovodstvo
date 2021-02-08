namespace Knjigovodstvo.Settings
{
    partial class PostavkeParoviKonta
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
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.textBoxKonto = new System.Windows.Forms.TextBox();
            this.textBoxOpis = new System.Windows.Forms.TextBox();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.labelKonto = new System.Windows.Forms.Label();
            this.labelOpis = new System.Windows.Forms.Label();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.buttonBrisi = new System.Windows.Forms.Button();
            this.buttonPostaviKonto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(12, 125);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 3;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
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
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 154);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(819, 334);
            this.dbDataGridView1.TabIndex = 1;
            this.dbDataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DbDataGridView1_CellMouseClick);
            // 
            // textBoxKonto
            // 
            this.textBoxKonto.Location = new System.Drawing.Point(87, 40);
            this.textBoxKonto.Name = "textBoxKonto";
            this.textBoxKonto.Size = new System.Drawing.Size(254, 23);
            this.textBoxKonto.TabIndex = 0;
            // 
            // textBoxOpis
            // 
            this.textBoxOpis.Location = new System.Drawing.Point(87, 96);
            this.textBoxOpis.Name = "textBoxOpis";
            this.textBoxOpis.Size = new System.Drawing.Size(254, 23);
            this.textBoxOpis.TabIndex = 2;
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(87, 68);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(254, 23);
            this.textBoxNaziv.TabIndex = 4;
            // 
            // labelKonto
            // 
            this.labelKonto.AutoSize = true;
            this.labelKonto.Location = new System.Drawing.Point(12, 43);
            this.labelKonto.Name = "labelKonto";
            this.labelKonto.Size = new System.Drawing.Size(39, 15);
            this.labelKonto.TabIndex = 5;
            this.labelKonto.Text = "Konto";
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Location = new System.Drawing.Point(12, 99);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(31, 15);
            this.labelOpis.TabIndex = 6;
            this.labelOpis.Text = "Opis";
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(12, 71);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(36, 15);
            this.labelNaziv.TabIndex = 7;
            this.labelNaziv.Text = "Naziv";
            // 
            // buttonBrisi
            // 
            this.buttonBrisi.Location = new System.Drawing.Point(93, 125);
            this.buttonBrisi.Name = "buttonBrisi";
            this.buttonBrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonBrisi.TabIndex = 4;
            this.buttonBrisi.Text = "Briši";
            this.buttonBrisi.UseVisualStyleBackColor = true;
            this.buttonBrisi.Click += new System.EventHandler(this.ButtonBrisi_Click);
            // 
            // buttonPostaviKonto
            // 
            this.buttonPostaviKonto.Location = new System.Drawing.Point(347, 40);
            this.buttonPostaviKonto.Name = "buttonPostaviKonto";
            this.buttonPostaviKonto.Size = new System.Drawing.Size(92, 23);
            this.buttonPostaviKonto.TabIndex = 1;
            this.buttonPostaviKonto.Text = "Postavi konto";
            this.buttonPostaviKonto.UseVisualStyleBackColor = true;
            this.buttonPostaviKonto.Click += new System.EventHandler(this.ButtonPostaviKonto_Click);
            // 
            // PostavkeParoviKonta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 500);
            this.Controls.Add(this.buttonPostaviKonto);
            this.Controls.Add(this.buttonBrisi);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.labelKonto);
            this.Controls.Add(this.textBoxNaziv);
            this.Controls.Add(this.textBoxOpis);
            this.Controls.Add(this.textBoxKonto);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.buttonSpremi);
            this.Name = "PostavkeParoviKonta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PostavkeParoviKonta";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSpremi;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.TextBox textBoxKonto;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.Label labelKonto;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Button buttonBrisi;
        private System.Windows.Forms.Button buttonPostaviKonto;
    }
}

namespace Knjigovodstvo.Books.Inventory
{
    partial class OsnovnoSredstvoForm
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
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDodajNovo = new System.Windows.Forms.Button();
            this.buttonObracunAmortizacije = new System.Windows.Forms.Button();
            this.buttonIzmjena = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 161);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1187, 381);
            this.dbDataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPostavke});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1211, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuPostavke
            // 
            this.menuPostavke.Name = "menuPostavke";
            this.menuPostavke.Size = new System.Drawing.Size(115, 20);
            this.menuPostavke.Text = "Postavke knjiženja";
            this.menuPostavke.Click += new System.EventHandler(this.ButtonPostavke_Click);
            // 
            // buttonDodajNovo
            // 
            this.buttonDodajNovo.Location = new System.Drawing.Point(12, 27);
            this.buttonDodajNovo.Name = "buttonDodajNovo";
            this.buttonDodajNovo.Size = new System.Drawing.Size(86, 23);
            this.buttonDodajNovo.TabIndex = 2;
            this.buttonDodajNovo.Text = "Dodaj novo";
            this.buttonDodajNovo.UseVisualStyleBackColor = true;
            this.buttonDodajNovo.Click += new System.EventHandler(this.ButtonDodajNovo_Click);
            // 
            // buttonObracunAmortizacije
            // 
            this.buttonObracunAmortizacije.Location = new System.Drawing.Point(12, 56);
            this.buttonObracunAmortizacije.Name = "buttonObracunAmortizacije";
            this.buttonObracunAmortizacije.Size = new System.Drawing.Size(113, 23);
            this.buttonObracunAmortizacije.TabIndex = 3;
            this.buttonObracunAmortizacije.Text = "Obračunaj amort.";
            this.buttonObracunAmortizacije.UseVisualStyleBackColor = true;
            this.buttonObracunAmortizacije.Click += new System.EventHandler(this.ButtonObracunAmortizacije_Click);
            // 
            // buttonIzmjena
            // 
            this.buttonIzmjena.Location = new System.Drawing.Point(104, 27);
            this.buttonIzmjena.Name = "buttonIzmjena";
            this.buttonIzmjena.Size = new System.Drawing.Size(75, 23);
            this.buttonIzmjena.TabIndex = 4;
            this.buttonIzmjena.Text = "Izmjena";
            this.buttonIzmjena.UseVisualStyleBackColor = true;
            this.buttonIzmjena.Click += new System.EventHandler(this.ButtonIzmjena_Click);
            // 
            // OsnovnoSredstvoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 554);
            this.Controls.Add(this.buttonIzmjena);
            this.Controls.Add(this.buttonObracunAmortizacije);
            this.Controls.Add(this.buttonDodajNovo);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OsnovnoSredstvoForm";
            this.Text = "Osnovna sredstva";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private System.Windows.Forms.Button buttonDodajNovo;
        private System.Windows.Forms.Button buttonObracunAmortizacije;
        private System.Windows.Forms.Button buttonIzmjena;
    }
}
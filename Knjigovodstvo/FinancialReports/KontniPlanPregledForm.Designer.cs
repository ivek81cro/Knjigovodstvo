
namespace Knjigovodstvo.FinancialReports
{
    partial class KontniPlanPregledForm
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
            this.buttonDodajKonto = new System.Windows.Forms.Button();
            this.textBoxFilterKonto = new System.Windows.Forms.TextBox();
            this.textBoxFilterOpis = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1222, 430);
            this.dbDataGridView1.TabIndex = 10;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // buttonDodajKonto
            // 
            this.buttonDodajKonto.Location = new System.Drawing.Point(13, 13);
            this.buttonDodajKonto.Name = "buttonDodajKonto";
            this.buttonDodajKonto.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajKonto.TabIndex = 11;
            this.buttonDodajKonto.Text = "Dodaj";
            this.buttonDodajKonto.UseVisualStyleBackColor = true;
            this.buttonDodajKonto.Click += new System.EventHandler(this.ButtonDodajKonto_Click);
            // 
            // textBoxFilterKonto
            // 
            this.textBoxFilterKonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFilterKonto.Location = new System.Drawing.Point(13, 161);
            this.textBoxFilterKonto.Name = "textBoxFilterKonto";
            this.textBoxFilterKonto.PlaceholderText = "Filter konta";
            this.textBoxFilterKonto.Size = new System.Drawing.Size(134, 23);
            this.textBoxFilterKonto.TabIndex = 12;
            this.textBoxFilterKonto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxFilterKonto_KeyUp);
            // 
            // textBoxFilterOpis
            // 
            this.textBoxFilterOpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFilterOpis.Location = new System.Drawing.Point(153, 161);
            this.textBoxFilterOpis.Name = "textBoxFilterOpis";
            this.textBoxFilterOpis.PlaceholderText = "Filter prema riječima u opisu";
            this.textBoxFilterOpis.Size = new System.Drawing.Size(300, 23);
            this.textBoxFilterOpis.TabIndex = 13;
            this.textBoxFilterOpis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxFilterOpis_KeyUp);
            // 
            // KontniPlanPregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 632);
            this.Controls.Add(this.textBoxFilterOpis);
            this.Controls.Add(this.textBoxFilterKonto);
            this.Controls.Add(this.buttonDodajKonto);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "KontniPlanPregledForm";
            this.Text = "Kontni Plan";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonDodajKonto;
        private System.Windows.Forms.TextBox textBoxFilterKonto;
        private System.Windows.Forms.TextBox textBoxFilterOpis;
    }
}
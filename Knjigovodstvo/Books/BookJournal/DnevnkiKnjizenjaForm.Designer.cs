
namespace Knjigovodstvo.Books.BookJournal
{
    partial class DnevnkiKnjizenjaForm
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
            this.labelFilterTemeljnica = new System.Windows.Forms.Label();
            this.textBoxFilterOpis = new System.Windows.Forms.TextBox();
            this.labelFilterOpis = new System.Windows.Forms.Label();
            this.textBoxFilterBrojTemeljnice = new System.Windows.Forms.TextBox();
            this.textBoxVrstaTemeljnice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1052, 518);
            this.dbDataGridView1.TabIndex = 0;
            // 
            // labelFilterTemeljnica
            // 
            this.labelFilterTemeljnica.AutoSize = true;
            this.labelFilterTemeljnica.Location = new System.Drawing.Point(352, 49);
            this.labelFilterTemeljnica.Name = "labelFilterTemeljnica";
            this.labelFilterTemeljnica.Size = new System.Drawing.Size(149, 15);
            this.labelFilterTemeljnica.TabIndex = 2;
            this.labelFilterTemeljnica.Text = "Filtriraj po broju temeljnice";
            // 
            // textBoxFilterOpis
            // 
            this.textBoxFilterOpis.Location = new System.Drawing.Point(111, 46);
            this.textBoxFilterOpis.Name = "textBoxFilterOpis";
            this.textBoxFilterOpis.PlaceholderText = "Tekst u opisu";
            this.textBoxFilterOpis.Size = new System.Drawing.Size(235, 23);
            this.textBoxFilterOpis.TabIndex = 3;
            this.textBoxFilterOpis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterOpisColumn);
            // 
            // labelFilterOpis
            // 
            this.labelFilterOpis.AutoSize = true;
            this.labelFilterOpis.Location = new System.Drawing.Point(13, 49);
            this.labelFilterOpis.Name = "labelFilterOpis";
            this.labelFilterOpis.Size = new System.Drawing.Size(92, 15);
            this.labelFilterOpis.TabIndex = 4;
            this.labelFilterOpis.Text = "Filtriraj po opisu";
            // 
            // textBoxFilterBrojTemeljnice
            // 
            this.textBoxFilterBrojTemeljnice.Location = new System.Drawing.Point(507, 46);
            this.textBoxFilterBrojTemeljnice.Name = "textBoxFilterBrojTemeljnice";
            this.textBoxFilterBrojTemeljnice.PlaceholderText = "Broj temeljnice";
            this.textBoxFilterBrojTemeljnice.Size = new System.Drawing.Size(97, 23);
            this.textBoxFilterBrojTemeljnice.TabIndex = 5;
            this.textBoxFilterBrojTemeljnice.TextChanged += new System.EventHandler(this.TextBoxFilterBrojTemeljnice_TextChanged);
            this.textBoxFilterBrojTemeljnice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterBrojTemeljnica);
            // 
            // textBoxVrstaTemeljnice
            // 
            this.textBoxVrstaTemeljnice.Location = new System.Drawing.Point(759, 46);
            this.textBoxVrstaTemeljnice.Name = "textBoxVrstaTemeljnice";
            this.textBoxVrstaTemeljnice.PlaceholderText = "Tekst vrste temeljnice";
            this.textBoxVrstaTemeljnice.Size = new System.Drawing.Size(127, 23);
            this.textBoxVrstaTemeljnice.TabIndex = 6;
            this.textBoxVrstaTemeljnice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterVrstaTemeljnice);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filtriraj po vrsti temeljnice";
            // 
            // DnevnkiKnjizenjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 605);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxVrstaTemeljnice);
            this.Controls.Add(this.textBoxFilterBrojTemeljnice);
            this.Controls.Add(this.labelFilterOpis);
            this.Controls.Add(this.textBoxFilterOpis);
            this.Controls.Add(this.labelFilterTemeljnica);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "DnevnkiKnjizenjaForm";
            this.Text = "Dnevnik knjiženja";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Label labelFilterTemeljnica;
        private System.Windows.Forms.TextBox textBoxFilterOpis;
        private System.Windows.Forms.Label labelFilterOpis;
        private System.Windows.Forms.TextBox textBoxFilterBrojTemeljnice;
        private System.Windows.Forms.TextBox textBoxVrstaTemeljnice;
        private System.Windows.Forms.Label label1;
    }
}
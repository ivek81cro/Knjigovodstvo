
namespace Knjigovodstvo.Books.BookJournal
{
    partial class KnjizeneTemeljniceDialog
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
            this.buttonOtvori = new System.Windows.Forms.Button();
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
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 42);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(830, 474);
            this.dbDataGridView1.TabIndex = 0;
            // 
            // buttonOtvori
            // 
            this.buttonOtvori.Location = new System.Drawing.Point(12, 13);
            this.buttonOtvori.Name = "buttonOtvori";
            this.buttonOtvori.Size = new System.Drawing.Size(75, 23);
            this.buttonOtvori.TabIndex = 1;
            this.buttonOtvori.Text = "Otvori";
            this.buttonOtvori.UseVisualStyleBackColor = true;
            this.buttonOtvori.Click += new System.EventHandler(this.ButtonOtvori_Click);
            // 
            // KnjizeneTemeljniceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 528);
            this.Controls.Add(this.buttonOtvori);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "KnjizeneTemeljniceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Knjižene temeljnice";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonOtvori;
    }
}
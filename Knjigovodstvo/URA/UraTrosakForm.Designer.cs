
namespace Knjigovodstvo.URA
{
    partial class UraTrosakForm
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
            this.groupBoxFilteri = new System.Windows.Forms.GroupBox();
            this.textBoxFilterNaziv = new System.Windows.Forms.TextBox();
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
            this.dataGridView1.Size = new System.Drawing.Size(1200, 484);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // groupBoxFilteri
            // 
            this.groupBoxFilteri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilteri.Controls.Add(this.textBoxFilterNaziv);
            this.groupBoxFilteri.Location = new System.Drawing.Point(12, 82);
            this.groupBoxFilteri.Name = "groupBoxFilteri";
            this.groupBoxFilteri.Size = new System.Drawing.Size(1200, 51);
            this.groupBoxFilteri.TabIndex = 11;
            this.groupBoxFilteri.TabStop = false;
            this.groupBoxFilteri.Text = "Filteri";
            // 
            // textBoxFilterNaziv
            // 
            this.textBoxFilterNaziv.Location = new System.Drawing.Point(734, 22);
            this.textBoxFilterNaziv.Name = "textBoxFilterNaziv";
            this.textBoxFilterNaziv.PlaceholderText = "Filter po nazivu";
            this.textBoxFilterNaziv.Size = new System.Drawing.Size(186, 23);
            this.textBoxFilterNaziv.TabIndex = 0;
            this.textBoxFilterNaziv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilterNaziv_KeyUp);
            // 
            // UraTrosakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 635);
            this.Controls.Add(this.groupBoxFilteri);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UraTrosakForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Knjiga ulaznih računa - Troškovi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFilteri.ResumeLayout(false);
            this.groupBoxFilteri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilteri;
        private System.Windows.Forms.TextBox textBoxFilterNaziv;
        private DBDataGridView dataGridView1;
    }
}
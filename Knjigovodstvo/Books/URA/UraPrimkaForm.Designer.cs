
using Knjigovodstvo.Global;

namespace Knjigovodstvo.URA
{
    partial class UraPrimkaForm
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
            this.buttonUcitajTablicu = new System.Windows.Forms.Button();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.knjigaFilter1 = new KnjigaFilter(dataGridView1, _columns);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(9, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1101, 466);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // buttonUcitajTablicu
            // 
            this.buttonUcitajTablicu.Location = new System.Drawing.Point(13, 13);
            this.buttonUcitajTablicu.Name = "buttonUcitajTablicu";
            this.buttonUcitajTablicu.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitajTablicu.TabIndex = 0;
            this.buttonUcitajTablicu.Text = "Učitaj";
            this.buttonUcitajTablicu.UseVisualStyleBackColor = true;
            this.buttonUcitajTablicu.Click += new System.EventHandler(this.ButtonUcitajTablicu_Click);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(95, 12);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 1;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // knjigaFilter1
            // 
            this.knjigaFilter1.Location = new System.Drawing.Point(9, 69);
            this.knjigaFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knjigaFilter1.Name = "knjigaFilter1";
            this.knjigaFilter1.Size = new System.Drawing.Size(1101, 64);
            this.knjigaFilter1.TabIndex = 13;
            // 
            // UraPrimkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 617);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.buttonUcitajTablicu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.knjigaFilter1);
            this.Name = "UraPrimkaForm";
            this.Text = "UraPregledForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUcitajTablicu;
        private System.Windows.Forms.Button buttonSpremi;
        private Global.KnjigaFilter knjigaFilter1;
    }
}
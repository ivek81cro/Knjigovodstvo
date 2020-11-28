using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings
{
    partial class PostavkePlaceTablicaForm
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
            this.dataGridView1 = new DBDataGridView();
            this.buttonEditPostavke = new System.Windows.Forms.Button();
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
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(460, 447);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // buttonEditPostavke
            // 
            this.buttonEditPostavke.Location = new System.Drawing.Point(12, 12);
            this.buttonEditPostavke.Name = "buttonEditPostavke";
            this.buttonEditPostavke.Size = new System.Drawing.Size(75, 23);
            this.buttonEditPostavke.TabIndex = 6;
            this.buttonEditPostavke.Text = "Izmijeni";
            this.buttonEditPostavke.UseVisualStyleBackColor = true;
            this.buttonEditPostavke.Click += new System.EventHandler(this.ButtonEditPostavke_Click);
            // 
            // PostavkeTablicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 543);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonEditPostavke);
            this.Name = "PostavkeTablicaForm";
            this.Text = "Postavke";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button buttonEditPostavke;

    }
}
using System;

namespace Knjigovodstvo.City
{
    partial class GradoviTableForm
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
            this.textBoxFilterGrad = new System.Windows.Forms.TextBox();
            this.namePartnerLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNewGrad = new System.Windows.Forms.Button();
            this.btnEditGrad = new System.Windows.Forms.Button();
            this.btnDeleteGrad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilterGrad
            // 
            this.textBoxFilterGrad.Location = new System.Drawing.Point(128, 51);
            this.textBoxFilterGrad.Name = "textBoxFilterGrad";
            this.textBoxFilterGrad.Size = new System.Drawing.Size(147, 23);
            this.textBoxFilterGrad.TabIndex = 1;
            this.textBoxFilterGrad.TextChanged += new System.EventHandler(this.TextBoxFilterGrad_TextChanged);
            // 
            // namePartnerLabel
            // 
            this.namePartnerLabel.AutoSize = true;
            this.namePartnerLabel.Location = new System.Drawing.Point(9, 54);
            this.namePartnerLabel.Name = "namePartnerLabel";
            this.namePartnerLabel.Size = new System.Drawing.Size(70, 15);
            this.namePartnerLabel.TabIndex = 2;
            this.namePartnerLabel.Text = "Naziv Grada";
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
            // btnNewGrad
            // 
            this.btnNewGrad.Location = new System.Drawing.Point(12, 12);
            this.btnNewGrad.Name = "btnNewGrad";
            this.btnNewGrad.Size = new System.Drawing.Size(75, 23);
            this.btnNewGrad.TabIndex = 5;
            this.btnNewGrad.Text = "Novi";
            this.btnNewGrad.UseVisualStyleBackColor = true;
            this.btnNewGrad.Click += new System.EventHandler(this.BtnNewGrad_Click);
            // 
            // btnEditGrad
            // 
            this.btnEditGrad.Location = new System.Drawing.Point(93, 12);
            this.btnEditGrad.Name = "btnEditGrad";
            this.btnEditGrad.Size = new System.Drawing.Size(139, 23);
            this.btnEditGrad.TabIndex = 6;
            this.btnEditGrad.Text = "Izmijeni / Odaberi";
            this.btnEditGrad.UseVisualStyleBackColor = true;
            this.btnEditGrad.Click += new System.EventHandler(this.BtnEditGrad_Click);
            // 
            // btnDeleteGrad
            // 
            this.btnDeleteGrad.Location = new System.Drawing.Point(238, 12);
            this.btnDeleteGrad.Name = "btnDeleteGrad";
            this.btnDeleteGrad.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGrad.TabIndex = 6;
            this.btnDeleteGrad.Text = "Briši";
            this.btnDeleteGrad.UseVisualStyleBackColor = true;
            this.btnDeleteGrad.Click += new System.EventHandler(this.BtnDeleteGrad_Click);
            // 
            // GradoviTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.btnDeleteGrad);
            this.Controls.Add(this.btnEditGrad);
            this.Controls.Add(this.btnNewGrad);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.textBoxFilterGrad);
            this.Name = "GradoviTableForm";
            this.Text = "GradoviTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterGrad;
        private System.Windows.Forms.Label namePartnerLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewGrad;
        private System.Windows.Forms.Button btnEditGrad;
        private System.Windows.Forms.Button btnDeleteGrad;
    }
}
using System;
using System.Windows.Forms;

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
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonNewGrad = new System.Windows.Forms.Button();
            this.buttonEditGrad = new System.Windows.Forms.Button();
            this.buttonDeleteGrad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilterGrad
            // 
            this.textBoxFilterGrad.Location = new System.Drawing.Point(128, 51);
            this.textBoxFilterGrad.Name = "textBoxFilterGrad";
            this.textBoxFilterGrad.Size = new System.Drawing.Size(147, 23);
            this.textBoxFilterGrad.TabIndex = 0;
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
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dbDataGridView1.Name = "dataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dbDataGridView1.TabIndex = 4;
            this.dbDataGridView1.Text = "dataGridView1";
            this.dbDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ButtonEditGrad_Click);
            // 
            // buttonNewGrad
            // 
            this.buttonNewGrad.Location = new System.Drawing.Point(12, 12);
            this.buttonNewGrad.Name = "btnNewGrad";
            this.buttonNewGrad.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGrad.TabIndex = 3;
            this.buttonNewGrad.Text = "Novi";
            this.buttonNewGrad.UseVisualStyleBackColor = true;
            this.buttonNewGrad.Click += new System.EventHandler(this.ButtonNewGrad_Click);
            // 
            // buttonEditGrad
            // 
            this.buttonEditGrad.Location = new System.Drawing.Point(93, 12);
            this.buttonEditGrad.Name = "btnEditGrad";
            this.buttonEditGrad.Size = new System.Drawing.Size(139, 23);
            this.buttonEditGrad.TabIndex = 1;
            this.buttonEditGrad.Text = "Izmijeni / Odaberi";
            this.buttonEditGrad.UseVisualStyleBackColor = true;
            this.buttonEditGrad.Click += new System.EventHandler(this.ButtonEditGrad_Click);
            // 
            // buttonDeleteGrad
            // 
            this.buttonDeleteGrad.Location = new System.Drawing.Point(238, 12);
            this.buttonDeleteGrad.Name = "btnDeleteGrad";
            this.buttonDeleteGrad.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteGrad.TabIndex = 2;
            this.buttonDeleteGrad.Text = "Briši";
            this.buttonDeleteGrad.UseVisualStyleBackColor = true;
            this.buttonDeleteGrad.Click += new System.EventHandler(this.ButtonDeleteGrad_Click);
            // 
            // GradoviTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.buttonDeleteGrad);
            this.Controls.Add(this.buttonEditGrad);
            this.Controls.Add(this.buttonNewGrad);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.textBoxFilterGrad);
            this.Name = "GradoviTableForm";
            this.Text = "Gradovi";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterGrad;
        private System.Windows.Forms.Label namePartnerLabel;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonNewGrad;
        private System.Windows.Forms.Button buttonEditGrad;
        private System.Windows.Forms.Button buttonDeleteGrad;
    }
}
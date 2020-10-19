using System;

namespace Knjigovodstvo.Payroll
{
    partial class PlacaTableForm
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
            this.textBoxFilterPlaca = new System.Windows.Forms.TextBox();
            this.namePartnerLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNewPlaca = new System.Windows.Forms.Button();
            this.btnEditPlaca = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilterPlaca
            // 
            this.textBoxFilterPlaca.Location = new System.Drawing.Point(128, 51);
            this.textBoxFilterPlaca.Name = "textBoxFilterPlaca";
            this.textBoxFilterPlaca.Size = new System.Drawing.Size(147, 23);
            this.textBoxFilterPlaca.TabIndex = 1;
            this.textBoxFilterPlaca.TextChanged += new System.EventHandler(this.TextBoxFilterPlaca_TextChanged);
            // 
            // namePartnerLabel
            // 
            this.namePartnerLabel.AutoSize = true;
            this.namePartnerLabel.Location = new System.Drawing.Point(9, 54);
            this.namePartnerLabel.Name = "namePartnerLabel";
            this.namePartnerLabel.Size = new System.Drawing.Size(115, 15);
            this.namePartnerLabel.TabIndex = 2;
            this.namePartnerLabel.Text = "Prezime Zaposlenika";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // btnNewPlaca
            // 
            this.btnNewPlaca.Location = new System.Drawing.Point(12, 12);
            this.btnNewPlaca.Name = "btnNewPlaca";
            this.btnNewPlaca.Size = new System.Drawing.Size(122, 23);
            this.btnNewPlaca.TabIndex = 5;
            this.btnNewPlaca.Text = "Novi izračun";
            this.btnNewPlaca.UseVisualStyleBackColor = true;
            this.btnNewPlaca.Click += new System.EventHandler(this.BtnNewPlaca_Click);
            // 
            // btnEditPlaca
            // 
            this.btnEditPlaca.Location = new System.Drawing.Point(140, 12);
            this.btnEditPlaca.Name = "btnEditPlaca";
            this.btnEditPlaca.Size = new System.Drawing.Size(122, 23);
            this.btnEditPlaca.TabIndex = 6;
            this.btnEditPlaca.Text = "Izmijeni izračun";
            this.btnEditPlaca.UseVisualStyleBackColor = true;
            this.btnEditPlaca.Click += new System.EventHandler(this.BtnEditPlaca_Click);
            // 
            // PlacaTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.btnEditPlaca);
            this.Controls.Add(this.btnNewPlaca);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.textBoxFilterPlaca);
            this.Name = "PlacaTableForm";
            this.Text = "Plaće zaposlenika";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterPlaca;
        private System.Windows.Forms.Label namePartnerLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewPlaca;
        private System.Windows.Forms.Button btnEditPlaca;
    }
}
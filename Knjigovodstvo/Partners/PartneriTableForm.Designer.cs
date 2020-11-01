using System.Windows.Forms;

namespace Knjigovodstvo.Partners
{
    partial class PartneriTableForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFilterPartner = new System.Windows.Forms.TextBox();
            this.namePartnerLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new DBDataGridView();
            this.btnNewPartner = new System.Windows.Forms.Button();
            this.btnEditPartner = new System.Windows.Forms.Button();
            this.btnDeletePartner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFilterPartner
            // 
            this.textBoxFilterPartner.Location = new System.Drawing.Point(98, 51);
            this.textBoxFilterPartner.Name = "textBoxFilterPartner";
            this.textBoxFilterPartner.Size = new System.Drawing.Size(147, 23);
            this.textBoxFilterPartner.TabIndex = 1;
            this.textBoxFilterPartner.TextChanged += new System.EventHandler(this.TextBoxFilterPartner_TextChanged);
            // 
            // namePartnerLabel
            // 
            this.namePartnerLabel.AutoSize = true;
            this.namePartnerLabel.Location = new System.Drawing.Point(9, 54);
            this.namePartnerLabel.Name = "namePartnerLabel";
            this.namePartnerLabel.Size = new System.Drawing.Size(83, 15);
            this.namePartnerLabel.TabIndex = 2;
            this.namePartnerLabel.Text = "Naziv Partnera";
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
            this.dataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // btnNewPartner
            // 
            this.btnNewPartner.Location = new System.Drawing.Point(12, 12);
            this.btnNewPartner.Name = "btnNewPartner";
            this.btnNewPartner.Size = new System.Drawing.Size(75, 23);
            this.btnNewPartner.TabIndex = 5;
            this.btnNewPartner.Text = "Novi";
            this.btnNewPartner.UseVisualStyleBackColor = true;
            this.btnNewPartner.Click += new System.EventHandler(this.BtnNewPartner_Click);
            // 
            // btnEditPartner
            // 
            this.btnEditPartner.Location = new System.Drawing.Point(93, 12);
            this.btnEditPartner.Name = "btnEditPartner";
            this.btnEditPartner.Size = new System.Drawing.Size(75, 23);
            this.btnEditPartner.TabIndex = 6;
            this.btnEditPartner.Text = "Izmijeni";
            this.btnEditPartner.UseVisualStyleBackColor = true;
            this.btnEditPartner.Click += new System.EventHandler(this.BtnEditPartner_Click);
            // 
            // btnDeletePartner
            // 
            this.btnDeletePartner.Location = new System.Drawing.Point(174, 12);
            this.btnDeletePartner.Name = "btnDeletePartner";
            this.btnDeletePartner.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePartner.TabIndex = 6;
            this.btnDeletePartner.Text = "Briši";
            this.btnDeletePartner.UseVisualStyleBackColor = true;
            this.btnDeletePartner.Click += new System.EventHandler(this.BtnDeletePartner_Click);
            // 
            // PartneriTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.btnDeletePartner);
            this.Controls.Add(this.btnEditPartner);
            this.Controls.Add(this.btnNewPartner);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.textBoxFilterPartner);
            this.Name = "PartneriTableForm";
            this.Text = "Poslovni Partneri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFilterPartner;
        private System.Windows.Forms.Label namePartnerLabel;
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewPartner;
        private System.Windows.Forms.Button btnEditPartner;
        private System.Windows.Forms.Button btnDeletePartner;
    }
}


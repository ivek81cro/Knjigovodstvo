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
            this.textBoxPartnerFilter = new System.Windows.Forms.TextBox();
            this.labelPartnerName = new System.Windows.Forms.Label();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonNewPartner = new System.Windows.Forms.Button();
            this.buttonEditPartner = new System.Windows.Forms.Button();
            this.buttonDeletePartner = new System.Windows.Forms.Button();
            this.buttonOdaberi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPartnerFilter
            // 
            this.textBoxPartnerFilter.Location = new System.Drawing.Point(98, 51);
            this.textBoxPartnerFilter.Name = "textBoxPartnerFilter";
            this.textBoxPartnerFilter.Size = new System.Drawing.Size(147, 23);
            this.textBoxPartnerFilter.TabIndex = 1;
            this.textBoxPartnerFilter.TextChanged += new System.EventHandler(this.TextBoxFilterPartner_TextChanged);
            // 
            // labelPartnerName
            // 
            this.labelPartnerName.AutoSize = true;
            this.labelPartnerName.Location = new System.Drawing.Point(9, 54);
            this.labelPartnerName.Name = "labelPartnerName";
            this.labelPartnerName.Size = new System.Drawing.Size(83, 15);
            this.labelPartnerName.TabIndex = 2;
            this.labelPartnerName.Text = "Naziv Partnera";
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
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1177, 447);
            this.dbDataGridView1.TabIndex = 4;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // buttonNewPartner
            // 
            this.buttonNewPartner.Location = new System.Drawing.Point(12, 12);
            this.buttonNewPartner.Name = "buttonNewPartner";
            this.buttonNewPartner.Size = new System.Drawing.Size(75, 23);
            this.buttonNewPartner.TabIndex = 5;
            this.buttonNewPartner.Text = "Novi";
            this.buttonNewPartner.UseVisualStyleBackColor = true;
            this.buttonNewPartner.Click += new System.EventHandler(this.ButtonNewPartner_Click);
            // 
            // buttonEditPartner
            // 
            this.buttonEditPartner.Location = new System.Drawing.Point(93, 12);
            this.buttonEditPartner.Name = "buttonEditPartner";
            this.buttonEditPartner.Size = new System.Drawing.Size(75, 23);
            this.buttonEditPartner.TabIndex = 6;
            this.buttonEditPartner.Text = "Izmijeni";
            this.buttonEditPartner.UseVisualStyleBackColor = true;
            this.buttonEditPartner.Click += new System.EventHandler(this.ButtonEditPartner_Click);
            // 
            // buttonDeletePartner
            // 
            this.buttonDeletePartner.Location = new System.Drawing.Point(174, 12);
            this.buttonDeletePartner.Name = "buttonDeletePartner";
            this.buttonDeletePartner.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePartner.TabIndex = 6;
            this.buttonDeletePartner.Text = "Briši";
            this.buttonDeletePartner.UseVisualStyleBackColor = true;
            this.buttonDeletePartner.Click += new System.EventHandler(this.ButtonDeletePartner_Click);
            // 
            // buttonOdaberi
            // 
            this.buttonOdaberi.Location = new System.Drawing.Point(251, 50);
            this.buttonOdaberi.Name = "buttonOdaberi";
            this.buttonOdaberi.Size = new System.Drawing.Size(75, 23);
            this.buttonOdaberi.TabIndex = 7;
            this.buttonOdaberi.Text = "Odaberi";
            this.buttonOdaberi.UseVisualStyleBackColor = true;
            this.buttonOdaberi.Visible = false;
            this.buttonOdaberi.Click += new System.EventHandler(this.ButtonOdaberi_Click);
            // 
            // PartneriTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 543);
            this.Controls.Add(this.buttonOdaberi);
            this.Controls.Add(this.buttonDeletePartner);
            this.Controls.Add(this.buttonEditPartner);
            this.Controls.Add(this.buttonNewPartner);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.labelPartnerName);
            this.Controls.Add(this.textBoxPartnerFilter);
            this.Name = "PartneriTableForm";
            this.Text = "Poslovni Partneri";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPartnerFilter;
        private System.Windows.Forms.Label labelPartnerName;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonNewPartner;
        private System.Windows.Forms.Button buttonEditPartner;
        private System.Windows.Forms.Button buttonDeletePartner;
        private Button buttonOdaberi;
    }
}


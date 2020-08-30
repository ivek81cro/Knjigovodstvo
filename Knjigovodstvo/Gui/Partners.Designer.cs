namespace Knjigovodstvo
{
    partial class partnersForm
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
            this.namePartnerTextBox = new System.Windows.Forms.TextBox();
            this.namePartnerLabel = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNewPartner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // namePartnerTextBox
            // 
            this.namePartnerTextBox.Location = new System.Drawing.Point(98, 51);
            this.namePartnerTextBox.Name = "namePartnerTextBox";
            this.namePartnerTextBox.Size = new System.Drawing.Size(147, 23);
            this.namePartnerTextBox.TabIndex = 1;
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(251, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Traži";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1011, 354);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // btnNewPartner
            // 
            this.btnNewPartner.Location = new System.Drawing.Point(945, 51);
            this.btnNewPartner.Name = "btnNewPartner";
            this.btnNewPartner.Size = new System.Drawing.Size(75, 23);
            this.btnNewPartner.TabIndex = 5;
            this.btnNewPartner.Text = "Novi";
            this.btnNewPartner.UseVisualStyleBackColor = true;
            this.btnNewPartner.Click += new System.EventHandler(this.BtnNewPartner_Click);
            // 
            // partnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 450);
            this.Controls.Add(this.btnNewPartner);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.namePartnerLabel);
            this.Controls.Add(this.namePartnerTextBox);
            this.Name = "partnersForm";
            this.Text = "Poslovni Partneri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox namePartnerTextBox;
        private System.Windows.Forms.Label namePartnerLabel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewPartner;
    }
}


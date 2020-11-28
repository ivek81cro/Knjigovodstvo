
namespace Knjigovodstvo.BankStatements
{
    partial class IzvodiPregledForm
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
            this.dataGridViewStavke = new System.Windows.Forms.DataGridView();
            this.buttonUcitajIzvod = new System.Windows.Forms.Button();
            this.dataGridViewIzvodi = new System.Windows.Forms.DataGridView();
            this.buttonOpenIzvod = new System.Windows.Forms.Button();
            this.buttonDeleteIzvod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStavke
            // 
            this.dataGridViewStavke.AllowUserToAddRows = false;
            this.dataGridViewStavke.AllowUserToDeleteRows = false;
            this.dataGridViewStavke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewStavke.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStavke.Location = new System.Drawing.Point(12, 139);
            this.dataGridViewStavke.Name = "dataGridViewStavke";
            this.dataGridViewStavke.ReadOnly = true;
            this.dataGridViewStavke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStavke.Size = new System.Drawing.Size(859, 482);
            this.dataGridViewStavke.TabIndex = 10;
            this.dataGridViewStavke.Text = "dataGridView1";
            // 
            // buttonUcitajIzvod
            // 
            this.buttonUcitajIzvod.Location = new System.Drawing.Point(13, 13);
            this.buttonUcitajIzvod.Name = "buttonUcitajIzvod";
            this.buttonUcitajIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitajIzvod.TabIndex = 11;
            this.buttonUcitajIzvod.Text = "Novi";
            this.buttonUcitajIzvod.UseVisualStyleBackColor = true;
            this.buttonUcitajIzvod.Click += new System.EventHandler(this.ButtonUcitajIzvod_Click);
            // 
            // dataGridViewIzvodi
            // 
            this.dataGridViewIzvodi.AllowUserToAddRows = false;
            this.dataGridViewIzvodi.AllowUserToDeleteRows = false;
            this.dataGridViewIzvodi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewIzvodi.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewIzvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIzvodi.Location = new System.Drawing.Point(877, 139);
            this.dataGridViewIzvodi.Name = "dataGridViewIzvodi";
            this.dataGridViewIzvodi.ReadOnly = true;
            this.dataGridViewIzvodi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIzvodi.Size = new System.Drawing.Size(255, 482);
            this.dataGridViewIzvodi.TabIndex = 12;
            this.dataGridViewIzvodi.Text = "dataGridView2";
            this.dataGridViewIzvodi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewIzvodi_CellMouseDoubleClick);
            // 
            // buttonOpenIzvod
            // 
            this.buttonOpenIzvod.Location = new System.Drawing.Point(877, 110);
            this.buttonOpenIzvod.Name = "buttonOpenIzvod";
            this.buttonOpenIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenIzvod.TabIndex = 13;
            this.buttonOpenIzvod.Text = "Otvori";
            this.buttonOpenIzvod.UseVisualStyleBackColor = true;
            this.buttonOpenIzvod.Click += new System.EventHandler(this.ButtonOpenIzvod_Click);
            // 
            // buttonDeleteIzvod
            // 
            this.buttonDeleteIzvod.Location = new System.Drawing.Point(958, 110);
            this.buttonDeleteIzvod.Name = "buttonDeleteIzvod";
            this.buttonDeleteIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteIzvod.TabIndex = 14;
            this.buttonDeleteIzvod.Text = "Briši";
            this.buttonDeleteIzvod.UseVisualStyleBackColor = true;
            this.buttonDeleteIzvod.Click += new System.EventHandler(this.ButtonDeleteIzvod_Click);
            // 
            // IzvodiPregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 633);
            this.Controls.Add(this.buttonDeleteIzvod);
            this.Controls.Add(this.buttonOpenIzvod);
            this.Controls.Add(this.dataGridViewIzvodi);
            this.Controls.Add(this.buttonUcitajIzvod);
            this.Controls.Add(this.dataGridViewStavke);
            this.Name = "IzvodiPregledForm";
            this.Text = "IzvodiPregledForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStavke;
        private System.Windows.Forms.Button buttonUcitajIzvod;
        private System.Windows.Forms.DataGridView dataGridViewIzvodi;
        private System.Windows.Forms.Button buttonOpenIzvod;
        private System.Windows.Forms.Button buttonDeleteIzvod;
    }
}
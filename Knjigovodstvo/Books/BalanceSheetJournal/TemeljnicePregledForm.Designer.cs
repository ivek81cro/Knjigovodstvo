
using System.Drawing;

namespace Knjigovodstvo.Books.BalanceSheetJournal
{
    partial class TemeljnicePregledForm
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
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.comboBoxVrstaTemeljnice = new System.Windows.Forms.ComboBox();
            this.labelVrsta = new System.Windows.Forms.Label();
            this.labelDuguje = new System.Windows.Forms.Label();
            this.labelPotrazuje = new System.Windows.Forms.Label();
            this.buttonDodajRed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(13, 182);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.Size = new System.Drawing.Size(1186, 395);
            this.dbDataGridView1.TabIndex = 0;
            this.dbDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbDataGridView1_CellDoubleClick);
            // 
            // comboBoxVrstaTemeljnice
            // 
            this.comboBoxVrstaTemeljnice.FormattingEnabled = true;
            this.comboBoxVrstaTemeljnice.Location = new System.Drawing.Point(13, 153);
            this.comboBoxVrstaTemeljnice.Name = "comboBoxVrstaTemeljnice";
            this.comboBoxVrstaTemeljnice.Size = new System.Drawing.Size(159, 23);
            this.comboBoxVrstaTemeljnice.TabIndex = 1;
            this.comboBoxVrstaTemeljnice.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxVrstaTemeljnice_SelectionChangeCommitted);
            // 
            // labelVrsta
            // 
            this.labelVrsta.AutoSize = true;
            this.labelVrsta.Location = new System.Drawing.Point(13, 135);
            this.labelVrsta.Name = "labelVrsta";
            this.labelVrsta.Size = new System.Drawing.Size(136, 15);
            this.labelVrsta.TabIndex = 2;
            this.labelVrsta.Text = "Odaberi vrstu temeljnice";
            // 
            // labelDuguje
            // 
            this.labelDuguje.AutoSize = true;
            this.labelDuguje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDuguje.ForeColor = System.Drawing.Color.Green;
            this.labelDuguje.Location = new System.Drawing.Point(322, 583);
            this.labelDuguje.Name = "labelDuguje";
            this.labelDuguje.Size = new System.Drawing.Size(52, 17);
            this.labelDuguje.TabIndex = 3;
            this.labelDuguje.Text = "Duguje:";
            // 
            // labelPotrazuje
            // 
            this.labelPotrazuje.AutoSize = true;
            this.labelPotrazuje.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPotrazuje.ForeColor = System.Drawing.Color.Green;
            this.labelPotrazuje.Location = new System.Drawing.Point(540, 583);
            this.labelPotrazuje.Name = "labelPotrazuje";
            this.labelPotrazuje.Size = new System.Drawing.Size(65, 17);
            this.labelPotrazuje.TabIndex = 4;
            this.labelPotrazuje.Text = "Potražuje:";
            // 
            // buttonDodajRed
            // 
            this.buttonDodajRed.Location = new System.Drawing.Point(13, 584);
            this.buttonDodajRed.Name = "buttonDodajRed";
            this.buttonDodajRed.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajRed.TabIndex = 5;
            this.buttonDodajRed.Text = "Dodaj red";
            this.buttonDodajRed.UseVisualStyleBackColor = true;
            this.buttonDodajRed.Click += new System.EventHandler(this.ButtonDodajRed_Click);
            // 
            // TemeljnicePregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 631);
            this.Controls.Add(this.buttonDodajRed);
            this.Controls.Add(this.labelPotrazuje);
            this.Controls.Add(this.labelDuguje);
            this.Controls.Add(this.labelVrsta);
            this.Controls.Add(this.comboBoxVrstaTemeljnice);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "TemeljnicePregledForm";
            this.Text = "Pregled temeljnica";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.ComboBox comboBoxVrstaTemeljnice;
        private System.Windows.Forms.Label labelVrsta;
        private System.Windows.Forms.Label labelDuguje;
        private System.Windows.Forms.Label labelPotrazuje;
        private System.Windows.Forms.Button buttonDodajRed;
    }
}
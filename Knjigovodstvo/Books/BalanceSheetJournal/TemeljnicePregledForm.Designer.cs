﻿
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
            this.dateTimePickerDatumKnjizenja = new System.Windows.Forms.DateTimePicker();
            this.labelDatumKnjizenja = new System.Windows.Forms.Label();
            this.buttonKnjiziTemeljnicu = new System.Windows.Forms.Button();
            this.buttonBrisiRed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dbDataGridView1.Location = new System.Drawing.Point(13, 182);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1186, 395);
            this.dbDataGridView1.TabIndex = 0;
            this.dbDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbDataGridView1_CellDoubleClick);
            this.dbDataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TemeljnicePregledForm_KeyDown);
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
            this.labelDuguje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.labelPotrazuje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.buttonDodajRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDodajRed.Location = new System.Drawing.Point(13, 584);
            this.buttonDodajRed.Name = "buttonDodajRed";
            this.buttonDodajRed.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajRed.TabIndex = 5;
            this.buttonDodajRed.Text = "Dodaj red";
            this.buttonDodajRed.UseVisualStyleBackColor = true;
            this.buttonDodajRed.Click += new System.EventHandler(this.ButtonDodajRed_Click);
            // 
            // dateTimePickerDatumKnjizenja
            // 
            this.dateTimePickerDatumKnjizenja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumKnjizenja.Location = new System.Drawing.Point(169, 12);
            this.dateTimePickerDatumKnjizenja.Name = "dateTimePickerDatumKnjizenja";
            this.dateTimePickerDatumKnjizenja.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDatumKnjizenja.TabIndex = 6;
            // 
            // labelDatumKnjizenja
            // 
            this.labelDatumKnjizenja.AutoSize = true;
            this.labelDatumKnjizenja.Location = new System.Drawing.Point(13, 18);
            this.labelDatumKnjizenja.Name = "labelDatumKnjizenja";
            this.labelDatumKnjizenja.Size = new System.Drawing.Size(150, 15);
            this.labelDatumKnjizenja.TabIndex = 7;
            this.labelDatumKnjizenja.Text = "Datum knjiženja temeljnice";
            // 
            // buttonKnjiziTemeljnicu
            // 
            this.buttonKnjiziTemeljnicu.Location = new System.Drawing.Point(13, 50);
            this.buttonKnjiziTemeljnicu.Name = "buttonKnjiziTemeljnicu";
            this.buttonKnjiziTemeljnicu.Size = new System.Drawing.Size(110, 23);
            this.buttonKnjiziTemeljnicu.TabIndex = 8;
            this.buttonKnjiziTemeljnicu.Text = "Knjiži temeljnicu";
            this.buttonKnjiziTemeljnicu.UseVisualStyleBackColor = true;
            // 
            // buttonBrisiRed
            // 
            this.buttonBrisiRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBrisiRed.Location = new System.Drawing.Point(97, 584);
            this.buttonBrisiRed.Name = "buttonBrisiRed";
            this.buttonBrisiRed.Size = new System.Drawing.Size(75, 23);
            this.buttonBrisiRed.TabIndex = 9;
            this.buttonBrisiRed.Text = "Briši red";
            this.buttonBrisiRed.UseVisualStyleBackColor = true;
            this.buttonBrisiRed.Click += new System.EventHandler(this.ButtonBrisiRed_Click);
            // 
            // TemeljnicePregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 631);
            this.Controls.Add(this.buttonBrisiRed);
            this.Controls.Add(this.buttonKnjiziTemeljnicu);
            this.Controls.Add(this.labelDatumKnjizenja);
            this.Controls.Add(this.dateTimePickerDatumKnjizenja);
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

        private void CustomiseDataGridView()
        {
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns.RemoveAt(0);
            dbDataGridView1.Columns.RemoveAt(dbDataGridView1.Columns.Count - 1);
            dbDataGridView1.Columns[0].ReadOnly = true;
        }

        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.ComboBox comboBoxVrstaTemeljnice;
        private System.Windows.Forms.Label labelVrsta;
        private System.Windows.Forms.Label labelDuguje;
        private System.Windows.Forms.Label labelPotrazuje;
        private System.Windows.Forms.Button buttonDodajRed;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumKnjizenja;
        private System.Windows.Forms.Label labelDatumKnjizenja;
        private System.Windows.Forms.Button buttonKnjiziTemeljnicu;
        private System.Windows.Forms.Button buttonBrisiRed;
    }
}
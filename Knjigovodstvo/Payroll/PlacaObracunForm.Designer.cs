﻿namespace Knjigovodstvo.Payroll
{
    partial class PlacaObracunForm
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
            this.labelRazdoblje = new System.Windows.Forms.Label();
            this.dateTimePickerDatumOd = new System.Windows.Forms.DateTimePicker();
            this.labelDatumOd = new System.Windows.Forms.Label();
            this.dateTimePickerDatumDo = new System.Windows.Forms.DateTimePicker();
            this.labelDatumDo = new System.Windows.Forms.Label();
            this.buttonObracunajSve = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRazdoblje
            // 
            this.labelRazdoblje.AutoSize = true;
            this.labelRazdoblje.Location = new System.Drawing.Point(12, 23);
            this.labelRazdoblje.Name = "labelRazdoblje";
            this.labelRazdoblje.Size = new System.Drawing.Size(152, 15);
            this.labelRazdoblje.TabIndex = 0;
            this.labelRazdoblje.Text = "Razdoblje na koje se odnosi";
            // 
            // dateTimePickerDatumOd
            // 
            this.dateTimePickerDatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumOd.Location = new System.Drawing.Point(35, 41);
            this.dateTimePickerDatumOd.Name = "dateTimePickerDatumOd";
            this.dateTimePickerDatumOd.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumOd.TabIndex = 1;
            // 
            // labelDatumOd
            // 
            this.labelDatumOd.AutoSize = true;
            this.labelDatumOd.Location = new System.Drawing.Point(12, 45);
            this.labelDatumOd.Name = "labelDatumOd";
            this.labelDatumOd.Size = new System.Drawing.Size(23, 15);
            this.labelDatumOd.TabIndex = 2;
            this.labelDatumOd.Text = "Od";
            // 
            // dateTimePickerDatumDo
            // 
            this.dateTimePickerDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumDo.Location = new System.Drawing.Point(161, 41);
            this.dateTimePickerDatumDo.Name = "dateTimePickerDatumDo";
            this.dateTimePickerDatumDo.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumDo.TabIndex = 1;
            // 
            // labelDatumDo
            // 
            this.labelDatumDo.AutoSize = true;
            this.labelDatumDo.Location = new System.Drawing.Point(137, 45);
            this.labelDatumDo.Name = "labelDatumDo";
            this.labelDatumDo.Size = new System.Drawing.Size(22, 15);
            this.labelDatumDo.TabIndex = 2;
            this.labelDatumDo.Text = "Do";
            // 
            // buttonObracunajSve
            // 
            this.buttonObracunajSve.Location = new System.Drawing.Point(263, 41);
            this.buttonObracunajSve.Name = "buttonObracunajSve";
            this.buttonObracunajSve.Size = new System.Drawing.Size(99, 23);
            this.buttonObracunajSve.TabIndex = 3;
            this.buttonObracunajSve.Text = "Obračunaj Sve";
            this.buttonObracunajSve.UseVisualStyleBackColor = true;
            this.buttonObracunajSve.Click += new System.EventHandler(this.buttonObracunajSve_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 361);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // PlacaObracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 560);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonObracunajSve);
            this.Controls.Add(this.labelDatumDo);
            this.Controls.Add(this.dateTimePickerDatumDo);
            this.Controls.Add(this.labelDatumOd);
            this.Controls.Add(this.dateTimePickerDatumOd);
            this.Controls.Add(this.labelRazdoblje);
            this.Name = "PlacaObracunForm";
            this.Text = "Obračun plaće";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRazdoblje;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumOd;
        private System.Windows.Forms.Label labelDatumOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumDo;
        private System.Windows.Forms.Label labelDatumDo;
        private System.Windows.Forms.Button buttonObracunajSve;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
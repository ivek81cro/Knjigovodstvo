
using System;

namespace Knjigovodstvo.PoreznaUra
{
    partial class PoreznaUraForm
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
            this.dateTimePickerOd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDo = new System.Windows.Forms.DateTimePicker();
            this.groupBoxRazdoblje = new System.Windows.Forms.GroupBox();
            this.labelRazdobljeDo = new System.Windows.Forms.Label();
            this.labelRazdobljeOd = new System.Windows.Forms.Label();
            this.buttonPripremi = new System.Windows.Forms.Button();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonKreirajXml = new System.Windows.Forms.Button();
            this.groupBoxAutor = new System.Windows.Forms.GroupBox();
            this.textBoxAutorIme = new System.Windows.Forms.TextBox();
            this.textBoxAutorPrezime = new System.Windows.Forms.TextBox();
            this.labelAutorIme = new System.Windows.Forms.Label();
            this.labelAutorPrezime = new System.Windows.Forms.Label();
            this.groupBoxRazdoblje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.groupBoxAutor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerOd
            // 
            this.dateTimePickerOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOd.Location = new System.Drawing.Point(34, 22);
            this.dateTimePickerOd.Name = "dateTimePickerOd";
            this.dateTimePickerOd.Size = new System.Drawing.Size(88, 23);
            this.dateTimePickerOd.TabIndex = 0;
            this.dateTimePickerOd.Value = new System.DateTime(2020, 12, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerDo
            // 
            this.dateTimePickerDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDo.Location = new System.Drawing.Point(34, 52);
            this.dateTimePickerDo.Name = "dateTimePickerDo";
            this.dateTimePickerDo.Size = new System.Drawing.Size(88, 23);
            this.dateTimePickerDo.TabIndex = 1;
            this.dateTimePickerDo.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            // 
            // groupBoxRazdoblje
            // 
            this.groupBoxRazdoblje.Controls.Add(this.labelRazdobljeDo);
            this.groupBoxRazdoblje.Controls.Add(this.labelRazdobljeOd);
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerDo);
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerOd);
            this.groupBoxRazdoblje.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRazdoblje.Name = "groupBoxRazdoblje";
            this.groupBoxRazdoblje.Size = new System.Drawing.Size(200, 93);
            this.groupBoxRazdoblje.TabIndex = 2;
            this.groupBoxRazdoblje.TabStop = false;
            this.groupBoxRazdoblje.Text = "Razdoblje";
            // 
            // labelRazdobljeDo
            // 
            this.labelRazdobljeDo.AutoSize = true;
            this.labelRazdobljeDo.Location = new System.Drawing.Point(6, 58);
            this.labelRazdobljeDo.Name = "labelRazdobljeDo";
            this.labelRazdobljeDo.Size = new System.Drawing.Size(22, 15);
            this.labelRazdobljeDo.TabIndex = 3;
            this.labelRazdobljeDo.Text = "Do";
            // 
            // labelRazdobljeOd
            // 
            this.labelRazdobljeOd.AutoSize = true;
            this.labelRazdobljeOd.Location = new System.Drawing.Point(5, 28);
            this.labelRazdobljeOd.Name = "labelRazdobljeOd";
            this.labelRazdobljeOd.Size = new System.Drawing.Size(23, 15);
            this.labelRazdobljeOd.TabIndex = 2;
            this.labelRazdobljeOd.Text = "Od";
            // 
            // buttonPripremi
            // 
            this.buttonPripremi.Location = new System.Drawing.Point(425, 26);
            this.buttonPripremi.Name = "buttonPripremi";
            this.buttonPripremi.Size = new System.Drawing.Size(75, 23);
            this.buttonPripremi.TabIndex = 3;
            this.buttonPripremi.Text = "Učitaj";
            this.buttonPripremi.UseVisualStyleBackColor = true;
            this.buttonPripremi.Click += new System.EventHandler(this.ButtonPripremi_Click);
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
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 158);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.RowTemplate.Height = 25;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1036, 471);
            this.dbDataGridView1.TabIndex = 4;
            // 
            // buttonKreirajXml
            // 
            this.buttonKreirajXml.Location = new System.Drawing.Point(426, 56);
            this.buttonKreirajXml.Name = "buttonKreirajXml";
            this.buttonKreirajXml.Size = new System.Drawing.Size(75, 23);
            this.buttonKreirajXml.TabIndex = 5;
            this.buttonKreirajXml.Text = "Kreiraj XML";
            this.buttonKreirajXml.UseVisualStyleBackColor = true;
            this.buttonKreirajXml.Click += new System.EventHandler(this.ButtonKreirajXml_Click);
            // 
            // groupBoxAutor
            // 
            this.groupBoxAutor.Controls.Add(this.labelAutorPrezime);
            this.groupBoxAutor.Controls.Add(this.labelAutorIme);
            this.groupBoxAutor.Controls.Add(this.textBoxAutorPrezime);
            this.groupBoxAutor.Controls.Add(this.textBoxAutorIme);
            this.groupBoxAutor.Location = new System.Drawing.Point(220, 12);
            this.groupBoxAutor.Name = "groupBoxAutor";
            this.groupBoxAutor.Size = new System.Drawing.Size(200, 93);
            this.groupBoxAutor.TabIndex = 6;
            this.groupBoxAutor.TabStop = false;
            this.groupBoxAutor.Text = "Autor";
            // 
            // textBoxAutorIme
            // 
            this.textBoxAutorIme.Location = new System.Drawing.Point(54, 20);
            this.textBoxAutorIme.Name = "textBoxAutorIme";
            this.textBoxAutorIme.Size = new System.Drawing.Size(140, 23);
            this.textBoxAutorIme.TabIndex = 0;
            // 
            // textBoxAutorPrezime
            // 
            this.textBoxAutorPrezime.Location = new System.Drawing.Point(54, 49);
            this.textBoxAutorPrezime.Name = "textBoxAutorPrezime";
            this.textBoxAutorPrezime.Size = new System.Drawing.Size(140, 23);
            this.textBoxAutorPrezime.TabIndex = 1;
            // 
            // labelAutorIme
            // 
            this.labelAutorIme.AutoSize = true;
            this.labelAutorIme.Location = new System.Drawing.Point(5, 23);
            this.labelAutorIme.Name = "labelAutorIme";
            this.labelAutorIme.Size = new System.Drawing.Size(27, 15);
            this.labelAutorIme.TabIndex = 2;
            this.labelAutorIme.Text = "Ime";
            // 
            // labelAutorPrezime
            // 
            this.labelAutorPrezime.AutoSize = true;
            this.labelAutorPrezime.Location = new System.Drawing.Point(5, 52);
            this.labelAutorPrezime.Name = "labelAutorPrezime";
            this.labelAutorPrezime.Size = new System.Drawing.Size(49, 15);
            this.labelAutorPrezime.TabIndex = 3;
            this.labelAutorPrezime.Text = "Prezime";
            // 
            // PoreznaUraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 641);
            this.Controls.Add(this.groupBoxAutor);
            this.Controls.Add(this.buttonKreirajXml);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.buttonPripremi);
            this.Controls.Add(this.groupBoxRazdoblje);
            this.Name = "PoreznaUraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PoreznaUraForm";
            this.groupBoxRazdoblje.ResumeLayout(false);
            this.groupBoxRazdoblje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.groupBoxAutor.ResumeLayout(false);
            this.groupBoxAutor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDo;
        private System.Windows.Forms.GroupBox groupBoxRazdoblje;
        private System.Windows.Forms.Label labelRazdobljeDo;
        private System.Windows.Forms.Label labelRazdobljeOd;
        private System.Windows.Forms.Button buttonPripremi;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonKreirajXml;
        private System.Windows.Forms.GroupBox groupBoxAutor;
        private System.Windows.Forms.Label labelAutorPrezime;
        private System.Windows.Forms.Label labelAutorIme;
        private System.Windows.Forms.TextBox textBoxAutorPrezime;
        private System.Windows.Forms.TextBox textBoxAutorIme;
    }
}
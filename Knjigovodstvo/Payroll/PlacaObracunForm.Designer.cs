using System.Drawing;
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
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
            this.dateTimePickerDatumOd = new System.Windows.Forms.DateTimePicker();
            this.labelDatumOd = new System.Windows.Forms.Label();
            this.dateTimePickerDatumDo = new System.Windows.Forms.DateTimePicker();
            this.labelDatumDo = new System.Windows.Forms.Label();
            this.buttonObracunajSve = new System.Windows.Forms.Button();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.comboBoxFilterDjelatnik = new System.Windows.Forms.ComboBox();
            this.labelFilterDjelatnik = new System.Windows.Forms.Label();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.comboBoxFilterPoMjesecu = new System.Windows.Forms.ComboBox();
            this.labelFilterMjesec = new System.Windows.Forms.Label();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.dateTimePickerDatumObracuna = new System.Windows.Forms.DateTimePicker();
            this.labelDatumObracuna = new System.Windows.Forms.Label();
            this.groupBoxRazdoblje = new System.Windows.Forms.GroupBox();
            this.buttonSpremiArhiva = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxRazdoblje.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerDatumOd
            // 
            this.dateTimePickerDatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumOd.Location = new System.Drawing.Point(32, 22);
            this.dateTimePickerDatumOd.Name = "dateTimePickerDatumOd";
            this.dateTimePickerDatumOd.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumOd.TabIndex = 1;
            // 
            // labelDatumOd
            // 
            this.labelDatumOd.AutoSize = true;
            this.labelDatumOd.Location = new System.Drawing.Point(9, 26);
            this.labelDatumOd.Name = "labelDatumOd";
            this.labelDatumOd.Size = new System.Drawing.Size(23, 15);
            this.labelDatumOd.TabIndex = 2;
            this.labelDatumOd.Text = "Od";
            // 
            // dateTimePickerDatumDo
            // 
            this.dateTimePickerDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumDo.Location = new System.Drawing.Point(32, 51);
            this.dateTimePickerDatumDo.Name = "dateTimePickerDatumDo";
            this.dateTimePickerDatumDo.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumDo.TabIndex = 1;
            // 
            // labelDatumDo
            // 
            this.labelDatumDo.AutoSize = true;
            this.labelDatumDo.Location = new System.Drawing.Point(8, 55);
            this.labelDatumDo.Name = "labelDatumDo";
            this.labelDatumDo.Size = new System.Drawing.Size(22, 15);
            this.labelDatumDo.TabIndex = 2;
            this.labelDatumDo.Text = "Do";
            // 
            // buttonObracunajSve
            // 
            this.buttonObracunajSve.Location = new System.Drawing.Point(165, 70);
            this.buttonObracunajSve.Name = "buttonObracunajSve";
            this.buttonObracunajSve.Size = new System.Drawing.Size(103, 23);
            this.buttonObracunajSve.TabIndex = 3;
            this.buttonObracunajSve.Text = "Obračunaj Plaće";
            this.buttonObracunajSve.UseVisualStyleBackColor = true;
            this.buttonObracunajSve.Click += new System.EventHandler(this.ButtonObracunajPlacu_Click);
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
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 187);
            this.dbDataGridView1.Name = "dataGridView1";
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1017, 361);
            this.dbDataGridView1.TabIndex = 4;
            this.dbDataGridView1.RowHeadersVisible = false;
            this.dbDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aquamarine;
            this.dbDataGridView1.EnableHeadersVisualStyles = false;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // comboBoxFilterDjelatnik
            // 
            this.comboBoxFilterDjelatnik.FormattingEnabled = true;
            this.comboBoxFilterDjelatnik.Location = new System.Drawing.Point(123, 154);
            this.comboBoxFilterDjelatnik.Name = "comboBoxFilterDjelatnik";
            this.comboBoxFilterDjelatnik.Size = new System.Drawing.Size(239, 23);
            this.comboBoxFilterDjelatnik.TabIndex = 5;
            this.comboBoxFilterDjelatnik.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxFilter_SelectionChangeCommitted);
            // 
            // labelFilterDjelatnik
            // 
            this.labelFilterDjelatnik.AutoSize = true;
            this.labelFilterDjelatnik.Location = new System.Drawing.Point(12, 157);
            this.labelFilterDjelatnik.Name = "labelFilterDjelatnik";
            this.labelFilterDjelatnik.Size = new System.Drawing.Size(105, 15);
            this.labelFilterDjelatnik.TabIndex = 6;
            this.labelFilterDjelatnik.Text = "Filter po djelatniku";
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Location = new System.Drawing.Point(603, 154);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(97, 23);
            this.buttonPonisti.TabIndex = 7;
            this.buttonPonisti.Text = "Poništi Filtere";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.ButtonPonisti_Click);
            // 
            // comboBoxFilterPoMjesecu
            // 
            this.comboBoxFilterPoMjesecu.FormattingEnabled = true;
            this.comboBoxFilterPoMjesecu.Location = new System.Drawing.Point(472, 154);
            this.comboBoxFilterPoMjesecu.Name = "comboBoxFilterPoMjesecu";
            this.comboBoxFilterPoMjesecu.Size = new System.Drawing.Size(125, 23);
            this.comboBoxFilterPoMjesecu.TabIndex = 8;
            this.comboBoxFilterPoMjesecu.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxFilter_SelectionChangeCommitted);
            // 
            // labelFilterMjesec
            // 
            this.labelFilterMjesec.AutoSize = true;
            this.labelFilterMjesec.Location = new System.Drawing.Point(369, 157);
            this.labelFilterMjesec.Name = "labelFilterMjesec";
            this.labelFilterMjesec.Size = new System.Drawing.Size(97, 15);
            this.labelFilterMjesec.TabIndex = 9;
            this.labelFilterMjesec.Text = "Filter po mjesecu";
            // 
            // menuPostavke
            // 
            this.menuPostavke.Name = "menuPostavke";
            this.menuPostavke.Size = new System.Drawing.Size(115, 20);
            this.menuPostavke.Text = "Postavke knjiženja";
            this.menuPostavke.Click += new System.EventHandler(this.ButtonOpenPostavkeForm);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPostavke});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Enabled = false;
            this.buttonKnjizi.Location = new System.Drawing.Point(165, 103);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(124, 23);
            this.buttonKnjizi.TabIndex = 14;
            this.buttonKnjizi.Text = "Knjiži na temeljnicu";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // dateTimePickerDatumObracuna
            // 
            this.dateTimePickerDatumObracuna.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumObracuna.Location = new System.Drawing.Point(275, 36);
            this.dateTimePickerDatumObracuna.Name = "dateTimePickerDatumObracuna";
            this.dateTimePickerDatumObracuna.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumObracuna.TabIndex = 15;
            // 
            // labelDatumObracuna
            // 
            this.labelDatumObracuna.AutoSize = true;
            this.labelDatumObracuna.Location = new System.Drawing.Point(165, 42);
            this.labelDatumObracuna.Name = "labelDatumObracuna";
            this.labelDatumObracuna.Size = new System.Drawing.Size(96, 15);
            this.labelDatumObracuna.TabIndex = 16;
            this.labelDatumObracuna.Text = "Datum obračuna";
            // 
            // groupBoxRazdoblje
            // 
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerDatumOd);
            this.groupBoxRazdoblje.Controls.Add(this.labelDatumOd);
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerDatumDo);
            this.groupBoxRazdoblje.Controls.Add(this.labelDatumDo);
            this.groupBoxRazdoblje.Location = new System.Drawing.Point(13, 34);
            this.groupBoxRazdoblje.Name = "groupBoxRazdoblje";
            this.groupBoxRazdoblje.Size = new System.Drawing.Size(146, 92);
            this.groupBoxRazdoblje.TabIndex = 17;
            this.groupBoxRazdoblje.TabStop = false;
            this.groupBoxRazdoblje.Text = "Razdoblje obračuna";
            // 
            // buttonSpremiArhiva
            // 
            this.buttonSpremiArhiva.Enabled = false;
            this.buttonSpremiArhiva.Location = new System.Drawing.Point(274, 70);
            this.buttonSpremiArhiva.Name = "buttonSpremiArhiva";
            this.buttonSpremiArhiva.Size = new System.Drawing.Size(101, 23);
            this.buttonSpremiArhiva.TabIndex = 18;
            this.buttonSpremiArhiva.Text = "Spremi u arhivu";
            this.buttonSpremiArhiva.UseVisualStyleBackColor = true;
            this.buttonSpremiArhiva.Click += new System.EventHandler(this.ButtonSpremiArhiva_Click);
            // 
            // PlacaObracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 560);
            this.Controls.Add(this.buttonSpremiArhiva);
            this.Controls.Add(this.groupBoxRazdoblje);
            this.Controls.Add(this.labelDatumObracuna);
            this.Controls.Add(this.dateTimePickerDatumObracuna);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.labelFilterMjesec);
            this.Controls.Add(this.comboBoxFilterPoMjesecu);
            this.Controls.Add(this.buttonPonisti);
            this.Controls.Add(this.labelFilterDjelatnik);
            this.Controls.Add(this.comboBoxFilterDjelatnik);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.buttonObracunajSve);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlacaObracunForm";
            this.Text = "Obračun plaće";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxRazdoblje.ResumeLayout(false);
            this.groupBoxRazdoblje.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumOd;
        private System.Windows.Forms.Label labelDatumOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumDo;
        private System.Windows.Forms.Label labelDatumDo;
        private System.Windows.Forms.Button buttonObracunajSve;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.ComboBox comboBoxFilterDjelatnik;
        private System.Windows.Forms.Label labelFilterDjelatnik;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.ComboBox comboBoxFilterPoMjesecu;
        private System.Windows.Forms.Label labelFilterMjesec;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private Button buttonKnjizi;
        private DateTimePicker dateTimePickerDatumObracuna;
        private Label labelDatumObracuna;
        private GroupBox groupBoxRazdoblje;
        private Button buttonSpremiArhiva;
    }
}
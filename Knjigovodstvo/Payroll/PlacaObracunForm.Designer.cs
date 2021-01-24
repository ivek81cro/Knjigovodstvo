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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePickerDatumOd = new System.Windows.Forms.DateTimePicker();
            this.labelDatumOd = new System.Windows.Forms.Label();
            this.dateTimePickerDatumDo = new System.Windows.Forms.DateTimePicker();
            this.labelDatumDo = new System.Windows.Forms.Label();
            this.buttonObracunajSve = new System.Windows.Forms.Button();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.dateTimePickerDatumObracuna = new System.Windows.Forms.DateTimePicker();
            this.labelDatumObracuna = new System.Windows.Forms.Label();
            this.groupBoxRazdoblje = new System.Windows.Forms.GroupBox();
            this.buttonSpremiArhiva = new System.Windows.Forms.Button();
            this.buttonBrisiOdabrane = new System.Windows.Forms.Button();
            this.textBoxFilterIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFilteri = new System.Windows.Forms.GroupBox();
            this.buttonFiltrirajDatum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDatumObracunaFilter = new System.Windows.Forms.ComboBox();
            this.buttonDohvatArhiva = new System.Windows.Forms.Button();
            this.groupBoxArhiva = new System.Windows.Forms.GroupBox();
            this.buttonPocetniPrikaz = new System.Windows.Forms.Button();
            this.groupBoxObračun = new System.Windows.Forms.GroupBox();
            this.groupBoxOdaberiSve = new System.Windows.Forms.GroupBox();
            this.checkBoxOdaberiSve = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxRazdoblje.SuspendLayout();
            this.groupBoxFilteri.SuspendLayout();
            this.groupBoxArhiva.SuspendLayout();
            this.groupBoxObračun.SuspendLayout();
            this.groupBoxOdaberiSve.SuspendLayout();
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
            this.buttonObracunajSve.Location = new System.Drawing.Point(7, 51);
            this.buttonObracunajSve.Name = "buttonObracunajSve";
            this.buttonObracunajSve.Size = new System.Drawing.Size(124, 23);
            this.buttonObracunajSve.TabIndex = 3;
            this.buttonObracunajSve.Text = "Obračunaj Plaće";
            this.buttonObracunajSve.UseVisualStyleBackColor = true;
            this.buttonObracunajSve.Click += new System.EventHandler(this.ButtonObracunajPlacu_Click);
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dbDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.EnableHeadersVisualStyles = false;
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 203);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowHeadersVisible = false;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1017, 345);
            this.dbDataGridView1.TabIndex = 4;
            this.dbDataGridView1.Text = "dataGridView1";
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
            this.buttonKnjizi.Location = new System.Drawing.Point(137, 51);
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
            this.dateTimePickerDatumObracuna.Location = new System.Drawing.Point(109, 22);
            this.dateTimePickerDatumObracuna.Name = "dateTimePickerDatumObracuna";
            this.dateTimePickerDatumObracuna.Size = new System.Drawing.Size(152, 23);
            this.dateTimePickerDatumObracuna.TabIndex = 15;
            // 
            // labelDatumObracuna
            // 
            this.labelDatumObracuna.AutoSize = true;
            this.labelDatumObracuna.Location = new System.Drawing.Point(7, 28);
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
            this.groupBoxRazdoblje.Location = new System.Drawing.Point(13, 32);
            this.groupBoxRazdoblje.Name = "groupBoxRazdoblje";
            this.groupBoxRazdoblje.Size = new System.Drawing.Size(146, 100);
            this.groupBoxRazdoblje.TabIndex = 17;
            this.groupBoxRazdoblje.TabStop = false;
            this.groupBoxRazdoblje.Text = "Razdoblje obračuna";
            // 
            // buttonSpremiArhiva
            // 
            this.buttonSpremiArhiva.Enabled = false;
            this.buttonSpremiArhiva.Location = new System.Drawing.Point(6, 21);
            this.buttonSpremiArhiva.Name = "buttonSpremiArhiva";
            this.buttonSpremiArhiva.Size = new System.Drawing.Size(121, 23);
            this.buttonSpremiArhiva.TabIndex = 18;
            this.buttonSpremiArhiva.Text = "Spremi u arhivu";
            this.buttonSpremiArhiva.UseVisualStyleBackColor = true;
            this.buttonSpremiArhiva.Click += new System.EventHandler(this.ButtonSpremiArhiva_Click);
            // 
            // buttonBrisiOdabrane
            // 
            this.buttonBrisiOdabrane.Enabled = false;
            this.buttonBrisiOdabrane.Location = new System.Drawing.Point(6, 79);
            this.buttonBrisiOdabrane.Name = "buttonBrisiOdabrane";
            this.buttonBrisiOdabrane.Size = new System.Drawing.Size(121, 23);
            this.buttonBrisiOdabrane.TabIndex = 20;
            this.buttonBrisiOdabrane.Text = "Briši odabrane";
            this.buttonBrisiOdabrane.UseVisualStyleBackColor = true;
            this.buttonBrisiOdabrane.Click += new System.EventHandler(this.ButtonBrisiOdabrane_Click);
            // 
            // textBoxFilterIme
            // 
            this.textBoxFilterIme.Location = new System.Drawing.Point(90, 21);
            this.textBoxFilterIme.Name = "textBoxFilterIme";
            this.textBoxFilterIme.PlaceholderText = "Ime ili prezime";
            this.textBoxFilterIme.Size = new System.Drawing.Size(131, 23);
            this.textBoxFilterIme.TabIndex = 21;
            this.textBoxFilterIme.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterByName);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ime i prezime";
            // 
            // groupBoxFilteri
            // 
            this.groupBoxFilteri.Controls.Add(this.buttonFiltrirajDatum);
            this.groupBoxFilteri.Controls.Add(this.label2);
            this.groupBoxFilteri.Controls.Add(this.comboBoxDatumObracunaFilter);
            this.groupBoxFilteri.Controls.Add(this.label1);
            this.groupBoxFilteri.Controls.Add(this.textBoxFilterIme);
            this.groupBoxFilteri.Location = new System.Drawing.Point(165, 138);
            this.groupBoxFilteri.Name = "groupBoxFilteri";
            this.groupBoxFilteri.Size = new System.Drawing.Size(509, 58);
            this.groupBoxFilteri.TabIndex = 23;
            this.groupBoxFilteri.TabStop = false;
            this.groupBoxFilteri.Text = "Filter";
            // 
            // buttonFiltrirajDatum
            // 
            this.buttonFiltrirajDatum.Location = new System.Drawing.Point(430, 20);
            this.buttonFiltrirajDatum.Name = "buttonFiltrirajDatum";
            this.buttonFiltrirajDatum.Size = new System.Drawing.Size(75, 23);
            this.buttonFiltrirajDatum.TabIndex = 25;
            this.buttonFiltrirajDatum.Text = "Filtriraj";
            this.buttonFiltrirajDatum.UseVisualStyleBackColor = true;
            this.buttonFiltrirajDatum.Click += new System.EventHandler(this.ButtonFiltrirajDatum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Datum obračuna";
            // 
            // comboBoxDatumObracunaFilter
            // 
            this.comboBoxDatumObracunaFilter.FormattingEnabled = true;
            this.comboBoxDatumObracunaFilter.Location = new System.Drawing.Point(330, 21);
            this.comboBoxDatumObracunaFilter.Name = "comboBoxDatumObracunaFilter";
            this.comboBoxDatumObracunaFilter.Size = new System.Drawing.Size(94, 23);
            this.comboBoxDatumObracunaFilter.TabIndex = 23;
            // 
            // buttonDohvatArhiva
            // 
            this.buttonDohvatArhiva.Location = new System.Drawing.Point(6, 50);
            this.buttonDohvatArhiva.Name = "buttonDohvatArhiva";
            this.buttonDohvatArhiva.Size = new System.Drawing.Size(121, 23);
            this.buttonDohvatArhiva.TabIndex = 24;
            this.buttonDohvatArhiva.Text = "Dohvat iz arhive";
            this.buttonDohvatArhiva.UseVisualStyleBackColor = true;
            this.buttonDohvatArhiva.Click += new System.EventHandler(this.ButtonDohvatArhiva_Click);
            // 
            // groupBoxArhiva
            // 
            this.groupBoxArhiva.Controls.Add(this.buttonPocetniPrikaz);
            this.groupBoxArhiva.Controls.Add(this.buttonDohvatArhiva);
            this.groupBoxArhiva.Controls.Add(this.buttonSpremiArhiva);
            this.groupBoxArhiva.Controls.Add(this.buttonBrisiOdabrane);
            this.groupBoxArhiva.Location = new System.Drawing.Point(680, 32);
            this.groupBoxArhiva.Name = "groupBoxArhiva";
            this.groupBoxArhiva.Size = new System.Drawing.Size(140, 165);
            this.groupBoxArhiva.TabIndex = 25;
            this.groupBoxArhiva.TabStop = false;
            this.groupBoxArhiva.Text = "Arhiva";
            // 
            // buttonPocetniPrikaz
            // 
            this.buttonPocetniPrikaz.Location = new System.Drawing.Point(7, 109);
            this.buttonPocetniPrikaz.Name = "buttonPocetniPrikaz";
            this.buttonPocetniPrikaz.Size = new System.Drawing.Size(120, 23);
            this.buttonPocetniPrikaz.TabIndex = 25;
            this.buttonPocetniPrikaz.Text = "Početni prikaz";
            this.buttonPocetniPrikaz.UseVisualStyleBackColor = true;
            this.buttonPocetniPrikaz.Click += new System.EventHandler(this.ButtonPocetniPrikaz_Click);
            // 
            // groupBoxObračun
            // 
            this.groupBoxObračun.Controls.Add(this.dateTimePickerDatumObracuna);
            this.groupBoxObračun.Controls.Add(this.labelDatumObracuna);
            this.groupBoxObračun.Controls.Add(this.buttonObracunajSve);
            this.groupBoxObračun.Controls.Add(this.buttonKnjizi);
            this.groupBoxObračun.Location = new System.Drawing.Point(165, 32);
            this.groupBoxObračun.Name = "groupBoxObračun";
            this.groupBoxObračun.Size = new System.Drawing.Size(509, 100);
            this.groupBoxObračun.TabIndex = 26;
            this.groupBoxObračun.TabStop = false;
            this.groupBoxObračun.Text = "Obračun i knjiženje";
            // 
            // groupBoxOdaberiSve
            // 
            this.groupBoxOdaberiSve.Controls.Add(this.checkBoxOdaberiSve);
            this.groupBoxOdaberiSve.Location = new System.Drawing.Point(13, 138);
            this.groupBoxOdaberiSve.Name = "groupBoxOdaberiSve";
            this.groupBoxOdaberiSve.Size = new System.Drawing.Size(146, 59);
            this.groupBoxOdaberiSve.TabIndex = 27;
            this.groupBoxOdaberiSve.TabStop = false;
            this.groupBoxOdaberiSve.Text = "Odabir";
            // 
            // checkBoxOdaberiSve
            // 
            this.checkBoxOdaberiSve.AutoSize = true;
            this.checkBoxOdaberiSve.Location = new System.Drawing.Point(9, 23);
            this.checkBoxOdaberiSve.Name = "checkBoxOdaberiSve";
            this.checkBoxOdaberiSve.Size = new System.Drawing.Size(88, 19);
            this.checkBoxOdaberiSve.TabIndex = 0;
            this.checkBoxOdaberiSve.Text = "Odaberi sve";
            this.checkBoxOdaberiSve.UseVisualStyleBackColor = true;
            this.checkBoxOdaberiSve.CheckStateChanged += new System.EventHandler(this.CheckBoxOdaberiSve_CheckStateChanged);
            // 
            // PlacaObracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 560);
            this.Controls.Add(this.groupBoxOdaberiSve);
            this.Controls.Add(this.groupBoxObračun);
            this.Controls.Add(this.groupBoxArhiva);
            this.Controls.Add(this.groupBoxFilteri);
            this.Controls.Add(this.groupBoxRazdoblje);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlacaObracunForm";
            this.Text = "Obračun plaće";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxRazdoblje.ResumeLayout(false);
            this.groupBoxRazdoblje.PerformLayout();
            this.groupBoxFilteri.ResumeLayout(false);
            this.groupBoxFilteri.PerformLayout();
            this.groupBoxArhiva.ResumeLayout(false);
            this.groupBoxObračun.ResumeLayout(false);
            this.groupBoxObračun.PerformLayout();
            this.groupBoxOdaberiSve.ResumeLayout(false);
            this.groupBoxOdaberiSve.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private Button buttonKnjizi;
        private DateTimePicker dateTimePickerDatumObracuna;
        private Label labelDatumObracuna;
        private GroupBox groupBoxRazdoblje;
        private Button buttonSpremiArhiva;
        private Button buttonBrisiOdabrane;
        private TextBox textBoxFilterIme;
        private Label label1;
        private GroupBox groupBoxFilteri;
        private Label label2;
        private Button buttonDohvatArhiva;
        private GroupBox groupBoxArhiva;
        private GroupBox groupBoxObračun;
        private ComboBox comboBoxDatumObracunaFilter;
        private Button buttonPocetniPrikaz;
        private Button buttonFiltrirajDatum;
        private GroupBox groupBoxOdaberiSve;
        private CheckBox checkBoxOdaberiSve;
    }
}
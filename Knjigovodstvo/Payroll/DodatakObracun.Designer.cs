
using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    partial class DodatakObracun
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
            this.buttonObracunajDodatke = new System.Windows.Forms.Button();
            this.dataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.comboBoxFilterDjelatnik = new System.Windows.Forms.ComboBox();
            this.labelFilterDjelatnik = new System.Windows.Forms.Label();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.comboBoxFilterPoMjesecu = new System.Windows.Forms.ComboBox();
            this.labelFilterMjesec = new System.Windows.Forms.Label();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.comboBoxOdabirDodatka = new System.Windows.Forms.ComboBox();
            this.buttonNoviDodatak = new System.Windows.Forms.Button();
            this.checkBoxSvi = new System.Windows.Forms.CheckBox();
            this.textBoxIznos = new System.Windows.Forms.TextBox();
            this.groupBoxNoviDodatak = new System.Windows.Forms.GroupBox();
            this.buttonBrisiRed = new System.Windows.Forms.Button();
            this.labelDatumObracuna = new System.Windows.Forms.Label();
            this.dateTimePickerDatumObracuna = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxNoviDodatak.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRazdoblje
            // 
            this.labelRazdoblje.AutoSize = true;
            this.labelRazdoblje.Location = new System.Drawing.Point(13, 37);
            this.labelRazdoblje.Name = "labelRazdoblje";
            this.labelRazdoblje.Size = new System.Drawing.Size(119, 15);
            this.labelRazdoblje.TabIndex = 0;
            this.labelRazdoblje.Text = "Razdoblje za obračun";
            // 
            // dateTimePickerDatumOd
            // 
            this.dateTimePickerDatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumOd.Location = new System.Drawing.Point(161, 31);
            this.dateTimePickerDatumOd.Name = "dateTimePickerDatumOd";
            this.dateTimePickerDatumOd.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumOd.TabIndex = 1;
            // 
            // labelDatumOd
            // 
            this.labelDatumOd.AutoSize = true;
            this.labelDatumOd.Location = new System.Drawing.Point(138, 35);
            this.labelDatumOd.Name = "labelDatumOd";
            this.labelDatumOd.Size = new System.Drawing.Size(23, 15);
            this.labelDatumOd.TabIndex = 2;
            this.labelDatumOd.Text = "Od";
            // 
            // dateTimePickerDatumDo
            // 
            this.dateTimePickerDatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumDo.Location = new System.Drawing.Point(284, 31);
            this.dateTimePickerDatumDo.Name = "dateTimePickerDatumDo";
            this.dateTimePickerDatumDo.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumDo.TabIndex = 1;
            // 
            // labelDatumDo
            // 
            this.labelDatumDo.AutoSize = true;
            this.labelDatumDo.Location = new System.Drawing.Point(260, 35);
            this.labelDatumDo.Name = "labelDatumDo";
            this.labelDatumDo.Size = new System.Drawing.Size(22, 15);
            this.labelDatumDo.TabIndex = 2;
            this.labelDatumDo.Text = "Do";
            // 
            // buttonObracunajDodatke
            // 
            this.buttonObracunajDodatke.Location = new System.Drawing.Point(13, 112);
            this.buttonObracunajDodatke.Name = "buttonObracunajDodatke";
            this.buttonObracunajDodatke.Size = new System.Drawing.Size(117, 23);
            this.buttonObracunajDodatke.TabIndex = 3;
            this.buttonObracunajDodatke.Text = "Obračunaj Dodatke";
            this.buttonObracunajDodatke.UseVisualStyleBackColor = true;
            this.buttonObracunajDodatke.Click += new System.EventHandler(this.ButtonObracunajDodatke_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 187);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(691, 361);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Text = "dataGridView1";
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
            this.buttonKnjizi.Location = new System.Drawing.Point(217, 112);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(124, 23);
            this.buttonKnjizi.TabIndex = 14;
            this.buttonKnjizi.Text = "Knjiži na temeljnicu";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(136, 112);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 15;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // comboBoxOdabirDodatka
            // 
            this.comboBoxOdabirDodatka.FormattingEnabled = true;
            this.comboBoxOdabirDodatka.Location = new System.Drawing.Point(9, 54);
            this.comboBoxOdabirDodatka.Name = "comboBoxOdabirDodatka";
            this.comboBoxOdabirDodatka.Size = new System.Drawing.Size(272, 23);
            this.comboBoxOdabirDodatka.TabIndex = 16;
            // 
            // buttonNoviDodatak
            // 
            this.buttonNoviDodatak.Location = new System.Drawing.Point(164, 25);
            this.buttonNoviDodatak.Name = "buttonNoviDodatak";
            this.buttonNoviDodatak.Size = new System.Drawing.Size(117, 23);
            this.buttonNoviDodatak.TabIndex = 17;
            this.buttonNoviDodatak.Text = "Novi Dodatak";
            this.buttonNoviDodatak.UseVisualStyleBackColor = true;
            this.buttonNoviDodatak.Click += new System.EventHandler(this.ButtonNoviDodatak_Click);
            // 
            // checkBoxSvi
            // 
            this.checkBoxSvi.AutoSize = true;
            this.checkBoxSvi.Location = new System.Drawing.Point(9, 29);
            this.checkBoxSvi.Name = "checkBoxSvi";
            this.checkBoxSvi.Size = new System.Drawing.Size(104, 19);
            this.checkBoxSvi.TabIndex = 18;
            this.checkBoxSvi.Text = "Svi Zaposlenici";
            this.checkBoxSvi.UseVisualStyleBackColor = true;
            // 
            // textBoxIznos
            // 
            this.textBoxIznos.Location = new System.Drawing.Point(181, 83);
            this.textBoxIznos.Name = "textBoxIznos";
            this.textBoxIznos.PlaceholderText = "Iznos";
            this.textBoxIznos.Size = new System.Drawing.Size(100, 23);
            this.textBoxIznos.TabIndex = 19;
            this.textBoxIznos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // groupBoxNoviDodatak
            // 
            this.groupBoxNoviDodatak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxNoviDodatak.Controls.Add(this.textBoxIznos);
            this.groupBoxNoviDodatak.Controls.Add(this.comboBoxOdabirDodatka);
            this.groupBoxNoviDodatak.Controls.Add(this.checkBoxSvi);
            this.groupBoxNoviDodatak.Controls.Add(this.buttonNoviDodatak);
            this.groupBoxNoviDodatak.Location = new System.Drawing.Point(706, 187);
            this.groupBoxNoviDodatak.Name = "groupBoxNoviDodatak";
            this.groupBoxNoviDodatak.Size = new System.Drawing.Size(287, 217);
            this.groupBoxNoviDodatak.TabIndex = 20;
            this.groupBoxNoviDodatak.TabStop = false;
            this.groupBoxNoviDodatak.Text = "Novi Dodatak";
            // 
            // buttonBrisiRed
            // 
            this.buttonBrisiRed.Location = new System.Drawing.Point(707, 524);
            this.buttonBrisiRed.Name = "buttonBrisiRed";
            this.buttonBrisiRed.Size = new System.Drawing.Size(75, 23);
            this.buttonBrisiRed.TabIndex = 21;
            this.buttonBrisiRed.Text = "Briši red";
            this.buttonBrisiRed.UseVisualStyleBackColor = true;
            this.buttonBrisiRed.Click += new System.EventHandler(this.ButtonBrisiRed_Click);
            // 
            // labelDatumObracuna
            // 
            this.labelDatumObracuna.AutoSize = true;
            this.labelDatumObracuna.Location = new System.Drawing.Point(13, 73);
            this.labelDatumObracuna.Name = "labelDatumObracuna";
            this.labelDatumObracuna.Size = new System.Drawing.Size(96, 15);
            this.labelDatumObracuna.TabIndex = 22;
            this.labelDatumObracuna.Text = "Datum obračuna";
            // 
            // dateTimePickerDatumObracuna
            // 
            this.dateTimePickerDatumObracuna.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumObracuna.Location = new System.Drawing.Point(161, 67);
            this.dateTimePickerDatumObracuna.Name = "dateTimePickerDatumObracuna";
            this.dateTimePickerDatumObracuna.Size = new System.Drawing.Size(91, 23);
            this.dateTimePickerDatumObracuna.TabIndex = 23;
            // 
            // DodatakObracun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 560);
            this.Controls.Add(this.dateTimePickerDatumObracuna);
            this.Controls.Add(this.labelDatumObracuna);
            this.Controls.Add(this.buttonBrisiRed);
            this.Controls.Add(this.groupBoxNoviDodatak);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.labelFilterMjesec);
            this.Controls.Add(this.comboBoxFilterPoMjesecu);
            this.Controls.Add(this.buttonPonisti);
            this.Controls.Add(this.labelFilterDjelatnik);
            this.Controls.Add(this.comboBoxFilterDjelatnik);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonObracunajDodatke);
            this.Controls.Add(this.labelDatumDo);
            this.Controls.Add(this.dateTimePickerDatumDo);
            this.Controls.Add(this.labelDatumOd);
            this.Controls.Add(this.dateTimePickerDatumOd);
            this.Controls.Add(this.labelRazdoblje);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DodatakObracun";
            this.Text = "Obračun dodataka";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxNoviDodatak.ResumeLayout(false);
            this.groupBoxNoviDodatak.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRazdoblje;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumOd;
        private System.Windows.Forms.Label labelDatumOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumDo;
        private System.Windows.Forms.Label labelDatumDo;
        private System.Windows.Forms.Button buttonObracunajDodatke;
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxFilterDjelatnik;
        private System.Windows.Forms.Label labelFilterDjelatnik;
        private System.Windows.Forms.Button buttonPonisti;
        private System.Windows.Forms.ComboBox comboBoxFilterPoMjesecu;
        private System.Windows.Forms.Label labelFilterMjesec;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private Button buttonKnjizi;
        private Button buttonSpremi;
        private ComboBox comboBoxOdabirDodatka;
        private Button buttonNoviDodatak;
        private CheckBox checkBoxSvi;
        private TextBox textBoxIznos;
        private GroupBox groupBoxNoviDodatak;
        private Button buttonBrisiRed;
        private Label labelDatumObracuna;
        private DateTimePicker dateTimePickerDatumObracuna;
    }
}
using System.Windows.Forms;

namespace Knjigovodstvo.JoppdDocument
{
    partial class JoppdPlacaForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelDatumObrasca = new System.Windows.Forms.Label();
            this.labelBrojObrasca = new System.Windows.Forms.Label();
            this.buttonPripremiPodatke = new System.Windows.Forms.Button();
            this.checkBoxSamoDodaci = new System.Windows.Forms.CheckBox();
            this.comboBoxDodaci = new System.Windows.Forms.ComboBox();
            this.checkBoxBezDodataka = new System.Windows.Forms.CheckBox();
            this.labelSatiRada = new System.Windows.Forms.Label();
            this.textBoxSatiRada = new System.Windows.Forms.TextBox();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIzvjesceSastavioIme = new System.Windows.Forms.TextBox();
            this.buttonSnimiPodatke = new System.Windows.Forms.Button();
            this.dateTimePickerRazdobljeOd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRazdobljeDo = new System.Windows.Forms.DateTimePicker();
            this.groupBoxRazdoblje = new System.Windows.Forms.GroupBox();
            this.groupBoxOpcije = new System.Windows.Forms.GroupBox();
            this.groupBoxOpci = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSatiPraznika = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.groupBoxRazdoblje.SuspendLayout();
            this.groupBoxOpcije.SuspendLayout();
            this.groupBoxOpci.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(119, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(84, 23);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // labelDatumObrasca
            // 
            this.labelDatumObrasca.AutoSize = true;
            this.labelDatumObrasca.Location = new System.Drawing.Point(6, 21);
            this.labelDatumObrasca.Name = "labelDatumObrasca";
            this.labelDatumObrasca.Size = new System.Drawing.Size(87, 15);
            this.labelDatumObrasca.TabIndex = 1;
            this.labelDatumObrasca.Text = "Datum obrasca";
            // 
            // labelBrojObrasca
            // 
            this.labelBrojObrasca.AutoSize = true;
            this.labelBrojObrasca.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBrojObrasca.Location = new System.Drawing.Point(209, 15);
            this.labelBrojObrasca.Name = "labelBrojObrasca";
            this.labelBrojObrasca.Size = new System.Drawing.Size(39, 20);
            this.labelBrojObrasca.TabIndex = 2;
            this.labelBrojObrasca.Text = "-----";
            // 
            // buttonPripremiPodatke
            // 
            this.buttonPripremiPodatke.Location = new System.Drawing.Point(19, 109);
            this.buttonPripremiPodatke.Name = "buttonPripremiPodatke";
            this.buttonPripremiPodatke.Size = new System.Drawing.Size(75, 23);
            this.buttonPripremiPodatke.TabIndex = 3;
            this.buttonPripremiPodatke.Text = "Pripremi";
            this.buttonPripremiPodatke.UseVisualStyleBackColor = true;
            this.buttonPripremiPodatke.Click += new System.EventHandler(this.ButtonPopuniObrazac_Click);
            // 
            // checkBoxSamoDodaci
            // 
            this.checkBoxSamoDodaci.AutoSize = true;
            this.checkBoxSamoDodaci.Location = new System.Drawing.Point(11, 58);
            this.checkBoxSamoDodaci.Name = "checkBoxSamoDodaci";
            this.checkBoxSamoDodaci.Size = new System.Drawing.Size(95, 19);
            this.checkBoxSamoDodaci.TabIndex = 4;
            this.checkBoxSamoDodaci.Text = "Samo dodaci";
            this.checkBoxSamoDodaci.UseVisualStyleBackColor = true;
            this.checkBoxSamoDodaci.CheckStateChanged += new System.EventHandler(this.CheckBoxSamoDodaci_CheckStateChanged);
            // 
            // comboBoxDodaci
            // 
            this.comboBoxDodaci.DropDownWidth = 800;
            this.comboBoxDodaci.FormattingEnabled = true;
            this.comboBoxDodaci.Location = new System.Drawing.Point(112, 56);
            this.comboBoxDodaci.Name = "comboBoxDodaci";
            this.comboBoxDodaci.Size = new System.Drawing.Size(199, 23);
            this.comboBoxDodaci.TabIndex = 5;
            this.comboBoxDodaci.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxDodaci_SelectionChangeCommitted);
            // 
            // checkBoxBezDodataka
            // 
            this.checkBoxBezDodataka.AutoSize = true;
            this.checkBoxBezDodataka.Location = new System.Drawing.Point(11, 22);
            this.checkBoxBezDodataka.Name = "checkBoxBezDodataka";
            this.checkBoxBezDodataka.Size = new System.Drawing.Size(96, 19);
            this.checkBoxBezDodataka.TabIndex = 6;
            this.checkBoxBezDodataka.Text = "Bez dodataka";
            this.checkBoxBezDodataka.UseVisualStyleBackColor = true;
            this.checkBoxBezDodataka.CheckStateChanged += new System.EventHandler(this.CheckBoxBezDodataka_CheckStateChanged);
            // 
            // labelSatiRada
            // 
            this.labelSatiRada.AutoSize = true;
            this.labelSatiRada.Location = new System.Drawing.Point(6, 47);
            this.labelSatiRada.Name = "labelSatiRada";
            this.labelSatiRada.Size = new System.Drawing.Size(65, 15);
            this.labelSatiRada.TabIndex = 8;
            this.labelSatiRada.Text = "Radnih sati";
            // 
            // textBoxSatiRada
            // 
            this.textBoxSatiRada.Location = new System.Drawing.Point(119, 44);
            this.textBoxSatiRada.Name = "textBoxSatiRada";
            this.textBoxSatiRada.Size = new System.Drawing.Size(56, 23);
            this.textBoxSatiRada.TabIndex = 9;
            this.textBoxSatiRada.Text = "168";
            this.textBoxSatiRada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSatiRada_KeyPress);
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
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 162);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(935, 369);
            this.dbDataGridView1.TabIndex = 10;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Izvješće sastavio";
            // 
            // textBoxIzvjesceSastavioIme
            // 
            this.textBoxIzvjesceSastavioIme.Location = new System.Drawing.Point(119, 103);
            this.textBoxIzvjesceSastavioIme.Name = "textBoxIzvjesceSastavioIme";
            this.textBoxIzvjesceSastavioIme.Size = new System.Drawing.Size(136, 23);
            this.textBoxIzvjesceSastavioIme.TabIndex = 12;
            this.textBoxIzvjesceSastavioIme.Text = "Ivan Batinić";
            // 
            // buttonSnimiPodatke
            // 
            this.buttonSnimiPodatke.Location = new System.Drawing.Point(100, 109);
            this.buttonSnimiPodatke.Name = "buttonSnimiPodatke";
            this.buttonSnimiPodatke.Size = new System.Drawing.Size(75, 23);
            this.buttonSnimiPodatke.TabIndex = 13;
            this.buttonSnimiPodatke.Text = "Spremi";
            this.buttonSnimiPodatke.UseVisualStyleBackColor = true;
            this.buttonSnimiPodatke.Click += new System.EventHandler(this.ButtonSnimiPodatke_Click);
            // 
            // dateTimePickerRazdobljeOd
            // 
            this.dateTimePickerRazdobljeOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerRazdobljeOd.Location = new System.Drawing.Point(6, 27);
            this.dateTimePickerRazdobljeOd.Name = "dateTimePickerRazdobljeOd";
            this.dateTimePickerRazdobljeOd.Size = new System.Drawing.Size(77, 23);
            this.dateTimePickerRazdobljeOd.TabIndex = 14;
            // 
            // dateTimePickerRazdobljeDo
            // 
            this.dateTimePickerRazdobljeDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerRazdobljeDo.Location = new System.Drawing.Point(89, 27);
            this.dateTimePickerRazdobljeDo.Name = "dateTimePickerRazdobljeDo";
            this.dateTimePickerRazdobljeDo.Size = new System.Drawing.Size(77, 23);
            this.dateTimePickerRazdobljeDo.TabIndex = 15;
            // 
            // groupBoxRazdoblje
            // 
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerRazdobljeOd);
            this.groupBoxRazdoblje.Controls.Add(this.dateTimePickerRazdobljeDo);
            this.groupBoxRazdoblje.Location = new System.Drawing.Point(11, 12);
            this.groupBoxRazdoblje.Name = "groupBoxRazdoblje";
            this.groupBoxRazdoblje.Size = new System.Drawing.Size(176, 71);
            this.groupBoxRazdoblje.TabIndex = 16;
            this.groupBoxRazdoblje.TabStop = false;
            this.groupBoxRazdoblje.Text = "Razdoblje";
            // 
            // groupBoxOpcije
            // 
            this.groupBoxOpcije.Controls.Add(this.checkBoxSamoDodaci);
            this.groupBoxOpcije.Controls.Add(this.comboBoxDodaci);
            this.groupBoxOpcije.Controls.Add(this.checkBoxBezDodataka);
            this.groupBoxOpcije.Location = new System.Drawing.Point(481, 12);
            this.groupBoxOpcije.Name = "groupBoxOpcije";
            this.groupBoxOpcije.Size = new System.Drawing.Size(322, 132);
            this.groupBoxOpcije.TabIndex = 17;
            this.groupBoxOpcije.TabStop = false;
            this.groupBoxOpcije.Text = "Opcije";
            // 
            // groupBoxOpci
            // 
            this.groupBoxOpci.Controls.Add(this.label2);
            this.groupBoxOpci.Controls.Add(this.textBoxSatiPraznika);
            this.groupBoxOpci.Controls.Add(this.labelDatumObrasca);
            this.groupBoxOpci.Controls.Add(this.dateTimePicker1);
            this.groupBoxOpci.Controls.Add(this.labelBrojObrasca);
            this.groupBoxOpci.Controls.Add(this.labelSatiRada);
            this.groupBoxOpci.Controls.Add(this.textBoxIzvjesceSastavioIme);
            this.groupBoxOpci.Controls.Add(this.textBoxSatiRada);
            this.groupBoxOpci.Controls.Add(this.label1);
            this.groupBoxOpci.Location = new System.Drawing.Point(203, 12);
            this.groupBoxOpci.Name = "groupBoxOpci";
            this.groupBoxOpci.Size = new System.Drawing.Size(260, 132);
            this.groupBoxOpci.TabIndex = 18;
            this.groupBoxOpci.TabStop = false;
            this.groupBoxOpci.Text = "Opći";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sati praznika";
            // 
            // textBoxSatiPraznika
            // 
            this.textBoxSatiPraznika.Location = new System.Drawing.Point(119, 74);
            this.textBoxSatiPraznika.Name = "textBoxSatiPraznika";
            this.textBoxSatiPraznika.Size = new System.Drawing.Size(56, 23);
            this.textBoxSatiPraznika.TabIndex = 14;
            this.textBoxSatiPraznika.Text = "0";
            // 
            // JoppdPlacaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 547);
            this.Controls.Add(this.groupBoxOpci);
            this.Controls.Add(this.groupBoxOpcije);
            this.Controls.Add(this.groupBoxRazdoblje);
            this.Controls.Add(this.buttonSnimiPodatke);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.buttonPripremiPodatke);
            this.Name = "JoppdPlacaForm";
            this.Text = "Joppd obrazac";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.groupBoxRazdoblje.ResumeLayout(false);
            this.groupBoxOpcije.ResumeLayout(false);
            this.groupBoxOpcije.PerformLayout();
            this.groupBoxOpci.ResumeLayout(false);
            this.groupBoxOpci.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDatumObrasca;
        private System.Windows.Forms.Label labelBrojObrasca;
        private System.Windows.Forms.Button buttonPripremiPodatke;
        private System.Windows.Forms.CheckBox checkBoxSamoDodaci;
        private System.Windows.Forms.ComboBox comboBoxDodaci;
        private System.Windows.Forms.CheckBox checkBoxBezDodataka;
        private System.Windows.Forms.Label labelSatiRada;
        private System.Windows.Forms.TextBox textBoxSatiRada;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIzvjesceSastavioIme;
        private Button buttonSnimiPodatke;
        private DateTimePicker dateTimePickerRazdobljeOd;
        private DateTimePicker dateTimePickerRazdobljeDo;
        private GroupBox groupBoxRazdoblje;
        private GroupBox groupBoxOpcije;
        private GroupBox groupBoxOpci;
        private Label label2;
        private TextBox textBoxSatiPraznika;
    }
}
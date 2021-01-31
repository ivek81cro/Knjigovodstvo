using Knjigovodstvo.Settings;
using System;
using System.Linq;

namespace Knjigovodstvo.Wages
{
    partial class PlacaIzracunForm
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
            this.comboBoxZaposlenik = new System.Windows.Forms.ComboBox();
            this.labelOdabirZaposlenika = new System.Windows.Forms.Label();
            this.labelBruto = new System.Windows.Forms.Label();
            this.textBoxBruto = new System.Windows.Forms.TextBox();
            this.checkBoxSamoMio1 = new System.Windows.Forms.CheckBox();
            this.buttonIzracunaj = new System.Windows.Forms.Button();
            this.labelMio1 = new System.Windows.Forms.Label();
            this.labelMio2 = new System.Windows.Forms.Label();
            this.textBoxMio1 = new System.Windows.Forms.TextBox();
            this.textBoxMio2 = new System.Windows.Forms.TextBox();
            this.labelDohodak = new System.Windows.Forms.Label();
            this.textBoxDohodak = new System.Windows.Forms.TextBox();
            this.labelOsobniOdbitak = new System.Windows.Forms.Label();
            this.labelPoreznaOsnovica = new System.Windows.Forms.Label();
            this.labelPorez1 = new System.Windows.Forms.Label();
            this.labelPorez2 = new System.Windows.Forms.Label();
            this.labelPorezUkupno = new System.Windows.Forms.Label();
            this.labelPrirez = new System.Windows.Forms.Label();
            this.labelUkupnoPorezPrirez = new System.Windows.Forms.Label();
            this.labelNetto = new System.Windows.Forms.Label();
            this.labelDoprinosZdravstvo = new System.Windows.Forms.Label();
            this.textBoxOdbitak = new System.Windows.Forms.TextBox();
            this.textBoxPoreznaOsnovica = new System.Windows.Forms.TextBox();
            this.textBoxPorez1 = new System.Windows.Forms.TextBox();
            this.textBoxPorez2 = new System.Windows.Forms.TextBox();
            this.textBoxPorezUkupno = new System.Windows.Forms.TextBox();
            this.textBoxPrirez = new System.Windows.Forms.TextBox();
            this.textBoxUkupnoPorezPrirez = new System.Windows.Forms.TextBox();
            this.textBoxNetto = new System.Windows.Forms.TextBox();
            this.textBoxDoprinosZdravstvo = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelBrutoRaed = new System.Windows.Forms.Label();
            this.textBoxBrutoRead = new System.Windows.Forms.TextBox();
            this.buttonDodaci = new System.Windows.Forms.Button();
            this.textBoxDodaci = new System.Windows.Forms.TextBox();
            this.labelDodaci = new System.Windows.Forms.Label();
            this.groupBoxDodaci = new System.Windows.Forms.GroupBox();
            this.groupBoxJoppd = new System.Windows.Forms.GroupBox();
            this.buttonSpremiJoppdPostavke = new System.Windows.Forms.Button();
            this.labelNacinIsplate = new System.Windows.Forms.Label();
            this.comboBoxNacinIsplate = new System.Windows.Forms.ComboBox();
            this.labelPrimitak = new System.Windows.Forms.Label();
            this.labelStjecatelj = new System.Windows.Forms.Label();
            this.labelRadnoVrijeme = new System.Windows.Forms.Label();
            this.labelPrviZadnjiMjesec = new System.Windows.Forms.Label();
            this.labelInvaliditet = new System.Windows.Forms.Label();
            this.labelOznakaDodatniMio = new System.Windows.Forms.Label();
            this.comboBoxRadnoVrijeme = new System.Windows.Forms.ComboBox();
            this.comboBoxMjesecPrviZadnji = new System.Windows.Forms.ComboBox();
            this.comboBoxInvaliditet = new System.Windows.Forms.ComboBox();
            this.comboBoxDodatniMio = new System.Windows.Forms.ComboBox();
            this.comboBoxPrimitak = new System.Windows.Forms.ComboBox();
            this.comboBoxStjecatelj = new System.Windows.Forms.ComboBox();
            this.groupBoxDodaci.SuspendLayout();
            this.groupBoxJoppd.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxZaposlenik
            // 
            this.comboBoxZaposlenik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZaposlenik.FormattingEnabled = true;
            this.comboBoxZaposlenik.Location = new System.Drawing.Point(12, 12);
            this.comboBoxZaposlenik.Name = "comboBoxZaposlenik";
            this.comboBoxZaposlenik.Size = new System.Drawing.Size(315, 23);
            this.comboBoxZaposlenik.TabIndex = 0;
            this.comboBoxZaposlenik.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxZaposlenik_SelectionChangeCommitted);
            // 
            // labelOdabirZaposlenika
            // 
            this.labelOdabirZaposlenika.AutoSize = true;
            this.labelOdabirZaposlenika.Location = new System.Drawing.Point(333, 15);
            this.labelOdabirZaposlenika.Name = "labelOdabirZaposlenika";
            this.labelOdabirZaposlenika.Size = new System.Drawing.Size(107, 15);
            this.labelOdabirZaposlenika.TabIndex = 40;
            this.labelOdabirZaposlenika.Text = "Odabir zaposlenika";
            // 
            // labelBruto
            // 
            this.labelBruto.AutoSize = true;
            this.labelBruto.Location = new System.Drawing.Point(12, 62);
            this.labelBruto.Name = "labelBruto";
            this.labelBruto.Size = new System.Drawing.Size(39, 15);
            this.labelBruto.TabIndex = 39;
            this.labelBruto.Text = "Bruto:";
            // 
            // textBoxBruto
            // 
            this.textBoxBruto.Location = new System.Drawing.Point(57, 59);
            this.textBoxBruto.Name = "textBoxBruto";
            this.textBoxBruto.Size = new System.Drawing.Size(150, 23);
            this.textBoxBruto.TabIndex = 1;
            this.textBoxBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // checkBoxSamoMio1
            // 
            this.checkBoxSamoMio1.AutoSize = true;
            this.checkBoxSamoMio1.Location = new System.Drawing.Point(229, 61);
            this.checkBoxSamoMio1.Name = "checkBoxSamoMio1";
            this.checkBoxSamoMio1.Size = new System.Drawing.Size(213, 19);
            this.checkBoxSamoMio1.TabIndex = 2;
            this.checkBoxSamoMio1.Text = "Mirovinsko osiguranje samo 1. stup";
            this.checkBoxSamoMio1.UseVisualStyleBackColor = true;
            // 
            // buttonIzracunaj
            // 
            this.buttonIzracunaj.Location = new System.Drawing.Point(12, 100);
            this.buttonIzracunaj.Name = "buttonIzracunaj";
            this.buttonIzracunaj.Size = new System.Drawing.Size(75, 23);
            this.buttonIzracunaj.TabIndex = 3;
            this.buttonIzracunaj.Text = "Izračunaj";
            this.buttonIzracunaj.UseVisualStyleBackColor = true;
            this.buttonIzracunaj.Click += new System.EventHandler(this.ButtonIzracunaj_Click);
            // 
            // labelMio1
            // 
            this.labelMio1.AutoSize = true;
            this.labelMio1.Location = new System.Drawing.Point(10, 181);
            this.labelMio1.Name = "labelMio1";
            this.labelMio1.Size = new System.Drawing.Size(66, 15);
            this.labelMio1.TabIndex = 38;
            this.labelMio1.Text = "Mio 1. stup";
            // 
            // labelMio2
            // 
            this.labelMio2.AutoSize = true;
            this.labelMio2.Location = new System.Drawing.Point(10, 214);
            this.labelMio2.Name = "labelMio2";
            this.labelMio2.Size = new System.Drawing.Size(66, 15);
            this.labelMio2.TabIndex = 37;
            this.labelMio2.Text = "Mio 2. stup";
            // 
            // textBoxMio1
            // 
            this.textBoxMio1.Location = new System.Drawing.Point(119, 180);
            this.textBoxMio1.Name = "textBoxMio1";
            this.textBoxMio1.ReadOnly = true;
            this.textBoxMio1.Size = new System.Drawing.Size(123, 23);
            this.textBoxMio1.TabIndex = 36;
            // 
            // textBoxMio2
            // 
            this.textBoxMio2.Location = new System.Drawing.Point(119, 211);
            this.textBoxMio2.Name = "textBoxMio2";
            this.textBoxMio2.ReadOnly = true;
            this.textBoxMio2.Size = new System.Drawing.Size(123, 23);
            this.textBoxMio2.TabIndex = 35;
            // 
            // labelDohodak
            // 
            this.labelDohodak.AutoSize = true;
            this.labelDohodak.Location = new System.Drawing.Point(10, 247);
            this.labelDohodak.Name = "labelDohodak";
            this.labelDohodak.Size = new System.Drawing.Size(55, 15);
            this.labelDohodak.TabIndex = 34;
            this.labelDohodak.Text = "Dohodak";
            // 
            // textBoxDohodak
            // 
            this.textBoxDohodak.Location = new System.Drawing.Point(119, 244);
            this.textBoxDohodak.Name = "textBoxDohodak";
            this.textBoxDohodak.ReadOnly = true;
            this.textBoxDohodak.Size = new System.Drawing.Size(123, 23);
            this.textBoxDohodak.TabIndex = 33;
            // 
            // labelOsobniOdbitak
            // 
            this.labelOsobniOdbitak.AutoSize = true;
            this.labelOsobniOdbitak.Location = new System.Drawing.Point(10, 280);
            this.labelOsobniOdbitak.Name = "labelOsobniOdbitak";
            this.labelOsobniOdbitak.Size = new System.Drawing.Size(90, 15);
            this.labelOsobniOdbitak.TabIndex = 32;
            this.labelOsobniOdbitak.Text = "Osobni Odbitak";
            // 
            // labelPoreznaOsnovica
            // 
            this.labelPoreznaOsnovica.AutoSize = true;
            this.labelPoreznaOsnovica.Location = new System.Drawing.Point(10, 313);
            this.labelPoreznaOsnovica.Name = "labelPoreznaOsnovica";
            this.labelPoreznaOsnovica.Size = new System.Drawing.Size(99, 15);
            this.labelPoreznaOsnovica.TabIndex = 31;
            this.labelPoreznaOsnovica.Text = "Porezna osnovica";
            // 
            // labelPorez1
            // 
            this.labelPorez1.AutoSize = true;
            this.labelPorez1.Location = new System.Drawing.Point(10, 346);
            this.labelPorez1.Name = "labelPorez1";
            this.labelPorez1.Size = new System.Drawing.Size(39, 15);
            this.labelPorez1.TabIndex = 30;
            this.labelPorez1.Text = "Porez ";
            // 
            // labelPorez2
            // 
            this.labelPorez2.AutoSize = true;
            this.labelPorez2.Location = new System.Drawing.Point(10, 379);
            this.labelPorez2.Name = "labelPorez2";
            this.labelPorez2.Size = new System.Drawing.Size(39, 15);
            this.labelPorez2.TabIndex = 29;
            this.labelPorez2.Text = "Porez ";
            // 
            // labelPorezUkupno
            // 
            this.labelPorezUkupno.AutoSize = true;
            this.labelPorezUkupno.Location = new System.Drawing.Point(10, 412);
            this.labelPorezUkupno.Name = "labelPorezUkupno";
            this.labelPorezUkupno.Size = new System.Drawing.Size(80, 15);
            this.labelPorezUkupno.TabIndex = 28;
            this.labelPorezUkupno.Text = "Porez ukupno";
            // 
            // labelPrirez
            // 
            this.labelPrirez.AutoSize = true;
            this.labelPrirez.Location = new System.Drawing.Point(10, 445);
            this.labelPrirez.Name = "labelPrirez";
            this.labelPrirez.Size = new System.Drawing.Size(36, 15);
            this.labelPrirez.TabIndex = 27;
            this.labelPrirez.Text = "Prirez";
            // 
            // labelUkupnoPorezPrirez
            // 
            this.labelUkupnoPorezPrirez.AutoSize = true;
            this.labelUkupnoPorezPrirez.Location = new System.Drawing.Point(10, 478);
            this.labelUkupnoPorezPrirez.Name = "labelUkupnoPorezPrirez";
            this.labelUkupnoPorezPrirez.Size = new System.Drawing.Size(94, 15);
            this.labelUkupnoPorezPrirez.TabIndex = 26;
            this.labelUkupnoPorezPrirez.Text = "Uk. porez i prirez";
            // 
            // labelNetto
            // 
            this.labelNetto.AutoSize = true;
            this.labelNetto.Location = new System.Drawing.Point(10, 511);
            this.labelNetto.Name = "labelNetto";
            this.labelNetto.Size = new System.Drawing.Size(37, 15);
            this.labelNetto.TabIndex = 25;
            this.labelNetto.Text = "Netto";
            // 
            // labelDoprinosZdravstvo
            // 
            this.labelDoprinosZdravstvo.AutoSize = true;
            this.labelDoprinosZdravstvo.Location = new System.Drawing.Point(11, 544);
            this.labelDoprinosZdravstvo.Name = "labelDoprinosZdravstvo";
            this.labelDoprinosZdravstvo.Size = new System.Drawing.Size(108, 15);
            this.labelDoprinosZdravstvo.TabIndex = 24;
            this.labelDoprinosZdravstvo.Text = "Doprinos zdravstvo";
            // 
            // textBoxOdbitak
            // 
            this.textBoxOdbitak.Location = new System.Drawing.Point(119, 277);
            this.textBoxOdbitak.Name = "textBoxOdbitak";
            this.textBoxOdbitak.ReadOnly = true;
            this.textBoxOdbitak.Size = new System.Drawing.Size(123, 23);
            this.textBoxOdbitak.TabIndex = 23;
            // 
            // textBoxPoreznaOsnovica
            // 
            this.textBoxPoreznaOsnovica.Location = new System.Drawing.Point(119, 310);
            this.textBoxPoreznaOsnovica.Name = "textBoxPoreznaOsnovica";
            this.textBoxPoreznaOsnovica.ReadOnly = true;
            this.textBoxPoreznaOsnovica.Size = new System.Drawing.Size(123, 23);
            this.textBoxPoreznaOsnovica.TabIndex = 22;
            // 
            // textBoxPorez1
            // 
            this.textBoxPorez1.Location = new System.Drawing.Point(119, 343);
            this.textBoxPorez1.Name = "textBoxPorez1";
            this.textBoxPorez1.ReadOnly = true;
            this.textBoxPorez1.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorez1.TabIndex = 21;
            // 
            // textBoxPorez2
            // 
            this.textBoxPorez2.Location = new System.Drawing.Point(119, 376);
            this.textBoxPorez2.Name = "textBoxPorez2";
            this.textBoxPorez2.ReadOnly = true;
            this.textBoxPorez2.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorez2.TabIndex = 20;
            // 
            // textBoxPorezUkupno
            // 
            this.textBoxPorezUkupno.Location = new System.Drawing.Point(119, 409);
            this.textBoxPorezUkupno.Name = "textBoxPorezUkupno";
            this.textBoxPorezUkupno.ReadOnly = true;
            this.textBoxPorezUkupno.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorezUkupno.TabIndex = 19;
            // 
            // textBoxPrirez
            // 
            this.textBoxPrirez.Location = new System.Drawing.Point(119, 442);
            this.textBoxPrirez.Name = "textBoxPrirez";
            this.textBoxPrirez.ReadOnly = true;
            this.textBoxPrirez.Size = new System.Drawing.Size(123, 23);
            this.textBoxPrirez.TabIndex = 18;
            // 
            // textBoxUkupnoPorezPrirez
            // 
            this.textBoxUkupnoPorezPrirez.Location = new System.Drawing.Point(119, 475);
            this.textBoxUkupnoPorezPrirez.Name = "textBoxUkupnoPorezPrirez";
            this.textBoxUkupnoPorezPrirez.ReadOnly = true;
            this.textBoxUkupnoPorezPrirez.Size = new System.Drawing.Size(123, 23);
            this.textBoxUkupnoPorezPrirez.TabIndex = 17;
            // 
            // textBoxNetto
            // 
            this.textBoxNetto.Location = new System.Drawing.Point(119, 508);
            this.textBoxNetto.Name = "textBoxNetto";
            this.textBoxNetto.ReadOnly = true;
            this.textBoxNetto.Size = new System.Drawing.Size(123, 23);
            this.textBoxNetto.TabIndex = 16;
            // 
            // textBoxDoprinosZdravstvo
            // 
            this.textBoxDoprinosZdravstvo.Location = new System.Drawing.Point(119, 541);
            this.textBoxDoprinosZdravstvo.Name = "textBoxDoprinosZdravstvo";
            this.textBoxDoprinosZdravstvo.ReadOnly = true;
            this.textBoxDoprinosZdravstvo.Size = new System.Drawing.Size(123, 23);
            this.textBoxDoprinosZdravstvo.TabIndex = 15;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(510, 609);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(591, 609);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Zatvori";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelBrutoRaed
            // 
            this.labelBrutoRaed.AutoSize = true;
            this.labelBrutoRaed.Location = new System.Drawing.Point(10, 152);
            this.labelBrutoRaed.Name = "labelBrutoRaed";
            this.labelBrutoRaed.Size = new System.Drawing.Size(36, 15);
            this.labelBrutoRaed.TabIndex = 3;
            this.labelBrutoRaed.Text = "Bruto";
            // 
            // textBoxBrutoRead
            // 
            this.textBoxBrutoRead.Location = new System.Drawing.Point(119, 149);
            this.textBoxBrutoRead.Name = "textBoxBrutoRead";
            this.textBoxBrutoRead.ReadOnly = true;
            this.textBoxBrutoRead.Size = new System.Drawing.Size(123, 23);
            this.textBoxBrutoRead.TabIndex = 2;
            // 
            // buttonDodaci
            // 
            this.buttonDodaci.Location = new System.Drawing.Point(6, 29);
            this.buttonDodaci.Name = "buttonDodaci";
            this.buttonDodaci.Size = new System.Drawing.Size(75, 23);
            this.buttonDodaci.TabIndex = 4;
            this.buttonDodaci.Text = "Dodaci";
            this.buttonDodaci.UseVisualStyleBackColor = true;
            this.buttonDodaci.Click += new System.EventHandler(this.ButtonDodaci_Click);
            // 
            // textBoxDodaci
            // 
            this.textBoxDodaci.Location = new System.Drawing.Point(6, 91);
            this.textBoxDodaci.Name = "textBoxDodaci";
            this.textBoxDodaci.ReadOnly = true;
            this.textBoxDodaci.Size = new System.Drawing.Size(123, 23);
            this.textBoxDodaci.TabIndex = 0;
            // 
            // labelDodaci
            // 
            this.labelDodaci.AutoSize = true;
            this.labelDodaci.Location = new System.Drawing.Point(6, 63);
            this.labelDodaci.Name = "labelDodaci";
            this.labelDodaci.Size = new System.Drawing.Size(88, 15);
            this.labelDodaci.TabIndex = 1;
            this.labelDodaci.Text = "Dodaci ukupno";
            // 
            // groupBoxDodaci
            // 
            this.groupBoxDodaci.Controls.Add(this.textBoxDodaci);
            this.groupBoxDodaci.Controls.Add(this.labelDodaci);
            this.groupBoxDodaci.Controls.Add(this.buttonDodaci);
            this.groupBoxDodaci.Location = new System.Drawing.Point(297, 149);
            this.groupBoxDodaci.Name = "groupBoxDodaci";
            this.groupBoxDodaci.Size = new System.Drawing.Size(369, 146);
            this.groupBoxDodaci.TabIndex = 1;
            this.groupBoxDodaci.TabStop = false;
            this.groupBoxDodaci.Text = "Dodaci na plaću";
            // 
            // groupBoxJoppd
            // 
            this.groupBoxJoppd.Controls.Add(this.buttonSpremiJoppdPostavke);
            this.groupBoxJoppd.Controls.Add(this.labelNacinIsplate);
            this.groupBoxJoppd.Controls.Add(this.comboBoxNacinIsplate);
            this.groupBoxJoppd.Controls.Add(this.labelPrimitak);
            this.groupBoxJoppd.Controls.Add(this.labelStjecatelj);
            this.groupBoxJoppd.Controls.Add(this.labelRadnoVrijeme);
            this.groupBoxJoppd.Controls.Add(this.labelPrviZadnjiMjesec);
            this.groupBoxJoppd.Controls.Add(this.labelInvaliditet);
            this.groupBoxJoppd.Controls.Add(this.labelOznakaDodatniMio);
            this.groupBoxJoppd.Controls.Add(this.comboBoxRadnoVrijeme);
            this.groupBoxJoppd.Controls.Add(this.comboBoxMjesecPrviZadnji);
            this.groupBoxJoppd.Controls.Add(this.comboBoxInvaliditet);
            this.groupBoxJoppd.Controls.Add(this.comboBoxDodatniMio);
            this.groupBoxJoppd.Controls.Add(this.comboBoxPrimitak);
            this.groupBoxJoppd.Controls.Add(this.comboBoxStjecatelj);
            this.groupBoxJoppd.Location = new System.Drawing.Point(297, 301);
            this.groupBoxJoppd.Name = "groupBoxJoppd";
            this.groupBoxJoppd.Size = new System.Drawing.Size(369, 287);
            this.groupBoxJoppd.TabIndex = 0;
            this.groupBoxJoppd.TabStop = false;
            this.groupBoxJoppd.Text = "Podaci za JOPPD obrazac";
            // 
            // buttonSpremiJoppdPostavke
            // 
            this.buttonSpremiJoppdPostavke.Location = new System.Drawing.Point(213, 22);
            this.buttonSpremiJoppdPostavke.Name = "buttonSpremiJoppdPostavke";
            this.buttonSpremiJoppdPostavke.Size = new System.Drawing.Size(150, 23);
            this.buttonSpremiJoppdPostavke.TabIndex = 12;
            this.buttonSpremiJoppdPostavke.Text = "Spremi JOPPD postavke";
            this.buttonSpremiJoppdPostavke.UseVisualStyleBackColor = true;
            this.buttonSpremiJoppdPostavke.Click += new System.EventHandler(this.ButtonSpremiJoppdPostavke_Click);
            // 
            // labelNacinIsplate
            // 
            this.labelNacinIsplate.AutoSize = true;
            this.labelNacinIsplate.Location = new System.Drawing.Point(133, 48);
            this.labelNacinIsplate.Name = "labelNacinIsplate";
            this.labelNacinIsplate.Size = new System.Drawing.Size(75, 15);
            this.labelNacinIsplate.TabIndex = 13;
            this.labelNacinIsplate.Text = "Način isplate";
            // 
            // comboBoxNacinIsplate
            // 
            this.comboBoxNacinIsplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNacinIsplate.DropDownWidth = 800;
            this.comboBoxNacinIsplate.FormattingEnabled = true;
            this.comboBoxNacinIsplate.Location = new System.Drawing.Point(6, 45);
            this.comboBoxNacinIsplate.Name = "comboBoxNacinIsplate";
            this.comboBoxNacinIsplate.Size = new System.Drawing.Size(121, 23);
            this.comboBoxNacinIsplate.TabIndex = 5;
            this.comboBoxNacinIsplate.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // labelPrimitak
            // 
            this.labelPrimitak.AutoSize = true;
            this.labelPrimitak.Location = new System.Drawing.Point(133, 115);
            this.labelPrimitak.Name = "labelPrimitak";
            this.labelPrimitak.Size = new System.Drawing.Size(93, 15);
            this.labelPrimitak.TabIndex = 14;
            this.labelPrimitak.Text = "Oznaka Primitka";
            // 
            // labelStjecatelj
            // 
            this.labelStjecatelj.AutoSize = true;
            this.labelStjecatelj.Location = new System.Drawing.Point(133, 83);
            this.labelStjecatelj.Name = "labelStjecatelj";
            this.labelStjecatelj.Size = new System.Drawing.Size(101, 15);
            this.labelStjecatelj.TabIndex = 15;
            this.labelStjecatelj.Text = "Oznaka stjecatelja";
            // 
            // labelRadnoVrijeme
            // 
            this.labelRadnoVrijeme.AutoSize = true;
            this.labelRadnoVrijeme.Location = new System.Drawing.Point(133, 245);
            this.labelRadnoVrijeme.Name = "labelRadnoVrijeme";
            this.labelRadnoVrijeme.Size = new System.Drawing.Size(192, 30);
            this.labelRadnoVrijeme.TabIndex = 16;
            this.labelRadnoVrijeme.Text = "Oznaka punog, nepunog, polovice \r\nradnog vremena";
            // 
            // labelPrviZadnjiMjesec
            // 
            this.labelPrviZadnjiMjesec.AutoSize = true;
            this.labelPrviZadnjiMjesec.Location = new System.Drawing.Point(133, 212);
            this.labelPrviZadnjiMjesec.Name = "labelPrviZadnjiMjesec";
            this.labelPrviZadnjiMjesec.Size = new System.Drawing.Size(216, 30);
            this.labelPrviZadnjiMjesec.TabIndex = 17;
            this.labelPrviZadnjiMjesec.Text = "Oznaka prvog/zadnjeg mjeseca u obv. \r\nmirovinskom osiguranju po istoj osnovi";
            // 
            // labelInvaliditet
            // 
            this.labelInvaliditet.AutoSize = true;
            this.labelInvaliditet.Location = new System.Drawing.Point(133, 176);
            this.labelInvaliditet.Name = "labelInvaliditet";
            this.labelInvaliditet.Size = new System.Drawing.Size(227, 30);
            this.labelInvaliditet.TabIndex = 18;
            this.labelInvaliditet.Text = "Oznaka posebnog doprinosa za poticanje \r\nzapošljavanja osoba sa invaliditetom";
            // 
            // labelOznakaDodatniMio
            // 
            this.labelOznakaDodatniMio.AutoSize = true;
            this.labelOznakaDodatniMio.Location = new System.Drawing.Point(133, 149);
            this.labelOznakaDodatniMio.Name = "labelOznakaDodatniMio";
            this.labelOznakaDodatniMio.Size = new System.Drawing.Size(195, 15);
            this.labelOznakaDodatniMio.TabIndex = 19;
            this.labelOznakaDodatniMio.Text = "Oznaka dodatnog doprinosa za Mio";
            // 
            // comboBoxRadnoVrijeme
            // 
            this.comboBoxRadnoVrijeme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRadnoVrijeme.DropDownWidth = 800;
            this.comboBoxRadnoVrijeme.FormattingEnabled = true;
            this.comboBoxRadnoVrijeme.Location = new System.Drawing.Point(6, 248);
            this.comboBoxRadnoVrijeme.Name = "comboBoxRadnoVrijeme";
            this.comboBoxRadnoVrijeme.Size = new System.Drawing.Size(121, 23);
            this.comboBoxRadnoVrijeme.TabIndex = 11;
            this.comboBoxRadnoVrijeme.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // comboBoxMjesecPrviZadnji
            // 
            this.comboBoxMjesecPrviZadnji.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMjesecPrviZadnji.DropDownWidth = 800;
            this.comboBoxMjesecPrviZadnji.FormattingEnabled = true;
            this.comboBoxMjesecPrviZadnji.Location = new System.Drawing.Point(6, 214);
            this.comboBoxMjesecPrviZadnji.Name = "comboBoxMjesecPrviZadnji";
            this.comboBoxMjesecPrviZadnji.Size = new System.Drawing.Size(121, 23);
            this.comboBoxMjesecPrviZadnji.TabIndex = 10;
            this.comboBoxMjesecPrviZadnji.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // comboBoxInvaliditet
            // 
            this.comboBoxInvaliditet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInvaliditet.DropDownWidth = 800;
            this.comboBoxInvaliditet.FormattingEnabled = true;
            this.comboBoxInvaliditet.Location = new System.Drawing.Point(6, 180);
            this.comboBoxInvaliditet.Name = "comboBoxInvaliditet";
            this.comboBoxInvaliditet.Size = new System.Drawing.Size(121, 23);
            this.comboBoxInvaliditet.TabIndex = 9;
            this.comboBoxInvaliditet.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // comboBoxDodatniMio
            // 
            this.comboBoxDodatniMio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDodatniMio.DropDownWidth = 800;
            this.comboBoxDodatniMio.FormattingEnabled = true;
            this.comboBoxDodatniMio.Location = new System.Drawing.Point(6, 146);
            this.comboBoxDodatniMio.Name = "comboBoxDodatniMio";
            this.comboBoxDodatniMio.Size = new System.Drawing.Size(121, 23);
            this.comboBoxDodatniMio.TabIndex = 8;
            this.comboBoxDodatniMio.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // comboBoxPrimitak
            // 
            this.comboBoxPrimitak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrimitak.DropDownWidth = 800;
            this.comboBoxPrimitak.FormattingEnabled = true;
            this.comboBoxPrimitak.Location = new System.Drawing.Point(6, 112);
            this.comboBoxPrimitak.Name = "comboBoxPrimitak";
            this.comboBoxPrimitak.Size = new System.Drawing.Size(121, 23);
            this.comboBoxPrimitak.TabIndex = 7;
            this.comboBoxPrimitak.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // comboBoxStjecatelj
            // 
            this.comboBoxStjecatelj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStjecatelj.DropDownWidth = 800;
            this.comboBoxStjecatelj.FormattingEnabled = true;
            this.comboBoxStjecatelj.Location = new System.Drawing.Point(6, 78);
            this.comboBoxStjecatelj.Name = "comboBoxStjecatelj";
            this.comboBoxStjecatelj.Size = new System.Drawing.Size(121, 23);
            this.comboBoxStjecatelj.TabIndex = 6;
            this.comboBoxStjecatelj.SelectionChangeCommitted += new System.EventHandler(this.PromjenaZaposlenikJoppd_SelectionChangeCommitted);
            // 
            // PlacaIzracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 644);
            this.Controls.Add(this.groupBoxJoppd);
            this.Controls.Add(this.groupBoxDodaci);
            this.Controls.Add(this.textBoxBrutoRead);
            this.Controls.Add(this.labelBrutoRaed);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxDoprinosZdravstvo);
            this.Controls.Add(this.textBoxNetto);
            this.Controls.Add(this.textBoxUkupnoPorezPrirez);
            this.Controls.Add(this.textBoxPrirez);
            this.Controls.Add(this.textBoxPorezUkupno);
            this.Controls.Add(this.textBoxPorez2);
            this.Controls.Add(this.textBoxPorez1);
            this.Controls.Add(this.textBoxPoreznaOsnovica);
            this.Controls.Add(this.textBoxOdbitak);
            this.Controls.Add(this.labelDoprinosZdravstvo);
            this.Controls.Add(this.labelNetto);
            this.Controls.Add(this.labelUkupnoPorezPrirez);
            this.Controls.Add(this.labelPrirez);
            this.Controls.Add(this.labelPorezUkupno);
            this.Controls.Add(this.labelPorez2);
            this.Controls.Add(this.labelPorez1);
            this.Controls.Add(this.labelPoreznaOsnovica);
            this.Controls.Add(this.labelOsobniOdbitak);
            this.Controls.Add(this.textBoxDohodak);
            this.Controls.Add(this.labelDohodak);
            this.Controls.Add(this.textBoxMio2);
            this.Controls.Add(this.textBoxMio1);
            this.Controls.Add(this.labelMio2);
            this.Controls.Add(this.labelMio1);
            this.Controls.Add(this.buttonIzracunaj);
            this.Controls.Add(this.checkBoxSamoMio1);
            this.Controls.Add(this.textBoxBruto);
            this.Controls.Add(this.labelBruto);
            this.Controls.Add(this.labelOdabirZaposlenika);
            this.Controls.Add(this.comboBoxZaposlenik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PlacaIzracunForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izračun plaće";
            this.groupBoxDodaci.ResumeLayout(false);
            this.groupBoxDodaci.PerformLayout();
            this.groupBoxJoppd.ResumeLayout(false);
            this.groupBoxJoppd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ComboBoxPrimitak_DropDown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxZaposlenik;
        private System.Windows.Forms.Label labelOdabirZaposlenika;
        private System.Windows.Forms.Label labelBruto;
        private System.Windows.Forms.TextBox textBoxBruto;
        private System.Windows.Forms.CheckBox checkBoxSamoMio1;
        private System.Windows.Forms.Button buttonIzracunaj;
        private System.Windows.Forms.Label labelMio1;
        private System.Windows.Forms.Label labelMio2;
        private System.Windows.Forms.TextBox textBoxMio1;
        private System.Windows.Forms.TextBox textBoxMio2;
        private System.Windows.Forms.Label labelDohodak;
        private System.Windows.Forms.TextBox textBoxDohodak;
        private System.Windows.Forms.Label labelOsobniOdbitak;
        private System.Windows.Forms.Label labelPoreznaOsnovica;
        private System.Windows.Forms.Label labelPorez1;
        private System.Windows.Forms.Label labelPorez2;
        private System.Windows.Forms.Label labelPorezUkupno;
        private System.Windows.Forms.Label labelPrirez;
        private System.Windows.Forms.Label labelUkupnoPorezPrirez;
        private System.Windows.Forms.Label labelNetto;
        private System.Windows.Forms.Label labelDoprinosZdravstvo;
        private System.Windows.Forms.TextBox textBoxOdbitak;
        private System.Windows.Forms.TextBox textBoxPoreznaOsnovica;
        private System.Windows.Forms.TextBox textBoxPorez1;
        private System.Windows.Forms.TextBox textBoxPorez2;
        private System.Windows.Forms.TextBox textBoxPorezUkupno;
        private System.Windows.Forms.TextBox textBoxPrirez;
        private System.Windows.Forms.TextBox textBoxUkupnoPorezPrirez;
        private System.Windows.Forms.TextBox textBoxNetto;
        private System.Windows.Forms.TextBox textBoxDoprinosZdravstvo;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelBrutoRaed;
        private System.Windows.Forms.TextBox textBoxBrutoRead;
        private System.Windows.Forms.Button buttonDodaci;
        private System.Windows.Forms.TextBox textBoxDodaci;
        private System.Windows.Forms.Label labelDodaci;
        private System.Windows.Forms.GroupBox groupBoxDodaci;
        private System.Windows.Forms.GroupBox groupBoxJoppd;
        private System.Windows.Forms.Label labelPrimitak;
        private System.Windows.Forms.Label labelStjecatelj;
        private System.Windows.Forms.Label labelRadnoVrijeme;
        private System.Windows.Forms.Label labelPrviZadnjiMjesec;
        private System.Windows.Forms.Label labelInvaliditet;
        private System.Windows.Forms.Label labelOznakaDodatniMio;
        private System.Windows.Forms.ComboBox comboBoxRadnoVrijeme;
        private System.Windows.Forms.ComboBox comboBoxMjesecPrviZadnji;
        private System.Windows.Forms.ComboBox comboBoxInvaliditet;
        private System.Windows.Forms.ComboBox comboBoxDodatniMio;
        private System.Windows.Forms.ComboBox comboBoxPrimitak;
        private System.Windows.Forms.ComboBox comboBoxStjecatelj;
        private System.Windows.Forms.Label labelNacinIsplate;
        private System.Windows.Forms.ComboBox comboBoxNacinIsplate;
        private System.Windows.Forms.Button buttonSpremiJoppdPostavke;
    }
}
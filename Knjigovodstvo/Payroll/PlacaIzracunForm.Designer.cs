namespace Knjigovodstvo.Payroll
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
            this.labelPorez24 = new System.Windows.Forms.Label();
            this.labelPorez36 = new System.Windows.Forms.Label();
            this.labelPorezUkupno = new System.Windows.Forms.Label();
            this.labelPrirez = new System.Windows.Forms.Label();
            this.labelUkupnoPorezPrirez = new System.Windows.Forms.Label();
            this.labelNetto = new System.Windows.Forms.Label();
            this.labelDoprinosZdravstvo = new System.Windows.Forms.Label();
            this.textBoxOdbitak = new System.Windows.Forms.TextBox();
            this.textBoxPoreznaOsnovica = new System.Windows.Forms.TextBox();
            this.textBoxPorez24 = new System.Windows.Forms.TextBox();
            this.textBoxPorez36 = new System.Windows.Forms.TextBox();
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
            this.labelPrirezStopa = new System.Windows.Forms.Label();
            this.groupBoxDodaci.SuspendLayout();
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
            this.labelOdabirZaposlenika.TabIndex = 1;
            this.labelOdabirZaposlenika.Text = "Odabir zaposlenika";
            // 
            // labelBruto
            // 
            this.labelBruto.AutoSize = true;
            this.labelBruto.Location = new System.Drawing.Point(12, 62);
            this.labelBruto.Name = "labelBruto";
            this.labelBruto.Size = new System.Drawing.Size(39, 15);
            this.labelBruto.TabIndex = 2;
            this.labelBruto.Text = "Bruto:";
            // 
            // textBoxBruto
            // 
            this.textBoxBruto.Location = new System.Drawing.Point(57, 59);
            this.textBoxBruto.Name = "textBoxBruto";
            this.textBoxBruto.Size = new System.Drawing.Size(150, 23);
            this.textBoxBruto.TabIndex = 3;
            this.textBoxBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBoxSamoMio1
            // 
            this.checkBoxSamoMio1.AutoSize = true;
            this.checkBoxSamoMio1.Location = new System.Drawing.Point(229, 61);
            this.checkBoxSamoMio1.Name = "checkBoxSamoMio1";
            this.checkBoxSamoMio1.Size = new System.Drawing.Size(213, 19);
            this.checkBoxSamoMio1.TabIndex = 4;
            this.checkBoxSamoMio1.Text = "Mirovinsko osiguranje samo 1. stup";
            this.checkBoxSamoMio1.UseVisualStyleBackColor = true;
            // 
            // buttonIzracunaj
            // 
            this.buttonIzracunaj.Location = new System.Drawing.Point(12, 100);
            this.buttonIzracunaj.Name = "buttonIzracunaj";
            this.buttonIzracunaj.Size = new System.Drawing.Size(75, 23);
            this.buttonIzracunaj.TabIndex = 5;
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
            this.labelMio1.TabIndex = 6;
            this.labelMio1.Text = "Mio 1. stup";
            // 
            // labelMio2
            // 
            this.labelMio2.AutoSize = true;
            this.labelMio2.Location = new System.Drawing.Point(10, 214);
            this.labelMio2.Name = "labelMio2";
            this.labelMio2.Size = new System.Drawing.Size(66, 15);
            this.labelMio2.TabIndex = 6;
            this.labelMio2.Text = "Mio 2. stup";
            // 
            // textBoxMio1
            // 
            this.textBoxMio1.Location = new System.Drawing.Point(119, 180);
            this.textBoxMio1.Name = "textBoxMio1";
            this.textBoxMio1.ReadOnly = true;
            this.textBoxMio1.Size = new System.Drawing.Size(123, 23);
            this.textBoxMio1.TabIndex = 7;
            // 
            // textBoxMio2
            // 
            this.textBoxMio2.Location = new System.Drawing.Point(119, 211);
            this.textBoxMio2.Name = "textBoxMio2";
            this.textBoxMio2.ReadOnly = true;
            this.textBoxMio2.Size = new System.Drawing.Size(123, 23);
            this.textBoxMio2.TabIndex = 7;
            // 
            // labelDohodak
            // 
            this.labelDohodak.AutoSize = true;
            this.labelDohodak.Location = new System.Drawing.Point(10, 247);
            this.labelDohodak.Name = "labelDohodak";
            this.labelDohodak.Size = new System.Drawing.Size(55, 15);
            this.labelDohodak.TabIndex = 8;
            this.labelDohodak.Text = "Dohodak";
            // 
            // textBoxDohodak
            // 
            this.textBoxDohodak.Location = new System.Drawing.Point(119, 244);
            this.textBoxDohodak.Name = "textBoxDohodak";
            this.textBoxDohodak.ReadOnly = true;
            this.textBoxDohodak.Size = new System.Drawing.Size(123, 23);
            this.textBoxDohodak.TabIndex = 7;
            // 
            // labelOsobniOdbitak
            // 
            this.labelOsobniOdbitak.AutoSize = true;
            this.labelOsobniOdbitak.Location = new System.Drawing.Point(10, 280);
            this.labelOsobniOdbitak.Name = "labelOsobniOdbitak";
            this.labelOsobniOdbitak.Size = new System.Drawing.Size(90, 15);
            this.labelOsobniOdbitak.TabIndex = 9;
            this.labelOsobniOdbitak.Text = "Osobni Odbitak";
            // 
            // labelPoreznaOsnovica
            // 
            this.labelPoreznaOsnovica.AutoSize = true;
            this.labelPoreznaOsnovica.Location = new System.Drawing.Point(10, 313);
            this.labelPoreznaOsnovica.Name = "labelPoreznaOsnovica";
            this.labelPoreznaOsnovica.Size = new System.Drawing.Size(99, 15);
            this.labelPoreznaOsnovica.TabIndex = 10;
            this.labelPoreznaOsnovica.Text = "Porezna osnovica";
            // 
            // labelPorez24
            // 
            this.labelPorez24.AutoSize = true;
            this.labelPorez24.Location = new System.Drawing.Point(10, 346);
            this.labelPorez24.Name = "labelPorez24";
            this.labelPorez24.Size = new System.Drawing.Size(61, 15);
            this.labelPorez24.TabIndex = 11;
            this.labelPorez24.Text = "Porez 24%";
            // 
            // labelPorez36
            // 
            this.labelPorez36.AutoSize = true;
            this.labelPorez36.Location = new System.Drawing.Point(10, 379);
            this.labelPorez36.Name = "labelPorez36";
            this.labelPorez36.Size = new System.Drawing.Size(61, 15);
            this.labelPorez36.TabIndex = 12;
            this.labelPorez36.Text = "Porez 36%";
            // 
            // labelPorezUkupno
            // 
            this.labelPorezUkupno.AutoSize = true;
            this.labelPorezUkupno.Location = new System.Drawing.Point(10, 412);
            this.labelPorezUkupno.Name = "labelPorezUkupno";
            this.labelPorezUkupno.Size = new System.Drawing.Size(80, 15);
            this.labelPorezUkupno.TabIndex = 13;
            this.labelPorezUkupno.Text = "Porez ukupno";
            // 
            // labelPrirez
            // 
            this.labelPrirez.AutoSize = true;
            this.labelPrirez.Location = new System.Drawing.Point(10, 445);
            this.labelPrirez.Name = "labelPrirez";
            this.labelPrirez.Size = new System.Drawing.Size(36, 15);
            this.labelPrirez.TabIndex = 14;
            this.labelPrirez.Text = "Prirez";
            // 
            // labelUkupnoPorezPrirez
            // 
            this.labelUkupnoPorezPrirez.AutoSize = true;
            this.labelUkupnoPorezPrirez.Location = new System.Drawing.Point(10, 478);
            this.labelUkupnoPorezPrirez.Name = "labelUkupnoPorezPrirez";
            this.labelUkupnoPorezPrirez.Size = new System.Drawing.Size(94, 15);
            this.labelUkupnoPorezPrirez.TabIndex = 15;
            this.labelUkupnoPorezPrirez.Text = "Uk. porez i prirez";
            // 
            // labelNetto
            // 
            this.labelNetto.AutoSize = true;
            this.labelNetto.Location = new System.Drawing.Point(10, 511);
            this.labelNetto.Name = "labelNetto";
            this.labelNetto.Size = new System.Drawing.Size(37, 15);
            this.labelNetto.TabIndex = 16;
            this.labelNetto.Text = "Netto";
            // 
            // labelDoprinosZdravstvo
            // 
            this.labelDoprinosZdravstvo.AutoSize = true;
            this.labelDoprinosZdravstvo.Location = new System.Drawing.Point(11, 544);
            this.labelDoprinosZdravstvo.Name = "labelDoprinosZdravstvo";
            this.labelDoprinosZdravstvo.Size = new System.Drawing.Size(108, 15);
            this.labelDoprinosZdravstvo.TabIndex = 17;
            this.labelDoprinosZdravstvo.Text = "Doprinos zdravstvo";
            // 
            // textBoxOdbitak
            // 
            this.textBoxOdbitak.Location = new System.Drawing.Point(119, 277);
            this.textBoxOdbitak.Name = "textBoxOdbitak";
            this.textBoxOdbitak.ReadOnly = true;
            this.textBoxOdbitak.Size = new System.Drawing.Size(123, 23);
            this.textBoxOdbitak.TabIndex = 7;
            // 
            // textBoxPoreznaOsnovica
            // 
            this.textBoxPoreznaOsnovica.Location = new System.Drawing.Point(119, 310);
            this.textBoxPoreznaOsnovica.Name = "textBoxPoreznaOsnovica";
            this.textBoxPoreznaOsnovica.ReadOnly = true;
            this.textBoxPoreznaOsnovica.Size = new System.Drawing.Size(123, 23);
            this.textBoxPoreznaOsnovica.TabIndex = 7;
            // 
            // textBoxPorez24
            // 
            this.textBoxPorez24.Location = new System.Drawing.Point(119, 343);
            this.textBoxPorez24.Name = "textBoxPorez24";
            this.textBoxPorez24.ReadOnly = true;
            this.textBoxPorez24.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorez24.TabIndex = 7;
            // 
            // textBoxPorez36
            // 
            this.textBoxPorez36.Location = new System.Drawing.Point(119, 376);
            this.textBoxPorez36.Name = "textBoxPorez36";
            this.textBoxPorez36.ReadOnly = true;
            this.textBoxPorez36.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorez36.TabIndex = 7;
            // 
            // textBoxPorezUkupno
            // 
            this.textBoxPorezUkupno.Location = new System.Drawing.Point(119, 409);
            this.textBoxPorezUkupno.Name = "textBoxPorezUkupno";
            this.textBoxPorezUkupno.ReadOnly = true;
            this.textBoxPorezUkupno.Size = new System.Drawing.Size(123, 23);
            this.textBoxPorezUkupno.TabIndex = 7;
            // 
            // textBoxPrirez
            // 
            this.textBoxPrirez.Location = new System.Drawing.Point(119, 442);
            this.textBoxPrirez.Name = "textBoxPrirez";
            this.textBoxPrirez.ReadOnly = true;
            this.textBoxPrirez.Size = new System.Drawing.Size(123, 23);
            this.textBoxPrirez.TabIndex = 7;
            // 
            // textBoxUkupnoPorezPrirez
            // 
            this.textBoxUkupnoPorezPrirez.Location = new System.Drawing.Point(119, 475);
            this.textBoxUkupnoPorezPrirez.Name = "textBoxUkupnoPorezPrirez";
            this.textBoxUkupnoPorezPrirez.ReadOnly = true;
            this.textBoxUkupnoPorezPrirez.Size = new System.Drawing.Size(123, 23);
            this.textBoxUkupnoPorezPrirez.TabIndex = 7;
            // 
            // textBoxNetto
            // 
            this.textBoxNetto.Location = new System.Drawing.Point(119, 508);
            this.textBoxNetto.Name = "textBoxNetto";
            this.textBoxNetto.ReadOnly = true;
            this.textBoxNetto.Size = new System.Drawing.Size(123, 23);
            this.textBoxNetto.TabIndex = 7;
            // 
            // textBoxDoprinosZdravstvo
            // 
            this.textBoxDoprinosZdravstvo.Location = new System.Drawing.Point(119, 541);
            this.textBoxDoprinosZdravstvo.Name = "textBoxDoprinosZdravstvo";
            this.textBoxDoprinosZdravstvo.ReadOnly = true;
            this.textBoxDoprinosZdravstvo.Size = new System.Drawing.Size(123, 23);
            this.textBoxDoprinosZdravstvo.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(281, 552);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(365, 552);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 19;
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
            this.labelBrutoRaed.TabIndex = 6;
            this.labelBrutoRaed.Text = "Bruto";
            // 
            // textBoxBrutoRead
            // 
            this.textBoxBrutoRead.Location = new System.Drawing.Point(119, 149);
            this.textBoxBrutoRead.Name = "textBoxBrutoRead";
            this.textBoxBrutoRead.ReadOnly = true;
            this.textBoxBrutoRead.Size = new System.Drawing.Size(123, 23);
            this.textBoxBrutoRead.TabIndex = 7;
            // 
            // buttonDodaci
            // 
            this.buttonDodaci.Location = new System.Drawing.Point(6, 29);
            this.buttonDodaci.Name = "buttonDodaci";
            this.buttonDodaci.Size = new System.Drawing.Size(75, 23);
            this.buttonDodaci.TabIndex = 20;
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
            this.textBoxDodaci.TabIndex = 7;
            // 
            // labelDodaci
            // 
            this.labelDodaci.AutoSize = true;
            this.labelDodaci.Location = new System.Drawing.Point(6, 63);
            this.labelDodaci.Name = "labelDodaci";
            this.labelDodaci.Size = new System.Drawing.Size(88, 15);
            this.labelDodaci.TabIndex = 21;
            this.labelDodaci.Text = "Dodaci ukupno";
            // 
            // groupBoxDodaci
            // 
            this.groupBoxDodaci.Controls.Add(this.textBoxDodaci);
            this.groupBoxDodaci.Controls.Add(this.labelDodaci);
            this.groupBoxDodaci.Controls.Add(this.buttonDodaci);
            this.groupBoxDodaci.Location = new System.Drawing.Point(279, 149);
            this.groupBoxDodaci.Name = "groupBoxDodaci";
            this.groupBoxDodaci.Size = new System.Drawing.Size(161, 163);
            this.groupBoxDodaci.TabIndex = 22;
            this.groupBoxDodaci.TabStop = false;
            this.groupBoxDodaci.Text = "Dodaci na plaću";
            // 
            // labelPrirezStopa
            // 
            this.labelPrirezStopa.AutoSize = true;
            this.labelPrirezStopa.Location = new System.Drawing.Point(248, 445);
            this.labelPrirezStopa.Name = "labelPrirezStopa";
            this.labelPrirezStopa.Size = new System.Drawing.Size(23, 15);
            this.labelPrirezStopa.TabIndex = 23;
            this.labelPrirezStopa.Text = "0%";
            // 
            // PlacaIzracunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 587);
            this.Controls.Add(this.labelPrirezStopa);
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
            this.Controls.Add(this.textBoxPorez36);
            this.Controls.Add(this.textBoxPorez24);
            this.Controls.Add(this.textBoxPoreznaOsnovica);
            this.Controls.Add(this.textBoxOdbitak);
            this.Controls.Add(this.labelDoprinosZdravstvo);
            this.Controls.Add(this.labelNetto);
            this.Controls.Add(this.labelUkupnoPorezPrirez);
            this.Controls.Add(this.labelPrirez);
            this.Controls.Add(this.labelPorezUkupno);
            this.Controls.Add(this.labelPorez36);
            this.Controls.Add(this.labelPorez24);
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
            this.Name = "PlacaIzracunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izračun plaće";
            this.groupBoxDodaci.ResumeLayout(false);
            this.groupBoxDodaci.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label labelPorez24;
        private System.Windows.Forms.Label labelPorez36;
        private System.Windows.Forms.Label labelPorezUkupno;
        private System.Windows.Forms.Label labelPrirez;
        private System.Windows.Forms.Label labelUkupnoPorezPrirez;
        private System.Windows.Forms.Label labelNetto;
        private System.Windows.Forms.Label labelDoprinosZdravstvo;
        private System.Windows.Forms.TextBox textBoxOdbitak;
        private System.Windows.Forms.TextBox textBoxPoreznaOsnovica;
        private System.Windows.Forms.TextBox textBoxPorez24;
        private System.Windows.Forms.TextBox textBoxPorez36;
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
        private System.Windows.Forms.Label labelPrirezStopa;
    }
}
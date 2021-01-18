
namespace Knjigovodstvo.Books.Inventory
{
    partial class OsnovnoSredstvoDodajForm
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
            this.labelNaziv = new System.Windows.Forms.Label();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.labelDatumNabave = new System.Windows.Forms.Label();
            this.labelDatumUporabe = new System.Windows.Forms.Label();
            this.dateTimePickerDatumNabave = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatumUporabe = new System.Windows.Forms.DateTimePicker();
            this.textBoxDobavljac = new System.Windows.Forms.TextBox();
            this.labelDobavljac = new System.Windows.Forms.Label();
            this.textBoxDokument = new System.Windows.Forms.TextBox();
            this.labelDokument = new System.Windows.Forms.Label();
            this.textBoxKolicina = new System.Windows.Forms.TextBox();
            this.labelKolicina = new System.Windows.Forms.Label();
            this.textBoxNabavnaVrijednost = new System.Windows.Forms.TextBox();
            this.labelNabavnaVrijednost = new System.Windows.Forms.Label();
            this.textBoxVijekTrajanja = new System.Windows.Forms.TextBox();
            this.labelVijekTrajanja = new System.Windows.Forms.Label();
            this.textBoxStopaOtpisa = new System.Windows.Forms.TextBox();
            this.labelStopaOtpisa = new System.Windows.Forms.Label();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(12, 37);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(36, 15);
            this.labelNaziv.TabIndex = 0;
            this.labelNaziv.Text = "Naziv";
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(125, 34);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(186, 23);
            this.textBoxNaziv.TabIndex = 1;
            // 
            // labelDatumNabave
            // 
            this.labelDatumNabave.AutoSize = true;
            this.labelDatumNabave.Location = new System.Drawing.Point(12, 80);
            this.labelDatumNabave.Name = "labelDatumNabave";
            this.labelDatumNabave.Size = new System.Drawing.Size(84, 15);
            this.labelDatumNabave.TabIndex = 2;
            this.labelDatumNabave.Text = "Datum nabave";
            // 
            // labelDatumUporabe
            // 
            this.labelDatumUporabe.AutoSize = true;
            this.labelDatumUporabe.Location = new System.Drawing.Point(12, 120);
            this.labelDatumUporabe.Name = "labelDatumUporabe";
            this.labelDatumUporabe.Size = new System.Drawing.Size(90, 15);
            this.labelDatumUporabe.TabIndex = 3;
            this.labelDatumUporabe.Text = "Datum uporabe";
            // 
            // dateTimePickerDatumNabave
            // 
            this.dateTimePickerDatumNabave.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumNabave.Location = new System.Drawing.Point(125, 74);
            this.dateTimePickerDatumNabave.Name = "dateTimePickerDatumNabave";
            this.dateTimePickerDatumNabave.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDatumNabave.TabIndex = 4;
            // 
            // dateTimePickerDatumUporabe
            // 
            this.dateTimePickerDatumUporabe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDatumUporabe.Location = new System.Drawing.Point(125, 114);
            this.dateTimePickerDatumUporabe.Name = "dateTimePickerDatumUporabe";
            this.dateTimePickerDatumUporabe.Size = new System.Drawing.Size(100, 23);
            this.dateTimePickerDatumUporabe.TabIndex = 5;
            // 
            // textBoxDobavljac
            // 
            this.textBoxDobavljac.Location = new System.Drawing.Point(125, 154);
            this.textBoxDobavljac.Name = "textBoxDobavljac";
            this.textBoxDobavljac.Size = new System.Drawing.Size(186, 23);
            this.textBoxDobavljac.TabIndex = 7;
            // 
            // labelDobavljac
            // 
            this.labelDobavljac.AutoSize = true;
            this.labelDobavljac.Location = new System.Drawing.Point(12, 157);
            this.labelDobavljac.Name = "labelDobavljac";
            this.labelDobavljac.Size = new System.Drawing.Size(59, 15);
            this.labelDobavljac.TabIndex = 6;
            this.labelDobavljac.Text = "Dobavljač";
            // 
            // textBoxDokument
            // 
            this.textBoxDokument.Location = new System.Drawing.Point(125, 194);
            this.textBoxDokument.Name = "textBoxDokument";
            this.textBoxDokument.Size = new System.Drawing.Size(186, 23);
            this.textBoxDokument.TabIndex = 9;
            // 
            // labelDokument
            // 
            this.labelDokument.AutoSize = true;
            this.labelDokument.Location = new System.Drawing.Point(12, 197);
            this.labelDokument.Name = "labelDokument";
            this.labelDokument.Size = new System.Drawing.Size(63, 15);
            this.labelDokument.TabIndex = 8;
            this.labelDokument.Text = "Dokument";
            // 
            // textBoxKolicina
            // 
            this.textBoxKolicina.Location = new System.Drawing.Point(125, 234);
            this.textBoxKolicina.Name = "textBoxKolicina";
            this.textBoxKolicina.Size = new System.Drawing.Size(49, 23);
            this.textBoxKolicina.TabIndex = 11;
            this.textBoxKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBox_KeyPress);
            // 
            // labelKolicina
            // 
            this.labelKolicina.AutoSize = true;
            this.labelKolicina.Location = new System.Drawing.Point(12, 237);
            this.labelKolicina.Name = "labelKolicina";
            this.labelKolicina.Size = new System.Drawing.Size(49, 15);
            this.labelKolicina.TabIndex = 10;
            this.labelKolicina.Text = "Količina";
            // 
            // textBoxNabavnaVrijednost
            // 
            this.textBoxNabavnaVrijednost.Location = new System.Drawing.Point(125, 274);
            this.textBoxNabavnaVrijednost.Name = "textBoxNabavnaVrijednost";
            this.textBoxNabavnaVrijednost.Size = new System.Drawing.Size(186, 23);
            this.textBoxNabavnaVrijednost.TabIndex = 13;
            this.textBoxNabavnaVrijednost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBox_KeyPress);
            // 
            // labelNabavnaVrijednost
            // 
            this.labelNabavnaVrijednost.AutoSize = true;
            this.labelNabavnaVrijednost.Location = new System.Drawing.Point(12, 277);
            this.labelNabavnaVrijednost.Name = "labelNabavnaVrijednost";
            this.labelNabavnaVrijednost.Size = new System.Drawing.Size(109, 15);
            this.labelNabavnaVrijednost.TabIndex = 12;
            this.labelNabavnaVrijednost.Text = "Nabavna vrijednost";
            // 
            // textBoxVijekTrajanja
            // 
            this.textBoxVijekTrajanja.Location = new System.Drawing.Point(125, 314);
            this.textBoxVijekTrajanja.Name = "textBoxVijekTrajanja";
            this.textBoxVijekTrajanja.Size = new System.Drawing.Size(49, 23);
            this.textBoxVijekTrajanja.TabIndex = 15;
            this.textBoxVijekTrajanja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBox_KeyPress);
            // 
            // labelVijekTrajanja
            // 
            this.labelVijekTrajanja.AutoSize = true;
            this.labelVijekTrajanja.Location = new System.Drawing.Point(12, 317);
            this.labelVijekTrajanja.Name = "labelVijekTrajanja";
            this.labelVijekTrajanja.Size = new System.Drawing.Size(74, 15);
            this.labelVijekTrajanja.TabIndex = 14;
            this.labelVijekTrajanja.Text = "Vijek trajanja";
            // 
            // textBoxStopaOtpisa
            // 
            this.textBoxStopaOtpisa.Location = new System.Drawing.Point(125, 354);
            this.textBoxStopaOtpisa.Name = "textBoxStopaOtpisa";
            this.textBoxStopaOtpisa.Size = new System.Drawing.Size(49, 23);
            this.textBoxStopaOtpisa.TabIndex = 17;
            this.labelStopaOtpisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBox_KeyPress);
            // 
            // labelStopaOtpisa
            // 
            this.labelStopaOtpisa.AutoSize = true;
            this.labelStopaOtpisa.Location = new System.Drawing.Point(12, 357);
            this.labelStopaOtpisa.Name = "labelStopaOtpisa";
            this.labelStopaOtpisa.Size = new System.Drawing.Size(72, 15);
            this.labelStopaOtpisa.TabIndex = 16;
            this.labelStopaOtpisa.Text = "Stopa otpisa";
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(13, 433);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 18;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // OsnovnoSredstvoDodajForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 468);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.textBoxStopaOtpisa);
            this.Controls.Add(this.labelStopaOtpisa);
            this.Controls.Add(this.textBoxVijekTrajanja);
            this.Controls.Add(this.labelVijekTrajanja);
            this.Controls.Add(this.textBoxNabavnaVrijednost);
            this.Controls.Add(this.labelNabavnaVrijednost);
            this.Controls.Add(this.textBoxKolicina);
            this.Controls.Add(this.labelKolicina);
            this.Controls.Add(this.textBoxDokument);
            this.Controls.Add(this.labelDokument);
            this.Controls.Add(this.textBoxDobavljac);
            this.Controls.Add(this.labelDobavljac);
            this.Controls.Add(this.dateTimePickerDatumUporabe);
            this.Controls.Add(this.dateTimePickerDatumNabave);
            this.Controls.Add(this.labelDatumUporabe);
            this.Controls.Add(this.labelDatumNabave);
            this.Controls.Add(this.textBoxNaziv);
            this.Controls.Add(this.labelNaziv);
            this.Name = "OsnovnoSredstvoDodajForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodavanje novog osnovnog sredstva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.Label labelDatumNabave;
        private System.Windows.Forms.Label labelDatumUporabe;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumNabave;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumUporabe;
        private System.Windows.Forms.TextBox textBoxDobavljac;
        private System.Windows.Forms.Label labelDobavljac;
        private System.Windows.Forms.TextBox textBoxDokument;
        private System.Windows.Forms.Label labelDokument;
        private System.Windows.Forms.TextBox textBoxKolicina;
        private System.Windows.Forms.Label labelKolicina;
        private System.Windows.Forms.TextBox textBoxNabavnaVrijednost;
        private System.Windows.Forms.Label labelNabavnaVrijednost;
        private System.Windows.Forms.TextBox textBoxVijekTrajanja;
        private System.Windows.Forms.Label labelVijekTrajanja;
        private System.Windows.Forms.TextBox textBoxStopaOtpisa;
        private System.Windows.Forms.Label labelStopaOtpisa;
        private System.Windows.Forms.Button buttonSpremi;
    }
}
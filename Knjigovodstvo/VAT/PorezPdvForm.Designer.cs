namespace Knjigovodstvo
{
    partial class PorezPdvForm
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
            this.groupBoxRazdoblje = new System.Windows.Forms.GroupBox();
            this.labelRazdobljeDo = new System.Windows.Forms.Label();
            this.labelRazdobljeOd = new System.Windows.Forms.Label();
            this.dateTimePickerDo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOd = new System.Windows.Forms.DateTimePicker();
            this.buttonIzracunaj = new System.Windows.Forms.Button();
            this.groupBoxIznosi = new System.Windows.Forms.GroupBox();
            this.groupBoxPorez = new System.Windows.Forms.GroupBox();
            this.labelIzPorUkupno = new System.Windows.Forms.Label();
            this.labelIzPor25 = new System.Windows.Forms.Label();
            this.labelIzPor13 = new System.Windows.Forms.Label();
            this.labelIzPor5 = new System.Windows.Forms.Label();
            this.labelIzPorOsUkupno = new System.Windows.Forms.Label();
            this.labelIzPorOs25 = new System.Windows.Forms.Label();
            this.labelPorOsUkupno = new System.Windows.Forms.Label();
            this.labelIzPorOs13 = new System.Windows.Forms.Label();
            this.labelPorUkupno = new System.Windows.Forms.Label();
            this.labelIzPorOs5 = new System.Windows.Forms.Label();
            this.labelPor25 = new System.Windows.Forms.Label();
            this.labelPorOs5 = new System.Windows.Forms.Label();
            this.labelPor13 = new System.Windows.Forms.Label();
            this.labelPorOs13 = new System.Windows.Forms.Label();
            this.labelPor5 = new System.Windows.Forms.Label();
            this.PorOs25 = new System.Windows.Forms.Label();
            this.groupBoxPretporez = new System.Windows.Forms.GroupBox();
            this.labelIzPpUkupno = new System.Windows.Forms.Label();
            this.labelIzPp25 = new System.Windows.Forms.Label();
            this.labelIzPp13 = new System.Windows.Forms.Label();
            this.labelIzPp5 = new System.Windows.Forms.Label();
            this.labelIzPpOsUkupno = new System.Windows.Forms.Label();
            this.labelIzPpOs25 = new System.Windows.Forms.Label();
            this.labelIzPpOs13 = new System.Windows.Forms.Label();
            this.labelIznPpOs5 = new System.Windows.Forms.Label();
            this.labelPpUkupno = new System.Windows.Forms.Label();
            this.labelPpOsUkupno = new System.Windows.Forms.Label();
            this.labelPp25 = new System.Windows.Forms.Label();
            this.labelPpOs5 = new System.Windows.Forms.Label();
            this.labelPp13 = new System.Windows.Forms.Label();
            this.labelPpOs13 = new System.Windows.Forms.Label();
            this.labelPp5 = new System.Windows.Forms.Label();
            this.labelPpOs25 = new System.Windows.Forms.Label();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.labelZaUplatu = new System.Windows.Forms.Label();
            this.labelIznZaUplatu = new System.Windows.Forms.Label();
            this.groupBoxRazdoblje.SuspendLayout();
            this.groupBoxIznosi.SuspendLayout();
            this.groupBoxPorez.SuspendLayout();
            this.groupBoxPretporez.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBoxRazdoblje.TabIndex = 3;
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
            // dateTimePickerDo
            // 
            this.dateTimePickerDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDo.Location = new System.Drawing.Point(34, 52);
            this.dateTimePickerDo.Name = "dateTimePickerDo";
            this.dateTimePickerDo.Size = new System.Drawing.Size(88, 23);
            this.dateTimePickerDo.TabIndex = 1;
            this.dateTimePickerDo.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
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
            // buttonIzracunaj
            // 
            this.buttonIzracunaj.Location = new System.Drawing.Point(218, 19);
            this.buttonIzracunaj.Name = "buttonIzracunaj";
            this.buttonIzracunaj.Size = new System.Drawing.Size(75, 23);
            this.buttonIzracunaj.TabIndex = 4;
            this.buttonIzracunaj.Text = "Izračunaj";
            this.buttonIzracunaj.UseVisualStyleBackColor = true;
            this.buttonIzracunaj.Click += new System.EventHandler(this.ButtonIzracunaj_Click);
            // 
            // groupBoxIznosi
            // 
            this.groupBoxIznosi.Controls.Add(this.labelIznZaUplatu);
            this.groupBoxIznosi.Controls.Add(this.labelZaUplatu);
            this.groupBoxIznosi.Controls.Add(this.groupBoxPorez);
            this.groupBoxIznosi.Controls.Add(this.groupBoxPretporez);
            this.groupBoxIznosi.Location = new System.Drawing.Point(12, 126);
            this.groupBoxIznosi.Name = "groupBoxIznosi";
            this.groupBoxIznosi.Size = new System.Drawing.Size(523, 421);
            this.groupBoxIznosi.TabIndex = 5;
            this.groupBoxIznosi.TabStop = false;
            this.groupBoxIznosi.Text = "Iznosi";
            // 
            // groupBoxPorez
            // 
            this.groupBoxPorez.Controls.Add(this.labelIzPorUkupno);
            this.groupBoxPorez.Controls.Add(this.labelIzPor25);
            this.groupBoxPorez.Controls.Add(this.labelIzPor13);
            this.groupBoxPorez.Controls.Add(this.labelIzPor5);
            this.groupBoxPorez.Controls.Add(this.labelIzPorOsUkupno);
            this.groupBoxPorez.Controls.Add(this.labelIzPorOs25);
            this.groupBoxPorez.Controls.Add(this.labelPorOsUkupno);
            this.groupBoxPorez.Controls.Add(this.labelIzPorOs13);
            this.groupBoxPorez.Controls.Add(this.labelPorUkupno);
            this.groupBoxPorez.Controls.Add(this.labelIzPorOs5);
            this.groupBoxPorez.Controls.Add(this.labelPor25);
            this.groupBoxPorez.Controls.Add(this.labelPorOs5);
            this.groupBoxPorez.Controls.Add(this.labelPor13);
            this.groupBoxPorez.Controls.Add(this.labelPorOs13);
            this.groupBoxPorez.Controls.Add(this.labelPor5);
            this.groupBoxPorez.Controls.Add(this.PorOs25);
            this.groupBoxPorez.Location = new System.Drawing.Point(6, 182);
            this.groupBoxPorez.Name = "groupBoxPorez";
            this.groupBoxPorez.Size = new System.Drawing.Size(511, 154);
            this.groupBoxPorez.TabIndex = 7;
            this.groupBoxPorez.TabStop = false;
            this.groupBoxPorez.Text = "Porez";
            // 
            // labelIzPorUkupno
            // 
            this.labelIzPorUkupno.AutoSize = true;
            this.labelIzPorUkupno.Location = new System.Drawing.Point(349, 125);
            this.labelIzPorUkupno.Name = "labelIzPorUkupno";
            this.labelIzPorUkupno.Size = new System.Drawing.Size(28, 15);
            this.labelIzPorUkupno.TabIndex = 23;
            this.labelIzPorUkupno.Text = "0,00";
            // 
            // labelIzPor25
            // 
            this.labelIzPor25.AutoSize = true;
            this.labelIzPor25.Location = new System.Drawing.Point(349, 95);
            this.labelIzPor25.Name = "labelIzPor25";
            this.labelIzPor25.Size = new System.Drawing.Size(28, 15);
            this.labelIzPor25.TabIndex = 22;
            this.labelIzPor25.Text = "0,00";
            // 
            // labelIzPor13
            // 
            this.labelIzPor13.AutoSize = true;
            this.labelIzPor13.Location = new System.Drawing.Point(349, 65);
            this.labelIzPor13.Name = "labelIzPor13";
            this.labelIzPor13.Size = new System.Drawing.Size(28, 15);
            this.labelIzPor13.TabIndex = 21;
            this.labelIzPor13.Text = "0,00";
            // 
            // labelIzPor5
            // 
            this.labelIzPor5.AutoSize = true;
            this.labelIzPor5.Location = new System.Drawing.Point(349, 35);
            this.labelIzPor5.Name = "labelIzPor5";
            this.labelIzPor5.Size = new System.Drawing.Size(28, 15);
            this.labelIzPor5.TabIndex = 20;
            this.labelIzPor5.Text = "0,00";
            // 
            // labelIzPorOsUkupno
            // 
            this.labelIzPorOsUkupno.AutoSize = true;
            this.labelIzPorOsUkupno.Location = new System.Drawing.Point(98, 125);
            this.labelIzPorOsUkupno.Name = "labelIzPorOsUkupno";
            this.labelIzPorOsUkupno.Size = new System.Drawing.Size(28, 15);
            this.labelIzPorOsUkupno.TabIndex = 19;
            this.labelIzPorOsUkupno.Text = "0,00";
            // 
            // labelIzPorOs25
            // 
            this.labelIzPorOs25.AutoSize = true;
            this.labelIzPorOs25.Location = new System.Drawing.Point(98, 95);
            this.labelIzPorOs25.Name = "labelIzPorOs25";
            this.labelIzPorOs25.Size = new System.Drawing.Size(28, 15);
            this.labelIzPorOs25.TabIndex = 18;
            this.labelIzPorOs25.Text = "0,00";
            // 
            // labelPorOsUkupno
            // 
            this.labelPorOsUkupno.AutoSize = true;
            this.labelPorOsUkupno.Location = new System.Drawing.Point(6, 125);
            this.labelPorOsUkupno.Name = "labelPorOsUkupno";
            this.labelPorOsUkupno.Size = new System.Drawing.Size(49, 15);
            this.labelPorOsUkupno.TabIndex = 7;
            this.labelPorOsUkupno.Text = "Ukupno";
            // 
            // labelIzPorOs13
            // 
            this.labelIzPorOs13.AutoSize = true;
            this.labelIzPorOs13.Location = new System.Drawing.Point(98, 65);
            this.labelIzPorOs13.Name = "labelIzPorOs13";
            this.labelIzPorOs13.Size = new System.Drawing.Size(28, 15);
            this.labelIzPorOs13.TabIndex = 17;
            this.labelIzPorOs13.Text = "0,00";
            // 
            // labelPorUkupno
            // 
            this.labelPorUkupno.AutoSize = true;
            this.labelPorUkupno.Location = new System.Drawing.Point(260, 125);
            this.labelPorUkupno.Name = "labelPorUkupno";
            this.labelPorUkupno.Size = new System.Drawing.Size(49, 15);
            this.labelPorUkupno.TabIndex = 6;
            this.labelPorUkupno.Text = "Ukupno";
            // 
            // labelIzPorOs5
            // 
            this.labelIzPorOs5.AutoSize = true;
            this.labelIzPorOs5.Location = new System.Drawing.Point(98, 35);
            this.labelIzPorOs5.Name = "labelIzPorOs5";
            this.labelIzPorOs5.Size = new System.Drawing.Size(28, 15);
            this.labelIzPorOs5.TabIndex = 16;
            this.labelIzPorOs5.Text = "0,00";
            // 
            // labelPor25
            // 
            this.labelPor25.AutoSize = true;
            this.labelPor25.Location = new System.Drawing.Point(260, 96);
            this.labelPor25.Name = "labelPor25";
            this.labelPor25.Size = new System.Drawing.Size(61, 15);
            this.labelPor25.TabIndex = 5;
            this.labelPor25.Text = "Porez 25%";
            // 
            // labelPorOs5
            // 
            this.labelPorOs5.AutoSize = true;
            this.labelPorOs5.Location = new System.Drawing.Point(6, 38);
            this.labelPorOs5.Name = "labelPorOs5";
            this.labelPorOs5.Size = new System.Drawing.Size(75, 15);
            this.labelPorOs5.TabIndex = 0;
            this.labelPorOs5.Text = "Osnovica 5%";
            // 
            // labelPor13
            // 
            this.labelPor13.AutoSize = true;
            this.labelPor13.Location = new System.Drawing.Point(260, 67);
            this.labelPor13.Name = "labelPor13";
            this.labelPor13.Size = new System.Drawing.Size(61, 15);
            this.labelPor13.TabIndex = 4;
            this.labelPor13.Text = "Porez 13%";
            // 
            // labelPorOs13
            // 
            this.labelPorOs13.AutoSize = true;
            this.labelPorOs13.Location = new System.Drawing.Point(6, 67);
            this.labelPorOs13.Name = "labelPorOs13";
            this.labelPorOs13.Size = new System.Drawing.Size(81, 15);
            this.labelPorOs13.TabIndex = 1;
            this.labelPorOs13.Text = "Osnovica 13%";
            // 
            // labelPor5
            // 
            this.labelPor5.AutoSize = true;
            this.labelPor5.Location = new System.Drawing.Point(260, 38);
            this.labelPor5.Name = "labelPor5";
            this.labelPor5.Size = new System.Drawing.Size(55, 15);
            this.labelPor5.TabIndex = 3;
            this.labelPor5.Text = "Porez 5%";
            // 
            // PorOs25
            // 
            this.PorOs25.AutoSize = true;
            this.PorOs25.Location = new System.Drawing.Point(6, 96);
            this.PorOs25.Name = "PorOs25";
            this.PorOs25.Size = new System.Drawing.Size(81, 15);
            this.PorOs25.TabIndex = 2;
            this.PorOs25.Text = "Osnovica 25%";
            // 
            // groupBoxPretporez
            // 
            this.groupBoxPretporez.Controls.Add(this.labelIzPpUkupno);
            this.groupBoxPretporez.Controls.Add(this.labelIzPp25);
            this.groupBoxPretporez.Controls.Add(this.labelIzPp13);
            this.groupBoxPretporez.Controls.Add(this.labelIzPp5);
            this.groupBoxPretporez.Controls.Add(this.labelIzPpOsUkupno);
            this.groupBoxPretporez.Controls.Add(this.labelIzPpOs25);
            this.groupBoxPretporez.Controls.Add(this.labelIzPpOs13);
            this.groupBoxPretporez.Controls.Add(this.labelIznPpOs5);
            this.groupBoxPretporez.Controls.Add(this.labelPpUkupno);
            this.groupBoxPretporez.Controls.Add(this.labelPpOsUkupno);
            this.groupBoxPretporez.Controls.Add(this.labelPp25);
            this.groupBoxPretporez.Controls.Add(this.labelPpOs5);
            this.groupBoxPretporez.Controls.Add(this.labelPp13);
            this.groupBoxPretporez.Controls.Add(this.labelPpOs13);
            this.groupBoxPretporez.Controls.Add(this.labelPp5);
            this.groupBoxPretporez.Controls.Add(this.labelPpOs25);
            this.groupBoxPretporez.Location = new System.Drawing.Point(6, 22);
            this.groupBoxPretporez.Name = "groupBoxPretporez";
            this.groupBoxPretporez.Size = new System.Drawing.Size(511, 154);
            this.groupBoxPretporez.TabIndex = 6;
            this.groupBoxPretporez.TabStop = false;
            this.groupBoxPretporez.Text = "Pretporez";
            // 
            // labelIzPpUkupno
            // 
            this.labelIzPpUkupno.AutoSize = true;
            this.labelIzPpUkupno.Location = new System.Drawing.Point(349, 121);
            this.labelIzPpUkupno.Name = "labelIzPpUkupno";
            this.labelIzPpUkupno.Size = new System.Drawing.Size(28, 15);
            this.labelIzPpUkupno.TabIndex = 15;
            this.labelIzPpUkupno.Text = "0,00";
            // 
            // labelIzPp25
            // 
            this.labelIzPp25.AutoSize = true;
            this.labelIzPp25.Location = new System.Drawing.Point(349, 91);
            this.labelIzPp25.Name = "labelIzPp25";
            this.labelIzPp25.Size = new System.Drawing.Size(28, 15);
            this.labelIzPp25.TabIndex = 14;
            this.labelIzPp25.Text = "0,00";
            // 
            // labelIzPp13
            // 
            this.labelIzPp13.AutoSize = true;
            this.labelIzPp13.Location = new System.Drawing.Point(349, 61);
            this.labelIzPp13.Name = "labelIzPp13";
            this.labelIzPp13.Size = new System.Drawing.Size(28, 15);
            this.labelIzPp13.TabIndex = 13;
            this.labelIzPp13.Text = "0,00";
            // 
            // labelIzPp5
            // 
            this.labelIzPp5.AutoSize = true;
            this.labelIzPp5.Location = new System.Drawing.Point(349, 31);
            this.labelIzPp5.Name = "labelIzPp5";
            this.labelIzPp5.Size = new System.Drawing.Size(28, 15);
            this.labelIzPp5.TabIndex = 12;
            this.labelIzPp5.Text = "0,00";
            // 
            // labelIzPpOsUkupno
            // 
            this.labelIzPpOsUkupno.AutoSize = true;
            this.labelIzPpOsUkupno.Location = new System.Drawing.Point(98, 121);
            this.labelIzPpOsUkupno.Name = "labelIzPpOsUkupno";
            this.labelIzPpOsUkupno.Size = new System.Drawing.Size(28, 15);
            this.labelIzPpOsUkupno.TabIndex = 11;
            this.labelIzPpOsUkupno.Text = "0,00";
            // 
            // labelIzPpOs25
            // 
            this.labelIzPpOs25.AutoSize = true;
            this.labelIzPpOs25.Location = new System.Drawing.Point(98, 91);
            this.labelIzPpOs25.Name = "labelIzPpOs25";
            this.labelIzPpOs25.Size = new System.Drawing.Size(28, 15);
            this.labelIzPpOs25.TabIndex = 10;
            this.labelIzPpOs25.Text = "0,00";
            // 
            // labelIzPpOs13
            // 
            this.labelIzPpOs13.AutoSize = true;
            this.labelIzPpOs13.Location = new System.Drawing.Point(98, 61);
            this.labelIzPpOs13.Name = "labelIzPpOs13";
            this.labelIzPpOs13.Size = new System.Drawing.Size(28, 15);
            this.labelIzPpOs13.TabIndex = 9;
            this.labelIzPpOs13.Text = "0,00";
            // 
            // labelIznPpOs5
            // 
            this.labelIznPpOs5.AutoSize = true;
            this.labelIznPpOs5.Location = new System.Drawing.Point(98, 31);
            this.labelIznPpOs5.Name = "labelIznPpOs5";
            this.labelIznPpOs5.Size = new System.Drawing.Size(28, 15);
            this.labelIznPpOs5.TabIndex = 8;
            this.labelIznPpOs5.Text = "0,00";
            // 
            // labelPpUkupno
            // 
            this.labelPpUkupno.AutoSize = true;
            this.labelPpUkupno.Location = new System.Drawing.Point(260, 121);
            this.labelPpUkupno.Name = "labelPpUkupno";
            this.labelPpUkupno.Size = new System.Drawing.Size(49, 15);
            this.labelPpUkupno.TabIndex = 7;
            this.labelPpUkupno.Text = "Ukupno";
            // 
            // labelPpOsUkupno
            // 
            this.labelPpOsUkupno.AutoSize = true;
            this.labelPpOsUkupno.Location = new System.Drawing.Point(6, 121);
            this.labelPpOsUkupno.Name = "labelPpOsUkupno";
            this.labelPpOsUkupno.Size = new System.Drawing.Size(49, 15);
            this.labelPpOsUkupno.TabIndex = 6;
            this.labelPpOsUkupno.Text = "Ukupno";
            // 
            // labelPp25
            // 
            this.labelPp25.AutoSize = true;
            this.labelPp25.Location = new System.Drawing.Point(259, 91);
            this.labelPp25.Name = "labelPp25";
            this.labelPp25.Size = new System.Drawing.Size(82, 15);
            this.labelPp25.TabIndex = 5;
            this.labelPp25.Text = "Pretporez 25%";
            // 
            // labelPpOs5
            // 
            this.labelPpOs5.AutoSize = true;
            this.labelPpOs5.Location = new System.Drawing.Point(5, 31);
            this.labelPpOs5.Name = "labelPpOs5";
            this.labelPpOs5.Size = new System.Drawing.Size(75, 15);
            this.labelPpOs5.TabIndex = 0;
            this.labelPpOs5.Text = "Osnovica 5%";
            // 
            // labelPp13
            // 
            this.labelPp13.AutoSize = true;
            this.labelPp13.Location = new System.Drawing.Point(259, 61);
            this.labelPp13.Name = "labelPp13";
            this.labelPp13.Size = new System.Drawing.Size(82, 15);
            this.labelPp13.TabIndex = 4;
            this.labelPp13.Text = "Pretporez 13%";
            // 
            // labelPpOs13
            // 
            this.labelPpOs13.AutoSize = true;
            this.labelPpOs13.Location = new System.Drawing.Point(5, 61);
            this.labelPpOs13.Name = "labelPpOs13";
            this.labelPpOs13.Size = new System.Drawing.Size(81, 15);
            this.labelPpOs13.TabIndex = 1;
            this.labelPpOs13.Text = "Osnovica 13%";
            // 
            // labelPp5
            // 
            this.labelPp5.AutoSize = true;
            this.labelPp5.Location = new System.Drawing.Point(259, 31);
            this.labelPp5.Name = "labelPp5";
            this.labelPp5.Size = new System.Drawing.Size(76, 15);
            this.labelPp5.TabIndex = 3;
            this.labelPp5.Text = "Pretporez 5%";
            // 
            // labelPpOs25
            // 
            this.labelPpOs25.AutoSize = true;
            this.labelPpOs25.Location = new System.Drawing.Point(5, 91);
            this.labelPpOs25.Name = "labelPpOs25";
            this.labelPpOs25.Size = new System.Drawing.Size(81, 15);
            this.labelPpOs25.TabIndex = 2;
            this.labelPpOs25.Text = "Osnovica 25%";
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Location = new System.Drawing.Point(218, 49);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 6;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // labelZaUplatu
            // 
            this.labelZaUplatu.AutoSize = true;
            this.labelZaUplatu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelZaUplatu.Location = new System.Drawing.Point(12, 358);
            this.labelZaUplatu.Name = "labelZaUplatu";
            this.labelZaUplatu.Size = new System.Drawing.Size(129, 20);
            this.labelZaUplatu.TabIndex = 8;
            this.labelZaUplatu.Text = "Za uplatu / povrat";
            // 
            // labelIznZaUplatu
            // 
            this.labelIznZaUplatu.AutoSize = true;
            this.labelIznZaUplatu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIznZaUplatu.Location = new System.Drawing.Point(161, 358);
            this.labelIznZaUplatu.Name = "labelIznZaUplatu";
            this.labelIznZaUplatu.Size = new System.Drawing.Size(36, 20);
            this.labelIznZaUplatu.TabIndex = 9;
            this.labelIznZaUplatu.Text = "0,00";
            // 
            // PorezPdvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 618);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.groupBoxIznosi);
            this.Controls.Add(this.buttonIzracunaj);
            this.Controls.Add(this.groupBoxRazdoblje);
            this.Name = "PorezPdvForm";
            this.Text = "Izračun PDV-a";
            this.groupBoxRazdoblje.ResumeLayout(false);
            this.groupBoxRazdoblje.PerformLayout();
            this.groupBoxIznosi.ResumeLayout(false);
            this.groupBoxIznosi.PerformLayout();
            this.groupBoxPorez.ResumeLayout(false);
            this.groupBoxPorez.PerformLayout();
            this.groupBoxPretporez.ResumeLayout(false);
            this.groupBoxPretporez.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRazdoblje;
        private System.Windows.Forms.Label labelRazdobljeDo;
        private System.Windows.Forms.Label labelRazdobljeOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerOd;
        private System.Windows.Forms.Button buttonIzracunaj;
        private System.Windows.Forms.GroupBox groupBoxIznosi;
        private System.Windows.Forms.GroupBox groupBoxPorez;
        private System.Windows.Forms.Label labelPor25;
        private System.Windows.Forms.Label labelPorOs5;
        private System.Windows.Forms.Label labelPor13;
        private System.Windows.Forms.Label labelPorOs13;
        private System.Windows.Forms.Label labelPor5;
        private System.Windows.Forms.Label PorOs25;
        private System.Windows.Forms.GroupBox groupBoxPretporez;
        private System.Windows.Forms.Label labelPpUkupno;
        private System.Windows.Forms.Label labelPpOsUkupno;
        private System.Windows.Forms.Label labelPp25;
        private System.Windows.Forms.Label labelPpOs5;
        private System.Windows.Forms.Label labelPp13;
        private System.Windows.Forms.Label labelPpOs13;
        private System.Windows.Forms.Label labelPp5;
        private System.Windows.Forms.Label labelPpOs25;
        private System.Windows.Forms.Label labelPorOsUkupno;
        private System.Windows.Forms.Label labelPorUkupno;
        private System.Windows.Forms.Label labelIzPpOsUkupno;
        private System.Windows.Forms.Label labelIzPpOs25;
        private System.Windows.Forms.Label labelIzPpOs13;
        private System.Windows.Forms.Label labelIznPpOs5;
        private System.Windows.Forms.Label labelIzPorUkupno;
        private System.Windows.Forms.Label labelIzPor25;
        private System.Windows.Forms.Label labelIzPor13;
        private System.Windows.Forms.Label labelIzPor5;
        private System.Windows.Forms.Label labelIzPorOsUkupno;
        private System.Windows.Forms.Label labelIzPorOs25;
        private System.Windows.Forms.Label labelIzPorOs13;
        private System.Windows.Forms.Label labelIzPorOs5;
        private System.Windows.Forms.Label labelIzPpUkupno;
        private System.Windows.Forms.Label labelIzPp25;
        private System.Windows.Forms.Label labelIzPp13;
        private System.Windows.Forms.Label labelIzPp5;
        private System.Windows.Forms.Button buttonKnjizi;
        private System.Windows.Forms.Label labelIznZaUplatu;
        private System.Windows.Forms.Label labelZaUplatu;
    }
}
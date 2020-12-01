using System.Windows.Forms;

namespace Knjigovodstvo.Settings.SettingsBookkeeping
{
    partial class PostavkeKnjizenjaPregledForm
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
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.comboBoxStupac = new System.Windows.Forms.ComboBox();
            this.labelStupac = new System.Windows.Forms.Label();
            this.labelKonto = new System.Windows.Forms.Label();
            this.textBoxKonto = new System.Windows.Forms.TextBox();
            this.comboBoxStrana = new System.Windows.Forms.ComboBox();
            this.labelStrana = new System.Windows.Forms.Label();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.buttonIzmjeni = new System.Windows.Forms.Button();
            this.buttonBrisi = new System.Windows.Forms.Button();
            this.checkBoxPredznak = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 155);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(813, 422);
            this.dbDataGridView1.TabIndex = 0;
            this.dbDataGridView1.TabStop = false;
            this.dbDataGridView1.Text = "dbDataGridView1";
            this.dbDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DbDataGridView1_CellClick);
            // 
            // comboBoxStupac
            // 
            this.comboBoxStupac.FormattingEnabled = true;
            this.comboBoxStupac.Location = new System.Drawing.Point(105, 126);
            this.comboBoxStupac.Name = "comboBoxStupac";
            this.comboBoxStupac.Size = new System.Drawing.Size(175, 23);
            this.comboBoxStupac.TabIndex = 1;
            // 
            // labelStupac
            // 
            this.labelStupac.AutoSize = true;
            this.labelStupac.Location = new System.Drawing.Point(12, 129);
            this.labelStupac.Name = "labelStupac";
            this.labelStupac.Size = new System.Drawing.Size(87, 15);
            this.labelStupac.TabIndex = 2;
            this.labelStupac.Text = "Odaberi stupac";
            // 
            // labelKonto
            // 
            this.labelKonto.AutoSize = true;
            this.labelKonto.Location = new System.Drawing.Point(286, 129);
            this.labelKonto.Name = "labelKonto";
            this.labelKonto.Size = new System.Drawing.Size(83, 15);
            this.labelKonto.TabIndex = 3;
            this.labelKonto.Text = "Odaberi konto";
            // 
            // textBoxKonto
            // 
            this.textBoxKonto.Location = new System.Drawing.Point(375, 126);
            this.textBoxKonto.Name = "textBoxKonto";
            this.textBoxKonto.PlaceholderText = "Broj konta";
            this.textBoxKonto.Size = new System.Drawing.Size(116, 23);
            this.textBoxKonto.TabIndex = 2;
            this.textBoxKonto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxKonto_MouseClick);
            // 
            // comboBoxStrana
            // 
            this.comboBoxStrana.FormattingEnabled = true;
            this.comboBoxStrana.Items.AddRange(new object[] {
            "Dugovna",
            "Potražna"});
            this.comboBoxStrana.Location = new System.Drawing.Point(543, 126);
            this.comboBoxStrana.Name = "comboBoxStrana";
            this.comboBoxStrana.Size = new System.Drawing.Size(89, 23);
            this.comboBoxStrana.TabIndex = 3;
            // 
            // labelStrana
            // 
            this.labelStrana.AutoSize = true;
            this.labelStrana.Location = new System.Drawing.Point(497, 129);
            this.labelStrana.Name = "labelStrana";
            this.labelStrana.Size = new System.Drawing.Size(40, 15);
            this.labelStrana.TabIndex = 6;
            this.labelStrana.Text = "Strana";
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(12, 13);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 0;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // buttonIzmjeni
            // 
            this.buttonIzmjeni.Location = new System.Drawing.Point(93, 13);
            this.buttonIzmjeni.Name = "buttonIzmjeni";
            this.buttonIzmjeni.Size = new System.Drawing.Size(75, 23);
            this.buttonIzmjeni.TabIndex = 7;
            this.buttonIzmjeni.Text = "Izmjeni";
            this.buttonIzmjeni.UseVisualStyleBackColor = true;
            this.buttonIzmjeni.Click += new System.EventHandler(this.ButtonIzmjeni_Click);
            // 
            // buttonBrisi
            // 
            this.buttonBrisi.Location = new System.Drawing.Point(174, 13);
            this.buttonBrisi.Name = "buttonBrisi";
            this.buttonBrisi.Size = new System.Drawing.Size(75, 23);
            this.buttonBrisi.TabIndex = 8;
            this.buttonBrisi.Text = "Briši";
            this.buttonBrisi.UseVisualStyleBackColor = true;
            this.buttonBrisi.Click += new System.EventHandler(this.ButtonBrisi_Click);
            // 
            // checkBoxPredznak
            // 
            this.checkBoxPredznak.AutoSize = true;
            this.checkBoxPredznak.Location = new System.Drawing.Point(638, 128);
            this.checkBoxPredznak.Name = "checkBoxPredznak";
            this.checkBoxPredznak.Size = new System.Drawing.Size(121, 19);
            this.checkBoxPredznak.TabIndex = 9;
            this.checkBoxPredznak.Text = "Mijenja predznak?";
            this.checkBoxPredznak.UseVisualStyleBackColor = true;
            // 
            // PostavkeKnjizenjaPregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 589);
            this.Controls.Add(this.checkBoxPredznak);
            this.Controls.Add(this.buttonBrisi);
            this.Controls.Add(this.buttonIzmjeni);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.labelStrana);
            this.Controls.Add(this.comboBoxStrana);
            this.Controls.Add(this.textBoxKonto);
            this.Controls.Add(this.labelKonto);
            this.Controls.Add(this.labelStupac);
            this.Controls.Add(this.comboBoxStupac);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "PostavkeKnjizenjaPregledForm";
            this.Text = "Postavke knjiženja";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dbDataGridView1;
        private ComboBox comboBoxStupac;
        private Label labelStupac;
        private Label labelKonto;
        private TextBox textBoxKonto;
        private ComboBox comboBoxStrana;
        private Label labelStrana;
        private Button buttonSpremi;
        private Button buttonIzmjeni;
        private Button buttonBrisi;
        private CheckBox checkBoxPredznak;
    }
}
namespace Knjigovodstvo.City
{
    partial class GradUnosForm
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
            this.labelPosta = new System.Windows.Forms.Label();
            this.labelZupanija = new System.Windows.Forms.Label();
            this.labelDrzava = new System.Windows.Forms.Label();
            this.comboBoxPosta = new System.Windows.Forms.ComboBox();
            this.textBoxDrzava = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBoxZupanija = new System.Windows.Forms.ComboBox();
            this.comboBoxGrad = new System.Windows.Forms.ComboBox();
            this.labelUpozorenja = new System.Windows.Forms.Label();
            this.textBoxPrirez = new System.Windows.Forms.TextBox();
            this.labelPrirez = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(12, 73);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(32, 15);
            this.labelNaziv.TabIndex = 0;
            this.labelNaziv.Text = "Grad";
            // 
            // labelPosta
            // 
            this.labelPosta.AutoSize = true;
            this.labelPosta.Location = new System.Drawing.Point(12, 102);
            this.labelPosta.Name = "labelPosta";
            this.labelPosta.Size = new System.Drawing.Size(36, 15);
            this.labelPosta.TabIndex = 0;
            this.labelPosta.Text = "Pošta";
            // 
            // labelZupanija
            // 
            this.labelZupanija.AutoSize = true;
            this.labelZupanija.Location = new System.Drawing.Point(12, 44);
            this.labelZupanija.Name = "labelZupanija";
            this.labelZupanija.Size = new System.Drawing.Size(53, 15);
            this.labelZupanija.TabIndex = 0;
            this.labelZupanija.Text = "Županija";
            // 
            // labelDrzava
            // 
            this.labelDrzava.AutoSize = true;
            this.labelDrzava.Location = new System.Drawing.Point(12, 15);
            this.labelDrzava.Name = "labelDrzava";
            this.labelDrzava.Size = new System.Drawing.Size(42, 15);
            this.labelDrzava.TabIndex = 0;
            this.labelDrzava.Text = "Država";
            // 
            // comboBoxPosta
            // 
            this.comboBoxPosta.Location = new System.Drawing.Point(68, 99);
            this.comboBoxPosta.Name = "comboBoxPosta";
            this.comboBoxPosta.Size = new System.Drawing.Size(96, 23);
            this.comboBoxPosta.TabIndex = 3;
            // 
            // textBoxDrzava
            // 
            this.textBoxDrzava.Location = new System.Drawing.Point(68, 12);
            this.textBoxDrzava.Name = "textBoxDrzava";
            this.textBoxDrzava.ReadOnly = true;
            this.textBoxDrzava.Size = new System.Drawing.Size(240, 23);
            this.textBoxDrzava.TabIndex = 0;
            this.textBoxDrzava.Text = "Hrvatska";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Odaberi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // comboBoxZupanija
            // 
            this.comboBoxZupanija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZupanija.FormattingEnabled = true;
            this.comboBoxZupanija.Location = new System.Drawing.Point(68, 41);
            this.comboBoxZupanija.Name = "comboBoxZupanija";
            this.comboBoxZupanija.Size = new System.Drawing.Size(240, 23);
            this.comboBoxZupanija.TabIndex = 1;
            this.comboBoxZupanija.SelectedValueChanged += new System.EventHandler(this.ComboBoxCounty_SelectedValueChanged);
            // 
            // comboBoxGrad
            // 
            this.comboBoxGrad.FormattingEnabled = true;
            this.comboBoxGrad.Location = new System.Drawing.Point(68, 70);
            this.comboBoxGrad.Name = "comboBoxGrad";
            this.comboBoxGrad.Size = new System.Drawing.Size(240, 23);
            this.comboBoxGrad.TabIndex = 2;
            this.comboBoxGrad.SelectedValueChanged += new System.EventHandler(this.comboBoxGrad_SelectedValueChanged);
            // 
            // labelUpozorenja
            // 
            this.labelUpozorenja.AutoSize = true;
            this.labelUpozorenja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUpozorenja.ForeColor = System.Drawing.Color.Firebrick;
            this.labelUpozorenja.Location = new System.Drawing.Point(13, 184);
            this.labelUpozorenja.Name = "labelUpozorenja";
            this.labelUpozorenja.Size = new System.Drawing.Size(106, 21);
            this.labelUpozorenja.TabIndex = 5;
            this.labelUpozorenja.Text = "Warning label";
            // 
            // textBoxPrirez
            // 
            this.textBoxPrirez.Location = new System.Drawing.Point(68, 128);
            this.textBoxPrirez.Name = "textBoxPrirez";
            this.textBoxPrirez.Size = new System.Drawing.Size(96, 23);
            this.textBoxPrirez.TabIndex = 4;
            // 
            // labelPrirez
            // 
            this.labelPrirez.AutoSize = true;
            this.labelPrirez.Location = new System.Drawing.Point(12, 131);
            this.labelPrirez.Name = "labelPrirez";
            this.labelPrirez.Size = new System.Drawing.Size(36, 15);
            this.labelPrirez.TabIndex = 0;
            this.labelPrirez.Text = "Prirez";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(164, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "%";
            // 
            // GradUnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 274);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPrirez);
            this.Controls.Add(this.textBoxPrirez);
            this.Controls.Add(this.labelUpozorenja);
            this.Controls.Add(this.comboBoxGrad);
            this.Controls.Add(this.comboBoxZupanija);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxDrzava);
            this.Controls.Add(this.comboBoxPosta);
            this.Controls.Add(this.labelDrzava);
            this.Controls.Add(this.labelZupanija);
            this.Controls.Add(this.labelPosta);
            this.Controls.Add(this.labelNaziv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GradUnosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unesi novi grad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Label labelPosta;
        private System.Windows.Forms.Label labelZupanija;
        private System.Windows.Forms.Label labelDrzava;
        private System.Windows.Forms.ComboBox comboBoxPosta;
        private System.Windows.Forms.TextBox textBoxDrzava;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboBoxZupanija;
        private System.Windows.Forms.ComboBox comboBoxGrad;
        private System.Windows.Forms.Label labelUpozorenja;
        private System.Windows.Forms.TextBox textBoxPrirez;
        private System.Windows.Forms.Label labelPrirez;
        private System.Windows.Forms.Label label2;
    }
}
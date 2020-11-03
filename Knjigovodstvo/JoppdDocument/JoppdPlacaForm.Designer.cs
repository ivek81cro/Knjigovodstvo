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
            this.buttonPopuniObrazac = new System.Windows.Forms.Button();
            this.checkBoxSamoDodaci = new System.Windows.Forms.CheckBox();
            this.comboBoxDodaci = new System.Windows.Forms.ComboBox();
            this.checkBoxBezDodataka = new System.Windows.Forms.CheckBox();
            this.checkBoxPojedinacno = new System.Windows.Forms.CheckBox();
            this.comboBoxZaposlenik = new System.Windows.Forms.ComboBox();
            this.labelSatiRada = new System.Windows.Forms.Label();
            this.textBoxSatiRada = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIzvjesceSastavioIme = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 23);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // labelDatumObrasca
            // 
            this.labelDatumObrasca.AutoSize = true;
            this.labelDatumObrasca.Location = new System.Drawing.Point(11, 16);
            this.labelDatumObrasca.Name = "labelDatumObrasca";
            this.labelDatumObrasca.Size = new System.Drawing.Size(87, 15);
            this.labelDatumObrasca.TabIndex = 1;
            this.labelDatumObrasca.Text = "Datum obrasca";
            // 
            // labelBrojObrasca
            // 
            this.labelBrojObrasca.AutoSize = true;
            this.labelBrojObrasca.Location = new System.Drawing.Point(246, 16);
            this.labelBrojObrasca.Name = "labelBrojObrasca";
            this.labelBrojObrasca.Size = new System.Drawing.Size(40, 15);
            this.labelBrojObrasca.TabIndex = 2;
            this.labelBrojObrasca.Text = "yyddd";
            // 
            // buttonPopuniObrazac
            // 
            this.buttonPopuniObrazac.Location = new System.Drawing.Point(11, 146);
            this.buttonPopuniObrazac.Name = "buttonPopuniObrazac";
            this.buttonPopuniObrazac.Size = new System.Drawing.Size(75, 23);
            this.buttonPopuniObrazac.TabIndex = 3;
            this.buttonPopuniObrazac.Text = "Popuni";
            this.buttonPopuniObrazac.UseVisualStyleBackColor = true;
            this.buttonPopuniObrazac.Click += new System.EventHandler(this.ButtonPopuniObrazac_Click);
            // 
            // checkBoxSamoDodaci
            // 
            this.checkBoxSamoDodaci.AutoSize = true;
            this.checkBoxSamoDodaci.Location = new System.Drawing.Point(15, 51);
            this.checkBoxSamoDodaci.Name = "checkBoxSamoDodaci";
            this.checkBoxSamoDodaci.Size = new System.Drawing.Size(95, 19);
            this.checkBoxSamoDodaci.TabIndex = 4;
            this.checkBoxSamoDodaci.Text = "Samo dodaci";
            this.checkBoxSamoDodaci.UseVisualStyleBackColor = true;
            // 
            // comboBoxDodaci
            // 
            this.comboBoxDodaci.DropDownWidth = 800;
            this.comboBoxDodaci.FormattingEnabled = true;
            this.comboBoxDodaci.Location = new System.Drawing.Point(114, 49);
            this.comboBoxDodaci.Name = "comboBoxDodaci";
            this.comboBoxDodaci.Size = new System.Drawing.Size(199, 23);
            this.comboBoxDodaci.TabIndex = 5;
            // 
            // checkBoxBezDodataka
            // 
            this.checkBoxBezDodataka.AutoSize = true;
            this.checkBoxBezDodataka.Location = new System.Drawing.Point(15, 86);
            this.checkBoxBezDodataka.Name = "checkBoxBezDodataka";
            this.checkBoxBezDodataka.Size = new System.Drawing.Size(96, 19);
            this.checkBoxBezDodataka.TabIndex = 6;
            this.checkBoxBezDodataka.Text = "Bez dodataka";
            this.checkBoxBezDodataka.UseVisualStyleBackColor = true;
            // 
            // checkBoxPojedinacno
            // 
            this.checkBoxPojedinacno.AutoSize = true;
            this.checkBoxPojedinacno.Location = new System.Drawing.Point(15, 121);
            this.checkBoxPojedinacno.Name = "checkBoxPojedinacno";
            this.checkBoxPojedinacno.Size = new System.Drawing.Size(92, 19);
            this.checkBoxPojedinacno.TabIndex = 7;
            this.checkBoxPojedinacno.Text = "Pojedinačno";
            this.checkBoxPojedinacno.UseVisualStyleBackColor = true;
            // 
            // comboBoxZaposlenik
            // 
            this.comboBoxZaposlenik.FormattingEnabled = true;
            this.comboBoxZaposlenik.Location = new System.Drawing.Point(114, 119);
            this.comboBoxZaposlenik.Name = "comboBoxZaposlenik";
            this.comboBoxZaposlenik.Size = new System.Drawing.Size(199, 23);
            this.comboBoxZaposlenik.TabIndex = 5;
            this.comboBoxZaposlenik.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxZaposlenik_SelectionChangeCommitted);
            // 
            // labelSatiRada
            // 
            this.labelSatiRada.AutoSize = true;
            this.labelSatiRada.Location = new System.Drawing.Point(383, 18);
            this.labelSatiRada.Name = "labelSatiRada";
            this.labelSatiRada.Size = new System.Drawing.Size(109, 15);
            this.labelSatiRada.TabIndex = 8;
            this.labelSatiRada.Text = "Sati rada u mjesecu";
            // 
            // textBoxSatiRada
            // 
            this.textBoxSatiRada.Location = new System.Drawing.Point(498, 15);
            this.textBoxSatiRada.Name = "textBoxSatiRada";
            this.textBoxSatiRada.Size = new System.Drawing.Size(56, 23);
            this.textBoxSatiRada.TabIndex = 9;
            this.textBoxSatiRada.Text = "168";
            this.textBoxSatiRada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSatiRada_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(935, 330);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Izvješće sastavio";
            // 
            // textBoxIzvjesceSastavioIme
            // 
            this.textBoxIzvjesceSastavioIme.Location = new System.Drawing.Point(669, 15);
            this.textBoxIzvjesceSastavioIme.Name = "textBoxIzvjesceSastavioIme";
            this.textBoxIzvjesceSastavioIme.Size = new System.Drawing.Size(136, 23);
            this.textBoxIzvjesceSastavioIme.TabIndex = 12;
            this.textBoxIzvjesceSastavioIme.Text = "Ivan Batinić";
            // 
            // JoppdPlacaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 547);
            this.Controls.Add(this.textBoxIzvjesceSastavioIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxSatiRada);
            this.Controls.Add(this.labelSatiRada);
            this.Controls.Add(this.comboBoxZaposlenik);
            this.Controls.Add(this.checkBoxPojedinacno);
            this.Controls.Add(this.checkBoxBezDodataka);
            this.Controls.Add(this.comboBoxDodaci);
            this.Controls.Add(this.checkBoxSamoDodaci);
            this.Controls.Add(this.buttonPopuniObrazac);
            this.Controls.Add(this.labelBrojObrasca);
            this.Controls.Add(this.labelDatumObrasca);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "JoppdPlacaForm";
            this.Text = "PlacaJoppdForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelDatumObrasca;
        private System.Windows.Forms.Label labelBrojObrasca;
        private System.Windows.Forms.Button buttonPopuniObrazac;
        private System.Windows.Forms.CheckBox checkBoxSamoDodaci;
        private System.Windows.Forms.ComboBox comboBoxDodaci;
        private System.Windows.Forms.CheckBox checkBoxBezDodataka;
        private System.Windows.Forms.CheckBox checkBoxPojedinacno;
        private System.Windows.Forms.ComboBox comboBoxZaposlenik;
        private System.Windows.Forms.Label labelSatiRada;
        private System.Windows.Forms.TextBox textBoxSatiRada;
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIzvjesceSastavioIme;
    }
}
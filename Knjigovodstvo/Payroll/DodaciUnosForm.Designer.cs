using System.Windows.Forms;

namespace Knjigovodstvo.Payroll
{
    partial class DodaciUnosForm
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
            this.dataGridView1 = new DBDataGridView();
            this.labelOdabirZaposlenika = new System.Windows.Forms.Label();
            this.comboBoxOdabirZaposlenika = new System.Windows.Forms.ComboBox();
            this.labelOdabirDodatka = new System.Windows.Forms.Label();
            this.comboBoxOdabirDodatka = new System.Windows.Forms.ComboBox();
            this.labelIznos = new System.Windows.Forms.Label();
            this.textBoxIznos = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(779, 288);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // labelOdabirZaposlenika
            // 
            this.labelOdabirZaposlenika.AutoSize = true;
            this.labelOdabirZaposlenika.Location = new System.Drawing.Point(13, 13);
            this.labelOdabirZaposlenika.Name = "labelOdabirZaposlenika";
            this.labelOdabirZaposlenika.Size = new System.Drawing.Size(113, 15);
            this.labelOdabirZaposlenika.TabIndex = 1;
            this.labelOdabirZaposlenika.Text = "Odaberi zaposlenika";
            // 
            // comboBoxOdabirZaposlenika
            // 
            this.comboBoxOdabirZaposlenika.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOdabirZaposlenika.FormattingEnabled = true;
            this.comboBoxOdabirZaposlenika.Location = new System.Drawing.Point(132, 10);
            this.comboBoxOdabirZaposlenika.Name = "comboBoxOdabirZaposlenika";
            this.comboBoxOdabirZaposlenika.Size = new System.Drawing.Size(192, 23);
            this.comboBoxOdabirZaposlenika.TabIndex = 2;
            this.comboBoxOdabirZaposlenika.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxOdabirZaposlenika_SelectionChangeCommitted);
            // 
            // labelOdabirDodatka
            // 
            this.labelOdabirDodatka.AutoSize = true;
            this.labelOdabirDodatka.Location = new System.Drawing.Point(13, 48);
            this.labelOdabirDodatka.Name = "labelOdabirDodatka";
            this.labelOdabirDodatka.Size = new System.Drawing.Size(95, 15);
            this.labelOdabirDodatka.TabIndex = 3;
            this.labelOdabirDodatka.Text = "Odaberi dodatak";
            // 
            // comboBoxOdabirDodatka
            // 
            this.comboBoxOdabirDodatka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOdabirDodatka.FormattingEnabled = true;
            this.comboBoxOdabirDodatka.Location = new System.Drawing.Point(132, 45);
            this.comboBoxOdabirDodatka.Name = "comboBoxOdabirDodatka";
            this.comboBoxOdabirDodatka.Size = new System.Drawing.Size(656, 23);
            this.comboBoxOdabirDodatka.TabIndex = 4;
            this.comboBoxOdabirDodatka.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxOdabirDodatka_SelectionChangeCommitted);
            // 
            // labelIznos
            // 
            this.labelIznos.AutoSize = true;
            this.labelIznos.Location = new System.Drawing.Point(13, 82);
            this.labelIznos.Name = "labelIznos";
            this.labelIznos.Size = new System.Drawing.Size(66, 15);
            this.labelIznos.TabIndex = 5;
            this.labelIznos.Text = "Unesi iznos";
            // 
            // textBoxIznos
            // 
            this.textBoxIznos.Location = new System.Drawing.Point(132, 79);
            this.textBoxIznos.Name = "textBoxIznos";
            this.textBoxIznos.Size = new System.Drawing.Size(192, 23);
            this.textBoxIznos.TabIndex = 6;
            this.textBoxIznos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 121);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(95, 121);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Briši";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DodaciUnosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxIznos);
            this.Controls.Add(this.labelIznos);
            this.Controls.Add(this.comboBoxOdabirDodatka);
            this.Controls.Add(this.labelOdabirDodatka);
            this.Controls.Add(this.comboBoxOdabirZaposlenika);
            this.Controls.Add(this.labelOdabirZaposlenika);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DodaciUnosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DodaciUnosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Label labelOdabirZaposlenika;
        private System.Windows.Forms.ComboBox comboBoxOdabirZaposlenika;
        private System.Windows.Forms.Label labelOdabirDodatka;
        private System.Windows.Forms.ComboBox comboBoxOdabirDodatka;
        private System.Windows.Forms.Label labelIznos;
        private System.Windows.Forms.TextBox textBoxIznos;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
    }
}
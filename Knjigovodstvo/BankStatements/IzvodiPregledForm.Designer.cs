
namespace Knjigovodstvo.BankStatements
{
    partial class IzvodiPregledForm
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
            this.dataGridViewStavke = new System.Windows.Forms.DataGridView();
            this.buttonUcitajIzvod = new System.Windows.Forms.Button();
            this.dataGridViewIzvodi = new System.Windows.Forms.DataGridView();
            this.buttonOpenIzvod = new System.Windows.Forms.Button();
            this.buttonDeleteIzvod = new System.Windows.Forms.Button();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.labelPortazuje = new System.Windows.Forms.Label();
            this.labelDuguje = new System.Windows.Forms.Label();
            this.labelStanjePocetno = new System.Windows.Forms.Label();
            this.labelStanjeZavrsno = new System.Windows.Forms.Label();
            this.groupBoxStanje = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzvodi)).BeginInit();
            this.groupBoxStanje.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStavke
            // 
            this.dataGridViewStavke.AllowUserToAddRows = false;
            this.dataGridViewStavke.AllowUserToDeleteRows = false;
            this.dataGridViewStavke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewStavke.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStavke.Location = new System.Drawing.Point(12, 139);
            this.dataGridViewStavke.Name = "dataGridViewStavke";
            this.dataGridViewStavke.ReadOnly = true;
            this.dataGridViewStavke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStavke.Size = new System.Drawing.Size(859, 482);
            this.dataGridViewStavke.TabIndex = 10;
            this.dataGridViewStavke.Text = "dataGridViewStavke";
            // 
            // buttonUcitajIzvod
            // 
            this.buttonUcitajIzvod.Location = new System.Drawing.Point(13, 13);
            this.buttonUcitajIzvod.Name = "buttonUcitajIzvod";
            this.buttonUcitajIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitajIzvod.TabIndex = 11;
            this.buttonUcitajIzvod.Text = "Novi";
            this.buttonUcitajIzvod.UseVisualStyleBackColor = true;
            this.buttonUcitajIzvod.Click += new System.EventHandler(this.ButtonUcitajIzvod_Click);
            // 
            // dataGridViewIzvodi
            // 
            this.dataGridViewIzvodi.AllowUserToAddRows = false;
            this.dataGridViewIzvodi.AllowUserToDeleteRows = false;
            this.dataGridViewIzvodi.AllowUserToResizeColumns = false;
            this.dataGridViewIzvodi.AllowUserToResizeRows = false;
            this.dataGridViewIzvodi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewIzvodi.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewIzvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIzvodi.Location = new System.Drawing.Point(877, 139);
            this.dataGridViewIzvodi.Name = "dataGridViewIzvodi";
            this.dataGridViewIzvodi.ReadOnly = true;
            this.dataGridViewIzvodi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIzvodi.Size = new System.Drawing.Size(255, 482);
            this.dataGridViewIzvodi.TabIndex = 12;
            this.dataGridViewIzvodi.Text = "dataGridView2";
            this.dataGridViewIzvodi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewIzvodi_CellMouseDoubleClick);
            // 
            // buttonOpenIzvod
            // 
            this.buttonOpenIzvod.Location = new System.Drawing.Point(877, 110);
            this.buttonOpenIzvod.Name = "buttonOpenIzvod";
            this.buttonOpenIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenIzvod.TabIndex = 13;
            this.buttonOpenIzvod.Text = "Otvori";
            this.buttonOpenIzvod.UseVisualStyleBackColor = true;
            this.buttonOpenIzvod.Click += new System.EventHandler(this.ButtonOpenIzvod_Click);
            // 
            // buttonDeleteIzvod
            // 
            this.buttonDeleteIzvod.Location = new System.Drawing.Point(958, 110);
            this.buttonDeleteIzvod.Name = "buttonDeleteIzvod";
            this.buttonDeleteIzvod.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteIzvod.TabIndex = 14;
            this.buttonDeleteIzvod.Text = "Briši";
            this.buttonDeleteIzvod.UseVisualStyleBackColor = true;
            this.buttonDeleteIzvod.Click += new System.EventHandler(this.ButtonDeleteIzvod_Click);
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Enabled = false;
            this.buttonKnjizi.Location = new System.Drawing.Point(12, 110);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 15;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // labelPortazuje
            // 
            this.labelPortazuje.AutoSize = true;
            this.labelPortazuje.BackColor = System.Drawing.Color.AliceBlue;
            this.labelPortazuje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPortazuje.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelPortazuje.Location = new System.Drawing.Point(466, 67);
            this.labelPortazuje.Name = "labelPortazuje";
            this.labelPortazuje.Size = new System.Drawing.Size(77, 21);
            this.labelPortazuje.TabIndex = 17;
            this.labelPortazuje.Text = "Potražuje:";
            // 
            // labelDuguje
            // 
            this.labelDuguje.AutoSize = true;
            this.labelDuguje.BackColor = System.Drawing.Color.AliceBlue;
            this.labelDuguje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDuguje.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelDuguje.Location = new System.Drawing.Point(277, 67);
            this.labelDuguje.Name = "labelDuguje";
            this.labelDuguje.Size = new System.Drawing.Size(63, 21);
            this.labelDuguje.TabIndex = 16;
            this.labelDuguje.Text = "Duguje:";
            // 
            // labelStanjePocetno
            // 
            this.labelStanjePocetno.AutoSize = true;
            this.labelStanjePocetno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStanjePocetno.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelStanjePocetno.Location = new System.Drawing.Point(6, 37);
            this.labelStanjePocetno.Name = "labelStanjePocetno";
            this.labelStanjePocetno.Size = new System.Drawing.Size(113, 21);
            this.labelStanjePocetno.TabIndex = 18;
            this.labelStanjePocetno.Text = "Početno stanje:";
            // 
            // labelStanjeZavrsno
            // 
            this.labelStanjeZavrsno.AutoSize = true;
            this.labelStanjeZavrsno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStanjeZavrsno.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelStanjeZavrsno.Location = new System.Drawing.Point(6, 67);
            this.labelStanjeZavrsno.Name = "labelStanjeZavrsno";
            this.labelStanjeZavrsno.Size = new System.Drawing.Size(114, 21);
            this.labelStanjeZavrsno.TabIndex = 19;
            this.labelStanjeZavrsno.Text = "Završno stanje:";
            // 
            // groupBoxStanje
            // 
            this.groupBoxStanje.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBoxStanje.Controls.Add(this.labelStanjePocetno);
            this.groupBoxStanje.Controls.Add(this.labelPortazuje);
            this.groupBoxStanje.Controls.Add(this.labelStanjeZavrsno);
            this.groupBoxStanje.Controls.Add(this.labelDuguje);
            this.groupBoxStanje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxStanje.Location = new System.Drawing.Point(181, 29);
            this.groupBoxStanje.Name = "groupBoxStanje";
            this.groupBoxStanje.Size = new System.Drawing.Size(690, 100);
            this.groupBoxStanje.TabIndex = 20;
            this.groupBoxStanje.TabStop = false;
            this.groupBoxStanje.Text = "Stanje izvoda";
            // 
            // IzvodiPregledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 633);
            this.Controls.Add(this.groupBoxStanje);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.buttonDeleteIzvod);
            this.Controls.Add(this.buttonOpenIzvod);
            this.Controls.Add(this.dataGridViewIzvodi);
            this.Controls.Add(this.buttonUcitajIzvod);
            this.Controls.Add(this.dataGridViewStavke);
            this.Name = "IzvodiPregledForm";
            this.Text = "IzvodiPregledForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStavke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIzvodi)).EndInit();
            this.groupBoxStanje.ResumeLayout(false);
            this.groupBoxStanje.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void CustomiseColumnWidthIzvodi()
        {
            dataGridViewIzvodi.RowHeadersVisible = false;
            dataGridViewIzvodi.Columns[0].Width = (int)(dataGridViewIzvodi.Width * 0.4);
            dataGridViewIzvodi.Columns[1].Width = (int)(dataGridViewIzvodi.Width * 0.4);
            dataGridViewIzvodi.Columns[2].Width = (int)(dataGridViewIzvodi.Width * 0.2);
        }
        private void CustomiseColumnWidthDetalji()
        {
            dataGridViewStavke.Columns[0].Width = (int)(dataGridViewStavke.Width * 0.3);
            dataGridViewStavke.Columns[1].Width = (int)(dataGridViewStavke.Width * 0.3);
        }

        private System.Windows.Forms.DataGridView dataGridViewStavke;
        private System.Windows.Forms.Button buttonUcitajIzvod;
        private System.Windows.Forms.DataGridView dataGridViewIzvodi;
        private System.Windows.Forms.Button buttonOpenIzvod;
        private System.Windows.Forms.Button buttonDeleteIzvod;
        private System.Windows.Forms.Button buttonKnjizi;
        private System.Windows.Forms.Label labelPortazuje;
        private System.Windows.Forms.Label labelDuguje;
        private System.Windows.Forms.Label labelStanjePocetno;
        private System.Windows.Forms.Label labelStanjeZavrsno;
        private System.Windows.Forms.GroupBox groupBoxStanje;
    }
}
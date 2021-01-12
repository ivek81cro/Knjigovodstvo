
using Knjigovodstvo.Global;

namespace Knjigovodstvo.URA
{
    partial class UraKnjigaForm
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
            this.dbDdataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonUcitaj = new System.Windows.Forms.Button();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuITroskovi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOdobrenja = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.knjigaFilter1 = new KnjigaFilter(dbDdataGridView1, _columns);
            this.menuPoreznaUra = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dbDdataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbDataGridView1
            //             
            this.dbDdataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDdataGridView1.Location = new System.Drawing.Point(12, 139);
            this.dbDdataGridView1.Name = "dataGridView1";
            this.dbDdataGridView1.Size = new System.Drawing.Size(1241, 466);
            this.dbDdataGridView1.TabIndex = 10;
            this.dbDdataGridView1.Text = "dataGridView1";
            // 
            // buttonUcitaj
            // 
            this.buttonUcitaj.Location = new System.Drawing.Point(12, 27);
            this.buttonUcitaj.Name = "buttonUcitaj";
            this.buttonUcitaj.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitaj.TabIndex = 0;
            this.buttonUcitaj.Text = "Učitaj";
            this.buttonUcitaj.UseVisualStyleBackColor = true;
            this.buttonUcitaj.Click += new System.EventHandler(this.ButtonUcitaj_Click);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(93, 27);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 1;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_Click);
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Location = new System.Drawing.Point(174, 27);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 12;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuITroskovi,
            this.menuOdobrenja,
            this.menuPostavke,
            this.menuPoreznaUra});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1265, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuITroskovi
            // 
            this.menuITroskovi.Name = "menuITroskovi";
            this.menuITroskovi.Size = new System.Drawing.Size(62, 20);
            this.menuITroskovi.Text = "Troškovi";
            this.menuITroskovi.Click += new System.EventHandler(this.ButtonTroskovi_Click);
            // 
            // menuOdobrenja
            // 
            this.menuOdobrenja.Name = "menuOdobrenja";
            this.menuOdobrenja.Size = new System.Drawing.Size(75, 20);
            this.menuOdobrenja.Text = "Odobrenja";
            this.menuOdobrenja.Click += new System.EventHandler(this.ButtonOdobrenja_Click);
            // 
            // menuPostavke
            // 
            this.menuPostavke.Name = "menuPostavke";
            this.menuPostavke.Size = new System.Drawing.Size(115, 20);
            this.menuPostavke.Text = "Postavke knjiženja";
            this.menuPostavke.Click += new System.EventHandler(this.ButtonOpenPostavkeForm);
            // 
            // menuPoreznaUra
            // 
            this.menuPoreznaUra.Name = "menuPoreznaUra";
            this.menuPoreznaUra.Size = new System.Drawing.Size(87, 20);
            this.menuPoreznaUra.Text = "Porezna URA";
            this.menuPoreznaUra.Click += new System.EventHandler(this.ButtonOpenPoreznaUraForm);
            // 
            // knjigaFilter1
            // 
            this.knjigaFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knjigaFilter1.Location = new System.Drawing.Point(12, 69);
            this.knjigaFilter1.Name = "knjigaFilter1";
            this.knjigaFilter1.Size = new System.Drawing.Size(1241, 64);
            this.knjigaFilter1.TabIndex = 13;
            // 
            // UraKnjigaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 617);
            this.Controls.Add(this.knjigaFilter1);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.buttonUcitaj);
            this.Controls.Add(this.dbDdataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UraKnjigaForm";
            this.Text = "Knjiga ulaznih računa";
            ((System.ComponentModel.ISupportInitialize)(this.dbDdataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DBDataGridView dbDdataGridView1;
        private System.Windows.Forms.Button buttonUcitaj;
        private System.Windows.Forms.Button buttonSpremi;
        private Global.KnjigaFilter knjigaFilter1;
        private System.Windows.Forms.Button buttonKnjizi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuITroskovi;
        private System.Windows.Forms.ToolStripMenuItem menuOdobrenja;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private System.Windows.Forms.ToolStripMenuItem menuPoreznaUra;
    }
}
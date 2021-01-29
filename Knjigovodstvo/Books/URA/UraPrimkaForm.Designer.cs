
using Knjigovodstvo.Global;

namespace Knjigovodstvo.URA
{
    partial class UraPrimkaForm
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
            this.buttonUcitajTablicu = new System.Windows.Forms.Button();
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.knjigaFilter1 = new KnjigaFilter(dbDataGridView1, _columns);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuPostavke = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(9, 139);
            this.dbDataGridView1.Name = "dataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(1101, 466);
            this.dbDataGridView1.TabIndex = 10;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // buttonUcitajTablicu
            // 
            this.buttonUcitajTablicu.Location = new System.Drawing.Point(9, 27);
            this.buttonUcitajTablicu.Name = "buttonUcitajTablicu";
            this.buttonUcitajTablicu.Size = new System.Drawing.Size(75, 23);
            this.buttonUcitajTablicu.TabIndex = 0;
            this.buttonUcitajTablicu.Text = "Učitaj";
            this.buttonUcitajTablicu.UseVisualStyleBackColor = true;
            this.buttonUcitajTablicu.Click += new System.EventHandler(this.ButtonLoadTable_Click);
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Location = new System.Drawing.Point(91, 26);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 1;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.ButtonSpremi_ClickAsync);
            // 
            // knjigaFilter1
            // 
            this.knjigaFilter1.Location = new System.Drawing.Point(9, 69);
            this.knjigaFilter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knjigaFilter1.Name = "knjigaFilter1";
            this.knjigaFilter1.Size = new System.Drawing.Size(1101, 64);
            this.knjigaFilter1.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPostavke});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1122, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuPostavke
            // 
            this.menuPostavke.Name = "menuPostavke";
            this.menuPostavke.Size = new System.Drawing.Size(115, 20);
            this.menuPostavke.Text = "Postavke knjiženja";
            this.menuPostavke.Click += new System.EventHandler(this.ButtonPostavke_Click);
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Location = new System.Drawing.Point(172, 27);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 12;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            this.buttonKnjizi.Click += new System.EventHandler(this.ButtonKnjizi_Click);
            // 
            // UraPrimkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 617);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.buttonSpremi);
            this.Controls.Add(this.buttonUcitajTablicu);
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.knjigaFilter1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UraPrimkaForm";
            this.Text = "Ura Primke";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonUcitajTablicu;
        private System.Windows.Forms.Button buttonSpremi;
        private Global.KnjigaFilter knjigaFilter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuPostavke;
        private System.Windows.Forms.Button buttonKnjizi;
    }
}
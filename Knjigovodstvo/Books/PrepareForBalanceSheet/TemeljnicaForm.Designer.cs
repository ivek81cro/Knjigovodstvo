
namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    partial class TemeljnicaForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dbDataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.buttonKnjizi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dbDataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbDataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.ReadOnly = true;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(991, 259);
            this.dbDataGridView1.TabIndex = 10;
            this.dbDataGridView1.Text = "dataGridView1";
            // 
            // buttonKnjizi
            // 
            this.buttonKnjizi.Location = new System.Drawing.Point(13, 324);
            this.buttonKnjizi.Name = "buttonKnjizi";
            this.buttonKnjizi.Size = new System.Drawing.Size(75, 23);
            this.buttonKnjizi.TabIndex = 11;
            this.buttonKnjizi.Text = "Knjiži";
            this.buttonKnjizi.UseVisualStyleBackColor = true;
            // 
            // TemeljnicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 359);
            this.Controls.Add(this.buttonKnjizi);
            this.Controls.Add(this.dbDataGridView1);
            this.Name = "TemeljnicaForm";
            this.Text = "TemeljnicaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private DBDataGridView dbDataGridView1;
        private System.Windows.Forms.Button buttonKnjizi;
    }
}
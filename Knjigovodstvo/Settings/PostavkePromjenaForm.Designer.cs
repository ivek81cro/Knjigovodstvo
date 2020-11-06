namespace Knjigovodstvo.Settings
{
    partial class PostavkePromjenaForm
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
            this.labelId = new System.Windows.Forms.Label();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.labelVrsta = new System.Windows.Forms.Label();
            this.labelVrijednost = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.textBoxVrsta = new System.Windows.Forms.TextBox();
            this.textBoxVrijednost = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(13, 47);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(17, 15);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Location = new System.Drawing.Point(13, 82);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(36, 15);
            this.labelNaziv.TabIndex = 1;
            this.labelNaziv.Text = "Naziv";
            // 
            // labelVrsta
            // 
            this.labelVrsta.AutoSize = true;
            this.labelVrsta.Location = new System.Drawing.Point(13, 117);
            this.labelVrsta.Name = "labelVrsta";
            this.labelVrsta.Size = new System.Drawing.Size(33, 15);
            this.labelVrsta.TabIndex = 2;
            this.labelVrsta.Text = "Vrsta";
            // 
            // labelVrijednost
            // 
            this.labelVrijednost.AutoSize = true;
            this.labelVrijednost.Location = new System.Drawing.Point(13, 152);
            this.labelVrijednost.Name = "labelVrijednost";
            this.labelVrijednost.Size = new System.Drawing.Size(60, 15);
            this.labelVrijednost.TabIndex = 3;
            this.labelVrijednost.Text = "Vrijednost";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(98, 44);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(111, 23);
            this.textBoxId.TabIndex = 4;
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(98, 79);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.ReadOnly = true;
            this.textBoxNaziv.Size = new System.Drawing.Size(111, 23);
            this.textBoxNaziv.TabIndex = 4;
            // 
            // textBoxVrsta
            // 
            this.textBoxVrsta.Location = new System.Drawing.Point(98, 114);
            this.textBoxVrsta.Name = "textBoxVrsta";
            this.textBoxVrsta.ReadOnly = true;
            this.textBoxVrsta.Size = new System.Drawing.Size(111, 23);
            this.textBoxVrsta.TabIndex = 4;
            // 
            // textBoxVrijednost
            // 
            this.textBoxVrijednost.Location = new System.Drawing.Point(98, 149);
            this.textBoxVrijednost.Name = "textBoxVrijednost";
            this.textBoxVrijednost.Size = new System.Drawing.Size(111, 23);
            this.textBoxVrijednost.TabIndex = 4;
            this.textBoxVrijednost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 266);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(183, 266);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Zatvori";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMessage.Location = new System.Drawing.Point(13, 192);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(100, 20);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "labelMessage";
            // 
            // PostavkePromjenaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 301);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxVrijednost);
            this.Controls.Add(this.textBoxVrsta);
            this.Controls.Add(this.textBoxNaziv);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelVrijednost);
            this.Controls.Add(this.labelVrsta);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.labelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PostavkePromjenaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Promjena postavke";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.Label labelVrsta;
        private System.Windows.Forms.Label labelVrijednost;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.TextBox textBoxVrsta;
        private System.Windows.Forms.TextBox textBoxVrijednost;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelMessage;
    }
}
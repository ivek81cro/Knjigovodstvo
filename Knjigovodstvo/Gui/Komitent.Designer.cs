namespace Knjigovodstvo.Gui
{
    partial class Komitent
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
            this.textBoxOib = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxFax = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxIban = new System.Windows.Forms.TextBox();
            this.textBoxTypeName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelOib = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelFax = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelIban = new System.Windows.Forms.Label();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.labelStreet = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSelectCity = new System.Windows.Forms.Button();
            this.labelCode = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxOib
            // 
            this.textBoxOib.Location = new System.Drawing.Point(75, 50);
            this.textBoxOib.MaxLength = 11;
            this.textBoxOib.Name = "textBoxOib";
            this.textBoxOib.Size = new System.Drawing.Size(251, 23);
            this.textBoxOib.TabIndex = 0;
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(75, 112);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(251, 23);
            this.textBoxStreet.TabIndex = 2;
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(75, 143);
            this.textBoxPost.MaxLength = 5;
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.ReadOnly = true;
            this.textBoxPost.Size = new System.Drawing.Size(161, 23);
            this.textBoxPost.TabIndex = 0;
            this.textBoxPost.TabStop = false;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(75, 174);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.ReadOnly = true;
            this.textBoxCity.Size = new System.Drawing.Size(161, 23);
            this.textBoxCity.TabIndex = 0;
            this.textBoxCity.TabStop = false;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(75, 205);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(251, 23);
            this.textBoxPhone.TabIndex = 4;
            // 
            // textBoxFax
            // 
            this.textBoxFax.Location = new System.Drawing.Point(75, 236);
            this.textBoxFax.Name = "textBoxFax";
            this.textBoxFax.Size = new System.Drawing.Size(251, 23);
            this.textBoxFax.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(75, 267);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(251, 23);
            this.textBoxEmail.TabIndex = 6;
            // 
            // textBoxIban
            // 
            this.textBoxIban.Location = new System.Drawing.Point(75, 298);
            this.textBoxIban.MaxLength = 21;
            this.textBoxIban.Name = "textBoxIban";
            this.textBoxIban.Size = new System.Drawing.Size(251, 23);
            this.textBoxIban.TabIndex = 7;
            // 
            // textBoxTypeName
            // 
            this.textBoxTypeName.Location = new System.Drawing.Point(115, 418);
            this.textBoxTypeName.Name = "textBoxTypeName";
            this.textBoxTypeName.Size = new System.Drawing.Size(211, 23);
            this.textBoxTypeName.TabIndex = 8;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(75, 81);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(251, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // labelOib
            // 
            this.labelOib.AutoSize = true;
            this.labelOib.Location = new System.Drawing.Point(18, 53);
            this.labelOib.Name = "labelOib";
            this.labelOib.Size = new System.Drawing.Size(26, 15);
            this.labelOib.TabIndex = 2;
            this.labelOib.Text = "OIB";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(18, 146);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(36, 15);
            this.labelPost.TabIndex = 2;
            this.labelPost.Text = "Pošta";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(18, 177);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(32, 15);
            this.labelCity.TabIndex = 2;
            this.labelCity.Text = "Grad";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(18, 208);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(45, 15);
            this.labelPhone.TabIndex = 2;
            this.labelPhone.Text = "Telefon";
            // 
            // labelFax
            // 
            this.labelFax.AutoSize = true;
            this.labelFax.Location = new System.Drawing.Point(18, 239);
            this.labelFax.Name = "labelFax";
            this.labelFax.Size = new System.Drawing.Size(25, 15);
            this.labelFax.TabIndex = 2;
            this.labelFax.Text = "Fax";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(18, 270);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 15);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email";
            // 
            // labelIban
            // 
            this.labelIban.AutoSize = true;
            this.labelIban.Location = new System.Drawing.Point(18, 301);
            this.labelIban.Name = "labelIban";
            this.labelIban.Size = new System.Drawing.Size(34, 15);
            this.labelIban.TabIndex = 2;
            this.labelIban.Text = "IBAN";
            // 
            // labelTypeName
            // 
            this.labelTypeName.AutoSize = true;
            this.labelTypeName.Location = new System.Drawing.Point(18, 421);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(94, 15);
            this.labelTypeName.TabIndex = 2;
            this.labelTypeName.Text = "Naziv djelatnosti";
            // 
            // labelStreet
            // 
            this.labelStreet.AutoSize = true;
            this.labelStreet.Location = new System.Drawing.Point(18, 115);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(33, 15);
            this.labelStreet.TabIndex = 2;
            this.labelStreet.Text = "Ulica";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(23, 467);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 25);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Spremi";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(303, 467);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 25);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Zatvori";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 84);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(36, 15);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Naziv";
            // 
            // buttonSelectCity
            // 
            this.buttonSelectCity.Location = new System.Drawing.Point(251, 158);
            this.buttonSelectCity.Name = "buttonSelectCity";
            this.buttonSelectCity.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectCity.TabIndex = 3;
            this.buttonSelectCity.Text = "Odaberi";
            this.buttonSelectCity.UseVisualStyleBackColor = true;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(18, 392);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(88, 15);
            this.labelCode.TabIndex = 2;
            this.labelCode.Text = "Šifra djelatnosti";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(18, 361);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(91, 15);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "Vrsta djelatnosti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fax";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(115, 389);
            this.textBoxCode.MaxLength = 21;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(211, 23);
            this.textBoxCode.TabIndex = 7;
            // 
            // textBoxType
            // 
            this.textBoxType.Location = new System.Drawing.Point(115, 358);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.Size = new System.Drawing.Size(211, 23);
            this.textBoxType.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 327);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(251, 23);
            this.textBox3.TabIndex = 5;
            // 
            // Komitent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 510);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.buttonSelectCity);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.labelIban);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelFax);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelOib);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxTypeName);
            this.Controls.Add(this.textBoxIban);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxFax);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(this.textBoxOib);
            this.Name = "Komitent";
            this.Text = "Komitent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOib;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxFax;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxIban;
        private System.Windows.Forms.TextBox textBoxTypeName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelOib;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelFax;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelIban;
        private System.Windows.Forms.Label labelTypeName;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSelectCity;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBox3;
    }
}
﻿namespace Knjigovodstvo.Gui
{
    partial class CityNew
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.labelCounty = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.textBoxPost = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBoxCounty = new System.Windows.Forms.ComboBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 73);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(32, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Grad";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(12, 102);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(36, 15);
            this.labelPost.TabIndex = 0;
            this.labelPost.Text = "Pošta";
            // 
            // labelCounty
            // 
            this.labelCounty.AutoSize = true;
            this.labelCounty.Location = new System.Drawing.Point(12, 44);
            this.labelCounty.Name = "labelCounty";
            this.labelCounty.Size = new System.Drawing.Size(53, 15);
            this.labelCounty.TabIndex = 0;
            this.labelCounty.Text = "Županija";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(12, 15);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(42, 15);
            this.labelCountry.TabIndex = 0;
            this.labelCountry.Text = "Država";
            // 
            // textBoxPost
            // 
            this.textBoxPost.Location = new System.Drawing.Point(68, 99);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(96, 23);
            this.textBoxPost.TabIndex = 1;
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(68, 12);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.ReadOnly = true;
            this.textBoxCountry.Size = new System.Drawing.Size(240, 23);
            this.textBoxCountry.TabIndex = 1;
            this.textBoxCountry.Text = "Hrvatska";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 239);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Odaberi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCounty.FormattingEnabled = true;
            this.comboBoxCounty.Location = new System.Drawing.Point(68, 41);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Size = new System.Drawing.Size(240, 23);
            this.comboBoxCounty.TabIndex = 4;
            this.comboBoxCounty.SelectedValueChanged += new System.EventHandler(this.comboBoxCounty_SelectedValueChanged);
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(68, 70);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(240, 23);
            this.comboBoxCity.TabIndex = 4;
            // 
            // CityNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 274);
            this.Controls.Add(this.comboBoxCity);
            this.Controls.Add(this.comboBoxCounty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxPost);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelCounty);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelName);
            this.Name = "CityNew";
            this.Text = "Unesi novi grad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label labelCounty;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.TextBox textBoxPost;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboBoxCounty;
        private System.Windows.Forms.ComboBox comboBoxCity;
    }
}
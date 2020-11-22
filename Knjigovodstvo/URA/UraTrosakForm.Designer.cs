﻿
namespace Knjigovodstvo.URA
{
    partial class UraTrosakForm
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
            this.dataGridView1 = new Knjigovodstvo.DBDataGridView();
            this.groupBoxFilteri = new System.Windows.Forms.GroupBox();
            this.textBoxFilterNaziv = new System.Windows.Forms.TextBox();
            this.checkBoxDatumi = new System.Windows.Forms.CheckBox();
            this.buttonFilterDatum = new System.Windows.Forms.Button();
            this.dateTimePickerDo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxFilteri.SuspendLayout();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 484);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // groupBoxFilteri
            // 
            this.groupBoxFilteri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilteri.Controls.Add(this.textBoxFilterNaziv);
            this.groupBoxFilteri.Location = new System.Drawing.Point(12, 82);
            this.groupBoxFilteri.Name = "groupBoxFilteri";
            this.groupBoxFilteri.Size = new System.Drawing.Size(1200, 51);
            this.groupBoxFilteri.TabIndex = 11;
            this.groupBoxFilteri.TabStop = false;
            this.groupBoxFilteri.Text = "Filteri";
            // 
            // textBoxFilterNaziv
            // 
            this.textBoxFilterNaziv.Location = new System.Drawing.Point(374, 18);
            this.textBoxFilterNaziv.Name = "textBoxFilterNaziv";
            this.textBoxFilterNaziv.PlaceholderText = "Filter po nazivu";
            this.textBoxFilterNaziv.Size = new System.Drawing.Size(175, 23);
            this.textBoxFilterNaziv.TabIndex = 14;
            this.textBoxFilterNaziv.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterDataGridView);
            // 
            // checkBoxDatumi
            // 
            this.checkBoxDatumi.AutoSize = true;
            this.checkBoxDatumi.Location = new System.Drawing.Point(221, 20);
            this.checkBoxDatumi.Name = "checkBoxDatumi";
            this.checkBoxDatumi.Size = new System.Drawing.Size(147, 19);
            this.checkBoxDatumi.TabIndex = 18;
            this.checkBoxDatumi.Text = "Uključi datume za filter";
            this.checkBoxDatumi.UseVisualStyleBackColor = true;
            this.checkBoxDatumi.CheckStateChanged += new System.EventHandler(this.CheckBoxDatumi_CheckStateChanged);
            // 
            // buttonFilterDatum
            // 
            this.buttonFilterDatum.Location = new System.Drawing.Point(555, 18);
            this.buttonFilterDatum.Name = "buttonFilterDatum";
            this.buttonFilterDatum.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterDatum.TabIndex = 17;
            this.buttonFilterDatum.Text = "Prikaži";
            this.buttonFilterDatum.UseVisualStyleBackColor = true;
            this.buttonFilterDatum.Click += new System.EventHandler(this.ButtonFilterDatum_Click);
            // 
            // dateTimePickerDo
            // 
            this.dateTimePickerDo.Enabled = false;
            this.dateTimePickerDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDo.Location = new System.Drawing.Point(114, 18);
            this.dateTimePickerDo.Name = "dateTimePickerDo";
            this.dateTimePickerDo.Size = new System.Drawing.Size(101, 23);
            this.dateTimePickerDo.TabIndex = 16;
            this.dateTimePickerDo.ValueChanged += new System.EventHandler(this.CheckValidRange);
            // 
            // dateTimePickerOd
            // 
            this.dateTimePickerOd.Enabled = false;
            this.dateTimePickerOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerOd.Location = new System.Drawing.Point(7, 18);
            this.dateTimePickerOd.Name = "dateTimePickerOd";
            this.dateTimePickerOd.Size = new System.Drawing.Size(101, 23);
            this.dateTimePickerOd.TabIndex = 15;
            this.dateTimePickerOd.ValueChanged += new System.EventHandler(this.CheckValidRange);
            // 
            // UraTrosakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 635);
            this.Controls.Add(this.groupBoxFilteri);
            this.Controls.Add(this.dataGridView1);
            this.groupBoxFilteri.Controls.Add(this.checkBoxDatumi);
            this.groupBoxFilteri.Controls.Add(this.buttonFilterDatum);
            this.groupBoxFilteri.Controls.Add(this.dateTimePickerDo);
            this.groupBoxFilteri.Controls.Add(this.dateTimePickerOd);
            this.Name = "UraTrosakForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Knjiga ulaznih računa - Troškovi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFilteri.ResumeLayout(false);
            this.groupBoxFilteri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilteri;
        private System.Windows.Forms.TextBox textBoxFilterNaziv;
        private DBDataGridView dataGridView1;
        private System.Windows.Forms.Button buttonFilterDatum;
        private System.Windows.Forms.DateTimePicker dateTimePickerDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerOd;
        private System.Windows.Forms.CheckBox checkBoxDatumi;
    }
}
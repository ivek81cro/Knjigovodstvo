
namespace Knjigovodstvo.Global
{
    partial class KontoDescription
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelKontoDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelKontoDescription
            // 
            this.labelKontoDescription.AutoSize = true;
            this.labelKontoDescription.Location = new System.Drawing.Point(4, 4);
            this.labelKontoDescription.Name = "labelKontoDescription";
            this.labelKontoDescription.Size = new System.Drawing.Size(0, 15);
            this.labelKontoDescription.TabIndex = 0;
            // 
            // KontoDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelKontoDescription);
            this.Name = "KontoDescription";
            this.Size = new System.Drawing.Size(510, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKontoDescription;
    }
}

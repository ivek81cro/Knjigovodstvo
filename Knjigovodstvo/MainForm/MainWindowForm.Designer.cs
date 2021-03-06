﻿using System;

namespace Knjigovodstvo.MainForm
{
    partial class MainWindowForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.postavkeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKomitent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStopePoreza = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPartneri = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZaposlenici = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGradovi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKnjige = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrimke = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRepro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUraKnjiga = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIraKnjiga = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOsnovnaSredstva = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlaca = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPregledPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObracunPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDodatak = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemJoppd = new System.Windows.Forms.ToolStripMenuItem();
            this.izvodiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPregledIzvoda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFinancijsko = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKontniPlan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTemeljnice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIzracunPdv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDnevnikKnjizenja = new System.Windows.Forms.ToolStripMenuItem();
            this.prozoriMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriSveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeMenu,
            this.menuKnjige,
            this.menuPlaca,
            this.izvodiMenu,
            this.menuFinancijsko,
            this.prozoriMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.prozoriMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1309, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // postavkeMenu
            // 
            this.postavkeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuKomitent,
            this.menuStopePoreza,
            this.menuPartneri,
            this.menuZaposlenici,
            this.menuGradovi});
            this.postavkeMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.postavkeMenu.Name = "postavkeMenu";
            this.postavkeMenu.Size = new System.Drawing.Size(66, 20);
            this.postavkeMenu.Text = "&Postavke";
            // 
            // menuKomitent
            // 
            this.menuKomitent.Name = "menuKomitent";
            this.menuKomitent.Size = new System.Drawing.Size(142, 22);
            this.menuKomitent.Text = "&Komitent";
            this.menuKomitent.Click += new System.EventHandler(this.ShowNewFormKomitent);
            // 
            // menuStopePoreza
            // 
            this.menuStopePoreza.Name = "menuStopePoreza";
            this.menuStopePoreza.Size = new System.Drawing.Size(142, 22);
            this.menuStopePoreza.Text = "&Stope poreza";
            this.menuStopePoreza.Click += new System.EventHandler(this.ShowNewFormPostavke);
            // 
            // menuPartneri
            // 
            this.menuPartneri.Name = "menuPartneri";
            this.menuPartneri.Size = new System.Drawing.Size(142, 22);
            this.menuPartneri.Text = "Par&tneri";
            this.menuPartneri.Click += new System.EventHandler(this.ShowNewFormPartneri);
            // 
            // menuZaposlenici
            // 
            this.menuZaposlenici.Name = "menuZaposlenici";
            this.menuZaposlenici.Size = new System.Drawing.Size(142, 22);
            this.menuZaposlenici.Text = "&Zaposlenici";
            this.menuZaposlenici.Click += new System.EventHandler(this.ShowNewFormZaposlenici);
            // 
            // menuGradovi
            // 
            this.menuGradovi.Name = "menuGradovi";
            this.menuGradovi.Size = new System.Drawing.Size(142, 22);
            this.menuGradovi.Text = "&Gradovi";
            this.menuGradovi.Click += new System.EventHandler(this.ShowNewFormGradovi);
            // 
            // menuKnjige
            // 
            this.menuKnjige.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUra,
            this.menuIra,
            this.menuOsnovnaSredstva});
            this.menuKnjige.Name = "menuKnjige";
            this.menuKnjige.Size = new System.Drawing.Size(52, 20);
            this.menuKnjige.Text = "&Knjige";
            // 
            // menuUra
            // 
            this.menuUra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPrimke,
            this.menuRepro,
            this.menuUraKnjiga});
            this.menuUra.Name = "menuUra";
            this.menuUra.Size = new System.Drawing.Size(167, 22);
            this.menuUra.Text = "URA";
            // 
            // menuPrimke
            // 
            this.menuPrimke.Name = "menuPrimke";
            this.menuPrimke.Size = new System.Drawing.Size(194, 22);
            this.menuPrimke.Text = "Primke";
            this.menuPrimke.Click += new System.EventHandler(this.ShowNewFormUraPrimkaForm);
            // 
            // menuRepro
            // 
            this.menuRepro.Name = "menuRepro";
            this.menuRepro.Size = new System.Drawing.Size(194, 22);
            this.menuRepro.Text = "Primke repromaterijala";
            this.menuRepro.Click += new System.EventHandler(this.ShowNewFormPrimkaRepro);
            // 
            // menuUraKnjiga
            // 
            this.menuUraKnjiga.Name = "menuUraKnjiga";
            this.menuUraKnjiga.Size = new System.Drawing.Size(194, 22);
            this.menuUraKnjiga.Text = "Ulazni računi";
            this.menuUraKnjiga.Click += new System.EventHandler(this.ShowNewFormUraKnjigaPregled);
            // 
            // menuIra
            // 
            this.menuIra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIraKnjiga});
            this.menuIra.Name = "menuIra";
            this.menuIra.Size = new System.Drawing.Size(167, 22);
            this.menuIra.Text = "IRA";
            // 
            // menuIraKnjiga
            // 
            this.menuIraKnjiga.Name = "menuIraKnjiga";
            this.menuIraKnjiga.Size = new System.Drawing.Size(142, 22);
            this.menuIraKnjiga.Text = "Izlazni računi";
            this.menuIraKnjiga.Click += new System.EventHandler(this.ShowNewFormIraKnjigaPregled);
            // 
            // menuOsnovnaSredstva
            // 
            this.menuOsnovnaSredstva.Name = "menuOsnovnaSredstva";
            this.menuOsnovnaSredstva.Size = new System.Drawing.Size(167, 22);
            this.menuOsnovnaSredstva.Text = "Osnovna sredstva";
            this.menuOsnovnaSredstva.Click += new System.EventHandler(this.ShowFormOsnovnoSredstvo);
            // 
            // menuPlaca
            // 
            this.menuPlaca.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPregledPlace,
            this.menuObracunPlace,
            this.menuDodatak,
            this.toolStripSeparator1,
            this.toolStripMenuItemJoppd});
            this.menuPlaca.Name = "menuPlaca";
            this.menuPlaca.Size = new System.Drawing.Size(47, 20);
            this.menuPlaca.Text = "&Plaća";
            // 
            // menuPregledPlace
            // 
            this.menuPregledPlace.Name = "menuPregledPlace";
            this.menuPregledPlace.Size = new System.Drawing.Size(173, 22);
            this.menuPregledPlace.Text = "Pregled";
            this.menuPregledPlace.Click += new System.EventHandler(this.ShowNewFormPregledPlaca);
            // 
            // menuObracunPlace
            // 
            this.menuObracunPlace.Name = "menuObracunPlace";
            this.menuObracunPlace.Size = new System.Drawing.Size(173, 22);
            this.menuObracunPlace.Text = "Obračun Plaće";
            this.menuObracunPlace.Click += new System.EventHandler(this.ShowNewFormObracunPlaca);
            // 
            // menuDodatak
            // 
            this.menuDodatak.Name = "menuDodatak";
            this.menuDodatak.Size = new System.Drawing.Size(173, 22);
            this.menuDodatak.Text = "Obračun Dodataka";
            this.menuDodatak.Click += new System.EventHandler(this.ShowDodatakObracunForm);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItemJoppd
            // 
            this.toolStripMenuItemJoppd.Name = "toolStripMenuItemJoppd";
            this.toolStripMenuItemJoppd.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItemJoppd.Text = "Joppd obrazac";
            this.toolStripMenuItemJoppd.Click += new System.EventHandler(this.ShowNewFormPlacaJoppdForm);
            // 
            // izvodiMenu
            // 
            this.izvodiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPregledIzvoda});
            this.izvodiMenu.Name = "izvodiMenu";
            this.izvodiMenu.Size = new System.Drawing.Size(50, 20);
            this.izvodiMenu.Text = "&Izvodi";
            // 
            // menuPregledIzvoda
            // 
            this.menuPregledIzvoda.Name = "menuPregledIzvoda";
            this.menuPregledIzvoda.Size = new System.Drawing.Size(114, 22);
            this.menuPregledIzvoda.Text = "&Pregled";
            this.menuPregledIzvoda.Click += new System.EventHandler(this.ShowNewFormPregledIzvodaForm);
            // 
            // menuFinancijsko
            // 
            this.menuFinancijsko.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIzracunPdv,
            this.menuKontniPlan,
            this.menuTemeljnice,
            this.menuDnevnikKnjizenja});
            this.menuFinancijsko.Name = "menuFinancijsko";
            this.menuFinancijsko.Size = new System.Drawing.Size(78, 20);
            this.menuFinancijsko.Text = "Financijsko";
            // 
            // menuKontniPlan
            // 
            this.menuKontniPlan.Name = "menuKontniPlan";
            this.menuKontniPlan.Size = new System.Drawing.Size(166, 22);
            this.menuKontniPlan.Text = "Kontni Plan";
            this.menuKontniPlan.Click += new System.EventHandler(this.ShowNewFormKontniPlanPregledForm);
            // 
            // menuTemeljnice
            // 
            this.menuTemeljnice.Name = "menuTemeljnice";
            this.menuTemeljnice.Size = new System.Drawing.Size(166, 22);
            this.menuTemeljnice.Text = "Temeljnice";
            this.menuTemeljnice.Click += new System.EventHandler(this.ShowNewFormTemeljnice);
            // 
            // menuIzracunPdv
            // 
            this.menuIzracunPdv.Name = "menuIzracunPdv";
            this.menuIzracunPdv.Size = new System.Drawing.Size(166, 22);
            this.menuIzracunPdv.Text = "Izračun PDV";
            this.menuIzracunPdv.Click += new System.EventHandler(this.ShowNewPorezPdvForm);
            // 
            // menuDnevnikKnjizenja
            // 
            this.menuDnevnikKnjizenja.Name = "menuDnevnikKnjizenja";
            this.menuDnevnikKnjizenja.Size = new System.Drawing.Size(166, 22);
            this.menuDnevnikKnjizenja.Text = "Dnevnik knjiženja";
            this.menuDnevnikKnjizenja.Click += new System.EventHandler(this.OpenDnevnikKnjizenjaForm);
            // 
            // prozoriMenu
            // 
            this.prozoriMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.zatvoriSveToolStripMenuItem});
            this.prozoriMenu.Name = "prozoriMenu";
            this.prozoriMenu.Size = new System.Drawing.Size(56, 20);
            this.prozoriMenu.Text = "P&rozori";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cascadeToolStripMenuItem.Text = "&Kaskadno";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.tileVerticalToolStripMenuItem.Text = "Poredaj &Vertikalno";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Poredaj &Horizontalno";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // zatvoriSveToolStripMenuItem
            // 
            this.zatvoriSveToolStripMenuItem.Name = "zatvoriSveToolStripMenuItem";
            this.zatvoriSveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.zatvoriSveToolStripMenuItem.Text = "&Zatvori sve";
            this.zatvoriSveToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
            this.indexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "&About ... ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 684);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1309, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 706);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Knjigovodstvo";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeMenu;
        private System.Windows.Forms.ToolStripMenuItem menuKnjige;
        private System.Windows.Forms.ToolStripMenuItem menuPlaca;
        private System.Windows.Forms.ToolStripMenuItem menuObracunPlace;
        private System.Windows.Forms.ToolStripMenuItem izvodiMenu;
        private System.Windows.Forms.ToolStripMenuItem menuPregledIzvoda;
        private System.Windows.Forms.ToolStripMenuItem prozoriMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriSveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem menuStopePoreza;
        private System.Windows.Forms.ToolStripMenuItem menuKomitent;
        private System.Windows.Forms.ToolStripMenuItem menuPartneri;
        private System.Windows.Forms.ToolStripMenuItem menuZaposlenici;
        private System.Windows.Forms.ToolStripMenuItem menuUra;
        private System.Windows.Forms.ToolStripMenuItem menuIra;
        private System.Windows.Forms.ToolStripMenuItem menuGradovi;
        private System.Windows.Forms.ToolStripMenuItem menuPregledPlace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemJoppd;
        private System.Windows.Forms.ToolStripMenuItem menuPrimke;
        private System.Windows.Forms.ToolStripMenuItem menuUraKnjiga;
        private System.Windows.Forms.ToolStripMenuItem menuIraKnjiga;
        private System.Windows.Forms.ToolStripMenuItem menuFinancijsko;
        private System.Windows.Forms.ToolStripMenuItem menuKontniPlan;
        private System.Windows.Forms.ToolStripMenuItem menuDodatak;
        private System.Windows.Forms.ToolStripMenuItem menuTemeljnice;
        private System.Windows.Forms.ToolStripMenuItem menuIzracunPdv;
        private System.Windows.Forms.ToolStripMenuItem menuRepro;
        private System.Windows.Forms.ToolStripMenuItem menuOsnovnaSredstva;
        private System.Windows.Forms.ToolStripMenuItem menuDnevnikKnjizenja;
    }
}




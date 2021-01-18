﻿using Knjigovodstvo.Database;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.Inventory
{
    public partial class OsnovnoSredstvoForm : Form
    {
        public OsnovnoSredstvoForm()
        {
            InitializeComponent();
            LoadDataGrid();
            _bookNames = BookNames.Amortizacija;
            LoadBookkeepingSettings();
        }

        private void LoadDataGrid()
        {
            _dt = new DbDataGet().GetTable(_osnovnoSredstvo);
            dbDataGridView1.DataSource = _dt;

            foreach (DataGridViewColumn col in dbDataGridView1.Columns)
            {
                col.HeaderText =
                    new TableHeaderFormat().FormatHeader(col.HeaderText);
            }

            CustomColumnEditable();
        }

        private void LoadBookkeepingSettings()
        {
            List<DataRow> dr = new DbDataGet().GetTable(new PostavkeKnjizenja(), $"Knjiga='{_bookNames}'").AsEnumerable().ToList();
            _postavkeKnjizenja = new List<PostavkeKnjizenja>();
            _postavkeKnjizenja = (from DataRow dRow in dr
                                  select new PostavkeKnjizenja()
                                  {
                                      Id = int.Parse(dRow["Id"].ToString()),
                                      Knjiga = dRow["Knjiga"].ToString(),
                                      Naziv_stupca = dRow["Naziv_stupca"].ToString(),
                                      Konto = dRow["Konto"].ToString(),
                                      Strana = dRow["Strana"].ToString(),
                                      Mijenja_predznak = dRow["Mijenja_predznak"].ToString() == "True"
                                  }).ToList();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingSettings();
        }

        private void CustomColumnEditable()
        {
            dbDataGridView1.Columns["Id"].Visible = false;
            dbDataGridView1.Columns["Iznos_amortizacije"].Visible = false;
        }

        private void ButtonPostavke_Click(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookNames);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void ButtonDodajNovo_Click(object sender, EventArgs e)
        {
            using OsnovnoSredstvoDodajForm form = new OsnovnoSredstvoDodajForm();
            form.ShowDialog();
            LoadDataGrid();
        }

        private void ButtonObracunAmortizacije_Click(object sender, EventArgs e)
        {

        }

        private DataTable _dt = new DataTable();
        private readonly OsnovnoSredstvo _osnovnoSredstvo= new OsnovnoSredstvo();
        private readonly BookNames _bookNames;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
    }
}

﻿using Knjigovodstvo.Database;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using Knjigovodstvo.IRA;
using Knjigovodstvo.Payroll;
using Knjigovodstvo.URA;
using Knjigovodstvo.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Settings.SettingsBookkeeping
{
    public partial class PostavkeKnjizenjaPregledForm : Form
    {
        public PostavkeKnjizenjaPregledForm(BookNames knjiga)
        {
            InitializeComponent();
            _postavkeKnjizenja.Knjiga = knjiga.ToString();
            switch (knjiga) 
            {
                case BookNames.Ura_odobrenje:
                    PopulateComboBoxStupac(new UraKnjiga());
                    break;
                case BookNames.Ura_trošak:
                    PopulateComboBoxStupac(new UraKnjiga());
                    break;
                case BookNames.Ura_primka:
                    PopulateComboBoxStupac(new Primka());
                    break;
                case BookNames.Ira:
                    PopulateComboBoxStupac(new IraKnjiga());
                    break;
                case BookNames.Place:
                    PopulateComboBoxStupac(new Placa());
                    break;
                case BookNames.Dodaci:
                    PopulateComboBoxStupac(new Dodatak());
                    break;
                default:
                    break;
            }
            LoadDatagrid();
        }

        private void LoadDatagrid()
        {
            dbDataGridView1.DataSource = new DataView(
                new DbDataGet().GetTable(_postavkeKnjizenja, $"Knjiga='{_postavkeKnjizenja.Knjiga}'"))
                .ToTable(false, "Naziv_stupca", "Konto", "Strana", "Mijenja_predznak");

            dbDataGridView1.Columns[0].Width = (int)(dbDataGridView1.Width * 0.3);
            dbDataGridView1.Columns[1].Width = (int)(dbDataGridView1.Width * 0.3);
        }

        private void PopulateComboBoxStupac(IDbObject knjigaVrsta)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();
            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(knjigaVrsta);

            comboBoxStupac.DataSource = obj.ElementAt(0);
        }

        private void TextBoxKonto_MouseClick(object sender, MouseEventArgs e)
        {
            using var form = new KontniPlanPregledForm();
            form.ShowDialog();
            textBoxKonto.Text = form.KontoBroj;
        }

        private void DbDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dbDataGridView1.SelectedRows[0];
            textBoxKonto.Text = _postavkeKnjizenja.Konto =  row.Cells["Konto"].Value.ToString();
            comboBoxStupac.Text = _postavkeKnjizenja.Naziv_stupca =  row.Cells["Naziv_stupca"].Value.ToString();
            comboBoxStrana.Text = _postavkeKnjizenja.Strana =  row.Cells["Strana"].Value.ToString();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            string konto = textBoxKonto.Text;

            if(new IntValidator().Check(konto) 
                && comboBoxStrana.Text != ""
                && comboBoxStupac.Text != "")
            {
                SetPostavkeKnjizenjaMember(konto);
                new DbDataInsert().InsertData(_postavkeKnjizenja);
            }
            else
            {
                MessageBox.Show("Provjerite odabrane i unešene podatke", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDatagrid();
        }

        private void SetPostavkeKnjizenjaMember(string konto)
        {
            if (_kontniPlan.ExistsKonto(konto))
            {
                _postavkeKnjizenja.Konto = textBoxKonto.Text;
                _postavkeKnjizenja.Naziv_stupca = comboBoxStupac.Text;
                _postavkeKnjizenja.Strana = comboBoxStrana.Text;
                _postavkeKnjizenja.Mijenja_predznak = checkBoxPredznak.Checked;
            }
            else
            {
                MessageBox.Show("Nepostojeći konto, kreirajte novi.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ButtonIzmjeni_Click(object sender, EventArgs e)
        {
            _postavkeKnjizenja.GetIdByKontoNazivStupca();
            SetPostavkeKnjizenjaMember(_postavkeKnjizenja.Konto);
            new DbDataUpdate().UpdateData(_postavkeKnjizenja);

            LoadDatagrid();
        }

        private void ButtonBrisi_Click(object sender, EventArgs e)
        {
            _postavkeKnjizenja.GetIdByKontoNazivStupca();
            new DbDataDelete().DeleteItem(_postavkeKnjizenja);

            LoadDatagrid();
        }

        private readonly PostavkeKnjizenja _postavkeKnjizenja = new PostavkeKnjizenja();
        private readonly KontniPlan _kontniPlan = new KontniPlan();
    }
}

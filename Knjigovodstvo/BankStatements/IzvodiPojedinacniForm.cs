﻿using Knjigovodstvo.FinancialReports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.BankStatements
{
    public partial class IzvodiPojedinacniForm : Form
    {
        public IzvodiPojedinacniForm(Izvod izvodKnjiga)
        {
            _izvod = izvodKnjiga;
            InitializeComponent();
            FillData();
            FormMethodPointer += new CallFillKontoColumn(FillKontoColumn);
            accountPairing.userFunctionPointer = FormMethodPointer;
        }

        public delegate void CallFillKontoColumn();
        private event CallFillKontoColumn FormMethodPointer;

        private void FillData()
        {
            labelDatumIzvoda.Text = "Datum izvoda: " + _izvod.Datum_izvoda;
            labelRedniBroj.Text = "Redni broj: " + _izvod.Redni_broj.ToString();
            labelStanjeZavrsno.Text = "Stanje završno: " + _izvod.Novo_stanje.ToString() + " HRK";

            _bindingList = new BindingList<IzvodPromet>(_izvod.Promet);
            _dSource = new BindingSource(_bindingList, null);

            dataGridView1.DataSource = _dSource;

            FillKontoColumn();
            CustomiseColumns();
        }

        private void FillKontoColumn()
        {
            List<IzvodParovi> parovi = new IzvodParovi().GetIzvodParovi();
            KontniPlan konto = new KontniPlan();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() == "" &&
                    parovi.Exists(p => p.Naziv_Izvod == row.Cells["Naziv"].Value.ToString()))
                {
                    int idPartner = parovi
                        .Where(p => p.Naziv_Izvod == row.Cells["Naziv"]
                        .Value.ToString())
                        .FirstOrDefault().Id_Konto;
                    konto.Id = idPartner;
                    konto.GetKontoById();
                    row.Cells["Konto"].Value = konto.Konto;
                }
            }
        }

        private void ButtonSpremi_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() == "")
                {
                    MessageBox.Show("Niste popunili sva polja 'Konto'","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (_izvod.ExistsInDatabase())
            {
                MessageBox.Show("Izvod već postoji u bazi", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (_izvod.InsertData())
            {
                _izvod.GetCurrentId();
            }

            if(_izvod.Id != 0)
            {
                foreach( var promet in _izvod.Promet)
                {
                    promet.Id_izvod = _izvod.Id;
                    promet.InsertData();
                }
            }

            Close();
        }
        
        private readonly Izvod _izvod;
        BindingSource _dSource = new BindingSource();
        BindingList<IzvodPromet> _bindingList;
    }
}

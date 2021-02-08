using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Settings;
using System.Collections.Generic;
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
        }

        public delegate void CallFillKontoColumn();
        private event CallFillKontoColumn FormMethodPointer;

        private void FillData()
        {
            labelDatumIzvoda.Text = "Datum izvoda: " + _izvod.Datum_izvoda;
            labelRedniBroj.Text = "Redni broj: " + _izvod.Redni_broj.ToString();
            labelStanjeZavrsno.Text = "Stanje završno: " + _izvod.Novo_stanje.ToString() + " HRK";

            _dSource = _izvod.GetPrometData();

            dbDataGridView1.DataSource = _dSource;

            FindKontoNumber();
        }

        private void FindKontoNumber()
        {
            List<KontoParovi> parovi = new KontoParovi(BookNames.Izvodi).GetParoviList();
            foreach(DataGridViewRow row in dbDataGridView1.Rows)
            {
                if (row.Cells["Konto"].Value.ToString() != "")
                    continue;
                if (parovi.Exists(p => p.Naziv == row.Cells["Naziv"].Value.ToString()))
                {
                    var paroviFiltered = parovi
                        .Where(p => p.Naziv == row.Cells["Naziv"].Value.ToString())
                        .ToList();
                    KontniPlan konto = new KontniPlan();
                    if(paroviFiltered.Count > 0)
                    {
                        List<string> opisi = new List<string>();
                        foreach (var par in paroviFiltered)
                        {
                            if (row.Cells["Opis"].Value.ToString().Contains(par.Opis))
                            {
                                paroviFiltered.Insert(0, par);
                                int kontoId = paroviFiltered.FirstOrDefault().Id_Konto;
                                konto.GetKontoById(kontoId);
                                break;
                            }                            
                        }
                    }
                    row.Cells["Konto"].Value = konto.Konto;
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dbDataGridView1.SelectedRows.Count > 0)
                kontoDescription.SetLabelKontoDescription(dbDataGridView1.SelectedRows[0]);
        }

        private void ButtonSpremi_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
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
                foreach(DataGridViewRow row  in dbDataGridView1.Rows)
                {
                    IzvodPromet p = new IzvodPromet() { Id_izvod = _izvod.Id };
                    p.InsertData(row);
                }
            }

            Close();
        }

        private void ButtonUpariKonto_Click(object sender, System.EventArgs e)
        {
            using PostavkeParoviKonta form = new PostavkeParoviKonta(BookNames.Izvodi.ToString());
            string[] opisKnjizenja = {_dSource.Rows[dbDataGridView1
                                        .SelectedCells[0]
                                        .RowIndex]["Naziv"]
                                        .ToString(),
                                       _dSource.Rows[dbDataGridView1
                                        .SelectedCells[0]
                                        .RowIndex]["Opis"]
                                        .ToString() };
            form.Parovi.Naziv = opisKnjizenja[0];
            form.Parovi.Opis = opisKnjizenja[1];
            form.SetControls();
            form.ShowDialog();

            FindKontoNumber();
        }

        private readonly Izvod _izvod;
        private DataTable _dSource = new DataTable();
    }
}

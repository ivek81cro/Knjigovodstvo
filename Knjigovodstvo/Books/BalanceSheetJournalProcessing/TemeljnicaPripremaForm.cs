using Knjigovodstvo.BankStatements;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Partners;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Validators;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public partial class TemeljnicaPripremaForm : Form
    {
        public TemeljnicaPripremaForm(IDbObject obj, List<PostavkeKnjizenja> postavkeKnjizenja)
        {
            _postavkeKnjizenja = postavkeKnjizenja;
            _obj = obj;
            string model = obj.GetType().Name;
            InitializeComponent();
            _labelList = new List<Label>() { labelDugovna, labelPotrazna };
            _dt = new DataTable()
            {
                Columns = { "Redni broj", "Opis stavke", "Opis knjiženja", "Konto", "Datum dokumenta", "Dugovna", "Potražna", "Mijenja predznak" }
            };
            SelectType(model);
        }

        private void SelectType(string model)
        {
            TemeljnicaDataPrepare tp = new TemeljnicaDataPrepare();
            switch (model)
            {
                case "KnjigaUra":
                    tp.PrepareDataUra(_dt, _postavkeKnjizenja, _obj);
                    FindKontoNumber();
                    break;
                case "Primka":
                    tp.PrepareDataPrimka(_dt, _postavkeKnjizenja, _obj);
                    FindKontoNumber();
                    break;
                case "PrimkaRepro":
                    tp.PrepareDataPrimkaRepro(_dt, _postavkeKnjizenja, _obj);
                    FindKontoNumber();
                    break;
                case "KnjigaIra":
                    tp.PrepareDataIra(_dt, _postavkeKnjizenja, _obj);
                    FindKontoNumber();
                    break;
                case "PlacaArhiva":
                    tp.PrepareDataPlaca(_dt, _postavkeKnjizenja, _obj);
                    break;
                case "DodatakArhiva":
                    tp.PrepareDataDodatak(_dt, _postavkeKnjizenja, _obj);
                    break;
                case "Izvod":
                    tp.PrepareDataIzvod(_dt, _obj);
                    break;
                default:
                    break;
            }
            PrepareDataShared();
        }        

        private void PrepareDataShared() 
        {
            if (_obj.GetType().Name == "Izvod")
                LoadValuesDebitAndCreditIzvod();
            else
                LoadValuesDebitAndCredit();

            _dt.Columns.Remove("Mijenja predznak");
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns[0].ReadOnly = true;
        }

        private void LoadValuesDebitAndCreditIzvod()
        {
            _dt.Rows[0]["Potražna"] = ((Izvod)_obj).Suma_dugovna.ToString();
            _dt.Rows[0]["Dugovna"] = ((Izvod)_obj).Suma_potrazna.ToString();
            var prometi = ((Izvod)_obj).Promet;
            for (int i = 1; i <= prometi.Count; i++)
            {
                _dt.Rows[i]["Dugovna"] = _dt.Rows[i]["Dugovna"].ToString() == "True" ? prometi[i - 1].Dugovna : 0;
                _dt.Rows[i]["Potražna"] = _dt.Rows[i]["Potražna"].ToString() == "True" ? prometi[i - 1].Potrazna : 0;
            }
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void FindKontoNumber()
        {
            if (_postavkeKnjizenja.Count != 0)
            {
                string naziv = _dt.Rows[0]["Opis knjiženja"].ToString().Split(':')[0];
                _dt.Rows[0]["Konto"] = _kontniPlan.FindByDescription(naziv);
            }
        }

        private void LoadValuesDebitAndCredit()
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();
            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(_obj);
            
            var iznosi = new Dictionary<string, string>();
            for (int i = 0; i < obj.First().Count; i++)
            {
                iznosi.Add(obj.First()[i].ToString(), obj.ElementAt(1)[i].ToString());
            }
            foreach (DataRow row in _dt.Rows)
            {
                ExtractValues(iznosi, row);
            }
            //Remove rows with both sides 0,00
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (string.Equals(_dt.Rows[i][4].ToString(), "0,00")
                    && string.Equals(_dt.Rows[i][5].ToString(), "0,00"))
                {
                    _dt.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void ExtractValues(Dictionary<string, string> iznosi, DataRow row)
        {
            string kljuc = row["Opis stavke"].ToString();
            string value;
            if (row["Dugovna"].ToString() == "True")
            {
                if (iznosi.TryGetValue(kljuc, out value))
                    row["Dugovna"] =
                        row["Mijenja predznak"].ToString() == "True" ?
                        decimal.Parse(value) * -1 : decimal.Parse(value);
            }
            else
            {
                row["Dugovna"] = "0,00";
            }

            if (row["Potražna"].ToString() == "True")
            {
                if (iznosi.TryGetValue($"{kljuc}", out value))
                    row["Potražna"] =
                        row["Mijenja predznak"].ToString() == "True" ?
                        decimal.Parse(value) * -1 : decimal.Parse(value);
            }
            else
            {
                row["Potražna"] = "0,00";
            }

            row["Opis stavke"] = new TableHeaderFormat().FormatHeader(row["Opis stavke"].ToString());
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }        

        private void DbDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dbDataGridView1.SelectedCells[0].ColumnIndex;
            if (dbDataGridView1.Columns[index].HeaderText == "Konto")
            using (var form = new KontniPlanPregledForm()) 
            {
                form.ShowDialog();
                _dt.Rows[dbDataGridView1.SelectedCells[0]
                    .RowIndex]["Konto"] = form.KontoBroj;
            }
        }

        private void DbDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DecimalValidate validate = new DecimalValidate();
            KontniPlan konto = new KontniPlan();
            DataGridViewRow row = dbDataGridView1.Rows[dbDataGridView1.CurrentCell.RowIndex];

            if (!validate.Check(row.Cells["Potražna"].Value.ToString())
                || !validate.Check(row.Cells["Dugovna"].Value.ToString()))
            {
                MessageBox.Show("Vrijednosti u poljima iznosa nisu u odgovarajućem formatu(0,00)", "Upozorenja");
            }

            if (row.Cells["Konto"].Value.ToString() != "" && !konto.ExistsKonto(row.Cells["Konto"].Value.ToString()))
            {
                MessageBox.Show("Nepostojeći konto, unesite novog partnera ili otvorite novi konto.", "Upozorenja");
                row.Cells["Konto"].Value = "";
            }
            
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void ButtonBrisiRed_Click(object sender, System.EventArgs e)
        {
            if(dbDataGridView1.SelectedCells.Count > 0)
                dbDataGridView1.Rows.RemoveAt(dbDataGridView1.SelectedCells[0].RowIndex);
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void ButtonDodajRed_Click(object sender, System.EventArgs e)
        {
            _dt.Rows.Add();
            _checkBalance.CheckEndBalance(_dt, _labelList);
        }

        private void ButtonKnjizi_Click(object sender, System.EventArgs e)
        {
            TemeljnicaPrepSave save = new TemeljnicaPrepSave();
            if (save.PrepareSave(_dt, _postavkeKnjizenja))
            {
                save.SaveToDatabase();
                Knjizeno = true;
                Close();
            }
        }

        private readonly KontniPlan _kontniPlan = new KontniPlan();
        private readonly IDbObject _obj;
        private readonly List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly DataTable _dt;
        private readonly List<Label> _labelList;
        private readonly CheckBalance _checkBalance = new CheckBalance();

        public bool Knjizeno { get; private set; } = false;
    }       
}

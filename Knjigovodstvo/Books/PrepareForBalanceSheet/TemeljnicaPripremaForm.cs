using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Partners;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Validators;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                case "UraKnjiga":
                    tp.PrepareDataUra(_dt, _postavkeKnjizenja, _obj);
                    FindPartnerontoNumber();
                    break;
                case "Primka":
                    tp.PrepareDataPrimka(_dt, _postavkeKnjizenja, _obj);
                    FindPartnerontoNumber();
                    break;
                case "IraKnjiga":
                    tp.PrepareDataIra(_dt, _postavkeKnjizenja, _obj);
                    FindPartnerontoNumber();
                    break;
                case "PlacaArhiva":
                    tp.PrepareDataPlaca(_dt, _postavkeKnjizenja, _obj);
                    break;
                case "DodatakArhiva":
                    tp.PrepareDataDodatak(_dt, _postavkeKnjizenja, _obj);
                    break;
                default:
                    break;
            }
            PrepareDataShared();
        }        

        private void PrepareDataShared() 
        {
            LoadValuesDebitAndCredit();
            _dt.Columns.Remove("Mijenja predznak");
            dbDataGridView1.DataSource = _dt;
            dbDataGridView1.Columns[0].ReadOnly = true;
        }

        private void FindPartnerontoNumber()
        {
            _dt.Rows[0]["Konto"] = _partner.GetKontoDByNaziv(_dt.Rows[0]["Opis knjiženja"].ToString().Split(':')[0]);
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
                string kljuc = row["Opis stavke"].ToString();
                string value;
                if (row["Dugovna"].ToString() == "True")
                {
                    if (iznosi.TryGetValue(kljuc, out value))
                        row["Dugovna"] = 
                            row["Mijenja predznak"].ToString() == "True"?decimal.Parse(value) * -1: decimal.Parse(value);
                }
                else
                {
                    row["Dugovna"] = "0,00";
                }

                if (row["Potražna"].ToString() == "True")
                {
                    if (iznosi.TryGetValue($"{kljuc}", out value))
                        row["Potražna"] = 
                            row["Mijenja predznak"].ToString() == "True" ? decimal.Parse(value) * -1 : decimal.Parse(value);
                }
                else
                {
                    row["Potražna"] = "0,00";
                }

                row["Opis stavke"] = new TableHeaderFormat().FormatHeader(row["Opis stavke"].ToString());
                CheckEndBalance();
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

        private void CheckEndBalance()
        {
            _dugovna = 0;
            _potrazna = 0;
            var validate = new DecimalValidate();
            foreach (DataRow row in _dt.Rows)
            {
                if (validate.Check(row["Dugovna"].ToString()))
                    _dugovna += decimal.Parse(row["Dugovna"].ToString());
                if (validate.Check(row["Potražna"].ToString()))
                    _potrazna += decimal.Parse(row["Potražna"].ToString());
            }

            labelDugovna.Text = "Dugovna: " + _dugovna.ToString();
            labelPotrazna.Text = "Potražna: " + _potrazna.ToString();
            if (_dugovna == _potrazna)
            {
                labelDugovna.ForeColor = Color.Green;
                labelPotrazna.ForeColor = Color.Green;
            }
            else
            {
                labelDugovna.ForeColor = Color.Red;
                labelPotrazna.ForeColor = Color.Red;
            }
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
            foreach (DataGridViewRow row in dbDataGridView1.Rows)
            {
                if (!validate.Check(row.Cells["Potražna"].Value.ToString())
                    || !validate.Check(row.Cells["Dugovna"].Value.ToString()))
                    MessageBox.Show("Vrijednosti u poljima iznosa nisu u odgovarajućem formatu(0,00)", "Upozorenja");
            }
            CheckEndBalance();
        }

        private void ButtonBrisiRed_Click(object sender, System.EventArgs e)
        {
            if(dbDataGridView1.SelectedCells.Count > 0)
                dbDataGridView1.Rows.RemoveAt(dbDataGridView1.SelectedCells[0].RowIndex);
            CheckEndBalance();
        }

        private void ButtonDodajRed_Click(object sender, System.EventArgs e)
        {
            _dt.Rows.Add();
            CheckEndBalance();
        }

        private void ButtonKnjizi_Click(object sender, System.EventArgs e)
        {
            TemeljnicaPrepSave save = new TemeljnicaPrepSave();
            if (save.PrepareSave(_dt, _postavkeKnjizenja))
                save.SaveToDatabase();
            Close();
        }

        private readonly Partneri _partner = new Partneri();
        private readonly IDbObject _obj;
        private readonly List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly DataTable _dt;
        private decimal _potrazna = 0;
        private decimal _dugovna = 0;
    }       
}

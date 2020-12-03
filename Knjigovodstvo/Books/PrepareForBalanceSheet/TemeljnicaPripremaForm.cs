using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using Knjigovodstvo.IRA;
using Knjigovodstvo.Partners;
using Knjigovodstvo.Settings;
using Knjigovodstvo.URA;
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
            switch (model)
            {
                case "UraKnjiga":
                    PrepareDataUra();
                    break;
                case "Primka":
                    PrepareDataPrimka();
                    break;
                case "IraKnjiga":
                    PrepareDataIra();
                    break;
                default:
                    break;
            }
        }

        private void PrepareDataIra()
        {
            IraKnjiga knjiga = (IraKnjiga)_obj;

            foreach (var postavka in _postavkeKnjizenja)
            {
                _dt.Rows.Add(
                    knjiga.Redni_broj,
                    postavka.Naziv_stupca,
                    knjiga.Naziv_i_sjediste_kupca.Split(' ')[0] + ": " + knjiga.Broj_racuna,
                    postavka.Konto,
                   knjiga.Datum.Split(' ')[0],
                    postavka.Strana == "Dugovna",
                    postavka.Strana == "Potražna",
                    postavka.Mijenja_predznak == true
                    );
            }
            PrepareDataShared();
        }

        private void PrepareDataUra()
        {
            UraKnjiga knjiga = (UraKnjiga)_obj;

            foreach (var postavka in _postavkeKnjizenja)
            {
                _dt.Rows.Add(
                    knjiga.Redni_broj,
                    postavka.Naziv_stupca,
                    knjiga.Naziv_dobavljaca + ":" + knjiga.Broj_racuna,
                    postavka.Konto,
                    knjiga.Datum_racuna.Split(' ')[0],
                    postavka.Strana == "Dugovna",
                    postavka.Strana == "Potražna",
                    postavka.Mijenja_predznak == true
                    );
            }
            PrepareDataShared();
        }

        private void PrepareDataPrimka()
        {
            Primka knjiga = (Primka)_obj;

            foreach (var postavka in _postavkeKnjizenja)
            {
                _dt.Rows.Add(
                    knjiga.Redni_broj,
                    postavka.Naziv_stupca,
                    knjiga.Naziv_dobavljaca + ":" + knjiga.Broj_racuna,
                    postavka.Konto,
                    knjiga.Datum_knjizenja.Split(' ')[0],
                    postavka.Strana == "Dugovna",
                    postavka.Strana == "Potražna",
                    postavka.Mijenja_predznak == true
                    );
            }
            PrepareDataShared();
        }

        private void PrepareDataShared() 
        {
            _dt.Rows[0]["Konto"] = _partner.GetKontoDByNaziv(_dt.Rows[0]["Opis knjiženja"].ToString().Split(':')[0]);

            LoadValuesDebitAndCredit();
            _dt.Columns.Remove("Mijenja predznak");
            dbDataGridView1.DataSource = _dt;
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
                CheckAreSidesEqual();
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

        private void CheckAreSidesEqual()
        {
            _dugovna = 0;
            _potrazna = 0;
            var validate = new FloatValidator();
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
            if(dbDataGridView1.SelectedCells[0].ColumnIndex == 2)
            using (var form = new KontniPlanPregledForm()) 
            {
                form.ShowDialog();
                _dt.Rows[dbDataGridView1.SelectedCells[0].RowIndex][dbDataGridView1.SelectedCells[0].ColumnIndex] = form.KontoBroj;
            }
        }

        private void DbDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CheckAreSidesEqual();
        }

        private void ButtonBrisiRed_Click(object sender, System.EventArgs e)
        {
            if(dbDataGridView1.SelectedCells.Count > 0)
                dbDataGridView1.Rows.RemoveAt(dbDataGridView1.SelectedCells[0].RowIndex);
            CheckAreSidesEqual();
        }

        private void ButtonDodajRed_Click(object sender, System.EventArgs e)
        {
            _dt.Rows.Add("", "", "", "", "", "");
            CheckAreSidesEqual();
        }

        private void ButtonKnjizi_Click(object sender, System.EventArgs e)
        {
            foreach(DataRow row in _dt.Rows)
            {
                _temeljnicaStavka.Add(new TemeljnicaStavka()
                {
                    Opis = row["Opis knjiženja"].ToString(),
                    Dokument = _postavkeKnjizenja.ElementAt(0).Knjiga,
                    Broj = int.Parse(row["Redni broj"].ToString()),
                    Konto = row["Konto"].ToString(),
                    Datum = row["Datum dokumenta"].ToString(),
                    Duguje2 = decimal.Parse(row["Dugovna"].ToString()),
                    Potrazuje2 = decimal.Parse(row["Potražna"].ToString())
                });
            }
        }

        private readonly Partneri _partner = new Partneri();
        private List<TemeljnicaStavka> _temeljnicaStavka = new List<TemeljnicaStavka>();
        private readonly IDbObject _obj;
        private readonly List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly DataTable _dt;
        private decimal _potrazna = 0;
        private decimal _dugovna = 0;
    }       
}

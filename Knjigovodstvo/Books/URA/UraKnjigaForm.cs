using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.GeneralData.WaitForm;
using Knjigovodstvo.Global;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.PoreznaUra;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.URA
{
    partial class UraKnjigaForm : Form
    {
        public UraKnjigaForm()
        {
            _columns.Add(0, "Datum");
            _columns.Add(1, "Naziv_dobavljaca");
            _columns.Add(2, "Broj_racuna");
            InitializeComponent();
            _dt = new DbDataCustomQuery()
                .ExecuteQuery("SELECT TOP 1 Redni_broj FROM KnjigaUra WHERE Redni_broj IS NOT NULL ORDER BY Redni_broj DESC;");
            if (_dt.Rows.Count != 0)
                _lastRecord = int.Parse(_dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;
            LoadDatagrid();
            _bookName = BookNames.Ura_trošak;
            LoadBookkeepingsettings();
        }

        private void LoadDatagrid()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    dbDdataGridView1.DataSource = new DbDataGet().GetTable(_uraKnjiga);
                }));
            }
            else
            {
                dbDdataGridView1.DataSource = new DbDataGet().GetTable(_uraKnjiga);
            }
            FixColumnHeaders();
        }

        private void LoadBookkeepingsettings()
        {
            List<DataRow> dr = new DbDataGet().GetTable(new PostavkeKnjizenja(), $"Knjiga='{_bookName}'").AsEnumerable().ToList();
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

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dbDdataGridView1.Columns.Count; i++)
            {
                dbDdataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dbDdataGridView1.Columns[i].HeaderText);
            }
        }

        private void OpenAndLoadXlsFile()
        {
            string path = "";
            ConvertXlsToCsv conv = new ConvertXlsToCsv("ulaznih");
            conv.OpenXlsFile(ref path);

            //internal method used to pass params to method used as argument in WaitDialog constr.
            void act()
            {
                conv.SaveToCsvAndLoad(ref path);
                _listaStavki = File.ReadAllLines(path).Skip(3).Select(v => new KnjigaUra().FromCsv(v)).ToList();
            }

            using (WaitDialog waitDialog = new WaitDialog(act, SplashMessages.Učitavanje))
            {
                waitDialog.ShowDialog(this);
            }

            var data = new BindingSource
            {
                DataSource = _listaStavki
            };
            dbDdataGridView1.DataSource = data;
        }

        private void SaveDataToDatabase()
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (KnjigaUra stavka in _listaStavki)
            {
                if (stavka.Redni_broj > _lastRecord)
                    ins.InsertData(stavka);
            }
        }

        private void SetSelectedItem(DataGridViewRow row) 
        {
            _uraKnjiga.Redni_broj = int.Parse(row.Cells["Redni_broj"].Value.ToString());
            _uraKnjiga.GetDataFromDatabaseByRedniBroj();
        }

        private void ButtonUcitaj_Click(object sender, EventArgs e)
        {
            OpenAndLoadXlsFile();
            FixColumnHeaders();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            using (WaitDialog waitDialog = new WaitDialog(SaveDataToDatabase, SplashMessages.Spremanje))
            {
                waitDialog.ShowDialog(this);
            }
            LoadDatagrid();
        }

        private void ButtonTroskovi_Click(object sender, EventArgs e)
        {
            dbDdataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Troskove);
            _bookName = BookNames.Ura_trošak;
            LoadBookkeepingsettings();
            FixColumnHeaders();
        }

        private void ButtonOdobrenja_Click(object sender, EventArgs e)
        {
            dbDdataGridView1.DataSource = new DbDataExecProcedure().GetTable(ProcedureNames.Izdvoji_Odobrenja);
            _bookName = BookNames.Ura_odobrenje;
            LoadBookkeepingsettings();
            FixColumnHeaders();
        }

        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookName);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingsettings();
        }

        private void ButtonOpenPoreznaUraForm(object sender, EventArgs e)
        {
            PoreznaUraForm form = new PoreznaUraForm();
            form.ShowDialog();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dbDdataGridView1.SelectedRows)
            {
                SetSelectedItem(row);//TODO: Knjizenje repromaterijala
                if (_uraKnjiga.Knjizen || _uraKnjiga.Broj_primke != 0)
                    continue;
                TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_uraKnjiga, _postavkeKnjizenja);
                form.ShowDialog();
                if (!form.Knjizeno)
                    break;
                else
                    new DbDataCustomQuery()
                        .ExecuteQuery($"UPDATE KnjigaUra SET Knjizen = 1 WHERE Redni_broj = {_uraKnjiga.Redni_broj}");
            }
        }

        private BookNames _bookName;
        private List<KnjigaUra> _listaStavki = new List<KnjigaUra>();
        private readonly int _lastRecord = 0;
        private readonly DataTable _dt;
        private readonly KnjigaUra _uraKnjiga = new KnjigaUra();
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}

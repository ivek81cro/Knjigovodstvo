using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.GeneralData.WaitForm;
using Knjigovodstvo.Global;
using Knjigovodstvo.Helpers;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.IRA
{
    public partial class IraKnjigaForm : Form
    {
        public IraKnjigaForm()
        {
            _columns.Add(0, "Datum");
            _columns.Add(1, "Naziv_i_sjediste_kupca");
            _columns.Add(2, "Broj_racuna");
            InitializeComponent();
            DataTable dt = new DbDataCustomQuery()
                    .ExecuteQuery("SELECT TOP 1 Redni_broj FROM KnjigaIra WHERE Redni_broj IS NOT NULL ORDER BY Redni_broj DESC;");
            if (dt.Rows.Count != 0)
                _lastRecord = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            else
                _lastRecord = 0;
            LoadDatagrid();
            _bookNames = BookNames.Ira;
            LoadBookkeepingSettings();
        }

        private void LoadDatagrid()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.DataSource = new DbDataGet().GetTable(new KnjigaIra());
                }));
            }
            else
            {
                dataGridView1.DataSource = new DbDataGet().GetTable(new KnjigaIra());
            }
            FixColumnHeaders();
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dataGridView1.Columns[i].HeaderText);
            }
        }

        private void OpenAndLoadXlsFile()
        {
            string path = "";
            ConvertXlsToCsv conv = new ConvertXlsToCsv("izlaznih");
            conv.OpenXlsFile(ref path);

            //internal method used to pass params to method used as argument in WaitDialog constr.
            if (path != null)
            {
                void act()
                {
                    conv.SaveToCsvAndLoad(ref path);
                    _listaStavki = File.ReadAllLines(path).Skip(3).Select(v => new KnjigaIra().FromCsv(v)).ToList();                    
                }

                using (WaitDialog waitDialog = new WaitDialog(act, SplashMessages.Učitavanje))
                {
                    waitDialog.ShowDialog(this);                    
                }
            }

            var data = new BindingSource
            {
                DataSource = _listaStavki
            };
            dataGridView1.DataSource = data;
            FixColumnHeaders();
        }

        private void SaveDataToDatabase()
        {
            DbDataInsert ins = new DbDataInsert();
            foreach (KnjigaIra stavka in _listaStavki)
            {
                if (stavka.Redni_broj > _lastRecord)
                    ins.InsertData(stavka);
            }
            LoadDatagrid();
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

        private void SetSelectedItem(DataGridViewRow row)
        {
            _iraKnjiga.Redni_broj = int.Parse(row.Cells["Redni_broj"].Value.ToString());
            _iraKnjiga.GetDataFromDatabaseByRedniBroj();
        }

        private void ButtonUcitaj_ClickAsync(object sender, EventArgs e)
        {
            OpenAndLoadXlsFile();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            using (WaitDialog waitDialog = new WaitDialog(SaveDataToDatabase, SplashMessages.Spremanje))
            {
                waitDialog.ShowDialog(this);
            }
        }

        private void ButtonPostavke_Click(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(_bookNames);
            form.FormClosing += new FormClosingEventHandler(PostavkeClosing_Event);
            form.ShowDialog();
        }

        private void PostavkeClosing_Event(object sender, FormClosingEventArgs e)
        {
            LoadBookkeepingSettings();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                SetSelectedItem(row);
                if (_iraKnjiga.Knjizen)
                    continue;
                TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_iraKnjiga, _postavkeKnjizenja);
                form.ShowDialog(); 
                if (!form.Knjizeno)
                    break;
                else
                    new DbDataCustomQuery()
                        .ExecuteQuery($"UPDATE KnjigaIra SET Knjizen = 1 WHERE Redni_broj = {_iraKnjiga.Redni_broj}");
            }
        }        

        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly KnjigaIra _iraKnjiga = new KnjigaIra();
        private readonly BookNames _bookNames;
        private List<KnjigaIra> _listaStavki = new List<KnjigaIra>();
        private readonly int _lastRecord = 0;
        private readonly Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}

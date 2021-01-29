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
            _bookNames = BookNames.Ira;
            InitializeComponent();            
            LoadDatagrid();
            LoadBookkeepingSettings();
        }

        private void LoadDatagrid()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    dbDataGridView1.DataSource = new DbDataGet().GetTable(new KnjigaIra());
                }));
            }
            else
            {
                dbDataGridView1.DataSource = new DbDataGet().GetTable(new KnjigaIra());
            }
            FixColumnHeaders();
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dbDataGridView1.Columns.Count; i++)
            {
                dbDataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dbDataGridView1.Columns[i].HeaderText);
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

                using WaitDialog waitDialog = new WaitDialog(act, SplashMessages.Učitavanje);
                waitDialog.ShowDialog(this);
            }

            var data = new BindingSource
            {
                DataSource = _listaStavki
            };
            dbDataGridView1.DataSource = data;
            FixColumnHeaders();
        }

        private void SaveDataToDatabase()
        {
            DbDataInsert ins = new DbDataInsert();
            ins.InsertDataBulk(_iraKnjiga, dbDataGridView1);
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

        private void CheckBoxShowCtrlDialog_CheckStateChanged(object sender, EventArgs e)
        {
            _noControllDialog = checkBoxShowCtrlDialog.Checked;
        }

        private void ButtonUcitaj_ClickAsync(object sender, EventArgs e)
        {
            OpenAndLoadXlsFile();
        }

        private void ButtonSpremi_Click(object sender, EventArgs e)
        {
            using WaitDialog waitDialog = new WaitDialog(SaveDataToDatabase, SplashMessages.Spremanje);
            waitDialog.ShowDialog(this);
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
            foreach (DataGridViewRow row in dbDataGridView1.SelectedRows)
            {
                SetSelectedItem(row);
                TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_iraKnjiga, _postavkeKnjizenja);
                if (_noControllDialog)
                {
                    form.ProcessDirectly();
                }
                else
                {
                    form.ShowDialog();
                }
                string query = $"UPDATE KnjigaIra SET Knjizen = 1 WHERE Redni_broj = {_iraKnjiga.Redni_broj}";
                if (!form.Knjizeno)
                    break;
                else
                    new DbDataCustomQuery().ExecuteQuery(query);
            }
        }

        private bool _noControllDialog;
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly KnjigaIra _iraKnjiga = new KnjigaIra();
        private readonly BookNames _bookNames;
        private List<KnjigaIra> _listaStavki = new List<KnjigaIra>();
        private readonly Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}

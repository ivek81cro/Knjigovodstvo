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

namespace Knjigovodstvo.URA
{
    public partial class UraPrimkaReproForm : Form
    {
        public UraPrimkaReproForm()
        {
            _columns.Add(0, "Datum_knjizenja");
            _columns.Add(1, "Naziv_dobavljaca");
            _columns.Add(2, "Broj_racuna");
            _bookNames = BookNames.Ura_repro;
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
                    dbDataGridView1.DataSource = new DbDataGet().GetTable(_primkaRepro);
                }));
            }
            else
            {
                dbDataGridView1.DataSource = new DbDataGet().GetTable(_primkaRepro);
            }
            FixColumnHeaders();
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

            if(_postavkeKnjizenja.Count == 0)
            {
                MessageBox.Show("Ne postoje postavke knjiženja za dokumente, molim postavite ih.", "Upozorenja");
            }
        }

        private void FixColumnHeaders()
        {
            for (int i = 0; i < dbDataGridView1.Columns.Count; i++)
            {
                dbDataGridView1.Columns[i].HeaderText =
                    new TableHeaderFormat().FormatHeader(dbDataGridView1.Columns[i].HeaderText);
            }
        }

        /// <summary>
        /// Opens exported .xlsx file and imports data
        /// </summary>
        private void OpenAndLoadXlsFile()
        {
            string path = "";
            ConvertXlsToCsv conv = new ConvertXlsToCsv("Primke");
            conv.OpenXlsFile(ref path);

            //internal method used to pass params to method used as argument in WaitDialog constr.
            void act()
            {
                conv.SaveToCsvAndLoad(ref path);
                _listaPrimki = File.ReadAllLines(path).Skip(3).Select(v => new PrimkaRepro().FromCsv(v)).ToList();
            }

            using (WaitDialog waitDialog = new WaitDialog(act, SplashMessages.Učitavanje))
            {
                waitDialog.ShowDialog(this);
            }

            var data = new BindingSource
            {
                DataSource = _listaPrimki
            };

            dbDataGridView1.DataSource = data;
        }

        private void SaveDataToDatabase()
        {
            DbDataInsert ins = new DbDataInsert();
            ins.InsertDataBulk(_primkaRepro, dbDataGridView1);
        }

        private void SetSelectedItem(DataGridViewRow row)
        {
            _primkaRepro.Broj_u_knjizi_ura = int.Parse(row.Cells["Broj_u_knjizi_ura"].Value.ToString());
            _primkaRepro.GetDataFromDatabaseByUraBroj();
        }

        private void CheckBoxShowCtrlDialog_CheckStateChanged(object sender, EventArgs e)
        {
            _noControllDialog = checkBoxShowCtrlDialog.Checked;
        }

        private void ProcessSelectedItems()
        {
            foreach (DataGridViewRow row in dbDataGridView1.SelectedRows)
            {
                SetSelectedItem(row);
                using TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_primkaRepro, _postavkeKnjizenja);
                if (_noControllDialog)
                {
                    form.ProcessDirectly();
                }
                else
                {
                    form.ShowDialog();
                }
                string query = $"UPDATE KnjigaUra SET Knjizen = 1 WHERE Redni_broj = {_primkaRepro.Broj_u_knjizi_ura}";
                if (!form.Knjizeno)
                    break;
                else
                    new DbDataCustomQuery().ExecuteQuery(query);
            }
        }

        /// <summary>
        /// Read CSV file into List and fill DataGridView with data for review before saving to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadTable_Click(object sender, EventArgs e)
        {
            OpenAndLoadXlsFile();
            FixColumnHeaders();
        }

        /// <summary>
        /// Save data from DataGridView to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSpremi_ClickAsync(object sender, EventArgs e)
        {
            using (WaitDialog waitDialog = new WaitDialog(SaveDataToDatabase, SplashMessages.Spremanje))
            {
                waitDialog.ShowDialog(this);
            }
            LoadDatagrid();
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
            using WaitDialog waitDialog = new WaitDialog(ProcessSelectedItems, SplashMessages.Spremanje);
            waitDialog.ShowDialog(this);
        }

        private bool _noControllDialog;
        private readonly PrimkaRepro _primkaRepro = new PrimkaRepro();
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
        private readonly BookNames _bookNames;
        private List<PrimkaRepro> _listaPrimki = new List<PrimkaRepro>();
        private readonly Dictionary<int, string> _columns = new Dictionary<int, string>();
    }
}

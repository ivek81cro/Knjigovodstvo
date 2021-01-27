using Knjigovodstvo.Books.PrepareForBalanceSheet;
using Knjigovodstvo.Database;
using Knjigovodstvo.IRA;
using Knjigovodstvo.Settings;
using Knjigovodstvo.Settings.SettingsBookkeeping;
using Knjigovodstvo.URA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo
{
    public partial class PorezPdvForm : Form
    {
        public PorezPdvForm()
        {
            InitializeComponent();
            _postavkeKnjizenja = new PostavkeKnjizenja().GetPostavkeKnjizenjaList(BookNames.Vat);
        }

        private void ImportDataFromDatabase()
        {
            string datumOd = dateTimePickerOd.Value.ToString("yyyy-MM-dd");
            string datumDo = dateTimePickerDo.Value.ToString("yyyy-MM-dd");
            DataTable dt = new DbDataGet().GetTable(new KnjigaUra(), $"Datum BETWEEN '{datumOd}' AND '{datumDo}'");
            _knjigaIra = new List<KnjigaIra>();
            _knjigaUra = new List<KnjigaUra>();

            foreach(DataRow row in dt.Rows)
            {
                KnjigaUra ura = new KnjigaUra();
                ura.FillData(row);
                _knjigaUra.Add(ura);
            }

            dt = new DbDataGet().GetTable(new KnjigaIra(), $"Datum BETWEEN '{datumOd}' AND '{datumDo}'");
            foreach (DataRow row in dt.Rows)
            {
                KnjigaIra ira = new KnjigaIra();
                ira.FillData(row);
                _knjigaIra.Add(ira);
            }

            SumVatItems();
        }

        private void SumVatItems()
        {
            if(_knjigaIra.Count > 0 && _knjigaIra.Count > 0)
            {
                _pdvStavke.Porez_osnovica_0_per = _knjigaIra.Sum(item => item.Porezna_osnovica_0_per);
                _pdvStavke.Porez_osnovica_5_per = _knjigaIra.Sum(item => item.Porezna_osnovica_5_per);
                _pdvStavke.Porez_osnovica_13_per = _knjigaIra.Sum(item => item.Porezna_osnovica_13_per);
                _pdvStavke.Porez_osnovica_25_per = _knjigaIra.Sum(item => item.Porezna_osnovica_25_per);
                _pdvStavke.Porez_za_T5 = _knjigaIra.Sum(item => item.PDV_5_per);
                _pdvStavke.Porez_za_T13 = _knjigaIra.Sum(item => item.PDV_13_per);
                _pdvStavke.Porez_za_T25 = _knjigaIra.Sum(item => item.PDV_25_per);
                _pdvStavke.Pretporez_osnovica_0_per = _knjigaUra.Sum(item => item.Porezna_osnovica_0_per);
                _pdvStavke.Pretporez_osnovica_5_per = _knjigaUra.Sum(item => item.Porezna_osnovica_5_per);
                _pdvStavke.Pretporez_osnovica_13_per = _knjigaUra.Sum(item => item.Porezna_osnovica_13_per);
                _pdvStavke.Pretporez_osnovica_25_per = _knjigaUra.Sum(item => item.Porezna_osnovica_25_per);
                _pdvStavke.Pretporez_za_T5 = _knjigaUra.Sum(item => item.Pretporez_za_T5);
                _pdvStavke.Pretporez_za_T13 = _knjigaUra.Sum(item => item.Pretporez_za_T13);
                _pdvStavke.Pretporez_za_T25 = _knjigaUra.Sum(item => item.Pretporez_za_T25);
            }
            _pdvStavke.SumTotals();
            SetLabels();
        }

        private void SetLabels()
        {
            labelIznPpOs5.Text = _pdvStavke.Pretporez_osnovica_5_per.ToString("n");
            labelIzPpOs13.Text = _pdvStavke.Pretporez_osnovica_13_per.ToString("n");
            labelIzPpOs25.Text = _pdvStavke.Pretporez_osnovica_25_per.ToString("n");
            labelIzPpOsUkupno.Text = _pdvStavke.Pretporez_osnovica_ukupno.ToString("n");
            labelIzPp5.Text = _pdvStavke.Pretporez_za_T5.ToString("n");
            labelIzPp13.Text = _pdvStavke.Pretporez_za_T13.ToString("n");
            labelIzPp25.Text = _pdvStavke.Pretporez_za_T25.ToString("n");
            labelIzPpUkupno.Text = _pdvStavke.Pretporez_ukupno.ToString("n");

            labelIzPorOs5.Text = _pdvStavke.Porez_osnovica_5_per.ToString("n");
            labelIzPorOs13.Text = _pdvStavke.Porez_osnovica_13_per.ToString("n");
            labelIzPorOs25.Text = _pdvStavke.Porez_osnovica_25_per.ToString("n");
            labelIzPorOsUkupno.Text = _pdvStavke.Porez_osnovica_ukupno.ToString("n");
            labelIzPor5.Text = _pdvStavke.Porez_za_T5.ToString("n");
            labelIzPor13.Text = _pdvStavke.Porez_za_T13.ToString("n");
            labelIzPor25.Text = _pdvStavke.Porez_za_T25.ToString("n");
            labelIzPorUkupno.Text = _pdvStavke.Porez_ukupno.ToString("n");

            labelIznZaUplatu.Text = _pdvStavke.Za_uplatu.ToString("n");
        }

        private void LoadBookkeepingsettings()
        {
            _postavkeKnjizenja = new PostavkeKnjizenja()
                .GetPostavkeKnjizenjaList(BookNames.Vat);
        }

        private void ButtonOpenPostavkeForm(object sender, EventArgs e)
        {
            PostavkeKnjizenjaPregledForm form = new PostavkeKnjizenjaPregledForm(BookNames.Vat);
            form.ShowDialog();
            LoadBookkeepingsettings();
        }

        private void ButtonKnjizi_Click(object sender, EventArgs e)
        {
            _pdvStavke.Datum_od = dateTimePickerOd.Value.ToString("dd.MM.yyyy.");
            _pdvStavke.Datum_do = dateTimePickerDo.Value.ToString("dd.MM.yyyy.");
            if (_pdvStavke.SaveToDatabase())
            {
                TemeljnicaPripremaForm form = new TemeljnicaPripremaForm(_pdvStavke, _postavkeKnjizenja);
                form.ShowDialog();
            }
            else
            {

            }
        }

        private void ButtonIzracunaj_Click(object sender, EventArgs e)
        {
            _pdvStavke = new PdvStavke();
            ImportDataFromDatabase();
        }

        private List<KnjigaUra> _knjigaUra = new List<KnjigaUra>();
        private List<KnjigaIra> _knjigaIra = new List<KnjigaIra>();
        private PdvStavke _pdvStavke = new PdvStavke();
        private List<PostavkeKnjizenja> _postavkeKnjizenja;
    }
}

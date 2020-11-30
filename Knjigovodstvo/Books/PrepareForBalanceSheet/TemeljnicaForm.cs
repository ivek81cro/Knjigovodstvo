using Knjigovodstvo.Interface;
using Knjigovodstvo.Partners;
using Knjigovodstvo.URA;
using System;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public partial class TemeljnicaForm : Form
    {
        public TemeljnicaForm(IDbObject knjiga)
        {
            _obj = knjiga;
            string model = knjiga.GetType().Name;
            SelectType(model);
            InitializeComponent();
            PrepareDataUra();
        }

        private void SelectType(string model)
        {
            switch (model) 
            {
                case "UraKnjiga":
                    PrepareDataUra();
                    break;
                default:
                    break;
            }
        }

        private void PrepareDataUra()
        {
            UraKnjiga knjiga = (UraKnjiga)_obj;
            _temeljnicaStavka.Opis = $"Knjiženje: {knjiga.Broj_racuna} - {knjiga.Naziv_dobavljaca}";
            _temeljnicaStavka.Dokument = "URA";
            _temeljnicaStavka.Konto = _partner.GetKontoDByNaziv(knjiga.Naziv_dobavljaca);
            _temeljnicaStavka.Datum = knjiga.Datum_racuna;
        }

        private Partneri _partner = new Partneri();
        private TemeljnicaStavka _temeljnicaStavka = new TemeljnicaStavka();
        private IDbObject _obj;
    }
}

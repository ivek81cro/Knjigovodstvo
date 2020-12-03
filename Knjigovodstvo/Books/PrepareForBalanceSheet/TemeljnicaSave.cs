using Knjigovodstvo.Database;
using Knjigovodstvo.Settings;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public class TemeljnicaSave
    {
        public void PrepareSave(DataTable _dt, List<PostavkeKnjizenja> _postavkeKnjizenja) 
        {
            foreach (DataRow row in _dt.Rows)
            {
                if (CheckKonto(row))
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
                else
                {
                    MessageBox.Show("Niste unijeli ispravan konto", "Neispravan konto");
                }
            }
        }

        public void SaveToDatabase()
        {
            if (_temeljnicaStavka.Count > 0)
            {
                foreach (var stavka in _temeljnicaStavka)
                    new DbDataInsert().InsertData(stavka);
            }
            else
            {
                MessageBox.Show("Ne postoje stavke za temeljnicu", "Neispravan konto");
            }
        }

        private bool CheckKonto(DataRow row)
        {
            if (row["Konto"].ToString() == "" || row["Konto"].ToString().Length < 2)
                return false;
            return true;
        }

        private List<TemeljnicaStavka> _temeljnicaStavka = new List<TemeljnicaStavka>();
    }
}

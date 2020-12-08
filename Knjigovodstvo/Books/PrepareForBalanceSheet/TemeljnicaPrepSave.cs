using Knjigovodstvo.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public class TemeljnicaPrepSave
    {
        public bool PrepareSave(DataTable _dt, List<PostavkeKnjizenja> _postavkeKnjizenja) 
        {
            foreach (DataRow row in _dt.Rows)
            {
                if (CheckKonto(row))
                {
                    _temeljnicaStavka.Add(new TemeljnicaStavka()
                    {
                        Opis = row["Opis knjiženja"].ToString() + 
                        " - " + row["Opis stavke"].ToString(),
                        Dokument = _postavkeKnjizenja.ElementAt(0).Knjiga,
                        Broj = int.Parse(row["Redni broj"].ToString()),
                        Konto = row["Konto"].ToString(),
                        Datum = DateTime.ParseExact(row["Datum dokumenta"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString(),
                        Duguje2 = decimal.Parse(row["Dugovna"].ToString()),
                        Potrazuje2 = decimal.Parse(row["Potražna"].ToString())
                    });
                }
                else
                {
                    MessageBox.Show("Niste unijeli ispravan konto", "Neispravan konto");
                    return false;
                }
            }
            return true;
        }

        public void SaveToDatabase()
        {
            if (_temeljnicaStavka.Count > 0)
            {
                foreach (var stavka in _temeljnicaStavka)
                {
                    if (!stavka.CheckIfExistsInDatabase() && !_updateConfirmed)
                        stavka.SaveToDatabase();
                    else if(_updateConfirmed)
                        stavka.UpdateStavka();
                    else 
                    {
                        if(MessageBox.Show("Podatak već postoji na temeljnici, radi li se o ispravci?"
                            , "Neispravan konto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            _updateConfirmed = true;
                            stavka.UpdateStavka();
                        }
                    }
                }
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

        private bool _updateConfirmed = false;
        private readonly List<TemeljnicaStavka> _temeljnicaStavka = new List<TemeljnicaStavka>();
    }
}

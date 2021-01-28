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
                    if (CheckEmpty(row))
                    {
                        _temeljnicaStavka.Add(new TemeljnicaStavka()
                        {
                            Opis = row["Opis knjiženja"].ToString() +
                            " - " + row["Opis stavke"].ToString(),
                            Dokument = _postavkeKnjizenja.ElementAt(0).Knjiga,
                            Broj = int.Parse(row["Redni broj"].ToString()),
                            Konto = row["Konto"].ToString(),
                            
                            Datum = DateTime.ParseExact(
                                row["Datum dokumenta"].ToString()
                                ,"dd.MM.yyyy."
                                ,CultureInfo.InvariantCulture)
                            .ToString("yyyy-MM-dd"),

                            Dugovna = decimal.Parse(row["Dugovna"].ToString()),
                            Potražna = decimal.Parse(row["Potražna"].ToString())
                        });
                    }
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
            TemeljnicaStavka stavka = new TemeljnicaStavka();
            if (_temeljnicaStavka.Count > 0)
            {
                    if (!stavka.CheckIfExistsInDatabase(_temeljnicaStavka))
                        stavka.SaveToDatabase(_temeljnicaStavka);
                    else 
                    {
                        if(MessageBox.Show("Podatak već postoji na temeljnici, radi li se o ispravci?"
                            , "Neispravan konto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            stavka.UpdateStavka();
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
            return !(row["Konto"].ToString() == "" || row["Konto"].ToString().Length < 2);                
        }

        private bool CheckEmpty(DataRow row)
        {
            return !(row["Dugovna"].ToString() == "0,00" && row["Potražna"].ToString() == "0,00");                
        }


        private readonly List<TemeljnicaStavka> _temeljnicaStavka = new List<TemeljnicaStavka>();
    }
}

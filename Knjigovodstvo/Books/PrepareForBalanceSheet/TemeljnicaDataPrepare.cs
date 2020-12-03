using Knjigovodstvo.Interface;
using Knjigovodstvo.IRA;
using Knjigovodstvo.Settings;
using Knjigovodstvo.URA;
using System.Collections.Generic;
using System.Data;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    public class TemeljnicaDataPrepare
    {
        public void PrepareDataIra(DataTable dt, List<PostavkeKnjizenja> postavkeKnjizenja, IDbObject obj)
        {
            IraKnjiga knjiga = (IraKnjiga)obj;

            foreach (var postavka in postavkeKnjizenja)
            {
                dt.Rows.Add(
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
        }

        public void PrepareDataUra(DataTable dt, List<PostavkeKnjizenja> postavkeKnjizenja, IDbObject obj)
        {
            UraKnjiga knjiga = (UraKnjiga)obj;

            foreach (var postavka in postavkeKnjizenja)
            {
                dt.Rows.Add(
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
        }

        public void PrepareDataPrimka(DataTable dt, List<PostavkeKnjizenja> postavkeKnjizenja, IDbObject obj)
        {
            Primka knjiga = (Primka)obj;

            foreach (var postavka in postavkeKnjizenja)
            {
                dt.Rows.Add(
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
        }
    }
}

using Knjigovodstvo.BankStatements;
using Knjigovodstvo.FinancialReports;
using Knjigovodstvo.Interface;
using Knjigovodstvo.IRA;
using Knjigovodstvo.Payroll;
using Knjigovodstvo.Settings;
using Knjigovodstvo.URA;
using System;
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

        internal void PrepareDataIzvod(DataTable dt, IDbObject obj)
        {
            Izvod izvod = (Izvod)obj;
            dt.Rows.Add(
                izvod.Redni_broj,
                "Žiro račun",
                "Izvod broj " + izvod.Redni_broj,
                "1000",
                izvod.Datum_izvoda.Split(' ')[0],
                true,
                true,
                false
                );
            foreach(var stavka in izvod.Promet)
            {
                dt.Rows.Add(
                    izvod.Redni_broj,
                    stavka.Naziv,
                    stavka.Opis,
                    stavka.Konto,
                    izvod.Datum_izvoda.Split(' ')[0],
                    stavka.Oznaka == "D",
                    stavka.Oznaka == "P",
                    false
                    );
            }
        }

        internal void PrepareDataDodatak(DataTable dt, List<PostavkeKnjizenja> postavkeKnjizenja, IDbObject obj)
        {
            DodatakArhiva knjiga = (DodatakArhiva)obj;

            foreach (var postavka in postavkeKnjizenja)
            {
                dt.Rows.Add(
                    knjiga.Id,
                    postavka.Naziv_stupca,
                    new KontniPlan().GetDescriptiopnByKontoNumber(postavka.Konto),
                    postavka.Konto,
                    DateTime.Today.ToString("dd.MM.yyyy"),
                    postavka.Strana == "Dugovna",
                    postavka.Strana == "Potražna",
                    postavka.Mijenja_predznak == true
                    );
            }
        }

        public void PrepareDataPlaca(DataTable dt, List<PostavkeKnjizenja> postavkeKnjizenja, IDbObject obj)
        {
            PlacaArhiva knjiga = (PlacaArhiva)obj;

            foreach (var postavka in postavkeKnjizenja)
            {
                dt.Rows.Add(
                    knjiga.Id,
                    postavka.Naziv_stupca,
                    new KontniPlan().GetDescriptiopnByKontoNumber(postavka.Konto),
                    postavka.Konto,
                    DateTime.Today.ToString("dd.MM.yyyy"),
                    postavka.Strana == "Dugovna",
                    postavka.Strana == "Potražna",
                    postavka.Mijenja_predznak == true
                    );
            }
        }
    }
}

using Knjigovodstvo.Database;
using Knjigovodstvo.Payroll;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Knjigovodstvo.JoppdDocument
{
    class JoppdEntitet
    {
        public void PopuniDodatke()
        {
            DataTable _dt = new DbDataGet().GetTable(new PlacaDodatak(), $"Oib='{this.Oib}'");
            List<DataRow> rows = _dt.AsEnumerable().ToList();
            _dodaci = (from DataRow dr in rows
                              select new PlacaDodatak()
                              {
                                  Id = int.Parse(dr["Id"].ToString()),
                                  Oib = dr["Oib"].ToString(),
                                  Sifra = dr["Sifra"].ToString(),
                                  Iznos = float.Parse(dr["Iznos"].ToString())
                              }).ToList();

            if (_dodaci.Count > 0)
            {
                Iznos_Neoporezivog = _dodaci.ElementAt(0).Iznos;
                Oznaka_Neoporezivog = _dodaci.ElementAt(0).Sifra;
            }
        }
        private List<PlacaDodatak> _dodaci;

        public string Opcina_Prebivalista { get; set; } = "";
        public string Opcina_Rada { get; set; } = "";
        public string Oib { get; set; } = "";
        public string Ime_Prezime { get; set; } = "";
        public string Stjecatelj { get; set; } = "";
        public string Primitak { get; set; } = "";
        public string Beneficirani { get; set; } = "";
        public string Invaliditet { get; set; } = "";
        public string Mjesec { get; set; } = "";
        public string Vrijeme { get; set; } = "";
        public int Sati { get; set; } = 0;
        public string Datum_Od { get; set; } = "";
        public string Datum_Do { get; set; } = "";
        public float Bruto { get; set; } = 0;
        public float Osnovica { get; set; } = 0;
        public float Mio_1 { get; set; } = 0;
        public float Mio_2 { get; set; } = 0;
        public float Zdravstvo { get; set; } = 0;
        public float Zaštita { get; set; } = 0;
        public float Zaposljavanje { get; set; } = 0;
        public float Povecani_Mio { get; set; } = 0;
        public float Povecani_Mio2 { get; set; } = 0;
        public float Zdravstvo_Inozemstvo { get; set; } = 0;
        public float Invaliditet_Doprinos { get; set; } = 0;
        public float Izdatak { get; set; } = 0;
        public float IzdatakUplaceni_Mio { get; set; } = 0;
        public float Dohodak { get; set; } = 0;
        public float Osobni_Odbitak { get; set; } = 0;
        public float Porezna_Osnovica { get; set; } = 0;
        public float Porez_Ukupno { get; set; } = 0;
        public float Prirez { get; set; } = 0;
        public string Oznaka_Neoporezivog { get; set; } = "";
        public float Iznos_Neoporezivog { get; set; } = 0;
        public string Nacin_Isplate { get; set; } = "";
        public float Iznos_Isplate { get; set; } = 0;
        public float Primitak_Nesamostalni { get; set; } = 0;
    }
}

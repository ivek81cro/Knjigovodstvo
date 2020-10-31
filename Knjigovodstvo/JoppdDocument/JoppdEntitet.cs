using Knjigovodstvo.Database;
using Knjigovodstvo.Models;
using Knjigovodstvo.Payroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;

namespace Knjigovodstvo.JoppdDocument
{
    [Serializable()]
    public class JoppdEntitet : IDbObject
    {
        public void PopuniDodatke(int redniBroj = 0)
        {
            DataTable _dt = new DbDataGet().GetTable(new PlacaDodatak(), $"Oib='{this.Oib}'");
            List<DataRow> rows = _dt.AsEnumerable().ToList();
            _dodaci = (from DataRow dr in rows
                              select new PlacaDodatak()
                              {
                                  Id = int.Parse(dr["Id"].ToString()),
                                  Oib = dr["Oib"].ToString(),
                                  Sifra = dr["Sifra"].ToString(),
                                  Iznos = decimal.Parse(dr["Iznos"].ToString())
                              }).ToList();

            if (_dodaci.Count > 0)
            {
                Iznos_Neoporezivog = _dodaci.ElementAt(0).Iznos;
                Oznaka_Neoporezivog = _dodaci.ElementAt(0).Sifra;
            }

            Redni_Broj = redniBroj;
        }

        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        private List<PlacaDodatak> _dodaci;
        [XmlElement("P1")]
        public int Redni_Broj = 0;
        [XmlElement("P2")]
        public string Opcina_Prebivalista { get; set; } = "0000";
        [XmlElement("P3")]
        public string Opcina_Rada { get; set; } = "0000";
        [XmlElement("P4")]
        public string Oib { get; set; } = "";
        [XmlElement("P5")]
        public string Ime_Prezime { get; set; } = "";
        [XmlElement("P61")]
        public string Stjecatelj { get; set; } = "0";
        [XmlElement("P62")]
        public string Primitak { get; set; } = "0";
        [XmlElement("P71")]
        public string Beneficirani { get; set; } = "0";
        [XmlElement("P72")]
        public string Invaliditet { get; set; } = "0";
        [XmlElement("P8")]
        public string Mjesec { get; set; } = "0";
        [XmlElement("P9")]
        public string Vrijeme { get; set; } = "0";
        [XmlElement("P10")]
        public int Sati { get; set; } = 0;
        [XmlElement("P101")]
        public string Datum_Od { get; set; } = "0";
        [XmlElement("P102")]
        public string Datum_Do { get; set; } = "0";
        [XmlElement("P11")]
        public decimal Bruto { get; set; } = 0;
        [XmlElement("P12")]
        public decimal Osnovica { get; set; } = 0;
        [XmlElement("P121")]
        public decimal Mio_1 { get; set; } = 0;
        [XmlElement("P122")]
        public decimal Mio_2 { get; set; } = 0;
        [XmlElement("P123")]
        public decimal Zdravstvo { get; set; } = 0;
        [XmlElement("P124")]
        public decimal Zaštita { get; set; } = 0;
        [XmlElement("P125")]
        public decimal Zaposljavanje { get; set; } = 0;
        [XmlElement("P126")]
        public decimal Povecani_Mio { get; set; } = 0;
        [XmlElement("P127")]
        public decimal Povecani_Mio2 { get; set; } = 0;
        [XmlElement("P128")]
        public decimal Zdravstvo_Inozemstvo { get; set; } = 0;
        [XmlElement("P129")]
        public decimal Invaliditet_Doprinos { get; set; } = 0;
        [XmlElement("P131")]
        public decimal Izdatak { get; set; } = 0;
        [XmlElement("P132")]
        public decimal IzdatakUplaceni_Mio { get; set; } = 0;
        [XmlElement("P133")]
        public decimal Dohodak { get; set; } = 0;
        [XmlElement("P134")]
        public decimal Osobni_Odbitak { get; set; } = 0;
        [XmlElement("P135")]
        public decimal Porezna_Osnovica { get; set; } = 0;
        [XmlElement("P141")]
        public decimal Porez_Ukupno { get; set; } = 0;
        [XmlElement("P142")]
        public decimal Prirez { get; set; } = 0;
        [XmlElement("P151")]
        public string Oznaka_Neoporezivog { get; set; } = "0";
        [XmlElement("P152")]
        public decimal Iznos_Neoporezivog { get; set; } = 0;
        [XmlElement("P161")]
        public string Nacin_Isplate { get; set; } = "0";
        [XmlElement("P162")]
        public decimal Iznos_Isplate { get; set; } = 0;
        [XmlElement("P17")]
        public decimal Primitak_Nesamostalni { get; set; } = 0;        
    }

    [Serializable()]
    [XmlRoot("StranaB")]
    public class JoppdEntitetCollection
    {
        [XmlArray("Primatelji")]
        [XmlArrayItem("P", typeof(JoppdEntitet))]
        public List<JoppdEntitet> JoppdEntitet { get; set; }
    }
}

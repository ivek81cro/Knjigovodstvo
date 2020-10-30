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

        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        private List<PlacaDodatak> _dodaci;
        [System.Xml.Serialization.XmlElement("P1")]
        public int Redni_Broj { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P2")]
        public string Opcina_Prebivalista { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P3")]
        public string Opcina_Rada { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P4")]
        public string Oib { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P5")]
        public string Ime_Prezime { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P61")]
        public string Stjecatelj { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P62")]
        public string Primitak { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P71")]
        public string Beneficirani { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P72")]
        public string Invaliditet { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P8")]
        public string Mjesec { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P9")]
        public string Vrijeme { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P10")]
        public int Sati { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P101")]
        public string Datum_Od { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P102")]
        public string Datum_Do { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P11")]
        public float Bruto { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P12")]
        public float Osnovica { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P121")]
        public float Mio_1 { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P122")]
        public float Mio_2 { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P123")]
        public float Zdravstvo { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P124")]
        public float Zaštita { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P125")]
        public float Zaposljavanje { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P126")]
        public float Povecani_Mio { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P127")]
        public float Povecani_Mio2 { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P128")]
        public float Zdravstvo_Inozemstvo { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P129")]
        public float Invaliditet_Doprinos { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P131")]
        public float Izdatak { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P132")]
        public float IzdatakUplaceni_Mio { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P133")]
        public float Dohodak { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P134")]
        public float Osobni_Odbitak { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P135")]
        public float Porezna_Osnovica { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P141")]
        public float Porez_Ukupno { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P142")]
        public float Prirez { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P151")]
        public string Oznaka_Neoporezivog { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P152")]
        public float Iznos_Neoporezivog { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P161")]
        public string Nacin_Isplate { get; set; } = "";
        [System.Xml.Serialization.XmlElement("P162")]
        public float Iznos_Isplate { get; set; } = 0;
        [System.Xml.Serialization.XmlElement("P17")]
        public float Primitak_Nesamostalni { get; set; } = 0;        
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

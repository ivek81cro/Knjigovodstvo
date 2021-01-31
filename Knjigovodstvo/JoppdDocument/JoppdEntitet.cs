using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Wages;
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
        public JoppdEntitet()
        {
        }
        public void PopuniDodatke()
        {
            DataTable _dt = new DbDataGet().GetTable(new DodatakArhiva(), 
                $"Oib='{Oib}' AND Datum_Od='{Datum_Od}' AND Datum_Do='{Datum_Do}'");
            List<DataRow> rows = _dt.AsEnumerable().ToList();
            _dodaci = (from DataRow dr in rows
                              select new Dodatak()
                              {
                                  Id = int.Parse(dr["Id"].ToString()),
                                  Oib = dr["Oib"].ToString(),
                                  Sifra = dr["Sifra"].ToString(),
                                  Iznos = Math.Round(decimal.Parse(dr["Iznos"].ToString()), 2)
                              }).ToList();

            if (_dodaci.Count > 0)
            {
                Iznos_Neoporezivog = _dodaci.ElementAt(0).Iznos;
                Iznos_Isplate += Iznos_Neoporezivog;
                Oznaka_Neoporezivog = _dodaci.ElementAt(0).Sifra;
            }
        }

        //Remove benefits that produce error at document control check
        public void PoduzetnikPrilagodi() 
        {
            if(Stjecatelj == "0032")
            {
                Iznos_Neoporezivog = 0;
                Oznaka_Neoporezivog = "0";
                Primitak_Nesamostalni = 0;
                Sati = (int)(Convert.ToDateTime(Datum_Do) - Convert.ToDateTime(Datum_Od)).TotalDays + 1;
            }
        }

        public int GetDodaciCount()
        {
            return _dodaci.Count;
        }

        public List<Dodatak> GetDodatakList(int dodatak_start_number)
        {
            int i = dodatak_start_number;
            List<Dodatak> dodaci = new List<Dodatak>();
            for(; i<_dodaci.Count; ++i)
            {
                dodaci.Add(_dodaci[i]);
            }

            return dodaci;
        }

        public bool IsPoslodavac()
        {
            if(Stjecatelj == "0032")
            {
                return true;
            }
            return false;
        }

        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        private List<Dodatak> _dodaci = new List<Dodatak>();

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
        public string Stjecatelj { get; set; } = "0000";
        [XmlElement("P62")]
        public string Primitak { get; set; } = "0000";
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
}

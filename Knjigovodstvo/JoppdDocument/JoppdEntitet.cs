using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;
using Knjigovodstvo.Wages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Knjigovodstvo.JoppdDocument
{
    [Serializable()]
    public class JoppdEntitet : IDbObject
    {
        public JoppdEntitet()
        {
        }

        public JoppdEntitet CreateNewJoppdEntitet(DataGridViewRow row, int redni_broj)
        {
            return new JoppdEntitet()
            {
                Redni_Broj = redni_broj,
                Opcina_Prebivalista = row.Cells["Opcina_Prebivalista"].Value.ToString(),
                Opcina_Rada = row.Cells["Opcina_Rada"].Value.ToString(),
                Oib = row.Cells["Oib"].Value.ToString(),
                Ime_Prezime = row.Cells["Ime_i_prezime"].Value.ToString(),
                Stjecatelj = row.Cells["Stjecatelj"].Value.ToString(),
                Primitak = row.Cells["Primitak"].Value.ToString(),
                Beneficirani = row.Cells["Beneficirani"].Value.ToString(),
                Invaliditet = row.Cells["Invaliditet"].Value.ToString(),
                Mjesec = row.Cells["Mjesec"].Value.ToString(),
                Vrijeme = row.Cells["Vrijeme"].Value.ToString(),
                Sati = int.Parse(row.Cells["Sati_radnih"].Value.ToString()),
                Sati_praznika = int.Parse(row.Cells["Sati_neradnih"].Value.ToString()),
                Datum_Od = row.Cells["Razdoblje_od"].Value.ToString(),
                Datum_Do = row.Cells["Razdoblje_do"].Value.ToString(),
                Bruto = decimal.Parse(row.Cells["Bruto"].Value.ToString()),
                Osnovica = decimal.Parse(row.Cells["Bruto"].Value.ToString()),
                Mio_1 = decimal.Parse(row.Cells["Mio_1"].Value.ToString()),
                Mio_2 = decimal.Parse(row.Cells["Mio_2"].Value.ToString()),
                Zdravstvo = decimal.Parse(row.Cells["Doprinos_zdravstvo"].Value.ToString()),
                IzdatakUplaceni_Mio = decimal.Parse(row.Cells["Mio_1"].Value.ToString()) +
                                        decimal.Parse(row.Cells["Mio_2"].Value.ToString()),
                Dohodak = decimal.Parse(row.Cells["Dohodak"].Value.ToString()),
                Osobni_Odbitak = decimal.Parse(row.Cells["OSobni_Odbitak"].Value.ToString()),
                Porezna_Osnovica = decimal.Parse(row.Cells["Porezna_Osnovica"].Value.ToString()),
                Porez_Ukupno = decimal.Parse(row.Cells["Porez_Ukupno"].Value.ToString()),
                Prirez = decimal.Parse(row.Cells["Prirez"].Value.ToString()),
                Primitak_Nesamostalni = decimal.Parse(row.Cells["Bruto"].Value.ToString()),
                Iznos_Isplate = decimal.Parse(row.Cells["Neto"].Value.ToString())
            };
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
        [XmlElement("P100")]
        public int Sati_praznika { get; set; }
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

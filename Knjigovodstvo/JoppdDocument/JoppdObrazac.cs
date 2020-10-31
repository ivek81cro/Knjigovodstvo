using System;
using System.Xml.Serialization;

namespace Knjigovodstvo.JoppdDocument
{
    [Serializable()]
    [XmlRoot("Metapodaci")]
    class JoppdObrazac
    {
        public string Naslov { get; set; }
        public string Autor { get; set; }
        public string Datum { get; set; }
        public string Format { get; set; }
        public string Jezik { get; set; }
        public string Identifikator { get; set; }
        public string Uskladjenost { get; set; }
        public string Tip { get; set; }
        public string Adresant { get; set; }

        public JoppdA StranaA { get; set; }
        public  JoppdB StranaB { get; set; }
    }
}

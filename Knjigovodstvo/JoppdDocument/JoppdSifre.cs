using Knjigovodstvo.Interface;
using System;

namespace Knjigovodstvo.JoppdDocument
{
    public enum Joppd_skupine
    {
        Beneficirani,
        Invaliditet,
        Mjesec,
        Nacin_Isplate,
        Neoporezivo,
        Podnositelj,
        Primici,
        Stjecatelj,
        Vrijeme
    }
    class JoppdSifre : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public string Skupina { get; set; } = "";
        public string Sifra { get; set; } = "";
        public string Opis { get; set; } = "";

    }
}

using Knjigovodstvo.Interface;
using System;

namespace Knjigovodstvo.JoppdDocument
{
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

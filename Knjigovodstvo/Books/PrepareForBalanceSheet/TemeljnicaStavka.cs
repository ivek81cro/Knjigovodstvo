﻿using Knjigovodstvo.Interface;
using Knjigovodstvo.URA;
using System;

namespace Knjigovodstvo.Books.PrepareForBalanceSheet
{
    class TemeljnicaStavka : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public string Opis { get; set; } = "";
        public string Dokument { get; set; } = "";
        public int Broj { get; set; } = 0;
        public string Konto { get; set; } = "";
        public string Datum { get; set; } = "";
        public string Valuta { get; set; } = "HRK";
        public decimal Duguje1 { get; set; } = 0;
        public decimal Potrazuje1 { get; set; } = 0;
        public decimal Duguje2 { get; set; } = 0;
        public decimal Potrazuje2 { get; set; } = 0;

    }
}

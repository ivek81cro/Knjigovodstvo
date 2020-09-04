using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    public class Opcina : IDbObject
    {
        public bool ValidateData()
        {
            if (Naziv.Length < 2 || Naziv.StartsWith("Odaberite"))
                return false;
            if (Zupanija.Length < 2 || Zupanija.StartsWith("Odaberite"))
                return false;
            if (Drzava.Length < 2)
                return false;
            if (Posta.Length != 5)
                return false;

            return true;
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Zupanija { get; set; }
        public string Drzava { get; set; }
        public string Posta { get; set; }
    }
}

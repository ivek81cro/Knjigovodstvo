using Knjigovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Payroll
{
    class Joppd : IDbObject
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

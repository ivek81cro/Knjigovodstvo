using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Books.Inventory
{
    public class Amortizacija : IDbObject
    {
        public FormError ValidateData()
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public int Id_osnovnog_sredstva { get; set; } = 0;
        public decimal Iznos_amortizacije { get; set; } = 0;
    }
}

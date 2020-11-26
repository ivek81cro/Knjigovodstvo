using System.Collections.Generic;

namespace Knjigovodstvo.BankStatements
{
    public class IzvodKnjiga
    {
        public int Id { get; set; } = 0;
        public int Redni_broj { get; set; } = 0;
        public string Datum_izvoda { get; set; } = "";
        public decimal Suma_potrazna { get; set; } = 0;
        public decimal Stanje_prethodnog_izvoda { get; set; } = 0;
        public decimal Novo_stanje { get; set; } = 0;

        public List<IzvodPromet> Promet = new List<IzvodPromet>();
    }
}

using Knjigovodstvo.Database;
using Knjigovodstvo.Interface;

namespace Knjigovodstvo.BankStatements
{
    public class IzvodPromet :IDbObject
    {
        public FormError ValidateData()
        {
            return FormError.None;
        }

        internal void InsertData()
        {
            new DbDataInsert().InsertData(this);
        }

        public int Id { get; set; } = 0;
        public int Id_izvod { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Opis { get; set; } = "";
        public string Konto { get; set; } = "";
        public decimal Dugovna { get; set; } = 0;
        public decimal Potrazna { get; set; } = 0;
        public string Oznaka { get; set; } = "x";
    }
}

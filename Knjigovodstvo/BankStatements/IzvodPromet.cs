namespace Knjigovodstvo.BankStatements
{
    public class IzvodPromet
    {
        public int Id { get; set; } = 0;
        public int Id_izvod { get; set; } = 0;
        public decimal Iznos { get; set; } = 0;
        public string Oznaka { get; set; } = "x";
        public string Naziv { get; set; } = "";
        public string Opis { get; set; } = "";
    }
}

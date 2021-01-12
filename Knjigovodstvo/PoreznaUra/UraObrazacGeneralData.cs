using System;

namespace Knjigovodstvo.PoreznaUra
{
    public class UraObrazacGeneralData
    {
        public Autor Autor { get; set; }
        public Razdoblje Razdoblje { get; set; }
    }

    public class Autor
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }

    public class Razdoblje
    {
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}

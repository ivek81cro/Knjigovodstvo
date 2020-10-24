namespace Knjigovodstvo.Payroll
{
    class PlacaObracun
    {
        public PlacaObracun(Placa placa)
        {
            _placa = placa;
        }

        public string Razdoblje_Od { get; set; }
        public string Razdoblje_Do { get; set; }

        private Placa _placa = new Placa();
    }
}

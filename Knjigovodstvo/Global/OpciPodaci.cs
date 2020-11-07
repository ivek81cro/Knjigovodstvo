using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Global
{
    public class OpciPodaci : IDbObject
    {
        FormError IDbObject.ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public string Oib { get; set; } = "00000000000";
        public string Naziv { get; set; } = "";
        public string Iban { get; set; } = "";
        public string Mbo { get; set; } = "";

    }
}

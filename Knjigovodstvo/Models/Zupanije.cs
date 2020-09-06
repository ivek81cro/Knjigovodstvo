namespace Knjigovodstvo.Models
{
    class Zupanije : IDbObject
    {        
        public FormError ValidateData()
        {
            if (Naziv == null)
                return FormError.Name;

            return FormError.None;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
    }
}

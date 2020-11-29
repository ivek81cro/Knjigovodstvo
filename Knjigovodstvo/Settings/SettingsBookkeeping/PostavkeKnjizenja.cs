using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Settings
{
    class PostavkeKnjizenja : IDbObject
    {
        public FormError ValidateData()
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; set; } = 0;
        public string Knjiga { get; set; } = "";
        public string Naziv_stupca { get; set; } = "";
        public string Konto { get; set; } = "";
        public string Strana { get; set; } = "";
    }
}

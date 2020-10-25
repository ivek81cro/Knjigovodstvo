namespace Knjigovodstvo.Models
{
    public enum FormError
    {
        Oib,
        Name,
        Street,
        Post,
        City,
        County,
        Country,
        Iban,
        Kupac_Dobavljac,
        Prazno,
        NumberFormat,
        Sifra,
        None
    }
    /// <summary>
    /// Database object.
    /// </summary>
    interface IDbObject
    {
        /// <summary>
        /// Validate data.
        /// </summary>
        /// <returns>Boolean, True if all is valid.</returns>
        public FormError ValidateData();
    }
}

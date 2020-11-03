using Knjigovodstvo.Interface;

namespace Knjigovodstvo.Code.Validators
{
    class ProcessFormErrors
    {
        public string FormErrorMessage(FormError errorType)
        {
            return errorType switch
            {
                FormError.Oib => "Provjerite unešeni oib.",
                FormError.Name => "Provjerite unešeni naziv.",
                FormError.Street => "Provjerite unešenu ulicu.",
                FormError.City => "Provjerite unešeni grad.",
                FormError.Post => "Provjerite unešeni broj pošte.",
                FormError.Iban => "Provjerite unešeni IBAN.",
                FormError.Kupac_Dobavljac => "Mora biti označeno Kupac/Dobavljač ili oboje.",
                FormError.Prazno => "Polje ne može ostati prazno",
                FormError.NumberFormat => "Neispravan format unešenog broja",
                FormError.Sifra => "Neispravan format šifre općine/grada",
                _ => "",
            };
        }
    }
}

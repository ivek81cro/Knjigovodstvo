using Knjigovodstvo.Models;

namespace Knjigovodstvo.Code.Validators
{
    class ProcessFormErrors
    {
        public string FormErrorMessage(FormError errorType)
        {
            switch (errorType)
            {
                case FormError.Oib:
                    return "Provjerite unešeni oib.";
                case FormError.Name:
                    return "Provjerite unešeni naziv.";
                case FormError.Street:
                    return "Provjerite unešenu ulicu.";
                case FormError.City:
                    return "Provjerite unešeni grad.";
                case FormError.Post:
                    return "Provjerite unešeni broj pošte.";
                case FormError.Iban:
                    return "Provjerite unešeni IBAN.";
                case FormError.Kupac_Dobavljac:
                    return "Mora biti označeno Kupac/Dobavljač ili oboje.";
                default:
                    return "";
            }
        }
    }
}

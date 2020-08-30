using Knjigovodstvo.Code.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    class PartnerDataValidate
    {
        public bool ValidateData(Partner partner)
        {
            IbanValidator iban = new IbanValidator();
            if (iban.Validate(partner.Iban))
                return false;

            return true;
        }
    }
}

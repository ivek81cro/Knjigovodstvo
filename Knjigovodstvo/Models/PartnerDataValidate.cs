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

            OibValidator oib = new OibValidator();
            if (oib.Validate(partner.Oib))
                return false;

            //TODO Validate Post, MBO and checkboxes

            return true;
        }
    }
}

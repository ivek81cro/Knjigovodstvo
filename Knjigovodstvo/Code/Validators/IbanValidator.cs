using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Knjigovodstvo.Code.Validators
{
    public class IbanValidator
    {
        public bool Validate(string iban)
        {
            int i = 0;
            bool status = true;

            if (iban.Length < 21)
                return false;

            foreach(char c in iban)
            {
                if (i < 2)
                    status = Char.IsLetter(iban, i);
                else
                    status = Char.IsDigit(iban, i);

                if (!status)
                    return status;
            }

            return status;
        }
    }
}

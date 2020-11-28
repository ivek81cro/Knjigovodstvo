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
            if (iban.Length < 21)
                return false;

            int i = 0;
            foreach (char c in iban)
            {
                if (i < 2)
                {
                    if (!Char.IsLetter(c))
                        return false;
                    
                }
                else
                {
                    if (!Char.IsDigit(c))
                        return false;
                }
                ++i;
            }

            return true;
        }
    }
}

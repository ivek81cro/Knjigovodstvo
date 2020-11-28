using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Code.Validators
{
    public class OibValidator
    {
        public bool Validate(string oib)
        {
            if (oib.Length != 11)
                return false;

            foreach(char c in oib)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Validators
{
    class IntValidator
    {
        public bool Check(string f)
        {
            if (int.TryParse(f, out _))
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Validators
{
    class FloatValidator
    {
        public bool Check(string f)
        {
            if (float.TryParse(f, out _))
            {
                return true;
            }
            return false;
        }
    }
}

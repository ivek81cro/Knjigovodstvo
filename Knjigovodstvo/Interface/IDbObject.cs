using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    interface IDbObject
    {
        public bool ValidateData();
    }
}

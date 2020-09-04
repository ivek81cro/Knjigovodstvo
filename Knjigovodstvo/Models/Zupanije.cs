using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    class Zupanije : IDbObject
    {        
        public bool ValidateData()
        {
            if (Naziv == null)
                return false;

            return true;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
    }
}

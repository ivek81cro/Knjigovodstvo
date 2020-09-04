using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Models
{
    /// <summary>
    /// Database object.
    /// </summary>
    interface IDbObject
    {
        /// <summary>
        /// Validate data.
        /// </summary>
        /// <returns>Boolean, True if all is valid.</returns>
        public bool ValidateData();
    }
}

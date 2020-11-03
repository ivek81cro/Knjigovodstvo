﻿namespace Knjigovodstvo.Interface
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
        public FormError ValidateData();
    }
}

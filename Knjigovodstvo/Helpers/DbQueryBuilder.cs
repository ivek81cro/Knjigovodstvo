using System;
using System.Collections.Generic;
using System.Text;

namespace Knjigovodstvo.Helpers
{
    public class DbQueryBuilder
    {
        public DbQueryBuilder(IEnumerable<List<String>> obj)
        {
            _obj = obj;
        }

        public string BuildQuery()
        {
            string query = "";

            return query;
        }

        private readonly IEnumerable<List<string>> _obj;
    }
}

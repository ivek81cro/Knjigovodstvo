﻿using Knjigovodstvo.Helpers;
using Knjigovodstvo.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    class DbDataUpdate
    {
        /// <summary>
        /// Updates row in table.
        /// </summary>
        /// <param name="dbObject">Table name based on type name of object.</param>
        /// <returns></returns>
        public bool UpdateData(IDbObject dbObject, string condition=null)
        {
            GenericPropertyFinder<IDbObject> property = new GenericPropertyFinder<IDbObject>();

            IEnumerable<List<string>> obj = property.PrintTModelPropertyAndValue(dbObject);

            string table = dbObject.GetType().ToString().Substring(dbObject.GetType().ToString().LastIndexOf('.') + 1);
            string query = new DbQueryBuilder(obj, table, condition).BuildQuery(QueryType.Update);

            if (condition != null)
            {
                if (query.EndsWith(';'))
                    query = query[0..^1];
                query += $" WHERE {condition};";
            }

            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                conn.Close();

                return true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(
                    $"Provjerite vezu sa bazom podataka.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Nepoznata greška kod brisanja podataka, kontaktirajte podršku.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}

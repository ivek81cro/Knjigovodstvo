using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    enum ProcedureNames
    {
        Dohvati_Distinct_Datum,
        DropPlacaPregled,
        PlacaPregled,
        Prebaci_postBroj,
        Prebaci_prirez
    }

    class DbDataExecProcedure
    {
        /// <summary>
        /// Gets table from database depending on recieved object.
        /// </summary>
        /// <param name="procName">Selected procedure from ProcedureNames enum.</param>
        /// <returns>DataTable based on condition</returns>
        public DataTable GetTable(ProcedureNames procName)
        {
            DataTable dt = new DataTable();
            string query = $"EXEC {CreateQuery(procName)};";
            
            try
            {
                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                //Fill the DataTable with records from Table.
                sda.Fill(dt);
            }
            catch (SqlException e)
            {
                MessageBox.Show(
                    $"Provjerite vezu sa bazom podataka.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Nepoznata greška kod dohvata županija, kontaktirajte podršku.\n {e.Message}",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return dt;
        }

        private string CreateQuery(ProcedureNames name)
        {
            switch (name) {
                case ProcedureNames.Dohvati_Distinct_Datum:
                    return "Dohvati_Distinct_Datum";
                case ProcedureNames.DropPlacaPregled:
                    return "DropPlacaPregled";
                case ProcedureNames.PlacaPregled:
                    return "PlacaPregled";
                case ProcedureNames.Prebaci_postBroj:
                    return "Prebaci_postBroj";
                case ProcedureNames.Prebaci_prirez:
                    return "Prebaci_prirez";
                default:
                    return "";
        }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}

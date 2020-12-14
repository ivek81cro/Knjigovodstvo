using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Knjigovodstvo.Database
{
    enum ProcedureNames
    {
        Placa_Distinct_Datum,
        /// <summary> params: @TABLENAME</summary>
        Drop_Table,
        PlacaPregled,
        Prebaci_postBroj,
        Prebaci_prirez,
        /// <summary> params: @datumOd, yyyy-MM, @day = null, dd</summary>
        Joppd_podaci,
        Get_Table_Names,
        Izdvoji_Troskove,
        Izdvoji_Odobrenja,
        IzvodKnjiga_GetLastId,
        Dodatak_Distinct_Datum
    }

    class DbDataExecProcedure
    {
        /// <summary>
        /// Gets table from database depending on recieved object.
        /// </summary>
        /// <param name="procName">Selected procedure from ProcedureNames enum.</param>
        /// <returns>DataTable based on condition</returns>
        public DataTable GetTable(ProcedureNames procName, string param = null)
        {
            DataTable dt = new DataTable();
            string query = $"EXEC {CreateQuery(procName, param)};";
            
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

        private string CreateQuery(ProcedureNames name, string param=null)
        {
            return name switch
            {
                ProcedureNames.Placa_Distinct_Datum => "Placa_Distinct_Datum",
                ProcedureNames.Dodatak_Distinct_Datum => "Dodatak_Distinct_Datum",
                ProcedureNames.Drop_Table => "Drop_Table " + param,
                ProcedureNames.PlacaPregled => "PlacaPregled",
                ProcedureNames.Prebaci_postBroj => "Prebaci_postBroj",
                ProcedureNames.Prebaci_prirez => "Prebaci_prirez",
                ProcedureNames.Joppd_podaci => "Joppd_podaci " + param,
                ProcedureNames.Get_Table_Names => "Get_Table_Names",
                ProcedureNames.Izdvoji_Troskove => "Izdvoji_Troskove",
                ProcedureNames.Izdvoji_Odobrenja => "Izdvoji_Odobrenja",
                ProcedureNames.IzvodKnjiga_GetLastId => "IzvodKnjiga_GetLastId",
                _ => "",
            };
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}

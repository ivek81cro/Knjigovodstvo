using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Knjigovodstvo.Helpers
{
    class DbDataUpdate
    {
        public bool UpadatePartner(Partner partner)
        {
            try
            {
                string query = "UPDATE Partneri SET Oib=@Oib, Naziv=@Naziv, Adresa=@Adresa, Posta=@Posta, Grad=@Grad, " +
                    "Telefon=@Telefon, Fax=@Fax, Email=@Email, Iban=@Iban, " +
                    "Mbo=@Mbo, Kupac=@Kupac, Dobavljac=@Dobavljac WHERE Id=@Id;";

                using SqlConnection conn = new SqlConnection(ConnHelper.ConnStr(connection_name));
                using SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Id", partner.Id);
                command.Parameters.AddWithValue("@Oib", partner.Oib);
                command.Parameters.AddWithValue("@Naziv", partner.Naziv);
                command.Parameters.AddWithValue("@Adresa", partner.Adresa);
                command.Parameters.AddWithValue("@Posta", Int32.Parse(partner.Posta));
                command.Parameters.AddWithValue("@Grad", partner.Grad);
                command.Parameters.AddWithValue("@Telefon", partner.Telefon);
                command.Parameters.AddWithValue("@Fax", partner.Fax);
                command.Parameters.AddWithValue("@Email", partner.Mail);
                command.Parameters.AddWithValue("@Iban", partner.Iban);
                command.Parameters.AddWithValue("@Mbo", Int32.Parse(partner.Mbo));
                command.Parameters.AddWithValue("@Kupac", partner.Kupac);
                command.Parameters.AddWithValue("@Dobavljac", partner.Dobavljac);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private readonly string connection_name = "KnjigovodstvoDb";
    }
}

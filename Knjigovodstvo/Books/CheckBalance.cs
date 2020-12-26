using Knjigovodstvo.Validators;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Knjigovodstvo.Books
{
    public class CheckBalance
    {
        /// <summary>
        /// Checks end balance of datagrid, List arguments [0]Dugovna label, [1]Potražna label
        /// </summary>
        /// <param name="dt">Datagridview's datasource</param>
        /// <param name="labels">[0]DugovnaLabel, [1]PotražnaLabel</param>
        public void CheckEndBalance(DataTable dt, List<Label> labels)
        {
            _dugovna = 0;
            _potrazna = 0;
            var validate = new DecimalValidate();
            foreach (DataRow row in dt.Rows)
            {
                if (validate.Check(row["Dugovna"].ToString()))
                    _dugovna += decimal.Parse(row["Dugovna"].ToString());
                if (validate.Check(row["Potražna"].ToString()))
                    _potrazna += decimal.Parse(row["Potražna"].ToString());
            }

            labels[0].Text = "Dugovna: " + _dugovna.ToString();
            labels[1].Text = "Potražna: " + _potrazna.ToString();
            if (_dugovna == _potrazna)
            {
                labels[0].ForeColor = Color.Green;
                labels[1].ForeColor = Color.Green;
            }
            else
            {
                labels[0].ForeColor = Color.Red;
                labels[1].ForeColor = Color.Red;
            }
        }

        private decimal _potrazna = 0;
        private decimal _dugovna = 0;
    }
}

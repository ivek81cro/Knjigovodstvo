using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Knjigovodstvo.Global
{
    class ConvertXlsToCsv
    {
        public ConvertXlsToCsv(string identifier)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _identifier = identifier;
        }

        public void OpenXlsFile(ref string put)
        {
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "Xlsx Files *.xlsx|*.xlsx|Xls Files *.xls|*.xls|Csv files *.csv|*.csv",
                FilterIndex = 1,
                Multiselect = false
            };

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                put = choofdlog.FileName.ToString();
            }

            if (put == null || put == "")
            {
                MessageBox.Show("Nije odabrana datoteka");
                return;
            }

            if (put.Contains(".csv")) 
                 return;
        }

        public void Convert(ref string put)
        {
            FileStream stream = File.Open(put, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            try
            {
                //old xls format 93-07
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            catch
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            DataSet result = excelReader.AsDataSet();
            excelReader.Close();

            result.Tables[0].TableName.ToString();

            List<string> data = CreateCsvString(result, put);
            string csvData = data[1];

            put = data[0]; //new file extension
            StreamWriter csv = new StreamWriter(@put, false, Encoding.UTF8);
            csv.Write(csvData);
            csv.Close();

            if (!csvData.Contains(_identifier))
                return;
        }

        private List<string> CreateCsvString(DataSet result, string put)
        {
            string csvData = "";
            int row_no = 0;
            int ind = 0;
            while (row_no < result.Tables[ind].Rows.Count) // ind is the index of table | (sheet name) which you want to convert to csv
            {
                for (int i = 0; i < result.Tables[ind].Columns.Count; i++)
                {
                    csvData += result.Tables[ind].Rows[row_no][i].ToString().Replace('\n', ' ') + ";";
                }
                row_no++;
                csvData += "\n";
            }
            if (put.Contains(".xlsx"))
            {
                put = put.Replace("xlsx", "csv");
            }
            else
            {
                put = put.Replace("xls", "csv");
            }

            return new List<string>() { put, csvData };
        }

        public void SaveToCsvAndLoad(ref string path)
        {
            Convert(ref path);

            if (path == "")
            {
                MessageBox.Show("Krivo odabrana datoteka", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private readonly string _identifier = "";
    }    
}

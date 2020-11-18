using ExcelDataReader;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Knjigovodstvo.Global
{
    class ConvertXlsToCsv
    {
        public ConvertXlsToCsv()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public void Convert(ref string put)
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
            if (put == null)
            {
                MessageBox.Show("Nije odabran file");
                return;
            }

            if (put.Contains(".csv")) return;

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
            string output = put; // define your own filepath & filename
            StreamWriter csv = new StreamWriter(@output, false, Encoding.UTF8);
            csv.Write(csvData);
            csv.Close();
        }
    }        
}

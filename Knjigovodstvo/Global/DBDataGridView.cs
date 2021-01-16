using System.Windows.Forms;

namespace Knjigovodstvo
{
    public class DBDataGridView : DataGridView
    {
        public DBDataGridView()
        {
            DoubleBuffered = true;
            Anchor = (((AnchorStyles.Top 
                | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
            BackgroundColor = System.Drawing.SystemColors.Window;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}

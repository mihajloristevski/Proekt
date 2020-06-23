using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class ComboBoxZ:ComboBox
    {
        public ComboBoxZ(int x, int y, int a, int b, ComboBox combobox)
        {
            combobox.Width = a;
            combobox.Height = b;
            combobox.Location = new Point(x, y);
            combobox.Font = new Font("Roboto", 10, FontStyle.Regular);
        }
    }
}

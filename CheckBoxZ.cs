using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class CheckBoxZ:CheckBox
    {
        public CheckBoxZ(int x, int y, int a, int b, string text, CheckBox cb)
        {
            cb.Width = a;
            cb.Height = b;
            cb.Location = new Point(x, y);
            cb.Font = new Font("Roboto", 10, FontStyle.Regular);
            cb.Text = text;
        }
    }
}

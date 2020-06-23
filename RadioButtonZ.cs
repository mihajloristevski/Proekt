using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class RadioButtonZ:RadioButton
    {
        public RadioButtonZ(int x, int y, int a, int b, string text ,int fontsize,RadioButton rb)
        {
            rb.Width = a;
            rb.Height = b;
            rb.Location = new Point(x, y);
            rb.Text = text;
            rb.Font = new Font("Roboto",fontsize, FontStyle.Regular);
        }
    }
}

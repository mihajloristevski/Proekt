using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class TextBoxX:TextBox
    {
        public TextBoxX(int x, int y, TextBox tb1)
        {
            tb1.Width = 200;
            tb1.Height = 40;
            tb1.ForeColor = Color.Black;
            tb1.BackColor = Color.FromArgb(255, 130, 130);
            tb1.Location = new Point(x, y);
            tb1.Text = "";
            tb1.PasswordChar = '●';
            tb1.MaxLength = 20;
        }
    }
}

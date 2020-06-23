using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class TextBoxZ:TextBox
    {
        public TextBoxZ(int x, int y,TextBox tb)
        {
            tb.Width = 200;
            tb.Height = 40;
            tb.Location = new Point (x,y);
            tb.ForeColor = Color.Black;
            tb.BackColor = Color.FromArgb(255, 130, 130); 
            tb.Font = new Font("Roboto", 10, FontStyle.Regular);
        }
       

        

    }
}

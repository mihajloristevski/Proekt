using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class ListBoxZ:ListBox
    {
       
        public ListBoxZ ( int x, int y, int a , int b , ListBox lb)
        {
            lb.Width = a;
            lb.Height = b;
            lb.ForeColor = Color.Black;
            lb.BackColor = Color.FromArgb(255, 130, 130);
            lb.Location = new Point(x, y);
            lb.Font = new Font("Roboto", 10, FontStyle.Regular);
           
        }

           
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class ButtonZ:Button
    {



        public ButtonZ(int x, int y, string text, Button bt)
        {
           
            bt.Height = 30;
            bt.Width = 100;
            bt.Text = text ;
            bt.Location =new  Point(x, y);
            bt.ForeColor = Color.FromArgb(255,66,66);
            bt.BackColor = Color.White;
           
           
        }
        
        

   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Proekt
{
    class LabelZ:Label
    {
        public LabelZ(int x, int y ,int a,int f, string text, Label lb) 
        {
            lb.Width = a;
            lb.Height = 30;
            lb.Text = text;
            lb.Location = new Point(x, y);
            lb.ForeColor = Color.FromArgb(255, 255, 255);
            lb.Font = new Font("Roboto",f, FontStyle.Bold);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameJam
{
    class Piece : Label
    {
        public Piece(int x, int y, int scale)
        {
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(scale, scale);
            BackColor = System.Drawing.Color.Green;
            Enabled = false;
        }
    }
}

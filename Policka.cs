using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hlavni
{
    internal class Policka
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool JeObsazena {  get; set; }
        public bool JeStrelena {  get; set; }

        public Policka(int x, int y) 
        {
            X = x;
            Y = y;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    class Kopiowanie
    {
        public Panel.Aktywnosc Panel { get; set; }
        public string[] Sciezki { get; set; }

        public Kopiowanie()
        {
            Sciezki = new string[2];
            Panel = 0;
        }
    }
}

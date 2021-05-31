using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniTC.Model
{
    class Kopiowanie
    {
        public Panel.Aktywnosc Panel { get; set; }
        public Sciezka Sciezka1 { get; set; }
        public Sciezka Sciezka2 { get; set; }

        public Kopiowanie()
        {
            Sciezka1 = new Sciezka();
            Sciezka2 = new Sciezka();
            Panel = 0;
        }

        public void Kopiuj()
        {
            if (Panel == (Panel.Aktywnosc)1)
            { 
                File.Copy(Sciezka1.SciezkaDocelowa(),Lokalizacje.LaczenieFolderPlik(Sciezka2.Path, Sciezka1.WybranyPlik), true);
            }
            else
            {
                File.Copy(Sciezka2.SciezkaDocelowa(), Lokalizacje.LaczenieFolderPlik(Sciezka1.Path, Sciezka2.WybranyPlik), true);
            }
            Panel = 0;
        }
        public bool CzyMoznaKopiowac()
        {
            if (Panel != 0 && Sciezka1.Path != null && Sciezka2.Path !=null)
                return true;
            else
                return false;
        }

    }
}

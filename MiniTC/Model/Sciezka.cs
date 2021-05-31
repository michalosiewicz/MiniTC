using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    class Sciezka
    {
        public string Path { get; set; }
        public int WybranyElement { get; set; }
        public string WybranyPlik { get; set; }
        public List<string> FolderyPliki { get; set; }

        public List<string> Zawartosc()
        {
            FolderyPliki = new List<string>();
            int x = 0;
            if (Path.Length > 3)
            {
                FolderyPliki.Add("..");
                x = 1;
            }

            var foldery = Directory.GetDirectories(Path);
            for (int i = 0; i < foldery.Length; i++)
            {
                foldery[i] = foldery[i].Remove(0, Path.Length + x);
                foldery[i] = "<D>" + foldery[i];
            }
            var pliki = Directory.GetFiles(Path);
            for (int i = 0; i < pliki.Length; i++)
            {
                pliki[i] = pliki[i].Remove(0, Path.Length + x);
            }
            FolderyPliki.AddRange(foldery);
            FolderyPliki.AddRange(pliki);
            return FolderyPliki;
        }

        public string ZmianaSciezki()
        {
            string path;
            if (FolderyPliki[WybranyElement] == "..")
            {
                path = Powrot();
            }
            else
            {
                string x = "";
                if (Path.Length > 3)
                {
                    x = @"\";
                }
                path = Path + x + FolderyPliki[WybranyElement].Remove(0, 3);
            }
            return path;
        }

        public string Powrot()
        {
            string path;
            int miejsce = 0;
            for (int i = 0; i < Path.Length; i++)
            {
                if (Path[i] == '\\')
                {
                    miejsce = i;
                }
            }
            path = Path.Remove(miejsce, Path.Length - miejsce);
            if (path.Length < 3)
                path += @"\";
            return path;
        }

        public string SciezkaDocelowa()
        {
            string x = "";
            if (Path.Length > 3)
            {
                x = @"\";
            }
            WybranyPlik = FolderyPliki[WybranyElement];
            return Path + x + FolderyPliki[WybranyElement];
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniTC.Model
{
    class Lokalizacje
    {
        public Lokalizacje()
        {
           
        }
        public string Path { get; set; }

        public List<string> FolderyPliki { get; set; }

        public static List<string> DostepneDyski()
        {
            List<string> dyski = new List<string>();
            dyski.AddRange(Directory.GetLogicalDrives());
            return dyski;
        }
        public List<string> Zawartosc()
        {
            FolderyPliki = new List<string>();
            int x = 0;
            if (Path.Length > 3)
            {
                FolderyPliki.Add("..");
                x = 1;
            }

            var foldery=Directory.GetDirectories(Path);
            for(int i = 0; i <foldery.Length; i++)
            {
                foldery[i] = foldery[i].Remove(0,Path.Length+x);
                foldery[i] = "<D>" + foldery[i];
            }
            var pliki=Directory.GetFiles(Path);
            for (int i = 0; i < pliki.Length; i++)
            {
                pliki[i] = pliki[i].Remove(0, Path.Length+x);
            }
            FolderyPliki.AddRange(foldery);
            FolderyPliki.AddRange(pliki);
            return FolderyPliki;
        }
        
        public void NowaSciezka(string path)
        { 
            Path = path;
        }

        public string ZmianaSciezki(string path,int indeks)
        { 
                if (FolderyPliki[indeks] == "..")
                {
                    path = Powrot(path);
                }
                else
                {
                    string x = "";
                    if (Path.Length > 3)
                    {
                        x = @"\";
                    }
                    path = path + x + FolderyPliki[indeks].Remove(0, 3);
                }
            return path;
        }

        public string Powrot(string path)
        {
            int miejsce = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '\\')
                {
                    miejsce = i;
                }
            }
            path = path.Remove(miejsce, path.Length - miejsce);
            if (path.Length < 3)
                path += @"\";
            return path;
        }

        public static bool CzyFolder(string nazwa)
        {
            if (nazwa == ".." || nazwa.Remove(3) == "<D>")
                return true;
            else
                return false;
        }

        public string SciezkaDocelowa(string nazwa)
        {
            string x = "";
            if (Path.Length > 3)
            {
                x = @"\";
            }
            return Path + x + nazwa;
        }
    }
}

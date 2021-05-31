using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniTC.Model
{
    static class Lokalizacje
    {
        public static List<string> DostepneDyski()
        {
            List<string> dyski = new List<string>();
            dyski.AddRange(Directory.GetLogicalDrives());
            return dyski;
        }

        public static string LaczenieFolderPlik(string path,string plik)
        {
            string x = "";
            if (path.Length > 3)
            {
                x = @"\";
            }
            return path + x + plik;
        }

        public static bool CzyFolder(string nazwa)
        {
            if (nazwa == ".." || nazwa.Remove(3) == "<D>")
                return true;
            else
                return false;
        }
    }
}
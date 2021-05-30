using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.ViewModel
{
    using BaseClass;
    using MiniTC.Model;
    using System.Windows;
    using System.Windows.Input;

    class PanelTCViewModel:ViewModelBase
    {
        #region Składowe prywatne
        private Lokalizacje Lk;

        private string sciezka;
        private List<string> napedy;
        private List<string> zawartoscSciezki;
        private string dysk;
        private int index = -1;
        #endregion

        #region Konstruktor
        public PanelTCViewModel()
        {
            Lk = new Lokalizacje();
            napedy = new List<string>();
            zawartoscSciezki = new List<string>();
        }
        #endregion

        #region Właściwości
        public string Sciezka
        {
            get { return sciezka; }
            set { sciezka = value;
                onPropertyChanged(nameof(Sciezka));
                Lk.NowaSciezka(sciezka);
                try { ZawartoscSciezki = Lk.Zawartosc(); }
                catch
                {
                    MessageBox.Show("Brak dostępu do folderu.","Error");
                    Sciezka = Lk.Powrot(Sciezka);
                }
            }
        }


        public List<string> Napedy
        {
            get { return napedy; }
            set { napedy = value; onPropertyChanged(nameof(Napedy)); }
        }

        public List<string> ZawartoscSciezki
        {
            get { return zawartoscSciezki; }
            set { zawartoscSciezki = value;
                onPropertyChanged(nameof(ZawartoscSciezki));
                Index = -1;
            }
        }

        public string Dysk
        {
            get { return dysk; }
            set { dysk = value; onPropertyChanged(nameof(Dysk)); }
        }

        public int Index
        {
            get { return index; }
            set { index = value; onPropertyChanged(nameof(Index)); }
        }
        #endregion

        #region Polecenia

        private ICommand sprawdzNapedy;
        public ICommand SprawdzNapedy
        {

            get
            {
                return sprawdzNapedy ?? (sprawdzNapedy = new RelayCommand(
                    p => { Napedy=Lokalizacje.DostepneDyski(); },
                    p => true
                    )) ;
            }
        }

        private ICommand wybranoNaped;
        public ICommand WybranoNaped
        {

            get
            {
                return wybranoNaped ?? (wybranoNaped = new RelayCommand(
                    p => { Sciezka=Dysk;},
                    p => true
                    ));
            }
        }

        private ICommand zmianaSciezki;
        public ICommand ZmianaSciezki
        {

            get
            {
                return zmianaSciezki ?? (zmianaSciezki = new RelayCommand(
                    p => { Sciezka = Lk.ZmianaSciezki(Sciezka, Index);},
                    p => Index > -1 && (ZawartoscSciezki[Index] == ".." || ZawartoscSciezki[Index].Remove(3)=="<D>")
                    ));
            }
        }

        #endregion

    }
}

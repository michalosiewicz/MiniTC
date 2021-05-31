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

        private string sciezka;
        private List<string> napedy;
        private List<string> zawartoscSciezki;
        private string dysk;
        private int index = -1;
        private bool zmianaListBoxa = true;
        private Sciezka path;
        int numer;
        private Kopiowanie kopiowanie;

        #endregion

        #region Konstruktor
        public PanelTCViewModel(Kopiowanie k,Sciezka s,int nr)
        {
            napedy = new List<string>();
            zawartoscSciezki = new List<string>();
            kopiowanie = k;
            path = s;
            numer = nr;
        }
        #endregion

        #region Właściwości
        public string Sciezka
        {
            get { return sciezka; }
            set { sciezka = value;
                onPropertyChanged(nameof(Sciezka));
                path.Path=sciezka;
                try { ZawartoscSciezki = path.Zawartosc(); }
                catch
                {
                    MessageBox.Show("Brak dostępu do folderu.","Error");
                    Sciezka = path.Powrot();
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
            set {
                Index = -1;
                zmianaListBoxa = false;
                zawartoscSciezki = value;
                onPropertyChanged(nameof(ZawartoscSciezki));
                zmianaListBoxa = true;
                kopiowanie.Panel = 0;
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
                    p => {
                            path.WybranyElement = Index;
                            if(Lokalizacje.CzyFolder(ZawartoscSciezki[Index]))
                                Sciezka = path.ZmianaSciezki();
                    },
                    p => Index > -1
                    ));
            }
        }

        private ICommand focus;
        public ICommand Focus
        {

            get
            {
                return focus ?? (focus = new RelayCommand(
                    p =>
                    {
                        kopiowanie.Panel=(Panel.Aktywnosc)numer;
                    },
                    p => zmianaListBoxa
                    )) ;
            }
        }

        #endregion

    }
}

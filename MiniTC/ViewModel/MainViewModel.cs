using MiniTC.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        public PanelTCViewModel Panel1 { get; set; }
        public PanelTCViewModel Panel2 { get; set; }

        Model.Kopiowanie kopiowanie;
        public MainViewModel()
        {
            kopiowanie = new Model.Kopiowanie();
            Panel1 = new PanelTCViewModel(kopiowanie,kopiowanie.Sciezka1,1);
            Panel2 = new PanelTCViewModel(kopiowanie,kopiowanie.Sciezka2,2);
        }

        private ICommand kopiuj;
        public ICommand Kopiuj
        {

            get
            {
                return kopiuj ?? (kopiuj = new RelayCommand(
                    p => {
                        try
                        {
                            kopiowanie.Kopiuj();
                            Panel1.Sciezka = Panel1.Sciezka;
                            Panel2.Sciezka = Panel2.Sciezka;
                        }
                        catch
                        {
                            MessageBox.Show("Brak możliowści kopiowania do wybranego folderu.", "Error");
                            kopiowanie.Panel = 0;
                        }
                        
                    },
                    p => kopiowanie.CzyMoznaKopiowac()
                    ));
            }
        }
    }
}

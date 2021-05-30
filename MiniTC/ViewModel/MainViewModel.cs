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
            Panel1 = new PanelTCViewModel(kopiowanie,1);
            Panel2 = new PanelTCViewModel(kopiowanie,2);
        }

        private string aktywnosc;
        public string Aktywnosc
        {
            get { return aktywnosc; }

            set{
                aktywnosc = value;
                onPropertyChanged();
            }
        }

        private ICommand kopiuj;
        public ICommand Kopiuj
        {

            get
            {
                return kopiuj ?? (kopiuj = new RelayCommand(
                    p => { MessageBox.Show(kopiowanie.Panel.ToString());
                        MessageBox.Show(kopiowanie.Sciezki[0]);
                        MessageBox.Show(kopiowanie.Sciezki[1]);
                        //tu trzeba dodac do sciezki wybrany element
                    },
                    p => kopiowanie.Panel!=0
                    ));
            }
        }
    }
}

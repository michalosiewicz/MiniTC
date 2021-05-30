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
        public MainViewModel()
        {
            Panel1 = new PanelTCViewModel();
            Panel2 = new PanelTCViewModel();
        }

        private ICommand kopiuj;
        public ICommand Kopiuj
        {

            get
            {
                return kopiuj ?? (kopiuj = new RelayCommand(
                    p => { MessageBox.Show("Kopiowanie");},
                    p => true
                    ));
            }
        }
    }
}

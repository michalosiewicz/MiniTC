using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC.View
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        #region Właściowości

        public static readonly DependencyProperty SciezkaDP =
            DependencyProperty.Register(nameof(Sciezka), typeof(string), typeof(PanelTC));

        public static readonly DependencyProperty NapedyDP =
            DependencyProperty.Register(nameof(Napedy), typeof(List<string>), typeof(PanelTC));

        public static readonly DependencyProperty ZawartoscDP =
            DependencyProperty.Register(nameof(Zawartosc), typeof(List<string>), typeof(PanelTC));

        public static readonly DependencyProperty DyskTextDP =
            DependencyProperty.Register(nameof(DyskText), typeof(string), typeof(PanelTC));

        public static readonly DependencyProperty IndeksDP =
            DependencyProperty.Register(nameof(Indeks), typeof(int), typeof(PanelTC));

        public string Sciezka
        {
            get { return (string)GetValue(SciezkaDP); }
            set { SetValue(SciezkaDP, value); }
        }

        public List<string> Napedy
        {
            get { return (List<string>)GetValue(NapedyDP); }
            set { SetValue(NapedyDP, value); }
        }

        public List<string> Zawartosc
        {
            get { return (List<string>)GetValue(ZawartoscDP); }
            set { SetValue(ZawartoscDP, value); }
        }

        public string DyskText
        {
            get { return (string)GetValue(DyskTextDP); }
            set { SetValue(DyskTextDP, value); }
        }

        public int Indeks
        {
            get { return (int)GetValue(IndeksDP); }
            set { SetValue(IndeksDP, value); }
        }

        #endregion

        #region Polecenia

        public static readonly RoutedEvent SprawdzenieNapedowEvent =
            EventManager.RegisterRoutedEvent("OpenComboBox",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(PanelTC));

        public event RoutedEventHandler SprawdzenieNapedow
        {
            add { AddHandler(SprawdzenieNapedowEvent, value); }
            remove { RemoveHandler(SprawdzenieNapedowEvent, value); }
        }

        void RaiseSprawdzenieNapedow()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.SprawdzenieNapedowEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent WybranoNapedEvent =
            EventManager.RegisterRoutedEvent("WybranoNaped",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(PanelTC));

        public event RoutedEventHandler WybranoNaped
        {
            add { AddHandler(WybranoNapedEvent, value); }
            remove { RemoveHandler(WybranoNapedEvent, value); }
        }

        void RaiseWybranoNaped()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.WybranoNapedEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent ZmianaSciezkiEvent =
            EventManager.RegisterRoutedEvent("ZmianaSciezki",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(PanelTC));

        public event RoutedEventHandler ZmianaSciezki
        {
            add { AddHandler(ZmianaSciezkiEvent, value); }
            remove { RemoveHandler(ZmianaSciezkiEvent, value); }
        }

        void RaiseZmianaSciezki()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.ZmianaSciezkiEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent ZmianaFocusEvent =
            EventManager.RegisterRoutedEvent("Focus",
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(PanelTC));

        public event RoutedEventHandler ZmianaFocus
        {
            add { AddHandler(ZmianaFocusEvent, value); }
            remove { RemoveHandler(ZmianaFocusEvent, value); }
        }

        void RaiseZmianaFocus()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(PanelTC.ZmianaFocusEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        private void Naped_DropDownOpened(object sender, EventArgs e)
        {
            RaiseSprawdzenieNapedow();
        }

        private void Naped_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseWybranoNaped();
        }

        private void ZawartoscSciezki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseZmianaSciezki();
        }

        private void ZawartoscSciezki_GotFocus(object sender, RoutedEventArgs e)
        {
            RaiseZmianaFocus();
        }
        #endregion
    }
}

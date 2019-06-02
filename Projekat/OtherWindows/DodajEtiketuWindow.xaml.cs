using HelpSistem;
using MaterialDesignThemes.Wpf;
using Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for DodajEtiketuWindow.xaml
    /// </summary>
    public partial class DodajEtiketuWindow : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private BitmapImage Bi { get; set; }
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        private string _opis;
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public DodajEtiketuWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Etikete.Add(new Etiketa()
            {
                Oznaka = Oznaka,
                Opis = Opis,
                Boja = odabirBoje.SelectedColorText
            });
            Close();
            ((MainWindow)Application.Current.MainWindow).MyCustomMessageQueue.Enqueue("Etiketa je uspešno dodata");
        }

        private void CommandBinding_Executed1(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[1]);

            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }
    }
}

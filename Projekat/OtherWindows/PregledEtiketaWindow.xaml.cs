using MaterialDesignThemes.Wpf;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for PregledEtiketaWindow.xaml
    /// </summary>
    public partial class PregledEtiketaWindow : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        private string _oznaka;
        public string OznakaEtikete
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
                    OnPropertyChanged("OznakaEtikete");
                }
            }
        }

        private Etiketa _etiketa;
        public Etiketa IzabranaEtiketa
        {
            get
            {
                return _etiketa;
            }
            set
            {
                if (value != _etiketa)
                {
                    _etiketa = value;
                    OnPropertyChanged("IzabranaEtiketa");
                }
            }
        }

        public PregledEtiketaWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            IzabranaEtiketa = (sender as Chip).DataContext as Etiketa;
            ((MainWindow)Application.Current.MainWindow).OtvorenaEtiketaOznaka = IzabranaEtiketa.Oznaka;
            OznakaEtikete = IzabranaEtiketa.Oznaka;
            opisBox.Text = IzabranaEtiketa.Opis;
            odabirBoje.SelectedColor = (Color)ColorConverter.ConvertFromString(IzabranaEtiketa.Boja);
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (IzabranaEtiketa == null)
            {
                // SNEKBAR NISTE ODABRALI TIP ZA PREGLED
                return;
            }
            Etiketa etiketa = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Etikete.Where(et => et.Oznaka == IzabranaEtiketa.Oznaka).FirstOrDefault();
            etiketa.Oznaka = oznakaBox.Text;
            etiketa.Opis = opisBox.Text;
            etiketa.Boja = odabirBoje.SelectedColorText;
            // SNEKBAR USPESNO STE IZMENILI
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (IzabranaEtiketa == null)
            {
                // SNEKBAR NISTE ODABRALI TIP ZA BRISANJE
                return;
            }
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Etikete.Remove(IzabranaEtiketa);
            oznakaBox.Text = "";
            opisBox.Text = "";
            odabirBoje.SelectedColor = null;
            IzabranaEtiketa = null;
            // SNEKBAR USPESNO STE OBRISALI
        }
    }
}

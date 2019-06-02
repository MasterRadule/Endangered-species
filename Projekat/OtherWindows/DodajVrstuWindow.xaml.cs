using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekat.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for DodajVrstuWindow.xaml
    /// </summary>
    public partial class DodajVrstuWindow : Window, INotifyPropertyChanged
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

        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
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

        private decimal _godisnjiPrihod;
        public decimal GodisnjiPrihod
        {
            get
            {
                return _godisnjiPrihod;
            }
            set
            {
                if (value != _godisnjiPrihod)
                {
                    _godisnjiPrihod = value;
                    OnPropertyChanged("GodisnjiPrihod");
                }
            }
        }

        private Tip _tip;
        public Tip TipVrste
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("TipVrste");
                }
            }
        }

        private string _turistickiStatus;
        public string TuristickiStatus
        {
            get
            {
                return _turistickiStatus;
            }
            set
            {
                if (value != _turistickiStatus)
                {
                    _turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        private string _statusUgrozenosti;
        public string StatusUgrozenosti
        {
            get
            {
                return _statusUgrozenosti;
            }
            set
            {
                if (value != _statusUgrozenosti)
                {
                    _statusUgrozenosti = value;
                    OnPropertyChanged("StatusUgrozenosti");
                }
            }
        }

        public DodajVrstuWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                try
                {
                    string putanja = dlg.FileName;
                    Bi = new BitmapImage(new Uri(dlg.FileName));
                    var brush = new ImageBrush();
                    brush.ImageSource = Bi;
                    ikonicaDugme.Background = brush;
                }
                catch
                {
                    MyCustomMessageQueue.Enqueue("Slika nije podržana");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            statusUgrozenostiBox.ItemsSource = Enum.GetValues(typeof(StatusUgrozenosti)).Cast<StatusUgrozenosti>();
            turistickiStatusBox.ItemsSource = Enum.GetValues(typeof(TuristickiStatus)).Cast<TuristickiStatus>();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            if (Bi == null)
            {
                Bi = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(t => t.Oznaka == TipVrste.Oznaka).Select(t => t.Ikonica).Single();
            }
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Vrste.Add(new Vrsta
            {
                Oznaka = Oznaka,
                Ime = Ime,
                Opis = Opis,
                Tip = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(t => t.Oznaka == TipVrste.Oznaka).Single(),
                StatusUgrozenosti = (StatusUgrozenosti)Enum.Parse(typeof(StatusUgrozenosti), StatusUgrozenosti),
                TuristickiStatus = (TuristickiStatus)Enum.Parse(typeof(TuristickiStatus), TuristickiStatus),
                Opasna = opasnaCheck.IsChecked.Value,
                IUCN = iucnCheck.IsChecked.Value,
                ZiviUNaseljenomRegionu = naseljenoCheck.IsChecked.Value,
                GodisnjiPrihod = GodisnjiPrihod,
                DatumOtkrivanja = datum.SelectedDate ?? DateTime.Now,
                Etikete = etiketeBox.SelectedItems.Cast<Etiketa>().ToList(),
                Ikonica = Bi
            });

            
            // POTREBNO DODATI SNEKBAR - USPESNO DODATA VRSTA I ZATVORITI PROZOR
            //Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox).Text.Insert((sender as TextBox).CaretIndex, e.Text);
            decimal test;
            if (decimal.TryParse(newText, out test))
            {
                if (test >= 0)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void GodisnjiPrihod_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab && e.Key != Key.Escape)
                e.Handled = true;
        }

        private void GodisnjiPrihod_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = (sender as TextBox).Text;
            if (decimal.TryParse(newText, out decimal test))
            {
                if (test >= 0)
                {
                    return;
                }
            }
            // this triggers if input was not direct (e.g. paste-ing)
            (sender as TextBox).Text = ""; 
            e.Handled = true;
        }
    }
}

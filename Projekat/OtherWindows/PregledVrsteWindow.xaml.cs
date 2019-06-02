using MaterialDesignThemes.Wpf;
using Projekat.Model;
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
using System.Windows.Shapes;
using Projekat.Model;
using System.ComponentModel;

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for PregledVrsteWindow.xaml
    /// </summary>
    public partial class PregledVrsteWindow : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private Vrsta _vrsta;
        public Vrsta IzabranaVrsta
        {
            get
            {
                return _vrsta;
            }
            set
            {
                if (value != _vrsta)
                {
                    _vrsta = value;
                    OnPropertyChanged("IzabranaVrsta");
                }
            }
        }

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

        private TuristickiStatus _turistickiStatus;
        public TuristickiStatus TuristickiStatus
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

        private StatusUgrozenosti _statusUgrozenosti;
        public StatusUgrozenosti StatusUgrozenosti
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

        private bool _opasna;
        public bool Opasna
        {
            get
            {
                return _opasna;
            }
            set
            {
                if (value != _opasna)
                {
                    _opasna = value;
                    OnPropertyChanged("Opasna");
                }
            }
        }

        private bool _iucn;
        public bool IUCN
        {
            get
            {
                return _iucn;
            }
            set
            {
                if (value != _iucn)
                {
                    _iucn = value;
                    OnPropertyChanged("IUCN");
                }
            }
        }

        private bool _naseljeno;
        public bool ZiviUNaseljenomRegionu
        {
            get
            {
                return _naseljeno;
            }
            set
            {
                if (value != _naseljeno)
                {
                    _naseljeno = value;
                    OnPropertyChanged("ZiviUNaseljenomRegionu");
                }
            }
        }

        private DateTime _datumOtkrivanja;
        public DateTime DatumOtkrivanja
        {
            get
            {
                return _datumOtkrivanja;
            }
            set
            {
                if (value != _datumOtkrivanja)
                {
                    _datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }

        private BitmapImage Bi { get; set; }
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }
        public PregledVrsteWindow()
        {
            InitializeComponent();
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        public PregledVrsteWindow(Vrsta vrsta)
        {
            InitializeComponent();
            DataContext = this;
            IzabranaVrsta = vrsta;
            ((MainWindow)Application.Current.MainWindow).OtvorenaVrstaOznaka = vrsta.Oznaka;
            Oznaka = IzabranaVrsta.Oznaka;
            Ime = IzabranaVrsta.Ime;
            Opis = IzabranaVrsta.Opis;
            GodisnjiPrihod = IzabranaVrsta.GodisnjiPrihod;
            TipVrste = IzabranaVrsta.Tip;
            StatusUgrozenosti = IzabranaVrsta.StatusUgrozenosti;
            TuristickiStatus = IzabranaVrsta.TuristickiStatus;
            Opasna = IzabranaVrsta.Opasna;
            IUCN = IzabranaVrsta.IUCN;
            ZiviUNaseljenomRegionu = IzabranaVrsta.ZiviUNaseljenomRegionu;
            DatumOtkrivanja = IzabranaVrsta.DatumOtkrivanja;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
            statusUgrozenostiBox.ItemsSource = Enum.GetValues(typeof(StatusUgrozenosti)).Cast<StatusUgrozenosti>();
            turistickiStatusBox.ItemsSource = Enum.GetValues(typeof(TuristickiStatus)).Cast<TuristickiStatus>();
            Bi = IzabranaVrsta.Ikonica;
            var brush = new ImageBrush();
            brush.ImageSource = Bi;
            ikonicaDugme.Background = brush;
            foreach(Etiketa e in IzabranaVrsta.Etikete)
            {
                etiketeBox.SelectedItems.Add(e);
            }
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
                string putanja = dlg.FileName;
                Console.WriteLine(putanja);
                Bi = new BitmapImage(new Uri(dlg.FileName));
                var brush = new ImageBrush();
                brush.ImageSource = Bi;
                ikonicaDugme.Background = brush;
            }
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            Vrsta v = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Vrste.Where(ti => ti.Oznaka == IzabranaVrsta.Oznaka).FirstOrDefault();
            v.Oznaka = Oznaka;
            v.Ime = Ime;
            v.Opis = Opis;
            v.Tip = TipVrste;
            v.StatusUgrozenosti = StatusUgrozenosti;
            v.TuristickiStatus = TuristickiStatus;
            v.Opasna = Opasna;
            v.IUCN = IUCN;
            v.ZiviUNaseljenomRegionu = ZiviUNaseljenomRegionu;
            v.GodisnjiPrihod = GodisnjiPrihod;
            v.DatumOtkrivanja = DatumOtkrivanja;
            v.Ikonica = Bi;
            v.Etikete = etiketeBox.SelectedItems.Cast<Etiketa>().ToList();
            // SNEKBAR USPESNO STE IZMENILI
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Vrste.Remove(IzabranaVrsta);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            statusUgrozenostiBox.ItemsSource = Enum.GetValues(typeof(StatusUgrozenosti)).Cast<StatusUgrozenosti>();
            turistickiStatusBox.ItemsSource = Enum.GetValues(typeof(TuristickiStatus)).Cast<TuristickiStatus>();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox).Text.Insert((sender as TextBox).CaretIndex, e.Text);
            if (decimal.TryParse(newText, out decimal test))
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

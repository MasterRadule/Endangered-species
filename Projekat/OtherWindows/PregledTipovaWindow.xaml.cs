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
    /// Interaction logic for PregledTipovaWindow.xaml
    /// </summary>
    public partial class PregledTipovaWindow : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private BitmapImage Bi { get; set; }

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

        private Tip _tip;
        public Tip IzabraniTip
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
                    OnPropertyChanged("IzabraniTip");
                }
            }
        }
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        private Style oldStyle = null;

        private Chip selectedChip = null;
        public PregledTipovaWindow()
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
                string putanja = dlg.FileName;
                Bi = new BitmapImage(new Uri(dlg.FileName));
                Console.WriteLine(ikonicaDugme.Background);
                var brush = new ImageBrush();
                brush.ImageSource = Bi;
                ikonicaDugme.Background = brush;
            }
        }

        private void chip_Click(object sender, RoutedEventArgs e)
        {
            if(selectedChip != null)
                selectedChip.Style = oldStyle;
            Chip chip = sender as Chip;
            selectedChip = chip;
            oldStyle = chip.Style;
            chip.Style = FindResource("selectedChipStyle") as Style;

            IzabraniTip = chip.DataContext as Tip;
            ((MainWindow)Application.Current.MainWindow).OtvorenTipOznaka = IzabraniTip.Oznaka;
            Oznaka = IzabraniTip.Oznaka;
            imeBox.Text = IzabraniTip.Ime;
            opisBox.Text = IzabraniTip.Opis;
            Bi = IzabraniTip.Ikonica;
            var brush = new ImageBrush();
            brush.ImageSource = Bi;
            ikonicaDugme.Background = brush;
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (IzabraniTip == null)
            {
                MyCustomMessageQueue.Enqueue("Niste odabrali tip za pregled");
                return;
            }
            Tip t = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(ti => ti.Oznaka == IzabraniTip.Oznaka).FirstOrDefault();
            t.Oznaka = oznakaBox.Text;
            t.Ime = imeBox.Text;
            t.Opis = opisBox.Text;
            t.Ikonica = Bi;
            MyCustomMessageQueue.Enqueue("Tip je uspešno sačuvan");
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (IzabraniTip == null)
            {
                MyCustomMessageQueue.Enqueue("Niste odabrali tip za brisanje");
                return;
            }
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Remove(IzabraniTip);
            oznakaBox.Text = "";
            imeBox.Text = "";
            opisBox.Text = "";
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#FFB0BEC5");
            ikonicaDugme.Background = brush;
            IzabraniTip = null;
            MyCustomMessageQueue.Enqueue("Tip je uspešno obrisan");
        }
    }
}

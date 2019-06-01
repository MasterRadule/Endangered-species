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

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for PregledTipovaWindow.xaml
    /// </summary>
    public partial class PregledTipovaWindow : Window
    {
        private BitmapImage Bi { get; set; }
        private Tip izabraniTip { get; set; }
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }
        public PregledTipovaWindow()
        {
            InitializeComponent();
            DataContext = (MainWindow)Application.Current.MainWindow;
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
            izabraniTip = (sender as Chip).DataContext as Tip;
            oznakaBox.Text = izabraniTip.Oznaka;
            imeBox.Text = izabraniTip.Ime;
            opisBox.Text = izabraniTip.Opis;
            Bi = izabraniTip.Ikonica;
            var brush = new ImageBrush();
            brush.ImageSource = Bi;
            ikonicaDugme.Background = brush;
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (izabraniTip == null)
            {
                // SNEKBAR NISTE ODABRALI TIP ZA PREGLED
                return;
            }
            Tip t = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(ti => ti.Oznaka == izabraniTip.Oznaka).FirstOrDefault();
            t.Oznaka = oznakaBox.Text;
            t.Ime = imeBox.Text;
            t.Opis = opisBox.Text;
            t.Ikonica = Bi;
            // SNEKBAR USPESNO STE IZMENILI
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            if (izabraniTip == null)
            {
                // SNEKBAR NISTE ODABRALI TIP ZA BRISANJE
                return;
            }
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Remove(izabraniTip);
            oznakaBox.Text = "";
            imeBox.Text = "";
            opisBox.Text = "";
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#FFB0BEC5");
            ikonicaDugme.Background = brush;
            izabraniTip = null;
            // SNEKBAR USPESNO STE OBRISALI
        }
    }
}

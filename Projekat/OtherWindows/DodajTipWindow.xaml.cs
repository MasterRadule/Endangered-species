using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DodajTipWindow.xaml
    /// </summary>
    public partial class DodajTipWindow : Window
    {
        private BitmapImage Bi { get; set; }

        public DodajTipWindow()
        {
            InitializeComponent();
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

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.NekorisceniTipovi.Add(new Tip()
            {
                Oznaka = oznakaBox.Text,
                Ime = imeBox.Text,
                Opis = opisBox.Text,
                Ikonica = Bi
            });
        }
    }
}

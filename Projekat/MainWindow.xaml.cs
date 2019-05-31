using Projekat.OtherWindows;
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
using Projekat.Common;
using Projekat.Utility;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GlavniKontejner GlavniKontejner { get; set; }
        public int AktivnaMapa { get; set; }
        public string Putanja { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Loader.Test();
            GlavniKontejner = new GlavniKontejner();
            Putanja = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "endangered_species.es");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajVrstuWindow dodajVrstuWindow = new DodajVrstuWindow();
            dodajVrstuWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DodajTipWindow dodajTipWindow = new DodajTipWindow();
            dodajTipWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PregledTipovaWindow pregledTipovaWindow = new PregledTipovaWindow();
            pregledTipovaWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DodajEtiketuWindow dodajEtiketuWindow = new DodajEtiketuWindow();
            dodajEtiketuWindow.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PregledEtiketaWindow pregledEtiketaWindow = new PregledEtiketaWindow();
            pregledEtiketaWindow.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".es"; // Default file extension
            dlg.Filter = "Endangered species maps (.es)|*.es"; // Filter files by extension
            dlg.Multiselect = false;

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string novaPutanja = dlg.FileName;

                if(!novaPutanja.Equals(Putanja))
                {
                    Putanja = novaPutanja;
                    GlavniKontejner = Loader.Deserijalizuj(Putanja);
                }

            }
            
        }

        private void SetMapImage(string path)
        {
            mapImage.BeginInit();
            mapImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            mapImage.EndInit();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 1;
            SetMapImage("Data/Maps/map_2.png");
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 2;
            SetMapImage("Data/Maps/map_3.png");
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 3;
            SetMapImage("Data/Maps/map_4.png");
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            if (mapImage != null) // on window startup, this button is checked, but image is still not loaded
            {
                AktivnaMapa = 0;
                SetMapImage("Data/Maps/map_1.png");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if(Putanja != null)
                Loader.Serijalizuj(GlavniKontejner, Putanja); // klik na dugme Sacuvaj
            // dodati snackbar Uspesno sacuvano
        }
    }
}

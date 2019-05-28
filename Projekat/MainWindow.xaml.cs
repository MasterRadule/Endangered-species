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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
        }

        private void SetMapImage(string path)
        {
            mapImage.BeginInit();
            mapImage.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            mapImage.EndInit();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SetMapImage("Data/Maps/map_2.png");
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            SetMapImage("Data/Maps/map_3.png");
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            SetMapImage("Data/Maps/map_4.png");
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            if(mapImage!=null) // on window startup, this button is checked, but image is still not loaded
                SetMapImage("Data/Maps/map_1.png");
        }
    }
}

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
    /// Interaction logic for DodajEtiketuWindow.xaml
    /// </summary>
    public partial class DodajEtiketuWindow : Window
    {
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }
        public DodajEtiketuWindow()
        {
            InitializeComponent();
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.NekorisceneEtikete.Add(new Etiketa()
            {
                Oznaka = oznakaBox.Text,
                Opis = opisBox.Text,
                Boja = odabirBoje.SelectedColorText
            });
        }
    }
}

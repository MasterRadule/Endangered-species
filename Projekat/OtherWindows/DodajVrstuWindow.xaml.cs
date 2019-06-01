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

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for DodajVrstuWindow.xaml
    /// </summary>
    public partial class DodajVrstuWindow : Window
    {
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }
        private BitmapImage Bi { get; set; }
        
        public DodajVrstuWindow()
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
            Tip tip = (Tip)tipBox.SelectedValue;
            StatusUgrozenosti statusUgrozenosti = (StatusUgrozenosti)Enum.Parse(typeof(StatusUgrozenosti), statusUgrozenostiBox.SelectedValue.ToString()); 
            TuristickiStatus turistickiStatus = (TuristickiStatus)Enum.Parse(typeof(TuristickiStatus), turistickiStatusBox.SelectedValue.ToString());
            bool opasna = opasnaCheck.IsChecked.Value;
            bool iucn = iucnCheck.IsChecked.Value;
            bool naseljena = naseljenoCheck.IsChecked.Value;
            decimal prihod = Convert.ToDecimal(godisnjiPrihod.Text);
            DateTime d = datum.DisplayDate;
            List<Etiketa> etikete = etiketeBox.SelectedItems.Cast<Etiketa>().ToList();
            if (Bi == null)
            {
                Bi = ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Where(t => t.Oznaka == tip.Oznaka).Select(t => t.Ikonica).Single();
            }
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Vrste.Add(new Vrsta
            {
                Oznaka = oznakaBox.Text,
                Ime = imeBox.Text,
                Opis = opisBox.Text,
                Tip = tip,
                StatusUgrozenosti = statusUgrozenosti,
                TuristickiStatus = turistickiStatus,
                Opasna = opasna,
                IUCN = iucn,
                ZiviUNaseljenomRegionu = naseljena,
                GodisnjiPrihod = prihod,
                DatumOtkrivanja = d,
                Etikete = etikete,
                Ikonica = Bi
            });
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

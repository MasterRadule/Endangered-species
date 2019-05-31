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

namespace Projekat.OtherWindows
{
    /// <summary>
    /// Interaction logic for DodajVrstuWindow.xaml
    /// </summary>
    public partial class DodajVrstuWindow : Window
    {
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }
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
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
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

    }
}

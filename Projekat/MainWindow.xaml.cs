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
using MaterialDesignThemes.Wpf;
using Projekat.Model;

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

        private Point startPoint = new Point();
        private bool dragging = false;

        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //Loader.Test();
            DataContext = this;
            GlavniKontejner = new GlavniKontejner();
            Putanja = null;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));

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
            dlg.Title = "Učitaj fajl";
            dlg.Filter = "Endangered species maps (.es)|*.es"; // Filter files by extension
            dlg.Multiselect = false;

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                string novaPutanja = dlg.FileName;

                if (!novaPutanja.Equals(Putanja))
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
            LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 2;
            SetMapImage("Data/Maps/map_3.png");
            LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 3;
            SetMapImage("Data/Maps/map_4.png");
            LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            AktivnaMapa = 0;
            if (mapImage != null) // on window startup, this button is checked, but image is still not loaded
            {
                
                SetMapImage("Data/Maps/map_1.png");
                LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (Putanja == null)
            {
                Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();
                saveDlg.Filter = "Endangered species maps (.es)|*.es";
                saveDlg.Title = "Sačuvaj fajl";
                Nullable<bool> result = saveDlg.ShowDialog();

                if (result.HasValue && result.Value)
                {
                    Putanja = saveDlg.FileName;
                }
            }
            Loader.Serijalizuj(GlavniKontejner, Putanja); // klik na dugme Sacuvaj
            MyCustomMessageQueue.Enqueue("Uspešno sačuvano");
        }

        private void Chip_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Chip_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (!dragging &&
                e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Vrsta vrsta = listViewItem.DataContext as Vrsta;

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("vrsta", vrsta);
                dragging = true;
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);

            }
        }

        private void Pin_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (!dragging && 
                e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                Chip chip =
                    FindAncestor<Chip>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Pin pin = chip.DataContext as Pin;

                MapGrid.Children.Remove(chip);
                GlavniKontejner.Mape[AktivnaMapa].Pinovi.Remove(pin);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("vrsta", pin.Vrsta);
                dragging = true;
                DragDrop.DoDragDrop(chip, dragData, DragDropEffects.Move);
            }
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("vrsta"))
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            dragging = false;
            if (e.Data.GetDataPresent("vrsta"))
            {
                Vrsta vrsta = e.Data.GetData("vrsta") as Vrsta;
                Point locationOnImage = e.GetPosition(MapGrid);
                Pin pin = new Pin() { Vrsta = vrsta, X = locationOnImage.X, Y = locationOnImage.Y };
                GlavniKontejner.Mape[AktivnaMapa].Pinovi.Add(pin);
                LoadChipFromPin(pin);
            }

        }

        private void LoadChipFromPin(Pin pin)
        {
            Image image = new Image
            {
                Source = pin.Vrsta.Ikonica
            };
            Chip chip = new Chip
            {
                Content = pin.Vrsta.Oznaka,
                Margin = new Thickness(pin.X, pin.Y, 0, 0),
                Icon = image,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                DataContext = pin,
                IsDeletable = true
            };
            chip.PreviewMouseLeftButtonDown += Chip_PreviewMouseLeftButtonDown;
            chip.PreviewMouseMove += Pin_PreviewMouseMove;
            chip.DeleteClick += Chip_DeleteClick;
            MapGrid.Children.Add(chip);
        }

        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {
            Chip chip = sender as Chip;
            MapGrid.Children.Remove(chip);
            GlavniKontejner.Mape[AktivnaMapa].Pinovi.Remove(chip.DataContext as Pin);
        }

        private void LoadMap(Mapa mapa)
        {
            // remove all children that are of type Chip
            int intTotalChildren = MapGrid.Children.Count - 1;
            for (int intCounter = intTotalChildren; intCounter > 0; intCounter--)
            {
                if (MapGrid.Children[intCounter].GetType() == typeof(Chip))
                {
                    Chip ucCurrentChild = (Chip)MapGrid.Children[intCounter];
                    MapGrid.Children.Remove(ucCurrentChild);
                }
            }

            mapa.Pinovi.ForEach(LoadChipFromPin);
        }

        private void RadioButton_DragEnter(object sender, DragEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
        }

    }
}

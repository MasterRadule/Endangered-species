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
using System.ComponentModel;
using BespokeFusion;

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private GlavniKontejner _glavniKontejner;
        public GlavniKontejner GlavniKontejner
        {
            get
            {
                return _glavniKontejner;
            }
            set
            {
                if (value != _glavniKontejner)
                {
                    _glavniKontejner = value;
                    OnPropertyChanged("GlavniKontejner");
                }
            }
        }
        public int AktivnaMapa { get; set; }
        public string Putanja { get; set; }

        private Point startPoint = new Point();
        private bool dragging = false;
        public string OtvorenaVrstaOznaka { get; set; }
        public string OtvorenTipOznaka { get; set; }
        public string OtvorenaEtiketaOznaka { get; set; }
        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        private bool QuestionMarkPopupOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            //Loader.Test();
            DataContext = this;
            GlavniKontejner = new GlavniKontejner();
            Putanja = null;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(2000));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!GlavniKontejner.Tipovi.Any())
            {
                MyCustomMessageQueue.Enqueue("Potrebno je dodati bar jedan tip pre dodavanje vrste");
                return;
            }
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
            var msg = new CustomMaterialMessageBox
            {
                TxtMessage = { Text = "Da li ste sigurni da želite da učitate novu datoteku? Sve nesnimnjene promene će biti izgubljene.", Background = FindResource("PrimaryHueMidForegroundBrush") as Brush },
                TxtTitle = { Text = "Potvrda učitavanja nove datoteke" },
                BtnOk = { Content = "Da" },
                BtnCancel = { Content = "Ne" },
                MainContentControl = { Background = FindResource("PrimaryHueMidForegroundBrush") as Brush },
            };

            msg.Show();

            if (msg.Result == MessageBoxResult.OK)
            {
                // Configure open file dialog box
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".es"; // Default file extension
                dlg.Title = "Učitaj fajl";
                dlg.Filter = "Endangered species maps (.es)|*.es"; // Filter files by extension
                dlg.Multiselect = false;

                // Show open file dialog box
                bool? result = dlg.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    string novaPutanja = dlg.FileName;

                    if (!novaPutanja.Equals(Putanja))
                    {
                        try
                        {
                            Putanja = novaPutanja;
                            GlavniKontejner = Loader.Deserijalizuj(Putanja);
                            LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
                            MyCustomMessageQueue.Enqueue("Izabrana datoteka je uspešno učitana");
                        }
                        catch
                        {
                            MyCustomMessageQueue.Enqueue("Izabrana datoteka nije podržana");
                        }

                    }

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
            try
            {
                Loader.Serijalizuj(GlavniKontejner, Putanja); // klik na dugme Sacuvaj
                MyCustomMessageQueue.Enqueue("Uspešno sačuvano");
            }
            catch
            {
                MyCustomMessageQueue.Enqueue("Neuspešno sačuvano. Možda nemate pravo pristupa izabranoj lokaciji.");
            }

        }

        private void Chip_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            dragging = false;
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
                vrsta.pinovi.Add(pin);
                GlavniKontejner.Mape[AktivnaMapa].Pinovi.Add(pin);
                LoadChipFromPin(pin);
            }

        }

        private void LoadChipFromPin(Pin pin)
        {
            Image image = new Image();
            Chip chip = new Chip
            {
                Margin = new Thickness(pin.X, pin.Y, 0, 0),
                Icon = image,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                DataContext = pin,
                IsDeletable = true
            };
            pin.chip = chip;

            BindingOperations.SetBinding(chip, Chip.ContentProperty, new Binding() { Path = new PropertyPath("Oznaka"), Source = pin.Vrsta });
            BindingOperations.SetBinding(image, Image.SourceProperty, new Binding() { Path = new PropertyPath("Ikonica"), Source = pin.Vrsta });
            chip.PreviewMouseLeftButtonDown += Chip_PreviewMouseLeftButtonDown;
            chip.PreviewMouseMove += Pin_PreviewMouseMove;
            chip.DeleteClick += Chip_DeleteClick;
            MapGrid.Children.Add(chip);
        }

        private void Chip_DeleteClick(object sender, RoutedEventArgs e)
        {
            Chip chip = sender as Chip;
            MapGrid.Children.Remove(chip);
            Pin pin = chip.DataContext as Pin;
            GlavniKontejner.Mape[AktivnaMapa].Pinovi.Remove(pin);
            pin.Vrsta.pinovi.Remove(pin);
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

            mapa.Pinovi.ToList().ForEach(LoadChipFromPin);
        }

        private void RadioButton_DragEnter(object sender, DragEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            rb.IsChecked = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            statusUgrozenostiBox.ItemsSource = Enum.GetValues(typeof(StatusUgrozenosti)).Cast<StatusUgrozenosti>();
            turistickiStatusBox.ItemsSource = Enum.GetValues(typeof(TuristickiStatus)).Cast<TuristickiStatus>();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            string newText = (sender as TextBox).Text.Insert((sender as TextBox).CaretIndex, e.Text);
            decimal test;
            if (decimal.TryParse(newText, out test))
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


        private void GodisnjiPrihod_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newText = (sender as TextBox).Text;
            decimal test;
            if (decimal.TryParse(newText, out test))
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

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                (sender as DatePicker).Text = "";
                e.Handled = true;
                return;
            }
            if (e.Key != Key.Tab && e.Key != Key.Escape)
                e.Handled = true;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = true);

            string imeOznakaTekst = pretragaImeOznakaTB.Text;
            GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.Oznaka.Contains(imeOznakaTekst) || i.Ime.Contains(imeOznakaTekst)));

            Tip tip = (Tip)tipBox.SelectedValue;
            if (tip != null)
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Tip == tip);

            string statusUgrozenostiS = statusUgrozenostiBox.Text;
            if (!string.IsNullOrEmpty(statusUgrozenostiS))
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.StatusUgrozenosti == (StatusUgrozenosti)Enum.Parse(typeof(StatusUgrozenosti), statusUgrozenostiS)));

            string turistickiStatusS = turistickiStatusBox.Text;
            if (!string.IsNullOrEmpty(turistickiStatusS))
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.TuristickiStatus == (TuristickiStatus)Enum.Parse(typeof(TuristickiStatus), turistickiStatusS)));

            if (DaNeCheck.IsChecked == true)
            {
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.Opasna == opasnaCheck.IsChecked.Value &&
                i.IUCN == iucnCheck.IsChecked.Value && i.ZiviUNaseljenomRegionu == naseljenoCheck.IsChecked.Value));
            }

            if (!string.IsNullOrEmpty(godisnjiPrihodDG.Text))
            {
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.GodisnjiPrihod >= Convert.ToDecimal(godisnjiPrihodDG.Text)));
            }

            if (!string.IsNullOrEmpty(godisnjiPrihodGG.Text))
            {
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.GodisnjiPrihod <= Convert.ToDecimal(godisnjiPrihodGG.Text)));
            }

            if (!string.IsNullOrEmpty(datumDG.Text))
            {
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.DatumOtkrivanja >= datumDG.DisplayDate));
            }

            if (!string.IsNullOrEmpty(datumGG.Text))
            {
                GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = i.Prikazana && (i.DatumOtkrivanja <= datumGG.DisplayDate));
            }

            TurnOffSearchButton.IsEnabled = true;
        }

        private void TurnOffSearchButton_Click(object sender, RoutedEventArgs e)
        {
            GlavniKontejner.Vrste.ToList().ForEach(i => i.Prikazana = true);
            TurnOffSearchButton.IsEnabled = false;
            pretragaImeOznakaTB.Text = "";
            tipBox.SelectedIndex = -1;
            statusUgrozenostiBox.SelectedIndex = -1;
            turistickiStatusBox.SelectedIndex = -1;
            DaNeCheck.IsChecked = false;
            opasnaCheck.IsChecked = false;
            iucnCheck.IsChecked = false;
            naseljenoCheck.IsChecked = false;
            godisnjiPrihodDG.Text = "";
            godisnjiPrihodGG.Text = "";
            datumDG.Text = "";
            datumGG.Text = "";
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            Chip chip = sender as Chip;
            Style oldStyle = chip.Style;
            chip.Style = FindResource("selectedChipStyle") as Style;

            PregledVrsteWindow pregledVrsteWindow = new PregledVrsteWindow((sender as Chip).DataContext as Vrsta);
            pregledVrsteWindow.ShowDialog();
            chip.Style = oldStyle;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var msg = new CustomMaterialMessageBox
            {
                TxtMessage = { Text = "Da li ste sigurni da želite da napravite novu datoteku? Sve nesnimnjene promene će biti izgubljene.", Background = FindResource("PrimaryHueMidForegroundBrush") as Brush },
                TxtTitle = { Text = "Potvrda kreiranja nove datoteke" },
                BtnOk = { Content = "Da" },
                BtnCancel = { Content = "Ne" },
                MainContentControl = { Background = FindResource("PrimaryHueMidForegroundBrush") as Brush },
            };

            msg.Show();

            if (msg.Result == MessageBoxResult.OK)
            {
                Putanja = null;
                GlavniKontejner = new GlavniKontejner();
                LoadMap(GlavniKontejner.Mape[AktivnaMapa]);
                MyCustomMessageQueue.Enqueue("Nova datoteka uspešno kreirana");
            }
        }

        private void Button_QuestionMark_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionMarkPopupOpen) {
                QuestionMarkPopup.IsPopupOpen = false;
                QuestionMarkPopupOpen = false;
            }
            else
            {
                QuestionMarkPopup.IsPopupOpen = true;
                QuestionMarkPopupOpen = true;
            }

        }

        private void Tutorial_Button_Click(object sender, RoutedEventArgs e)
        {
            TutorialWindow tutorialWindow = new TutorialWindow((sender as Button).Name);
            tutorialWindow.ShowDialog();
        }
    }
}

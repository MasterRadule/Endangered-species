﻿using MaterialDesignThemes.Wpf;
using Projekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DodajTipWindow.xaml
    /// </summary>
    public partial class DodajTipWindow : Window
    {
        private BitmapImage Bi { get; set; }

        public SnackbarMessageQueue MyCustomMessageQueue { get; set; }

        public DodajTipWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyCustomMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(1000));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = null;
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png"; // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();
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

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).GlavniKontejner.Tipovi.Add(new Tip()
            {
                Oznaka = oznakaBox.Text,
                Ime = imeBox.Text,
                Opis = opisBox.Text,
                Ikonica = Bi
            });

        }
    }
}

using Projekat;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace HelpSistem
{
    /// <summary>
    /// Interaction logic for HelpViewer.xaml
    /// </summary>
    public partial class HelpViewer : Window
    {
        public HelpViewer(string key, Window originator)
        {
            string page;
            string section;

            if (key.Contains("#"))
            {
                page = key.Split('#')[0];
                section = key.Split('#')[1];
            }
            else
            {
                page = key;
                section = "";
            }

            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = string.Format("{0}/Help/Pages/{1}.htm", curDir, page);
            if (!File.Exists(path))
            {
                page = "error";
                section = "";
            }
            Uri u = new Uri(string.Format("file:///{0}/Help/Pages/{1}.htm#{2}", curDir, page, section));
            wbHelp.Navigate(u);

        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }


    }
}

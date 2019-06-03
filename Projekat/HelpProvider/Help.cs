using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using form = System.Windows.Forms;

namespace Projekat.HelpProvider
{
    public static class Help
    {
        static Help()
        {
            // Rather than having to manually associate the Help command, let's take care
            // of this here.
            CommandManager.RegisterClassCommandBinding(typeof(FrameworkElement),
              new CommandBinding(ApplicationCommands.Help,
                new ExecutedRoutedEventHandler(Executed),
                new CanExecuteRoutedEventHandler(CanExecute)));
        }

        #region Filename

        /// <summary>
        /// Filename Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty FilenameProperty =
          DependencyProperty.RegisterAttached("Filename", typeof(string), typeof(Help));

        /// <summary>
        /// Gets the Filename property.
        /// </summary>
        public static string GetFilename(DependencyObject d)
        {
            return (string)d.GetValue(FilenameProperty);
        }

        /// <summary>
        /// Sets the Filename property.
        /// </summary>
        public static void SetFilename(DependencyObject d, string value)
        {
            d.SetValue(FilenameProperty, value);
        }

        #endregion

        #region Keyword

        /// <summary>
        /// Keyword Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty KeywordProperty =
          DependencyProperty.RegisterAttached("Keyword", typeof(string), typeof(Help));

        /// <summary>
        /// Gets the Keyword property.
        /// </summary>
        public static string GetKeyword(DependencyObject d)
        {
            return (string)d.GetValue(KeywordProperty);
        }

        /// <summary>
        /// Sets the Keyword property.
        /// </summary>
        public static void SetKeyword(DependencyObject d, string value)
        {
            d.SetValue(KeywordProperty, value);
        }
        #endregion

        #region Helpers
        private static void CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            FrameworkElement el = sender as FrameworkElement;
            if (el != null)
            {
                string fileName = FindFilename(el);
                if (!string.IsNullOrEmpty(fileName))
                    args.CanExecute = true;
            }
        }

        private static void Executed(object sender, ExecutedRoutedEventArgs args)
        {
            // Call ShowHelp.
            DependencyObject parent = args.OriginalSource as DependencyObject;
            string keyword = GetKeyword(parent);
            if (!string.IsNullOrEmpty(keyword))
            {
                form.Help.ShowHelp(null, FindFilename(parent), form.HelpNavigator.KeywordIndex, keyword);
            }
            else
            {
                form.Help.ShowHelp(null, FindFilename(parent));
            }
        }

        private static string FindFilename(DependencyObject sender)
        {
            if (sender != null)
            {
                string fileName = GetFilename(sender);
                if (!string.IsNullOrEmpty(fileName))
                    return fileName;
                return FindFilename(VisualTreeHelper.GetParent(sender));
            }
            return null;
        }
        #endregion
    }
}

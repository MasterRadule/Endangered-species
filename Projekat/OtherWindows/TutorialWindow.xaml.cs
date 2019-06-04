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
    /// Interaction logic for TutorialWindow.xaml
    /// </summary>
    public partial class TutorialWindow : Window
    {
        public TutorialWindow(string tutorijal)
        {
            InitializeComponent();
            TutorialVideo.Source = new Uri(@"C:\Users\Danijel\Documents\GitHub\ISAMRS\Endangered-species\Projekat\Tutorials\" + tutorijal + ".mp4", UriKind.Relative);
        }
    }
}

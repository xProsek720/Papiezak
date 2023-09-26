using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
using System.IO;
using Path = System.IO.Path;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Papiezak
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DisableRund dr;
        midi md;
        bowserKiller bk;
        noKiosk bow;
        noKiosk mem1;
        fejkProgress fp;
        Tapeta tap;


        public MainWindow()
        {

            InitializeComponent();


        }
        /*
        public string ConvertMidiFileToBase64String(string midiFilePath)
        {
            byte[] midiBytes = System.IO.File.ReadAllBytes(midiFilePath);
            return Convert.ToBase64String(midiBytes);
        }*/

        public void loadProgressClasses()
        {
            fp = new fejkProgress(this.progressBar, this.setupInfo, this.scrollView);
        }
        public void loadClasses() 
        {
            dr = new DisableRund();
            md = new midi();
            bk = new bowserKiller();
            bow = new noKiosk("https://www.youtube.com/watch?v=gKgIc_9XYgo&autoplay=1", 46,720, 720);
            mem1 = new noKiosk("https://www.youtube.com/watch?v=5Uio3mIvoCg&autoplay=1", 11, 0, 0);
            tap = new Tapeta();
            fireClasses();
        }
        public void fireClasses() 
        {
            bow.PlayAndOpenBrowser();
            mem1.PlayAndOpenBrowser();
        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            loadProgressClasses();
            fp.BtnStart_Click(sender, e);

            //File.WriteAllText("lol2.txt", ConvertMidiFileToBase64String("tapeta.jpg"));
            
            loadClasses();
        }
    }
}

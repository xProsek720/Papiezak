using System;
using System.Collections.Generic;
using System.IO;
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

namespace CreamPieWatchDog
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WatchDog wd;
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            //makeB64();  
            LoadClasses();

        }
        /*
        public string ConvertMidiFileToBase64String(string midiFilePath)
        {
            byte[] midiBytes = System.IO.File.ReadAllBytes(midiFilePath);
            return Convert.ToBase64String(midiBytes);
        }
        public void makeB64() 
        {


            File.WriteAllText("lol4.txt", ConvertMidiFileToBase64String("Papiezak.exe"));
        }
        */
        public void LoadClasses() 
        {
            wd = new WatchDog();
            wd.Start();
        }
    }
}

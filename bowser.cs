using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papiezak
{
    internal class bowser
    {
        string url = "https://www.youtube.com/watch?v=gKgIc_9XYgo&autoplay=1";
        int sec = 32;
        bool turnOff = true;
        public bowser() 
        {

        }
        public bowser(string url) 
        {
            this.url = url;
            turnOff = false;
        }
        public bowser(string url, int sec)
        {
            this.url = url;
            this.sec = sec;
            turnOff = false;
        }
        public bowser(int sec) 
        {
            this.sec=sec;
            turnOff = false;
        }
        public async void PlayAndOpenBrowser()
        {
            string browserPath = null;

            if (File.Exists(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"))
            {
                browserPath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            }
            if (File.Exists(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"))
            {
                browserPath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            }
            if (File.Exists(@"C:\Program Files\Google\Chrome\Application\chrome.exe")) 
            {
                browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            }
            if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
            {
                browserPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            }


            await Task.Delay(TimeSpan.FromSeconds(sec));
            if (browserPath.Contains("chrome.exe"))
            {
                if (turnOff) 
                {
                    Process.Start("cmd", "/C taskkill /IM chrome.exe /F");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                Process.Start(browserPath, $"--kiosk {url}");
            }
            else if (browserPath.Contains("firefox.exe"))
            {
                if (turnOff) 
                {
                    Process.Start("cmd", "/C taskkill /IM firefox.exe /F");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                Process.Start(browserPath, $"-kiosk {url}");
            }
            else if (browserPath.Contains("msedge.exe"))
            {
                if (turnOff) 
                {
                    Process.Start("cmd", "/C taskkill /IM msedge.exe /F");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                Process.Start(browserPath, $"--start-fullscreen --kiosk {url}");
            }
        }
    }
}

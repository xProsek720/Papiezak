using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papiezak
{
    internal class bowserKiller
    {
        string url = "https://www.youtube.com/watch?v=gKgIc_9XYgo&autoplay=1";
        int sec = 32;
        bool turnOff = true;
        public bowserKiller() 
        {
            Kill();
        }

        public async void Kill()
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


            await Task.Delay(TimeSpan.FromSeconds(1));
            if (browserPath.Contains("chrome.exe"))
            {
                Process.Start("cmd", "/C taskkill /IM chrome.exe /F");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            else if (browserPath.Contains("firefox.exe"))
            {
                Process.Start("cmd", "/C taskkill /IM firefox.exe /F");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            else if (browserPath.Contains("msedge.exe"))
            {
                Process.Start("cmd", "/C taskkill /IM msedge.exe /F");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}

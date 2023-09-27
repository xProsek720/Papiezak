﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreamPieWatchDog
{
    internal class WatchDog
    {

        private string appPath;
        private string appName;

        public WatchDog()
        {
            if (!File.Exists("CreamPieWatchDog.exe")) 
            {
                File.WriteAllBytes("CreamPieWatchDog.exe", Convert.FromBase64String(WatchDogB64));
            }
            this.appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\CreamPieWatchDog.exe";
            this.appName = Path.GetFileNameWithoutExtension(this.appPath);
        }

        public void Start()
        {
            while (true)
            {
                if (!IsProcessRunning(appName))
                {

                    try
                    {
                        Process.Start(appPath);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                Thread.Sleep(1000);
            }
        }


        private bool IsProcessRunning(string name)
        {

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;

namespace Papiezak
{
    internal class fejkProgress
    {
        private DispatcherTimer _timer;
        private Random _random;
        System.Windows.Controls.TextBlock setupInfo;
        System.Windows.Controls.ProgressBar progressBar;
        System.Windows.Controls.ScrollViewer scrollViewer;
        private int _progressCount;
        public fejkProgress(System.Windows.Controls.ProgressBar progressBar, System.Windows.Controls.TextBlock setupInfo, System.Windows.Controls.ScrollViewer scrollViewer) 
        {
            this.progressBar = progressBar;
            this.setupInfo = setupInfo;
            this.scrollViewer = scrollViewer;
            _timer = new DispatcherTimer();
            _random = new Random();
            _timer.Interval = TimeSpan.FromMilliseconds(100); // Adjust for faster/slower progress
            _timer.Tick += Timer_Tick;
            _progressCount = 1;
        }
        public void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            setupInfo.Text = "Starting installation...\n";
            progressBar.Value = 0; // Reset progress bar
            _progressCount = 1;
            _timer.Start();
        }
        public bool settOnce = false;
        public bool finalOnce = false;
        public void Timer_Tick(object sender, EventArgs e)
        {

            // Add a random value to the progress bar each tick
            progressBar.Value += _random.Next(1, 5); // Adjust the range for bigger/smaller increments
            if (progressBar.Value <= 10)
            {
                setupInfo.Text += ($"Installing component {_progressCount}...\n");

                _progressCount++;
            }
            else if (progressBar.Value <= 90)
            {
                if (!settOnce) 
                {
                    setupInfo.Text += ($"Configuring settings...\n");
                    settOnce = true;
                }
            }
            else if (progressBar.Value <= 95)
            {
                if (!finalOnce) 
                {
                    setupInfo.Text += ($"Finalizing setup...\n");
                    finalOnce = true;
                }
            }
            else if (progressBar.Value >= 100) // Stop when 100% is reached
            {
                _timer.Stop();
                setupInfo.Text += ("Installation complete!");
                MessageBox.Show("Progress completed!");
            }
            scrollViewer.ScrollToHorizontalOffset(scrollViewer.ExtentHeight);
        }
    }

}

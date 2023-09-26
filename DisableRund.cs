using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

public class DisableRund
{
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool BlockInput(bool fBlockIt);

    public DisableRund()
	{
        Stop();
	}
    public async void Stop()
    {
        // Disable Win+L (might lock the workstation)
        Process.Start("rundll32.exe", "user32.dll,BlockInput");


        // Block keyboard and mouse input
        BlockInput(true);

        // Wait for 5 seconds
        await Task.Delay(TimeSpan.FromSeconds(65));

        Process.Start("rundll32.exe", "user32.dll,BlockInput");
        // Unblock keyboard and mouse input
        BlockInput(false);
    }       
}

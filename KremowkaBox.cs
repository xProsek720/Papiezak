using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Papiezak
{
    internal class KremowkaBox
    {
        public KremowkaBox() 
        {
            int j = 0;
            while (j < 3)
            {
                StartPleasingCreamPies();
                
            }
        }

        public async Task<Task<MessageBoxResult>> ShowKremowkaBox() 
        {
            return Task.Run(() => MessageBox.Show("Insert Kremówka plz.\nAVE 21:37!\nWłóż Creampie proszę."));
        }

        private async Task StartPleasingCreamPies() 
        {
            int i = 0;
            while (i < 3) 
            {
                _ = ShowKremowkaBox();
                await Task.Delay(2137);

            }
        }

    }
}

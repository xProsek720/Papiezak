using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papiezak
{
    internal class KremowyManager
    {
        KremowkaBox[] creampieBoxes = new KremowkaBox[10];
        public KremowyManager() 
        {
            makeCreampies();
        }

        public async Task makeCreampies() 
        {
            for (int i = 0; i < 2; i++)
            {
                creampieBoxes[i] = new KremowkaBox();
                await Task.Delay(2137);
            }
        }
    }
}

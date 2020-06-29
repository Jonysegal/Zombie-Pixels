using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class Sleeper
    {
        const int SleepTime = 300;
        public static void Sleep() => System.Threading.Thread.Sleep(SleepTime);
        public static void Loop()
        {
            Sleep();
        }
    }
}

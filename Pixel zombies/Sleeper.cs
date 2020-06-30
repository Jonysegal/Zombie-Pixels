using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class Sleeper
    {
        static double SleepTime = 1000;
        public static void Sleep() => System.Threading.Thread.Sleep((int)SleepTime);
        public static void Loop()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Period))
                SleepTime = SleepTime * .75;
            if(Keyboard.IsKeyPressed(Keyboard.Key.Comma))
                SleepTime = SleepTime * 1.25;
            Sleep();
        }
    }
}

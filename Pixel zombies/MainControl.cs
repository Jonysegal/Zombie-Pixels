using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    class MainControl
    {
        static void Main(string[] args)
        {
            Initialize();
            RunLoop();
        }
        static void Initialize()
        {
        }
        static void RunLoop()
        {
            while (true)
            {
                KeyboardManager.Loop();
                Config.Loop();
                CameraControl.Loop();

                FullMap.Loop();

                EntityControl.Loop();

                Drawer.Loop();
             //   Sleeper.Loop();

            }
        }
    }

}

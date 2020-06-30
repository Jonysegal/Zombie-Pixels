
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Pixel_zombies
{
    public static class Drawer
    {

        /// <summary>
        /// On invokation of drawer in the game loop, drawer has two responsibilites.
        /// 1) Update the image for any sprites modified in map storer over the past frame.
        /// 2) Draw the image to the window.
        /// </summary>

        static RenderWindow window;
        static Texture texture;
        static Image image;
        static Sprite sprite;
        public const int WindowSize = 1000;
        public static View view = new View(new Vector2f(100, 900), new Vector2f(100, 100));

        

        static Drawer()
        {
            window = new RenderWindow(new VideoMode(WindowSize, WindowSize), "Window");
            window.SetView(view);
            texture = new Texture(WindowSize, WindowSize);
            image = new Image(WindowSize, WindowSize);
            sprite = new Sprite(texture);
            InitializeImage();
        }

        static void InitializeImage()
        {
            Clear();
        }

        static void Clear()
        {
            for (uint i = 0; i < WindowSize; i++)
            {
                for (uint j = 0; j < WindowSize; j++)
                {
                    if (i == 10 || j == 10 || i == WindowSize - 10 || j == WindowSize - 10)
                        image.SetPixel(i, j, Color.Yellow);
                    else
                        image.SetPixel(i, j, Tile.TypeColorMap[Tile.Type.Floor]);
                }
            }
        }

        static void SetPixelsFromDrawController()
        {
           // Console.WriteLine("new draw");
            foreach (var v in FullMap.modifiedPoints)
            {
             //   Console.WriteLine("setting " + v.ToString() + " to " + FullMap.GetAt(v).GetDrawingColor());
                image.SetPixel((uint)v.x, WindowSize - (uint)v.y, FullMap.GetAt(v).GetDrawingColor());
            }
        }

        public static void Loop()
        {
            SetPixelsFromDrawController();
            Draw();
        }

        static void Draw()
        {
            texture.Update(image);
            window.Draw(sprite);
            window.Display();
        }

        public static void UpdateView() => window.SetView(view);



    }
}

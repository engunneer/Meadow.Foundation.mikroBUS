using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.mikroBUS;
using System;

namespace C8x8Y_Sample
{
    // Change F7MicroV2 to F7Micro for V1.x boards
    public class MeadowApp : App<F7MicroV2, MeadowApp>
    {
        public MeadowApp()
        {
            Console.WriteLine("Initializing ...");

            var c8x8Y = new C8x8Y(Device, Device.CreateSpiBus(), Device.Pins.D02);
            c8x8Y.IgnoreOutOfBoundsPixels = true;

            c8x8Y.Clear();

            var graphics = new MicroGraphics(c8x8Y)
            {
                Rotation = RotationType._180Degrees
            };
            graphics.CurrentFont = new Font4x8();

            var message = "Wilderness Labs Meadow F7 Feather";

            while (true)
            {
                for (int x = 0; x < message.Length * 4; x++)
                {
                    graphics.Clear();
                    graphics.DrawText(0 - x, 1, message);
                    graphics.Show();
                }
            }
        }
    }
}
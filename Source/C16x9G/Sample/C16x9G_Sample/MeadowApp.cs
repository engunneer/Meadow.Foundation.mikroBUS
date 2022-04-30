using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.mikroBUS;
using System;
using System.Threading;

namespace C16x9G_Sample
{
    // Change F7MicroV2 to F7Micro for V1.x boards
    public class MeadowApp : App<F7MicroV2, MeadowApp>
    {
        public MeadowApp()
        {
            Console.WriteLine("Initializing ...");

            var c16x9G = new C16x9G(Device, Device.Pins.D14, Device.CreateI2cBus(Meadow.Hardware.I2cBusSpeed.Standard));
            c16x9G.IgnoreOutOfBoundsPixels = true;

            c16x9G.Clear();

            var graphics = new MicroGraphics(c16x9G)
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
using Meadow;
using Meadow.Devices;
using Meadow.Foundation.mikroBUS;
using System;


namespace CButtonG_Sample
{
    // Change F7MicroV2 to F7Micro for V1.x boards
    public class MeadowApp : App<F7FeatherV2, MeadowApp>
    {
        public MeadowApp()
        {
            Console.WriteLine("Initializing ...");

            var ledButton = new CButtonG(Device, Device.Pins.D03, Device.Pins.D04);

            ledButton.StartPulse(TimeSpan.FromSeconds(2), 0.75f, 0);
            ledButton.Clicked += (s, e) =>
            {
                ledButton.IsOn = !ledButton.IsOn;
            };


        }
    }
}
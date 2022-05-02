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

            var joystick = new CJoystick(Device, Device.Pins.D14, Device.CreateI2cBus());

            joystick.StartUpdating(TimeSpan.FromMilliseconds(20));

            joystick.Updated += Joystick_Updated;
            joystick.Clicked += Joystick_Clicked;
        }

        private void Joystick_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Center clicked");
        }

        private void Joystick_Updated(object sender, IChangeResult<Meadow.Peripherals.Sensors.Hid.AnalogJoystickPosition> e)
        {
            Console.WriteLine($"{e.New.Horizontal}, {e.New.Vertical}");
        }
    }
}
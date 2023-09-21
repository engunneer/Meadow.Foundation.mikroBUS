# Meadow.Foundation.mikroBUS.Sensors.Hid.CJoystick

**MikroElectronika I2C Joystick MikroBus click board**

The **CJoystick** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
CJoystick joystick;

public MeadowApp()
{
    Console.WriteLine("Initializing ...");

    joystick = new CJoystick(Device.Pins.A02, Device.CreateI2cBus());

    //loop and read digital position 
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Position: {joystick.DigitalPosition}");
        Console.WriteLine($"Pressed: {joystick.State}");

        Thread.Sleep(50);
    }

    //start continous reading
    joystick.StartUpdating(TimeSpan.FromMilliseconds(100));

    //classic events
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

```
## How to Contribute

- **Found a bug?** [Report an issue](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Have a **feature idea or driver request?** [Open a new feature request](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Want to **contribute code?** Fork the [Meadow.Foundation.mikroBus](https://github.com/WildernessLabs/Meadow.Foundation.mikroBus) repository and submit a pull request against the `develop` branch


## Need Help?

If you have questions or need assistance, please join the Wilderness Labs [community on Slack](http://slackinvite.wildernesslabs.co/).

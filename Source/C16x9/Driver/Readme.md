# Meadow.Foundation.mikroBUS.Displays.C16x9

**MikroElectronika I2C 16x9 Click LED board**

The **C16x9** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
C16x9 c16x9;

public MeadowApp()
{
    Console.WriteLine("Initializing ...");

    c16x9 = new C16x9(Device.Pins.D14, Device.CreateI2cBus(Meadow.Hardware.I2cBusSpeed.Standard));
    c16x9.IgnoreOutOfBoundsPixels = true;

    c16x9.Clear();

    var graphics = new MicroGraphics(c16x9)
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

```
## How to Contribute

- **Found a bug?** [Report an issue](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Have a **feature idea or driver request?** [Open a new feature request](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Want to **contribute code?** Fork the [Meadow.Foundation.mikroBus](https://github.com/WildernessLabs/Meadow.Foundation.mikroBus) repository and submit a pull request against the `develop` branch


## Need Help?

If you have questions or need assistance, please join the Wilderness Labs [community on Slack](http://slackinvite.wildernesslabs.co/).

# Meadow.Foundation.mikroBUS.Displays.C8x8

**MikroElectronika SPI 8x8 Click LED board**

The **C8x8** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
C8x8 c8x8;

public MeadowApp()
{
    Console.WriteLine("Initializing ...");

    c8x8 = new C8x8(Device.CreateSpiBus(), Device.Pins.D14);

    var graphics = new MicroGraphics(c8x8)
    {
        IgnoreOutOfBoundsPixels = true,
        Rotation = RotationType._270Degrees
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

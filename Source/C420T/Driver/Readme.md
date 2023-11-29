# Meadow.Foundation.mikroBUS.Sensors.C420T

**MikroElectronika SPI 4-20mA Transmitter click board**

The **C420T** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
private C420T transmitter;

public override Task Initialize()
{
    Console.WriteLine("Initializing ...");

    transmitter = new C420T(Device.CreateSpiBus(), Device.Pins.D00);

    return Task.CompletedTask;
}

public override async Task Run()
{
    var ma = 4;
    var direction = 1;

    while (true)
    {
        ma += direction;
        if (ma == 20)
        {
            direction = -1;
        }
        else if (ma == 4)
        {
            direction = 1;
        }

        var val = new Meadow.Units.Current(ma, Meadow.Units.Current.UnitType.Milliamps);

        Resolver.Log.Info($"Writing: {val.Milliamps:0.00} mA");
        transmitter?.GenerateOutput(val);

        await Task.Delay(1000);
    }
}

```
## How to Contribute

- **Found a bug?** [Report an issue](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Have a **feature idea or driver request?** [Open a new feature request](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Want to **contribute code?** Fork the [Meadow.Foundation.mikroBus](https://github.com/WildernessLabs/Meadow.Foundation.mikroBus) repository and submit a pull request against the `develop` branch


## Need Help?

If you have questions or need assistance, please join the Wilderness Labs [community on Slack](http://slackinvite.wildernesslabs.co/).

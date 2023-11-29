# Meadow.Foundation.mikroBUS.Sensors.MBus.CMBusMaster

**MikroElectronika Serial M-Bus MikroBus click board**

The **CMBusMaster** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
private CMBusMaster master;
private IProjectLabHardware projectLab;
private PadPulsM2 pulseCounter;

public override Task Initialize()
{
    Resolver.Log.Info("Initializing ...");

    projectLab = ProjectLab.Create();

    master = new CMBusMaster(
        projectLab.MikroBus1.CreateSerialPort(
            baudRate: 9600,
            parity: Meadow.Hardware.Parity.Even)
        );

    pulseCounter = new PadPulsM2(master);

    return Task.CompletedTask;
}

public override async Task Run()
{
    pulseCounter.StartMonitoring();

    Resolver.Log.Info($"Ports: {pulseCounter.Ports[0].ID:X8} {pulseCounter.Ports[1].ID:X8}");

    while (true)
    {
        Resolver.Log.Info($"Counts: {pulseCounter.Ports[0].CurrentCount:X8} {pulseCounter.Ports[1].CurrentCount:X8}");
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}

```
## How to Contribute

- **Found a bug?** [Report an issue](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Have a **feature idea or driver request?** [Open a new feature request](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Want to **contribute code?** Fork the [Meadow.Foundation.mikroBus](https://github.com/WildernessLabs/Meadow.Foundation.mikroBus) repository and submit a pull request against the `develop` branch


## Need Help?

If you have questions or need assistance, please join the Wilderness Labs [community on Slack](http://slackinvite.wildernesslabs.co/).

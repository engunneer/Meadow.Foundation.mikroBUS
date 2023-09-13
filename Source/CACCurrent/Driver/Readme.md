# Meadow.Foundation.mikroBUS.Sensors.Buttons.CACCurrent

**MikroElectronika SPI AC Current click board**

The **CButton** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/)

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/)

## Usage

```
private CACCurrent currentClick;
private const bool useSpi = false;

public override Task Initialize()
{
    Console.WriteLine("Initializing ...");

    if (useSpi)
    {
        currentClick = new CACCurrent(
            Device.CreateSpiBus(),
            Device.Pins.D14.CreateDigitalOutputPort());
    }
    else
    {
        currentClick = new CACCurrent(Device.Pins.A00.CreateAnalogInputPort(5));
    }

    currentClick.CurrentUpdated += OnCurrentUpdated;
    currentClick.StartUpdating();

    return Task.CompletedTask;
}

public override async Task Run()
{
    while (true)
    {
        var r = await currentClick.Read();
        Resolver.Log.Info($"Reading: {r.Amps:0.00} A");
        await Task.Delay(1000);
    }
}

private void OnCurrentUpdated(object sender, IChangeResult<Meadow.Units.Current> e)
{
    Resolver.Log.Info($"Current changed from {(e.Old ?? new Meadow.Units.Current(0)).Amps}A to {e.New.Amps}A");
}

```

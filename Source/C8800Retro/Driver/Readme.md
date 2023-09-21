# Meadow.Foundation.mikroBUS.Displays.C8800Retro

**MikroElectronika Altair 8800 I2C led driver and keyscan MikroBus retro click board**

The **C8800Retro** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/).

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/).

To view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/).

## Usage

```csharp
C8800Retro altair;

MicroGraphics graphics;

public override Task Initialize()
{
    Console.WriteLine("Initializing ...");

    altair = new C8800Retro(Device.CreateI2cBus(), Device.Pins.D03);

    var button1B = altair.GetButton(C8800Retro.ButtonColumn._1, C8800Retro.ButtonRow.B);
    button1B.Clicked += Button1B_Clicked;

    graphics = new MicroGraphics(altair)
    {
        CurrentFont = new Font4x8(),
    };

    return base.Initialize();
}

private void Button1B_Clicked(object sender, EventArgs e)
{
    Console.WriteLine("Button 1B clicked");
}

public override async Task Run()
{
    altair.EnableBlink(true, true);

    graphics.Clear();
    graphics.DrawText(0, 0, "MF", Color.White);
    graphics.Show();

    await Task.Delay(6000);

    altair.EnableBlink(false);
}

```
## How to Contribute

- **Found a bug?** [Report an issue](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Have a **feature idea or driver request?** [Open a new feature request](https://github.com/WildernessLabs/Meadow_Issues/issues)
- Want to **contribute code?** Fork the [Meadow.Foundation.mikroBus](https://github.com/WildernessLabs/Meadow.Foundation.mikroBus) repository and submit a pull request against the `develop` branch


## Need Help?

If you have questions or need assistance, please join the Wilderness Labs [community on Slack](http://slackinvite.wildernesslabs.co/).

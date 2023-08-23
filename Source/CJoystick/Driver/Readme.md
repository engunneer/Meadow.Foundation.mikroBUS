# Meadow.Foundation.mikroBUS.Sensors.Hid.CJoystick

**MikroElectronika I2C Joystick MikroBus click board**

The **CJoystick** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/)

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/)

## Usage

```
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

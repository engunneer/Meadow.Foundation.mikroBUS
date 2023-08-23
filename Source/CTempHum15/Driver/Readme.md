# Meadow.Foundation.mikroBUS.Sensors.Atmospheric.CTempHum15

**MikroElectronika I2C Temp and Hum 15 temperature and humidity click board**

The **CTempHum15** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/)

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all of Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/)

## Usage

```
CTempHum15 cTempHum15;

public MeadowApp()
{
    Console.WriteLine("Initializing...");

    cTempHum15 = new CTempHum15(Device.CreateI2cBus());

    var consumer = CTempHum15.CreateObserver(
        handler: result =>
        {
            Console.WriteLine($"Observer: Temp changed by threshold; new temp: {result.New.Temperature?.Celsius:N2}C, old: {result.Old?.Temperature?.Celsius:N2}C");
        },
        filter: result =>
        {
            //c# 8 pattern match syntax. checks for !null and assigns var.
            if (result.Old is { } old)
            {
                return (
                (result.New.Temperature.Value - old.Temperature.Value).Abs().Celsius > 0.5
                &&
                (result.New.Humidity.Value.Percent - old.Humidity.Value.Percent) > 0.05
                );
            }
            return false;
        }
    );
    cTempHum15.Subscribe(consumer);

    cTempHum15.Updated += (sender, result) =>
    {
        Console.WriteLine($"  Temperature: {result.New.Temperature?.Celsius:N2}C");
        Console.WriteLine($"  Relative Humidity: {result.New.Humidity:N2}%");
    };

    ReadConditions().Wait();

    cTempHum15.StartUpdating(TimeSpan.FromSeconds(1));
}

async Task ReadConditions()
{
    var conditions = await cTempHum15.Read();
    Console.WriteLine("Initial Readings:");
    Console.WriteLine($"  Temperature: {conditions.Temperature?.Celsius:N2}C");
    Console.WriteLine($"  Relative Humidity: {conditions.Humidity?.Percent:N2}%");
}

        
```


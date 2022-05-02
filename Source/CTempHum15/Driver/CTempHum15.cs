using Meadow.Foundation.Sensors.Atmospheric;
using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS
{
    /// <summary>
    /// Represents a mikroBUS Temp&Hum 15 Click board
    /// </summary>
    public class CTempHum15 : Sht4x
    {
        public CTempHum15(II2cBus i2cBus) : base(i2cBus, (byte)Addresses.Default)
        {
        }
    }
}
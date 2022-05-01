using Meadow.Foundation.Sensors.Hid;
using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS
{
    /// <summary>
    /// Represents a mikroBUS Joystick Click board
    /// </summary>
    public class CJoystick : N50p105
    {
        public CJoystick(II2cBus i2cBus, byte address = 64) : base(i2cBus, address)
        {
        }
    }
}
using Meadow.Devices;
using Meadow.Foundation.Displays;
using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS
{
    /// <summary>
    /// Represents a mikroBUS 8x8 Y (yellow) Click board
    /// </summary>
    public class C8x8Y : Max7219
    {
        public C8x8Y(ISpiBus spiBus, IDigitalOutputPort chipselectPort) 
            : base(spiBus, chipselectPort, 1, Max7219Mode.Display)
        {
        }

        public C8x8Y(IMeadowDevice device, ISpiBus spiBus, IPin chipSelectPin) 
            : base(device, spiBus, chipSelectPin, 1, Max7219Mode.Display)
        {
        }
    }
}
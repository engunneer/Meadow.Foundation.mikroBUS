using Meadow.Devices;
using Meadow.Foundation.Displays;
using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS
{
    /// <summary>
    /// Represents a mikroBUS 8x8 Click board
    /// </summary>
    public class C8x8 : Max7219
    {
        public C8x8(ISpiBus spiBus, IDigitalOutputPort chipselectPort) 
            : base(spiBus, chipselectPort, 1, Max7219Mode.Display)
        {
        }

        public C8x8(IMeadowDevice device, ISpiBus spiBus, IPin chipSelectPin) 
            : base(device, spiBus, chipSelectPin, 1, Max7219Mode.Display)
        {
        }
    }
}
using Meadow.Devices;
using Meadow.Foundation.Displays;
using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS.Displays
{
    /// <summary>
    /// Represents a mikroBUS 8x8 Click board
    /// </summary>
    public class C8x8 : Max7219
    {
        /// <summary>
        /// Creates a new MikroBus 8x8 object 
        /// </summary>
        /// <param name="spiBus">SPI bus</param>
        /// <param name="chipselectPort">Chip select port</param>
        public C8x8(ISpiBus spiBus, IDigitalOutputPort chipselectPort) 
            : base(spiBus, chipselectPort, 1, Max7219Mode.Display)
        {
        }

        /// <summary>
        /// Creates a new MikroBus 8x8 object 
        /// </summary>
        /// <param name="device">Meadow Device</param>
        /// <param name="spiBus">SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        public C8x8(IMeadowDevice device, ISpiBus spiBus, IPin chipSelectPin) 
            : base(device, spiBus, chipSelectPin, 1, Max7219Mode.Display)
        {
        }
    }
}
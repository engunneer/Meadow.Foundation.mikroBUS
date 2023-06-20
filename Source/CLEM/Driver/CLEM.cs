using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS.Sensors.Buttons
{
    /// <summary>
    /// Represents a mikroBUS AC current sensing LEM Click board
    /// </summary>
    public class CLEM
    {
        /// <summary>
        /// Creates a new CLEM object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        public CLEM(ISpiBus spiBus, IPin chipSelectPin)
        {

        }

        /// <summary>
        /// Creates a new CLEM object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPort">Chip select port</param>
        public CLEM(ISpiBus spiBus, IDigitalInputPort chipSelectPort)
        {

        }
    }
}
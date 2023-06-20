using Meadow.Hardware;

namespace Meadow.Foundation.mikroBUS.Sensors
{
    /// <summary>
    /// Represents a mikroBUS current sensing AC Current Click board
    /// </summary>
    public class CACCurrent
    {
        /// <summary>
        /// Creates a new CACCurrent object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        public CACCurrent(ISpiBus spiBus, IPin chipSelectPin)
        {

        }

        /// <summary>
        /// Creates a new CACCurrent object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPort">Chip select port</param>
        public CACCurrent(ISpiBus spiBus, IDigitalInputPort chipSelectPort)
        {

        }
    }
}
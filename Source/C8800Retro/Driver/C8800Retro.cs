using Meadow.Foundation.ICs.IOExpanders;
using Meadow.Foundation.Leds;
using Meadow.Hardware;
using System;

namespace Meadow.Foundation.mikroBUS.Sensors.Buttons
{
    /// <summary>
    /// Represents a mikroBUS Altair 8800 Retro click board
    /// </summary>
    public class C8800Retro : As1115
    {
        /// <summary>
        /// Creates an Altair 8800 retro click board object
        /// </summary>
        /// <param name="device">The Meadow device</param>
        /// <param name="i2cBus">The I2C bus</param>
        /// <param name="buttonInterruptPin">The interrupt pin</param>
        /// <param name="address">The I2C address</param>
        public C8800Retro(IMeadowDevice device, II2cBus i2cBus, IPin buttonInterruptPin, byte address = 0) 
            : base(device, i2cBus, buttonInterruptPin, address)
        {
        }
    }
}
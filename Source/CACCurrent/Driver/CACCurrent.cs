using Meadow.Foundation.ICs.IOExpanders;
using Meadow.Hardware;
using Meadow.Units;
using System;
using System.Threading.Tasks;

namespace Meadow.Foundation.mikroBUS.Sensors
{
    /// <summary>
    /// Represents a mikroBUS current sensing AC Current Click board
    /// </summary>
    public class CACCurrent : SamplingSensorBase<Current>
    {
        /// <summary>
        /// Raised when the value of the reading changes
        /// </summary>
        public event EventHandler<IChangeResult<Current>> CurrentUpdated = delegate { };

        ///<Summary>
        /// AnalogInputPort connected to the current sensor
        ///</Summary>
        protected IAnalogInputPort AnalogInputPort { get; set; }

        /// <summary>
        /// Current voltage
        /// </summary>
        public Current? Current { get; protected set; }

        /// <summary>
        /// Reference voltage (2.048V)
        /// </summary>
        public Voltage ReferenceVoltage { get; protected set; } = new Voltage(2.048, Voltage.UnitType.Volts);

        readonly Mcp3201 mcp3201;

        /// <summary>
        /// Creates a new CACCurrent object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        /// <param name="sampleCount">How many samples to take during a given reading (default is 5)</param>
        /// <param name="sampleInterval">The time between sample readings (default is 5 seconds)</param>
        public CACCurrent(ISpiBus spiBus,
            IPin chipSelectPin,
            int sampleCount = 5,
            TimeSpan? sampleInterval = null)
        {
            mcp3201 = new Mcp3201(spiBus, chipSelectPin);
            Initialize(sampleCount, sampleInterval);
        }

        /// <summary>
        /// Creates a new CACCurrent object
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPort">Chip select port</param>
        /// <param name="sampleCount">How many samples to take during a given reading (default is 5)</param>
        /// <param name="sampleInterval">The time between sample readings (default is 5 seconds)</param>
        public CACCurrent(ISpiBus spiBus,
            IDigitalOutputPort chipSelectPort,
            int sampleCount = 5,
            TimeSpan? sampleInterval = null)
        {
            mcp3201 = new Mcp3201(spiBus, chipSelectPort);
            Initialize(sampleCount, sampleInterval);
        }

        void Initialize(int sampleCount = 5, TimeSpan? sampleInterval = null)
        {
            AnalogInputPort = mcp3201.CreateAnalogInputPort(sampleCount, sampleInterval ?? TimeSpan.FromSeconds(5), ReferenceVoltage);

            AnalogInputPort.Subscribe
            (
                IAnalogInputPort.CreateObserver(
                    result =>
                    {
                        ChangeResult<Current> changeResult = new ChangeResult<Current>()
                        {
                            New = VoltageToCurrent(result.New),
                            Old = Current
                        };
                        Current = changeResult.New;
                        RaiseEventsAndNotify(changeResult);
                    }
                )
            );
        }

        /// <summary>
        /// Convenience method to get the current temperature. For frequent reads, use
        /// StartSampling() and StopSampling() in conjunction with the SampleBuffer.
        /// </summary>
        /// <returns>The temperature averages of the given sample count</returns>
        protected override async Task<Current> ReadSensor()
        {
            var voltage = await AnalogInputPort.Read();
            var newCurrent = VoltageToCurrent(voltage);
            Current = newCurrent;
            return newCurrent;
        }

        /// <summary>
        /// Starts continuously sampling the sensor
        /// </summary>
        public override void StartUpdating(TimeSpan? updateInterval)
        {
            lock (samplingLock)
            {
                if (IsSampling) { return; }
                IsSampling = true;
                AnalogInputPort.StartUpdating(updateInterval);
            }
        }

        /// <summary>
        /// Stops sampling the current
        /// </summary>
        public override void StopUpdating()
        {
            lock (samplingLock)
            {
                if (!IsSampling) { return; }
                IsSampling = false;
                AnalogInputPort.StopUpdating();
            }
        }

        /// <summary>
        /// Method to notify subscribers to CurrentUpdated event handler
        /// </summary>
        /// <param name="changeResult"></param>
        protected override void RaiseEventsAndNotify(IChangeResult<Current> changeResult)
        {
            CurrentUpdated?.Invoke(this, changeResult);
            base.RaiseEventsAndNotify(changeResult);
        }

        Current VoltageToCurrent(Voltage voltage)
        {
            return new Current(voltage.Volts * 30.0 / 1.8, Units.Current.UnitType.Amps);
        }
    }
}
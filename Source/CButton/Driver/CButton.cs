using Meadow.Devices;
using Meadow.Foundation.Leds;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Hardware;
using Meadow.Peripherals.Leds;
using System;

namespace Meadow.Foundation.mikroBUS.Sensors.Buttons
{
    /// <summary>
    /// Represents a mikroBUS Button G,R,Y Click board
    /// </summary>
    public class CButton : PushButton, IPwmLed
    {
        /// <summary>
        /// Gets or sets a value indicating whether the LED is on.
        /// </summary>
        /// <value><c>true</c> if is on; otherwise, <c>false</c>.</value>
        public bool IsOn 
        {
            get => pwmLed.IsOn;
            set => pwmLed.IsOn = value;
        }

        /// <summary>
        /// Gets the brightness of the LED, controlled by a PWM signal
        /// </summary>
        public float Brightness
        {
            get => pwmLed.Brightness;
            set => pwmLed.Brightness = value;
        }

        readonly IPwmLed pwmLed;

        /// <summary>
        /// Creates a new CButton object
        /// </summary>
        /// <param name="device">Meadow device</param>
        /// <param name="ledPin">Led pin</param>
        /// <param name="buttonPin">Button pin</param>
        public CButton(IMeadowDevice device, IPin ledPin, IPin buttonPin) 
            : base(device, buttonPin, ResistorMode.InternalPullUp)
        {
            pwmLed = new PwmLed(device, ledPin, new Units.Voltage(TypicalForwardVoltage.Green));
        }

        /// <summary>
        /// Creates a new CButton object
        /// </summary>
        /// <param name="ledPwmPort">Led PWM port</param>
        /// <param name="buttonInterruptPort">Button interrupt port</param>
        public CButton(IPwmPort ledPwmPort, IDigitalInputPort buttonInterruptPort)
            : base(buttonInterruptPort)
        {
            pwmLed = new PwmLed(ledPwmPort, new Units.Voltage(TypicalForwardVoltage.Green));
        }

        /// <summary>
        /// Start the Blink animation which sets the brightness of the LED alternating between a low and high brightness setting, using the durations provided.
        /// </summary>
        public void StartBlink(TimeSpan onDuration, TimeSpan offDuration, float highBrightness = 1f, float lowBrightness = 0f)
        {
            pwmLed?.StartBlink(onDuration, offDuration, highBrightness, lowBrightness);
        }

        /// <summary>
        /// Start the Pulse animation which gradually alternates the brightness of the LED between a low and high brightness setting, using the durations provided.
        /// </summary>
        public void StartPulse(TimeSpan pulseDuration, float highBrightness, float lowBrightness = 0.15F)
        {
            pwmLed?.StartPulse(pulseDuration, highBrightness, lowBrightness);
        }

        /// <summary>
        /// Stops any running animations
        /// </summary>
        public void Stop()
        {
            pwmLed?.Stop();
        }
    }
}
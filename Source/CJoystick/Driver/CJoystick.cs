using System;
using Meadow.Devices;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Foundation.Sensors.Hid;
using Meadow.Hardware;
using Meadow.Peripherals.Sensors.Buttons;

namespace Meadow.Foundation.mikroBUS
{
    /// <summary>
    /// Represents a mikroBUS Joystick Click board
    /// </summary>
    public class CJoystick : As5013, IButton
    {
        readonly PushButton button;

        public CJoystick(IMeadowDevice device, IPin tstPin,
            II2cBus i2cBus, byte address = 64) : base(i2cBus, address)
        {
            button = new PushButton(device, tstPin);

            button.PressStarted += (s, e) => PressStarted(s, e);
            button.PressEnded += (s, e) => PressEnded(s, e);
            button.Clicked += (s, e) => Clicked(s, e);
            button.LongClicked += (s, e) => LongClicked(s, e);
        }

        public TimeSpan LongClickedThreshold
        {
            get => button.LongClickedThreshold;
            set => button.LongClickedThreshold = value;
        }

        public bool State => button.State;

        public event EventHandler PressStarted = delegate { };
        public event EventHandler PressEnded = delegate { };
        public event EventHandler Clicked = delegate { };
        public event EventHandler LongClicked = delegate { };
    }
}
using Meadow;
using Meadow.Devices;
using Meadow.Foundation.mikroBUS.Sensors;
using System;
using System.Threading.Tasks;

namespace CACCurrent_Sample
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    public class MeadowApp : App<F7CoreComputeV2>
    {
        //<!=SNIP=>

        private C420T transmitter;
        private C420R receiver;

        private IProjectLabHardware projectLab;

        public override Task Initialize()
        {
            Console.WriteLine("Initializing ...");

            projectLab = ProjectLab.Create();

            transmitter = new C420T(projectLab.MikroBus2.SpiBus, projectLab.MikroBus2.Pins.CS);
            receiver = new C420R(projectLab.MikroBus1.SpiBus, projectLab.MikroBus1.Pins.CS);

            return Task.CompletedTask;
        }

        public override async Task Run()
        {
            var ma = 4;
            var direction = 1;

            while (true)
            {
                ma += direction;
                if (ma == 20)
                {
                    direction = -1;
                }
                else if (ma == 4)
                {
                    direction = 1;
                }

                var val = new Meadow.Units.Current(ma, Meadow.Units.Current.UnitType.Milliamps);

                Resolver.Log.Info($"Writing: {val.Milliamps:0.00} mA");
                transmitter?.GenerateOutput(val);

                var read = await receiver.Read();
                Resolver.Log.Info($"Reading: {read.Milliamps:0.00} mA");

                await Task.Delay(1000);
            }
        }

        //<!=SNOP=>
    }
}
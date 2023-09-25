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

        private IProjectLabHardware projectLab;
        private C420R receiver;

        public override Task Initialize()
        {
            Console.WriteLine("Initializing ...");

            projectLab = ProjectLab.Create();

            receiver = new C420R(projectLab.MikroBus1.SpiBus, projectLab.MikroBus1.Pins.CS);

            return Task.CompletedTask;
        }

        public override async Task Run()
        {
            while (true)
            {
                var r = await receiver.Read();
                Resolver.Log.Info($"Reading: {r.Milliamps:0.00} mA");
                await Task.Delay(100);
            }
        }

        private void OnCurrentUpdated(object sender, IChangeResult<Meadow.Units.Current> e)
        {
            Resolver.Log.Info($"Current changed from {(e.Old ?? new Meadow.Units.Current(0)).Amps}A to {e.New.Amps}A");
        }

        //<!=SNOP=>
    }
}
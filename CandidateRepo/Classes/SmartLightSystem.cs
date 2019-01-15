using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;

namespace CandidateRepo.Classes
{
    [Name("SmartLightSystem")]
    class SmartLightSystem : Device, ISmartLightSystem
    {

        public SmartLightSystem(string name, IDeviceManager manager) : base(name, manager)
        {
            State = "Lights off";
        }

        [Name("GetCurrentState")]
        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }

        [Name("LightsOn")]
        public void LightsOn()
        {
            Console.WriteLine($"On device {Name} Lights became turned on");
        }

        [Name("LightsOff")]
        public void LightsOff()
        {
            Console.WriteLine($"On device {Name} Lights became turned off");
        }
    }
}

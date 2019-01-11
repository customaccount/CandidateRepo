using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Classes
{
    [Name("SmartLightSystem")]
    class SmartLightSystem : Device, ISmartLightSystem
    {

        public SmartLightSystem(string name) : base(name)
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

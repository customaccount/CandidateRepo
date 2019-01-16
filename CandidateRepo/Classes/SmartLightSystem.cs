using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class SmartLightSystem : Device, ISmartLightSystem
    {

        public SmartLightSystem(string name, IDeviceManager manager) : base(name, manager)
        {
            State = "Lights off";
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }

        public void LightsOn()
        {
            Console.WriteLine($"On device {Name} Lights became turned on");
        }

        public void LightsOff()
        {
            Console.WriteLine($"On device {Name} Lights became turned off");
        }

        public override List<Command> GetCommands(Visitor visitor)
        {
            return visitor.GetCommandsForLightSystem(this);
        }
    }
}

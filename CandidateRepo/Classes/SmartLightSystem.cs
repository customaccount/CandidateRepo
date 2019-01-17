using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes.Commands;
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

        public override List<Command> GetCommands()
        {
            var commands = new List<Command>();
            commands.AddRange(new List<Command>()
                {
                    new GetCurrentStateCommand(this),
                    new RebootCommand(this),
                    new UpdateParamsCommand(this),
                    new RegisterDeviceCommand(this),
                    new LightsOnCommand(this),
                    new LightsOffCommand(this),
                });

            return commands;
        }
    }
}

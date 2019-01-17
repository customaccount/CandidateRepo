using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes.Commands;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Humidifier : Device, IHumidifier
    {
        public Humidifier(string name, IDeviceManager manager) : base(name, manager) { State = "Off"; }

        public void Evaporate()
        {
            Console.WriteLine($"Humidifier {Name} is evaporating");
        }

        public override void Reboot()
        {
            Console.WriteLine($"Humidifier {Name} rebooted...");
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
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
                        new EvaporateCommand(this)
                    });

            return commands;
        }
    }
}

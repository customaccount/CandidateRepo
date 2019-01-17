using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes.Commands;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class TermControlSystem : Device, ITermControlSystem
    {

        public TermControlSystem(string name, IDeviceManager manager) : base(name, manager)
        {
            State = "normal";
            Params = "23C";
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}, Goal Temperature = {Params}");
        }

        public void FastFreeze()
        {
            Console.WriteLine($"FastFreeze started on device {Name}");
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
                        new FastFreezeCommand(this)
                    });

            return commands;
        }
    }
}

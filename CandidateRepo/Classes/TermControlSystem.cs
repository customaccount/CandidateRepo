using CandidateRepo.AbstractClasses;
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

        public override List<Command> GetCommands(Visitor visitor)
        {
            return visitor.GetCommandsForTermControlSystem(this);
        }
    }
}

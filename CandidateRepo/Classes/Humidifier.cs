using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Humidifier : Device, IHumidifier
    {
        public Humidifier(string name, IDeviceManager manager) : base(name, manager) { State = "Off"; }

        public override List<Command> GetCommands(Visitor visitor)
        {
            return visitor.GetCommandsForHumidifier(this);
        }

        public void Evaporate()
        {
            Console.WriteLine($"Humidifier {Name} is evaporating");
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }
    }
}

using CandidateRepo.AbstractClasses;
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
    }
}

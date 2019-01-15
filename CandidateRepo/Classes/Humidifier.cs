using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;

namespace CandidateRepo.Classes
{
    [Name("Humidifier")]
    class Humidifier : Device, IHumidifier
    {
        public Humidifier(string name, IDeviceManager manager) : base(name, manager) { State = "Off"; }

        [Name("Evaporate")]
        public void Evaporate()
        {
            Console.WriteLine($"Humidifier {Name} is evaporating");
        }

        [Name("GetCurrentState")]
        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }
    }
}

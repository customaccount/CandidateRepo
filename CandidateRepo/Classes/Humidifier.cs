using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Classes
{
    [Name("Humidifier")]
    class Humidifier : Device, IHumidifier
    {
        public Humidifier(string name) : base(name) { State = "Off"; }

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

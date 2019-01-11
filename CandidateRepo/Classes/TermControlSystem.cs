using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Classes
{
    [Name("TermControlSystem")]
    class TermControlSystem : Device, ITermControlSystem
    {

        public TermControlSystem(string name) : base(name)
        {
            State = "normal";
            Params = "23C";
        }


        [Name("GetCurrentState")]
        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}, Goal Temperature = {Params}");
        }

        [Name("FastFreeze")]
        public void FastFreeze()
        {
            Console.WriteLine($"FastFreeze started on device {Name}");
        }


    }
}

using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Dispetcher : Visitor
    {
        public override List<Command> GetCommands(IBaseDevice device)
        {
            return device.GetCommands();
        }
    }
}

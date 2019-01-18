using System.Collections.Generic;
using CandidateRepo.Interfaces;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Visitor
    {
        public abstract List<Command> GetCommands(IBaseDevice device);
    }

    
}

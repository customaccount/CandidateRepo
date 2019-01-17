using System.Collections.Generic;
using CandidateRepo.Classes;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Visitor
    {
        public abstract List<Command> GetCommands();
    }

    
}

using System.Collections.Generic;
using CandidateRepo.Classes;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Visitor
    {
        public abstract List<Command> GetCommandsForHumidifier(Humidifier device);
        public abstract List<Command> GetCommandsForLightSystem(SmartLightSystem device);
        public abstract List<Command> GetCommandsForTermControlSystem(TermControlSystem device);
    }

    
}

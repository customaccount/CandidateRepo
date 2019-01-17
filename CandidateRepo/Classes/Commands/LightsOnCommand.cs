using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class LightsOnCommand : Command
    {
        ISmartLightSystem receiver;
        public LightsOnCommand(ISmartLightSystem device)
        {
            receiver = device;
            Name = "LightsOn";
        }
        public override void Execute()
        {
            receiver.LightsOn();
        }
    }
}

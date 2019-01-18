using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class LightsOffCommand : Command
    {
        ISmartLightSystem receiver;
        public LightsOffCommand(ISmartLightSystem device)
        {
            receiver = device;
            Name = "LightsOff";
        }
        public override void Execute()
        {
            receiver.LightsOff();
        }
    }
}

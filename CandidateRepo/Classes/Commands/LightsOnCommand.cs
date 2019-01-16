using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class LightsOnCommand : Command
    {
        SmartLightSystem receiver;
        public LightsOnCommand(SmartLightSystem device)
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

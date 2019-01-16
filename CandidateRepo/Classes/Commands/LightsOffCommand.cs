using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class LightsOffCommand : Command
    {
        SmartLightSystem receiver;
        public LightsOffCommand(SmartLightSystem device)
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

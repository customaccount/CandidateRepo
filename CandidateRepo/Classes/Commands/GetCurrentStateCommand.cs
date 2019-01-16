using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class GetCurrentStateCommand : Command
    {

        Device receiver;
        public GetCurrentStateCommand(Device device)
        {
            receiver = device;
            Name = "GetCurrentState";
        }
        public override void Execute()
        {
            receiver.GetCurrentState();
        }

    }
}

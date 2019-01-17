using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class GetCurrentStateCommand : Command
    {

        IBaseDevice receiver;
        public GetCurrentStateCommand(IBaseDevice device)
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

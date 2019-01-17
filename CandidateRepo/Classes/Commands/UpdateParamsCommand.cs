using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class UpdateParamsCommand : Command
    {
        IBaseDevice receiver;
        public UpdateParamsCommand(IBaseDevice device)
        {
            receiver = device;
            Name = "UpdateParams";
        }
        public override void Execute()
        {
            receiver.UpdateParams();
        }
    }

}

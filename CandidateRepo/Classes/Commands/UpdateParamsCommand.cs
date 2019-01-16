using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class UpdateParamsCommand : Command
    {
        Device receiver;
        public UpdateParamsCommand(Device device)
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

using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class RebootCommand : Command
    {
        IBaseDevice receiver;
        public RebootCommand(IBaseDevice device)
        {
            receiver = device;
            Name = "Reboot";
        }
        public override void Execute()
        {
            receiver.Reboot();
        }
    }
}

using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class RebootCommand : Command
    {
        Device receiver;
        public RebootCommand(Device device)
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

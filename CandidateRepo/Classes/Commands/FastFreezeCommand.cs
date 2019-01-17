using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class FastFreezeCommand : Command
    {
        ITermControlSystem receiver;
        public FastFreezeCommand(ITermControlSystem device)
        {
            receiver = device;
            Name = "FastFreeze";
        }
        public override void Execute()
        {
            receiver.FastFreeze();
        }
    }
}

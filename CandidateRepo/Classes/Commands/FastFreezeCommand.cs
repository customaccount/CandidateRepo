using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class FastFreezeCommand : Command
    {
        TermControlSystem receiver;
        public FastFreezeCommand(TermControlSystem device)
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

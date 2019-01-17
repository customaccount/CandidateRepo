using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class EvaporateCommand : Command
    {
        IHumidifier receiver;
        public EvaporateCommand(IHumidifier device)
        {
            receiver = device;
            Name = "Evaporate";
        }
        public override void Execute()
        {
            receiver.Evaporate();
        }
    }
}

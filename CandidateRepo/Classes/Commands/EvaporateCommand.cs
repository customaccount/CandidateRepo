using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class EvaporateCommand : Command
    {
        Humidifier receiver;
        public EvaporateCommand(Humidifier device)
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

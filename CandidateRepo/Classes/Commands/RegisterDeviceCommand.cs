using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;

namespace CandidateRepo.Classes.Commands
{
    class RegisterDeviceCommand : Command
    {
        IBaseDevice receiver;
        public RegisterDeviceCommand(IBaseDevice device)
        {
            receiver = device;
            Name = "RegisterDevice";
        }
        public override void Execute()
        {
            receiver.RegisterDevice();
        }
    }
}

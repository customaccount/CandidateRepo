using CandidateRepo.AbstractClasses;

namespace CandidateRepo.Classes.Commands
{
    class RegisterDeviceCommand : Command
    {
        Device receiver;
        public RegisterDeviceCommand(Device device)
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

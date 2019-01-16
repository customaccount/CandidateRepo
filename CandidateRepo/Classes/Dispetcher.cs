using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes.Commands;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Dispetcher : Visitor
    {
        List<Command> commands;
        Device _currentDevice;

        public Dispetcher(Device device)
        {
            _currentDevice = device;
            commands = new List<Command>();
        }

        public override List<Command> GetCommandsForHumidifier(Humidifier device)
        {
            commands.AddRange(new List<Command>()
            {
                new GetCurrentStateCommand(device),
                new RebootCommand(device),
                new UpdateParamsCommand(device),
                new RegisterDeviceCommand(device),
                new EvaporateCommand(device)
            });

            return commands;
        }

        public override List<Command> GetCommandsForLightSystem(SmartLightSystem device)
        {
            commands.AddRange(new List<Command>()
            {
                new GetCurrentStateCommand(device),
                new RebootCommand(device),
                new UpdateParamsCommand(device),
                new RegisterDeviceCommand(device),
                new LightsOnCommand(device),
                new LightsOffCommand(device),
            });

            return commands;
        }

        public override List<Command> GetCommandsForTermControlSystem(TermControlSystem device)
        {
            commands.AddRange(new List<Command>()
            {
                new GetCurrentStateCommand(device),
                new RebootCommand(device),
                new UpdateParamsCommand(device),
                new RegisterDeviceCommand(device),
                new FastFreezeCommand(device)
            });

            return commands;
        }
    }
}

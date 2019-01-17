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


        public override List<Command> GetCommands()
        {
            if (_currentDevice.GetType() == typeof(Humidifier))
            {
                commands.AddRange(new List<Command>()
                    {
                        new GetCurrentStateCommand(_currentDevice),
                        new RebootCommand(_currentDevice),
                        new UpdateParamsCommand(_currentDevice),
                        new RegisterDeviceCommand(_currentDevice),
                        new EvaporateCommand(_currentDevice as Humidifier)
                    });

                return commands;
            }

            if (_currentDevice.GetType() == typeof(SmartLightSystem))
            {
                commands.AddRange(new List<Command>()
                {
                    new GetCurrentStateCommand(_currentDevice),
                    new RebootCommand(_currentDevice),
                    new UpdateParamsCommand(_currentDevice),
                    new RegisterDeviceCommand(_currentDevice),
                    new LightsOnCommand(_currentDevice as SmartLightSystem),
                    new LightsOffCommand(_currentDevice as SmartLightSystem),
                });

                return commands;
            }

            if (_currentDevice.GetType() == typeof(TermControlSystem))
            {
                commands.AddRange(new List<Command>()
                    {
                        new GetCurrentStateCommand(_currentDevice),
                        new RebootCommand(_currentDevice),
                        new UpdateParamsCommand(_currentDevice),
                        new RegisterDeviceCommand(_currentDevice),
                        new FastFreezeCommand(_currentDevice as TermControlSystem)
                    });

                return commands;
            }

            return commands;
        }

    }
}

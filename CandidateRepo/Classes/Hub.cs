using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Hub : Device, IHub
    {
        List<IBaseDevice> _registeredDevices;

        public Hub(string name, IDeviceManager manager) : base(name, manager)
        {
            _registeredDevices = new List<IBaseDevice>();
            State = "normal";
        }

        public void RegisterDevice(IBaseDevice device)
        {
            if (this.Equals(device))
            {
                Console.WriteLine("You can't register device on itsself!");
            }
            else
            {
                if (_registeredDevices.Contains(device)) Console.WriteLine($"Device {device.Name} was already registered.");
                else
                {
                    _registeredDevices.Add(device);
                    Console.WriteLine($"Device {device.Name} registered on hub {Name}");
                }
            }
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
            if (_registeredDevices.Count > 0)
            {
                Console.WriteLine($"Connected {_registeredDevices.Count} devices");
                foreach (var item in _registeredDevices)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public IEnumerable<IBaseDevice> GetRegisteredDevices()
        {
            return _registeredDevices;
        }

        public override List<Command> GetCommands(Visitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}

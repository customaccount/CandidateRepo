using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Classes
{
    public class Hub : Device, IHub
    {
        List<Device> registeredDevices;

        public Hub(string name) : base(name)
        {
            registeredDevices = new List<Device>();
            State = "normal";
        }

        public void RegisterDevice(Device device)
        {
            if (this.Equals(device))
            {
                Console.WriteLine("You can't register device on itsself!");
            }
            else
            {
                if (registeredDevices.Contains(device)) Console.WriteLine($"Device {device.Name} was already registered.");
                else
                {
                    registeredDevices.Add(device);
                    Console.WriteLine($"Device {device.Name} registered on hub {Name}");
                }
            }
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
            if (registeredDevices.Count > 0)
            {
                Console.WriteLine($"Connected {registeredDevices.Count} devices");
                foreach (var item in registeredDevices)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public List<Device> GetRegisteredDevices()
        {
            return registeredDevices;
        }
    }
}

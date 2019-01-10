using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo
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

    [Name("TermControlSystem")]
    class TermControlSystem : Device, ITermControlSystem
    {

        public TermControlSystem(string name) : base(name)
        {
            State = "normal";
            Params = "23C";
        }

        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}, Goal Temperature = {Params}");
        }

        [Name("FastFreeze")]
        public void FastFreeze()
        {
            Console.WriteLine($"FastFreeze started on device {Name}");
        }


    }

    [Name("SmartLightSystem")]
    class SmartLightSystem : Device, ISmartLightSystem
    {

        public SmartLightSystem(string name) : base(name)
        {
            State = "Lights off";
        }

        [Name("GetCurrentState")]
        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }

        [Name("LightsOn")]
        public void LightsOn()
        {
            Console.WriteLine($"On device {Name} Lights became turned on");
        }

        [Name("LightsOff")]
        public void LightsOff()
        {
            Console.WriteLine($"On device {Name} Lights became turned off");
        }
    }


    [Name("Humidifier")]
    class Humidifier : Device, IHumidifier
    {
        public Humidifier(string name) : base(name) { State = "Off"; }

        [Name("Evaporate")]
        public void Evaporate()
        {
            Console.WriteLine($"Humidifier {Name} is evaporating");
        }

        [Name("GetCurrentState")]
        public override void GetCurrentState()
        {
            Console.WriteLine($"Currently state: {State}");
        }
    }
}

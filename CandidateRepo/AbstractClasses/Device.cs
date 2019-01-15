using CandidateRepo.Classes;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Device : IBaseDevice
    {
        public string Name { get; }
        IDeviceManager _deviceManager;
        protected string State { get; set; }
        protected string Params { get; set; }

        [Name("Reboot")]
        public void Reboot()
        {
            Console.WriteLine($"Device {Name} rebooted...");
        }

        [Name("GetCurrentState")]
        public abstract void GetCurrentState();

        [Name("RegisterDevice")]
        public virtual void RegisterDevice()
        {
            bool complete = false;
            while (!complete)
            {
                Console.WriteLine("Please choose the hub, you want to register it");

                var hubs = _deviceManager.GetDevices(typeof(IHub)).ToList();
                for (int j = 1; j <= hubs.Count; j++)
                {
                    Console.WriteLine($"{j}. {(hubs[j - 1] as IBaseDevice).Name}");
                }
                string hubnumber = Console.ReadLine();
                if ((Int32.TryParse(hubnumber, out int hubres)) && (hubres <= hubs.Count) && (hubres > 0))
                {
                    var hub = hubs[hubres - 1];
                    (hub as IHub).RegisterDevice(this as IBaseDevice);
                    complete = true;
                }
            }
        }

        [Name("UpdateParams")]
        public virtual void UpdateParams()
        {
            Console.WriteLine($"Current param is {Params}.\nPlease input new param.");
            Params = Console.ReadLine();
            Console.WriteLine($"Parameters of device {Name} updated to {Params}");
        }

        public Device(string name, IDeviceManager manager)
        {
            Name = name;
            _deviceManager = manager;
        }

        public Dictionary<string,MethodInfo> GetMethods()
        {
            Type type = this.GetType();
            var methods = type.GetMethods().Where(m => (m.CustomAttributes.ToList().Count > 0)).ToList();
            Dictionary<string, MethodInfo> result = new Dictionary<string, MethodInfo>();
            foreach (var item in methods)
            {
                var ca = item.CustomAttributes.ToList();
                foreach (var attr in ca)
                {
                    if (attr.AttributeType.FullName == "CandidateRepo.Classes.NameAttribute")
                    {
                        string methodName = attr.ConstructorArguments[0].Value.ToString();
                        result.Add(methodName, item);
                    }
                }
            }

            return result;
        }

        public int ExecuteMethod(MethodInfo method)
        {
            method.Invoke(this, null);
            return 0;
        }
    }
}

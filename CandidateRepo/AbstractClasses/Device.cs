using CandidateRepo.Classes;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Device : IBaseDevice
    {
        public string Name { get; }
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

                var hubs = ConsoleInterface.GetDevicesList().Where(d => (d is IHub)).ToList();
                for (int j = 1; j <= hubs.Count; j++)
                {
                    Console.WriteLine($"{j}. {hubs[j - 1].Name}");
                }
                string hubnomber = Console.ReadLine();
                if ((Int32.TryParse(hubnomber, out int hubres)) && (hubres <= hubs.Count) && (hubres > 0))
                {
                    var hub = hubs[hubres - 1];
                    (hub as Hub).RegisterDevice(this as Device);
                    complete = true;
                    //Console.ReadKey();
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

        public Device(string name)
        {
            Name = name;
        }

        public List<MethodInfo> GetMethods()
        {
            Type type = this.GetType();
            var methods = type.GetMethods().Where(m => (m.CustomAttributes.ToList().Count > 0)).ToList();
            methods = methods.Where(m => m.CustomAttributes.ToList()[0].ConstructorArguments.ToList().Count > 0).ToList();
            return methods;
        }

        public int ExecuteMethod(string methodName)
        {
            Type type = this.GetType();
            var methods = type.GetMethods().Where(m => (m.CustomAttributes.ToList().Count > 0)).ToList();
            methods = methods.Where(m => m.CustomAttributes.ToList()[0].ConstructorArguments.ToList().Count > 0).ToList();
            var method = methods.Where(m => m.CustomAttributes.ToList()[0].ConstructorArguments.ToList()[0].Value.ToString() == methodName).FirstOrDefault();
            method.Invoke(this, null);
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo
{
    static class ConsoleInterface
    {
        static List<Device> devices = new List<Device>();
        public static void Initialize()
        {
            var h1 = new Hub("Hub1");
            var h2 = new Hub("Hub2");
            devices.Add(h1);
            devices.Add(h2);
            var t1 = new TermControlSystem("TermControlSystem in the room");
            var t2 = new TermControlSystem("TermControlSystem in the kitchen");
            var l1 = new SmartLightSystem("Ligths at hall");
            var l2 = new SmartLightSystem("Ligths in the room");
            var l3 = new SmartLightSystem("Ligths in the kitchen");
            var hum1 = new Humidifier("Humidifier in the room");
            var hum2 = new Humidifier("Humidifier in the servers room");
            devices.Add(t1);
            devices.Add(t2);
            h1.RegisterDevice(t1);
            h1.RegisterDevice(t2);
            h1.RegisterDevice(l1);
            h1.RegisterDevice(l2);
            h1.RegisterDevice(l3);
            h1.RegisterDevice(hum1);
            h2.RegisterDevice(hum2);
        }

        public static List<Device> GetDevicesList()
        {
            return devices;
        }

        public static void StartInterface()
        {
            //devices = Program.devices;
            int result = 0;
            while (true)
            {
                result = StartOptions();
                if (result == 1) break;
            }
        }

        static int StartOptions()
        {
            Console.Clear();
            Console.WriteLine("Devices List:");
            int i = 1;
            foreach (var item in devices.Where(d => (d is IHub)))
            {
                Console.WriteLine($"{i}. {item.Name}");
                i++;
            }
            Console.WriteLine("To watch devices, registered on hub please type number of it.");
            Console.WriteLine("To create a new device type \"c\"");
            Console.WriteLine("To quite application please type \"q\"");
            string input = Console.ReadLine();
            if (input.ToLower() == "c") CreateNewDevice();
            if ((Int32.TryParse(input, out int result)) && (result <= devices.Where(d => (d is IHub)).ToList().Count) && (result > 0))
            {
                var hub = devices.Where(d => (d is IHub)).ToList()[result - 1] as IHub;
                while (true)
                {
                    result = ShowHubDevices(hub);
                    if (result == 1) return 0;
                }
            }

            if (input.ToLower() == "q") return 1;
            return 0;
        }

        static int ShowHubDevices(IHub hub)
        {
            List<Device> hubDevices = hub.GetRegisteredDevices();
            int i = 1;
            Console.Clear();
            Console.WriteLine($"Registered devices on {(hub as Device).Name} :");
            foreach (var item in hubDevices)
            {
                Console.WriteLine($"{i}. {item.Name}");
                i++;
            }
            Console.WriteLine("Please type number of device to watch options, or type \"b\" to go back");
            string input = Console.ReadLine();
            if (input.ToLower() == "b") return 1;
            if ((Int32.TryParse(input, out int result)) && (result <= hubDevices.Count) && (result > 0))
            {
                var device = hubDevices[result - 1];
                int showMethodsresult = 0;
                while (showMethodsresult == 0)
                {
                    var methods = device.GetMethods();
                    showMethodsresult = ShowMethods(methods, device);
                }
            }
            return 0;
        }

        static int ShowMethods(List<MethodInfo> methodInfos, Device device)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Device {device.Name} has this commands:");
                int i = 1;
                foreach (var item in methodInfos)
                {
                    Console.WriteLine($"{i}. {item.CustomAttributes.ToList()[0].ConstructorArguments.ToList()[0].Value}");
                    i++;
                }
                Console.WriteLine("Please type number of command to execute it, or type \"b\" to go back");

                string input = Console.ReadLine();
                if (input.ToLower() == "b") return 1;
                if ((Int32.TryParse(input, out int result)) && (result <= methodInfos.Count) && (result > 0))
                {
                    device.ExecuteMethod(methodInfos[result - 1].CustomAttributes.ToList()[0].ConstructorArguments.ToList()[0].Value.ToString());
                    Console.WriteLine("\nComand completed. Please type the nubmer of new command, or type \"b\" to go back");
                    Console.ReadKey();
                }
            }
        }

        static int CreateNewDevice()
        {
            Type myType = Type.GetType("CandidateRepo.Device", false, true);
            var assembly = Assembly.GetAssembly(myType);
            var types = assembly.GetTypes().Where(t => t.CustomAttributes.ToList().Count > 0);
            types = types.Where(t => t.CustomAttributes.ToList()[0].ConstructorArguments.ToList().Count > 0).ToList();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose divice type:");
                int i = 1;
                foreach (var item in types)
                {
                    Console.WriteLine($"{i}. {item.CustomAttributes.ToList()[0].ConstructorArguments.ToList()[0].Value.ToString()}");
                    i++;
                }

                Console.WriteLine("Please type number of device to create it, or type \"b\" to go back");
                string input = Console.ReadLine();
                if (input.ToLower() == "b") return 1;
                if ((Int32.TryParse(input, out int result)) && (result <= types.ToList().Count) && (result > 0))
                {
                    Console.WriteLine("Please enter device name:");
                    string name = Console.ReadLine();
                    Type type = types.ToList()[result - 1];
                    var constructors = type.GetConstructors().ToList();
                    var device = constructors.ToList()[0].Invoke(new object[] { name });
                    bool complete = false;
                    Console.WriteLine($"Device {name} created.");
                    while (!complete)
                    {
                        Console.WriteLine("Please choose the hub, you want to register it");
                        var hubs = devices.Where(d => (d is IHub)).ToList();
                        for (int j = 1; j <= hubs.Count; j++)
                        {
                            Console.WriteLine($"{j}. {hubs[j - 1].Name}");
                        }
                        string hubnomber = Console.ReadLine();
                        if ((Int32.TryParse(hubnomber, out int hubres)) && (hubres <= hubs.Count) && (hubres > 0))
                        {
                            var hub = hubs[hubres - 1];
                            (hub as Hub).RegisterDevice(device as Device);
                            complete = true;
                            Console.ReadKey();
                        }
                    }
                    return 0;
                }
            }

        }
    }
}

using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CandidateRepo.Classes
{
    class ConsoleInterface : IConsoleInterface
    {
        IDeviceManager _deviceManager;

        public ConsoleInterface(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        public void StartInterface()
        {
            int result = 0;
            while (true)
            {
                result = StartOptions();
                if (result == 1) break;
            }
        }

        int StartOptions()
        {
            Console.Clear();
            Console.WriteLine("Hubs List:");

            int i = 1;
            List<IBaseDevice> hubs = _deviceManager.GetDevices(typeof(IHub)).ToList();
            foreach (var item in hubs)
            {
                Console.WriteLine($"{i}. {item.Name}");
                i++;
            }
            Console.WriteLine("To watch devices, registered on hub please type number of it.");
            Console.WriteLine("To create a new device type \"c\"");
            Console.WriteLine("To quite application please type \"q\"");

            string input = Console.ReadLine();
            if (input.ToLower() == "c") CreateNewDevice();
            if ((Int32.TryParse(input, out int result)) && (result <= hubs.Count) && (result > 0))
            {
                var hub = hubs[result - 1];
                {
                    result = ShowHubDevices(hub as IHub);
                    if (result == 1) return 0;
                }
            }

            if (input.ToLower() == "q") return 1;
            return 0;
        }

        int ShowHubDevices(IHub hub)
        {
            List<IBaseDevice> hubDevices = hub.GetRegisteredDevices().ToList();
            int i = 1;
            Console.Clear();
            Console.WriteLine($"Registered devices on {(hub as IBaseDevice).Name} :");
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
                    if (device is Device)
                    {
                        var methodsDict = (device as Device).GetMethods();
                        showMethodsresult = ShowMethods(methodsDict, device as Device);
                    }
                    else
                    {
                        Console.WriteLine("Could not read device funcs");
                        Console.ReadKey();
                        showMethodsresult = 1;
                    }
                }
            }
            return 0;
        }

        int ShowMethods(Dictionary<string,MethodInfo> methodsDict, Device device)
        {
            Console.Clear();
            Console.WriteLine($"Device {device.Name} has this commands:");
            int i = 1;
            foreach (var item in methodsDict)
            {
                Console.WriteLine($"{i}. {item.Key}");
                i++;
            }
            Console.WriteLine("Please type number of command to execute it, or type \"b\" to go back");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "b") return 1;
                if ((Int32.TryParse(input, out int result)) && (result <= methodsDict.Count) && (result > 0))
                {
                    var method = methodsDict.Values.ToList()[result - 1];
                    device.ExecuteMethod(method);
                    Console.WriteLine("\nComand completed. Please type the nubmer of new command, or type \"b\" to go back");
                }
            }
        }

        int CreateNewDevice()
        {
            List<Type> types = _deviceManager.GetDevicesTypes().ToList();
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

                    var device = _deviceManager.CreateDevice(type, name);
                    bool complete = false;
                    Console.WriteLine($"Device {name} created.");
                    while (!complete)
                    {
                        Console.WriteLine("Please choose the hub, you want to register it");
                        var hubs = _deviceManager.GetDevices(typeof(IHub)).ToList();
                        for (int j = 1; j <= hubs.Count; j++)
                        {
                            Console.WriteLine($"{j}. {hubs[j - 1].Name}");
                        }
                        string hubnomber = Console.ReadLine();
                        if ((Int32.TryParse(hubnomber, out int hubres)) && (hubres <= hubs.Count) && (hubres > 0))
                        {
                            var hub = hubs[hubres - 1];
                            (hub as IHub).RegisterDevice(device);
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

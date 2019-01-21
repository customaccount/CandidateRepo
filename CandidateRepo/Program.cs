using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes;
using CandidateRepo.Interfaces;
using System;
using Unity;
using Unity.Registration;
using Unity.Resolution;

namespace CandidateRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterInstance(typeof(IDeviceManager), DeviceManager.GetDeviceManager());
            container.RegisterType<IConsoleInterface, ConsoleInterface>();
            container.RegisterType<Visitor, Dispetcher>();

            var deviceManager = container.Resolve(typeof(IDeviceManager), null);

            Console.ForegroundColor = ConsoleColor.Black;
            if (deviceManager is DeviceManager)
            (deviceManager as DeviceManager).InitializeDevices();
            Console.ForegroundColor = ConsoleColor.White;

            var consoleInterface = container.Resolve<IConsoleInterface>(
                new ParameterOverride("Some",deviceManager), 
                new ParameterOverride(null, container.Resolve<Visitor>()));

            consoleInterface.StartInterface();
        }
    }
}

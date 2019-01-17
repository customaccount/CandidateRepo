using CandidateRepo.AbstractClasses;
using CandidateRepo.Classes;
using CandidateRepo.Interfaces;

namespace CandidateRepo
{
    class Program
    {
        static IDeviceManager _deviceManager = DeviceManager.GetDeviceManager();
        static IConsoleInterface _consoleInterface = new ConsoleInterface(_deviceManager);
        static void Main(string[] args)
        {
            _consoleInterface.StartInterface();
        }
    }
}

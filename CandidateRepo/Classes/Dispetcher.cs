using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System.Collections.Generic;

namespace CandidateRepo.Classes
{
    public class Dispetcher : Visitor
    {
        IBaseDevice _currentDevice;

        public Dispetcher(IBaseDevice device)
        {
            _currentDevice = device;
        }

        public override List<Command> GetCommands()
        {
            return _currentDevice.GetCommands();
        }
    }
}

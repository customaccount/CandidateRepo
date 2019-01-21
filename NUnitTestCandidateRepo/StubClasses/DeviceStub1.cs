using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCandidateRepo.StubClasses
{
    class DeviceStub1 : Device
    {
        public DeviceStub1(string name, IDeviceManager manager) : base(name, manager) { }
        public override List<Command> GetCommands()
        {
            throw new Exception("Stub commands!");
        }

        public override void GetCurrentState()
        {
            throw new NotImplementedException();
        }
    }
}

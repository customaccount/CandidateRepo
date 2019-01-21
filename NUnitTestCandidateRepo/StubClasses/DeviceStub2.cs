using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCandidateRepo.StubClasses
{
    class DeviceStub2 : Device
    {
        public DeviceStub2(string name, IDeviceManager manager) : base(name, manager) { }
        public override List<Command> GetCommands()
        {
            throw new NotImplementedException();
        }

        public override void GetCurrentState()
        {
            throw new NotImplementedException();
        }
    }
}

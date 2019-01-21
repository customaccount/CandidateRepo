using CandidateRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestCandidateRepo.StubClasses
{
    class DeviceManagerStub : IDeviceManager
    {
        public IBaseDevice CreateDevice(Type type, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBaseDevice> GetDevices(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> GetDevicesTypes()
        {
            throw new NotImplementedException();
        }
    }
}

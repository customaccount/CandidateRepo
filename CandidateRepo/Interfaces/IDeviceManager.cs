using System;
using System.Collections.Generic;

namespace CandidateRepo.Interfaces
{
    public interface IDeviceManager
    {
        IEnumerable<IBaseDevice> GetDevices(Type type);

        IBaseDevice CreateDevice(Type type, string name);

        IEnumerable<Type> GetDevicesTypes();
    }
}

using CandidateRepo.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Interfaces
{
    interface IHub
    {
        void RegisterDevice(Device device);
        List<Device> GetRegisteredDevices();
    }
}

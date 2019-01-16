using System.Collections.Generic;

namespace CandidateRepo.Interfaces
{
    public interface IHub : IBaseDevice
    {
        void RegisterDevice(IBaseDevice device);

        IEnumerable<IBaseDevice> GetRegisteredDevices();
    }
}

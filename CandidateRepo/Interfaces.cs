using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo
{
    interface IBaseDevice
    {
        void Reboot();
        void GetCurrentState();
        void UpdateParams();
        void RegisterDevice();
    }

    interface IHub
    {
        void RegisterDevice(Device device);
        List<Device> GetRegisteredDevices();
    }

    interface ITermControlSystem
    {
        void FastFreeze();
    }

    interface ISmartLightSystem
    {
        void LightsOn();
        void LightsOff();
    }

    interface IHumidifier
    {
        void Evaporate();
    }
}

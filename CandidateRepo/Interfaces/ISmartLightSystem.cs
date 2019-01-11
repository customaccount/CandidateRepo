using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Interfaces
{
    interface ISmartLightSystem : IBaseDevice
    {
        void LightsOn();
        void LightsOff();
    }
}

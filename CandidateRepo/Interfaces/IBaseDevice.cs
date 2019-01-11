using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Interfaces
{
    interface IBaseDevice
    {
        void Reboot();
        void GetCurrentState();
        void UpdateParams();
        void RegisterDevice();
    }
}

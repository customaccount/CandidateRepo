using CandidateRepo.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Interfaces
{
    interface ICreator
    {
        Device CreateDevice(Type type, string name);
    }
}

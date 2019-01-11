using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.Classes
{
    class CreatorOfDevices : ICreator
    {
        public Device CreateDevice(Type type, string name)
        {
            var constructors = type.GetConstructors().ToList();
            var device = constructors.ToList()[0].Invoke(new object[] { name });
            return device as Device;
        }
    }
}

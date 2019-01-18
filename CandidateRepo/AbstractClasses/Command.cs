using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepo.AbstractClasses
{
    public abstract class Command
    {
        public abstract void Execute();
        public string Name { get; set; }
    }
}

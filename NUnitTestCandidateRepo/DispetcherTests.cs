using CandidateRepo.Classes;
using NUnit.Framework;
using NUnitTestCandidateRepo.StubClasses;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using CandidateRepo.Interfaces;

namespace NUnitTestCandidateRepo
{
    class DispetcherTests
    {
        [Test]
        public void DispetcherShouldInvokeGetCommandsMethodOnDevice()
        {
            Dispetcher dispetcher = new Dispetcher();
            var baseDevice = Substitute.For<IBaseDevice>();
            dispetcher.GetCommands(baseDevice);
            baseDevice.Received().GetCommands();
        }
    }
}

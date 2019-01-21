using CandidateRepo.Classes;
using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using CandidateRepo.Interfaces;
using System.Linq;
using System.IO;

namespace NUnitTestCandidateRepo
{

    /*NEED TO TEST
             void RegisterDevice(IBaseDevice device);

        IEnumerable<IBaseDevice> GetRegisteredDevices();

                void Reboot();

        void GetCurrentState();

        void UpdateParams();

        void RegisterDevice();

        List<Command> GetCommands();

        public override void GetCurrentState()
        public override List<Command> GetCommands()

        */
    class HubTests
    {
        [Test]
        public void RegisterDeviceMethodShouldAddDevicesToList()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var deviceManager = Substitute.For<IDeviceManager>();
                Hub hub = new Hub("Hub", deviceManager);
                var device1 = Substitute.For<IBaseDevice>();
                var device2 = Substitute.For<IBaseDevice>();
                hub.RegisterDevice(device1);
                hub.RegisterDevice(device2);
                Assert.AreEqual(2, hub.GetRegisteredDevices().ToList().Count);
            }
        }

        [Test]
        public void GetCuurentStateShouldWriteStateToConsole()
        {
            var deviceManager = Substitute.For<IDeviceManager>();
            Hub hub = new Hub("Hub", deviceManager);

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                hub.GetCurrentState();
                string expected = $"Currently state: normal\r\n";
                Assert.AreEqual(expected, sw.ToString());

            }
            Console.Out.Close();

            var streamWriter = new StreamWriter(Console.OpenStandardOutput());
            streamWriter.AutoFlush = true;
            Console.SetOut(streamWriter);
            hub.RegisterDevice(Substitute.For<IBaseDevice>());
            hub.RegisterDevice(Substitute.For<IBaseDevice>());

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                hub.GetCurrentState();
                string expected = $"Currently state: normal\r\nConnected 2 devices\r\n\r\n\r\n";
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        //[Test]
        //public void UpdateParamsShouldChangeState()
        //{
        //    var deviceManager = Substitute.For<IDeviceManager>();
        //    Hub hub = new Hub("Hub", deviceManager);

        //    //using (StringWriter sw = new StringWriter())
        //    //{
        //    //    Console.SetOut(sw);
        //    //    hub.GetCurrentState();
        //    //    string expected = $"Currently state: normal\r\n";
        //    //    Assert.AreEqual(expected, sw.ToString());

        //    //}
        //    //Console.Out.Close();
        //    hub.UpdateParams();
        //    Console.WriteLine("aasdfasdfas");
        //    //using (StringWriter sw = new StringWriter())
        //    //{
        //    //    Console.In = sw;
        //    //    sw.Write("nananan");
        //    //}

        //        var streamWriter = new StreamWriter(Console.OpenStandardOutput());
        //    streamWriter.AutoFlush = true;
        //    Console.SetOut(streamWriter);
        //    hub.RegisterDevice(Substitute.For<IBaseDevice>());
        //    hub.RegisterDevice(Substitute.For<IBaseDevice>());

        //    using (StringWriter sw = new StringWriter())
        //    {
        //        Console.SetOut(sw);
        //        hub.GetCurrentState();
        //        string expected = $"Currently state: normal\r\nConnected 2 devices\r\n\r\n\r\n";
        //        Assert.AreEqual(expected, sw.ToString());
        //    }
        //}
    }
}

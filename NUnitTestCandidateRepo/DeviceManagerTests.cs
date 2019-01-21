using NUnit.Framework;
using CandidateRepo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using CandidateRepo.Interfaces;
using NUnitTestCandidateRepo.StubClasses;


namespace NUnitTestCandidateRepo
{
    class DeviceManagerTests
    {
        [Test]
        public void GetDeviceManagerShouldGetOnlyOneInstance()
        {
            IDeviceManager deviceManager = DeviceManager.GetDeviceManager();
            Assert.AreEqual(deviceManager, DeviceManager.GetDeviceManager());
        }

        [Test]
        public void CreatedDevicesShouldBeReturnedByType()
        {
            IDeviceManager deviceManager = DeviceManager.GetDeviceManager();
            var stub1device1 = deviceManager.CreateDevice(typeof(DeviceStub1), "Stub1");
            var stub2device1 = deviceManager.CreateDevice(typeof(DeviceStub1), "Stub1");
            var stub1device2 = deviceManager.CreateDevice(typeof(DeviceStub2), "Stub1");

            List<IBaseDevice> returnedStubDevices1 = deviceManager.GetDevices(typeof(DeviceStub1)).ToList();
            
            Assert.AreEqual(2, returnedStubDevices1.Count);
            Assert.AreSame(stub1device1, returnedStubDevices1[0]);
            Assert.AreSame(stub2device1, returnedStubDevices1[1]);
            Assert.AreSame(stub1device2, deviceManager.GetDevices(typeof(DeviceStub2)).ToList()[0]);
        }

        [Test]
        public void GetDevicesTypesShouldReturnListOf3Types()
        {
            IDeviceManager deviceManager = DeviceManager.GetDeviceManager();
            var types = new List<Type>() { typeof(SmartLightSystem), typeof(Humidifier), typeof(TermControlSystem) };
            var returnedTypes = deviceManager.GetDevicesTypes().ToList();
            
            for (int i = 0; i < returnedTypes.Count; i++)
            {
                Assert.AreEqual(types[i], returnedTypes[i]);
            } 
        }
    }
}

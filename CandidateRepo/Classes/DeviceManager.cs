using CandidateRepo.AbstractClasses;
using CandidateRepo.Interfaces;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandidateRepo.Classes
{
    class DeviceManager : IDeviceManager
    {
        List<IBaseDevice> _devices;
        static DeviceManager _deviceManagerInstance;
        private static object syncRoot = new Object();

        public static IDeviceManager GetDeviceManager()
        {
            if (_deviceManagerInstance == null)
            {
                lock (syncRoot)
                {
                    if (_deviceManagerInstance == null)
                        _deviceManagerInstance = new DeviceManager();
                }
            }
            return _deviceManagerInstance;
        }

        private DeviceManager()
        {
            _deviceManagerInstance = this;
            _devices = new List<IBaseDevice>();
            Console.ForegroundColor = ConsoleColor.Black;
            InitializeDevices();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public IBaseDevice CreateDevice(Type type, string name)
        {
            var constructors = type.GetConstructors().ToList();
            var device = constructors.ToList()[0].Invoke(new object[] { name, _deviceManagerInstance });
            _devices.Add(device as IBaseDevice);
            return device as Device;
        }

        public IEnumerable<IBaseDevice> GetDevices(Type type)
        {
            return _devices.Where(d => type.IsInstanceOfType(d)).ToList();
        }

        public IEnumerable<Type> GetDevicesTypes()
        {
            return new List<Type>() { typeof(SmartLightSystem), typeof(Humidifier), typeof(TermControlSystem) };
        }

        public void InitializeDevices()
        {
            var h1 = new Hub("Hub1", this);
            var h2 = new Hub("Hub2", this);
            var t1 = new TermControlSystem("TermControlSystem in the room", this);
            var t2 = new TermControlSystem("TermControlSystem in the kitchen", this);
            var l1 = new SmartLightSystem("Ligths at hall", this);
            var l2 = new SmartLightSystem("Ligths in the room", this);
            var l3 = new SmartLightSystem("Ligths in the kitchen", this);
            var hum1 = new Humidifier("Humidifier in the room", this);
            var hum2 = new Humidifier("Humidifier in the servers room", this);
            _devices.Add(h1);
            _devices.Add(h2);
            _devices.Add(t1);
            _devices.Add(t2);
            _devices.Add(l1);
            _devices.Add(l2);
            _devices.Add(l3);
            _devices.Add(hum1);
            _devices.Add(hum2);
            h1.RegisterDevice(t1);
            h1.RegisterDevice(t2);
            h1.RegisterDevice(l1);
            h1.RegisterDevice(l2);
            h1.RegisterDevice(l3);
            h1.RegisterDevice(hum1);
            h2.RegisterDevice(hum2);
        }
    }
}

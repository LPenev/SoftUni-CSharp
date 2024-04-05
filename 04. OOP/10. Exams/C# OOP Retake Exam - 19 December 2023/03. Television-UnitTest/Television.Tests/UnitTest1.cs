namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private string brand = "Sony";
        private double price = 200.00;
        private int screenWidth = 20;
        private int screenHeigth = 40;
        private TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
        }

        [Test]
        public void Constructor()
        {
            Assert.AreEqual(brand, device.Brand);
            Assert.AreEqual(price, device.Price);
            Assert.AreEqual(screenWidth, device.ScreenWidth);
            Assert.AreEqual(screenHeigth, device.ScreenHeigth);
        }

        [Test]
        public void SwitchOn()
        {
            var result = device.SwitchOn();
            Assert.AreEqual("Cahnnel 0 - Volume 13 - Sound On", result);
        }

        [Test]
        public void ChangeChanel()
        {
            Assert.AreEqual(20, device.ChangeChannel(20));
            ArgumentException ae = Assert.Throws<ArgumentException>(() => device.ChangeChannel(-20));
            Assert.AreEqual("Invalid key!",ae.Message);
            Assert.AreEqual(20,device.CurrentChannel);
        }

        [Test]
        public void VolumChangeUp()
        {
            Assert.AreEqual("Volume: 99", device.VolumeChange("UP", 86));
            Assert.AreEqual("Volume: 100", device.VolumeChange("UP", 1));
            Assert.AreEqual("Volume: 100", device.VolumeChange("UP", 7));
        }

        [Test]
        public void VolumChangeDown()
        {
            Assert.AreEqual("Volume: 1", device.VolumeChange("DOWN", 12));
            Assert.AreEqual("Volume: 0", device.VolumeChange("DOWN", 1));
            Assert.AreEqual("Volume: 0", device.VolumeChange("DOWN", 7));
            Assert.AreEqual(0, device.Volume);
        }

        [Test]
        public void MuteDevice()
        {
            bool currentState = device.IsMuted;
            Assert.AreNotEqual(currentState, device.MuteDevice());
            Assert.AreNotEqual(currentState, device.IsMuted);
        }

        [Test]
        public void toString()
        {
            string example = $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$";
            Assert.AreEqual(example, device.ToString());
        }
    }
}
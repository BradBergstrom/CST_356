using System;
using NUnit.Framework;
using FakeItEasy;
using Lab5.Data.Entities;
using Lab5.Repositories;
using Lab5.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab5_TestApp.Tests
{

    [TestFixture]
    public class ServiceTests
    {
        private iRepository _respository;

        [SetUp]
        public void SetUp()
        {
            _respository = A.Fake<iRepository>();
        }

        [Test]
        public void ShouldNotIndicateCheckupAlert()
        {
            // Arrange
            A.CallTo(() => _respository.GetCar(A<int>.Ignored)).Returns(new Car
            {
                NextCheckup = DateTime.Now.AddDays(29)
            });

            // Act (SUT)
            var carService = new Service(_respository);
            var carViewModel = carService.GetCar(1);

            // Assert
            NUnit.Framework.Assert.IsFalse(carViewModel.CheckupAlert);
        }

        [Test]
        public void ShouldIndicateCheckupAlert()
        {
            // Arrange
            A.CallTo(() => _respository.GetCar(A<int>.Ignored)).Returns(new Car
            {
                NextCheckup = DateTime.Now.AddDays(13)
            });

            // Act (SUT)
            var carService = new Service(_respository);
            var carViewModel = carService.GetCar(1);

            // Assert
            NUnit.Framework.Assert.IsTrue(carViewModel.CheckupAlert);

        }
    }
}

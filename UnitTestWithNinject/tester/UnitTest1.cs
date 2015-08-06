using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using UnitTestWithNinject.Models;
using UnitTestWithNinject.Controllers;

namespace tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        //[Fact]
        //public void GetAllProductsReturnsEverythingInRepository()
        //{
        //    // Arrange
        //    var allUnits = new[] {
        //        new Unit { UnitId=111, UnitName="Tomato Soup", UnitAddress="Food" },
        //        new Unit { UnitId=222, UnitName="Laptop Computer", UnitAddress="Electronics" }
        //    };
        //    var repo = new StubIUnitRepository
        //    {
        //        GetAll = () => allUnits
        //    };
        //    var controller = new UnitController(repo);

        //    // Act
        //    var result = controller.Get();

        //    // Assert
        //    Xunit.Assert.Same(allUnits, result);
        //}
    }
}

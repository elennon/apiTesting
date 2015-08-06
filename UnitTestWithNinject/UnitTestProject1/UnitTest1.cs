using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;


using System.Collections.Generic;
using System.Linq;
using UnitTestWithNinject.Models;
using UnitTestWithNinject.Controllers;
using UnitTestWithNinject.Fakes;
using System.Web.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Fact]
        public void GetAllUnitsReturnsEverythingInRepository()
        {
            // Arrange
            var allUnits = new List<UnitTestWithNinject.Models.Unit> {
                new Unit { UnitId=111, UnitName="castle", UnitAddress="ina castle" },
                new Unit { UnitId=112, UnitName="Apt 56", UnitAddress="a apt block" },
                new Unit { UnitId=113, UnitName="house on hill", UnitAddress="hill" },
                new Unit { UnitId=114, UnitName="my shed", UnitAddress="out back" },
                new Unit { UnitId=115, UnitName="hole", UnitAddress="down a hole" },
                new Unit { UnitId=226, UnitName="tree house", UnitAddress="up a tree" }
            };
            var repo = new UnitTestWithNinject.Fakes.StubIUnitRepository
            {
                GetUnits = () => allUnits//.AsQueryable()
            };
            var controller = new UnitController(repo);

            // Act
            var result = controller.Get();//.ToList();

            // Assert
            Xunit.Assert.Same(allUnits, result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(6, result.ToList().Count);
        }

        [TestMethod]
        [Fact]
        public void GetUnitReturnsCorrectItemFromRepository()
        {
            // Arrange
            var unit = new Unit { UnitId = 222, UnitName = "Laptop Computer", UnitAddress = "Electronics" };
            var repo = new StubIUnitRepository { GetByIdInt32 = id => unit };
            var controller = new UnitController(repo);

            // Act
            var result = controller.Get(222);

            // Assert
            Xunit.Assert.Same(unit, result);
        }

        [TestMethod]
        [Fact]
        public void GetUnitThrowsWhenRepositoryReturnsNull()
        {
            var repo = new StubIUnitRepository
            {
                GetByIdInt32 = id => null
            };
            var controller = new UnitController(repo);

            Xunit.Assert.Throws<HttpResponseException>(() => controller.Get(1));
        }

        [TestMethod]
        [Fact]
        public void GetProductsByCategoryFiltersByCategory()
        {
            var units = new List<UnitTestWithNinject.Models.Unit> {
                new Unit { UnitId=111, UnitName="castle", UnitAddress="ina castle" },
                new Unit { UnitId=112, UnitName="Apt 56", UnitAddress="a apt block" },
                new Unit { UnitId=113, UnitName="house on hill", UnitAddress="hill" },
                new Unit { UnitId=114, UnitName="my shed", UnitAddress="out back" },
                new Unit { UnitId=115, UnitName="hole", UnitAddress="down a hole" },
                new Unit { UnitId=226, UnitName="tree house", UnitAddress="up a tree" }
            };
            var repo = new StubIUnitRepository { GetUnits = () => units };
            var controller = new UnitController(repo);

            var result = controller.GetUnitsByAddress("hill").ToList();

            Xunit.Assert.Same(units[2], result[0]);
        }
    }
}

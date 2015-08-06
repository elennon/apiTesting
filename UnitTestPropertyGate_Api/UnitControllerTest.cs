using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyGate_API;
using PropertyGate_API.Controllers;
using PropertyGate_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Web.Http;
using System.Net.Http;

namespace UnitTestPropertyGate_Api
{
    [TestClass]
    public class UnitControllerTest
    {

        [TestMethod]
        [Fact]
        public void GetAllUnitsReturnsEverythingInRepository()
        {
            // Arrange
            var units = new List<Unit> {
                new Unit { UnitId= new Guid(), UnitName="castle", UnitAddress="ina castle" },
                new Unit { UnitId= new Guid(), UnitName="Apt 56", UnitAddress="a apt block" },
                new Unit { UnitId= new Guid(), UnitName="house on hill", UnitAddress="hill" },
                new Unit { UnitId= new Guid(), UnitName="my shed", UnitAddress="out back" },
                new Unit { UnitId= new Guid(), UnitName="hole", UnitAddress="down a hole" },
                new Unit { UnitId= new Guid(), UnitName="tree house", UnitAddress="up a tree" }
            };
            string stringg = "";
            var repo = new PropertyGate_API.Fakes.StubIRepository<Unit>().GetUnits = () => units;
            var unitof = new PropertyGate_API.Fakes.StubIUnitOfWork() ;//.UnitRepositoryGet ;//= () => repo;
            unitof.UnitRepositoryGet = new PropertyGate_API.Fakes.StubIRepository<Unit>();

            var controller = new UnitController(new PropertyGate_API.Fakes.StubIUnitOfWork());
           // controller.repo.UnitRepository.GetUnits() = () => units;
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
           
            // Act
            var result = controller.GetUnit();//.ToList();

            // Assert
            Xunit.Assert.Same(units, result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
           // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(6, result.ToList().Count);
        }
    }
}

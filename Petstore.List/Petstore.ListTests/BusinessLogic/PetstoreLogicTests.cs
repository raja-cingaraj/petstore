using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petstore.List.DataLayer;
using Petstore.List.Model;
using Petstore.ListTests;
using System.Collections.Generic;
using System.Text.Json;

namespace Petstore.List.BusinessLogic.Tests
{
    [TestClass()]
    public class PetstoreLogicTests
    {
        private PetstoreLogic logic;
        private Mock<IPetstoreService> petstoreService;

        [TestInitialize()]
        public void Initialize()
        {
            petstoreService = new Mock<IPetstoreService>();

            logic = new PetstoreLogic(petstoreService.Object);
        }

        [TestMethod()]
        [DataRow(@"TestData\Input\PetstoreData3.json", @"TestData\Output\PetstoreData3.json")]
        [DataRow(@"TestData\Input\PetstoreData4.json", @"TestData\Output\PetstoreData4.json")]
        public void GetAvailablePetsTest(string inputFile, string outputFile)
        {
            var inputData = DataHelper.ParseData<List<Pet>>(inputFile);
            petstoreService.Setup(p => p.GetAvailablePets())
                .Returns(inputData);

            var actualData = logic.GetAvailablePets();

            var expectedData = DataHelper.ParseData<List<Pet>>(outputFile);

            Assert.AreEqual(JsonSerializer.Serialize(expectedData), JsonSerializer.Serialize(actualData), "Check expected result");
        }
    }
}
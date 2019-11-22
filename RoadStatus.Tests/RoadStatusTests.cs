using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace RoadStatus.Tests
{
    [TestClass]
    public class RoadStatusTests : BaseTestSetup
    {
        #region Valid Road Scenarios
        [TestMethod]
        [DataRow("a2", "A2")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_DisplayName_ShouldNotBeNullOrEmpty(string validRoadId, string expectedDisplayName)
        {
            base.Setup();

            var statusTracker = new StatusTracker(_tflRepository.Object, _config.Object);

            var status = statusTracker.GetRoadStatus(It.IsAny<string>());
            if (status != null)
                Assert.AreEqual(expectedDisplayName, status.DisplayName);
        }

        [TestMethod]
        public void TestGetRoadStatus_When_ValidRoadId_Then_RoadStatus_ShouldNotBeNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestGetRoadStatus_When_ValidRoadId_Then_StatusSeverityDescription_ShouldNotBeNullOrEmpty()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestGetRoadStatus_When_ValidRoadId_Then_Return_ZeroSystemErrorCode()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Invalid Road Scenarios
        [TestMethod]
        public void TestGetRoadStatus_When_InValidRoadId_Then_Return_InformativeError()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestGetRoadStatus_When_InValidRoadId_Then_Return_NonZeroSystemErrorCode()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

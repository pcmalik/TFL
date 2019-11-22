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
            //Arrange
            base.Setup();
            var statusTracker = new StatusTracker(_tflRepository.Object, _config.Object);

            //Act
            var road = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
             Assert.AreEqual(expectedDisplayName, road?.SuccessStatus.DisplayName);
        }

        [TestMethod]
        [DataRow("a2", "Good")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_RoadStatus_ShouldNotBeNullOrEmpty(string validRoadId, string expectedRoadStatus)
        {
            //Arrange
            base.Setup();
            var statusTracker = new StatusTracker(_tflRepository.Object, _config.Object);

            //Act
            var road = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expectedRoadStatus, road?.SuccessStatus.StatusSeverity);
        }

        [TestMethod]
        [DataRow("a2", "No Exceptional Delays")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_StatusSeverityDescription_ShouldNotBeNullOrEmpty(string validRoadId, string expectedRoadStatusDescription)
        {
            //Arrange
            base.Setup();
            var statusTracker = new StatusTracker(_tflRepository.Object, _config.Object);

            //Act
            var road = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expectedRoadStatusDescription, road?.SuccessStatus.StatusSeverityDescription);
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

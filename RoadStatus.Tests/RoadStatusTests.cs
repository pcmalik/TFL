using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RoadStatus.Models;
using RoadStatus.Tracker;

namespace RoadStatus.Tests
{
    [TestClass]
    public class RoadStatusTests : BaseTestSetup
    {
        #region Valid Road Scenarios
        [TestMethod]
        [DataRow("A2")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_Return_Expected_DisplayName(string expectedDisplayName)
        {
            //Arrange
            base.SetupForValidRoad();
            var statusTracker = new StatusTracker(_tflRepository.Object);

            //Act
            var roadInfo = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
             Assert.AreEqual(expectedDisplayName, roadInfo?.DisplayName);
        }

        [TestMethod]
        [DataRow("Good")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_Return_Expected_RoadStatus(string expectedRoadStatus)
        {
            //Arrange
            base.SetupForValidRoad();
            var statusTracker = new StatusTracker(_tflRepository.Object);

            //Act
            var roadInfo = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expectedRoadStatus, roadInfo?.StatusSeverity);
        }

        [TestMethod]
        [DataRow("No Exceptional Delays")]
        public void TestGetRoadStatus_When_ValidRoadId_Then_Return_Expected_StatusSeverityDescription(string expectedRoadStatusDescription)
        {
            //Arrange
            base.SetupForValidRoad();
            var statusTracker = new StatusTracker(_tflRepository.Object);

            //Act
            var roadInfo = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expectedRoadStatusDescription, roadInfo?.StatusSeverityDescription);
        }
        #endregion

        #region Invalid Road Scenarios
        [TestMethod]
        [DataRow("A233 is not a valid road")]
        public void TestGetRoadStatus_When_InValidRoadId_Then_Return_Expected_InformativeError(string expectedFailureMessage)
        {
            base.SetupForInvalidRoad();
            var statusTracker = new StatusTracker(_tflRepository.Object);

            //Act
            var roadInfo = statusTracker.GetRoadStatus(It.IsAny<string>());

            //Assert
            Assert.AreEqual(expectedFailureMessage, roadInfo?.FailureMessage);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestGetRoadStatus_When_InValidRoadId_Then_Return_Expected_LastExitCode(int expectedLastExitCode)
        {
            //Arrange
            var statusTracker = new Mock<IStatusTracker>();
            statusTracker.Setup(x => x.GetRoadStatus(It.IsAny<string>())).Returns(new RoadInfo{Valid = false});

            var application = new StatusReporter(statusTracker.Object);
            //Act
            var result = application.GetRoadStatus("Invalid_Road");

            //Assert
            Assert.AreEqual(expectedLastExitCode, result);
        }

        #endregion

    }
}

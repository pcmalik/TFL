using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RoadStatus.Tests
{
    [TestClass]
    public class RoadStatusTests
    {
        #region Valid Road Scenarios
        [TestMethod]
        public void TestGetRoadStatus_When_ValidRoadId_Then_DisplayName_ShouldNotBeNullOrEmpty()
        {
            throw new NotImplementedException();
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

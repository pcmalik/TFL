using Microsoft.Extensions.Options;
using Moq;
using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;

namespace RoadStatus.Tests
{
    public class BaseTestSetup
    {
        protected Mock<IRoadStatusRepository> _tflRepository;

        protected virtual void SetupForValidRoad()
        {
            _tflRepository = new Mock<IRoadStatusRepository>();

            _tflRepository.Setup(x => x.GetRoadStatus(It.IsAny<string>())).Returns(new RoadInfo
                        {
                            Valid = true,
                            DisplayName = "A2",
                            StatusSeverity = "Good",
                            StatusSeverityDescription = "No Exceptional Delays",
            });
        }

        protected virtual void SetupForInvalidRoad()
        {
            _tflRepository = new Mock<IRoadStatusRepository>();

            _tflRepository.Setup(x => x.GetRoadStatus(It.IsAny<string>())).Returns(new RoadInfo
                        {
                            Valid = false,
                            FailureMessage = "A233 is not a valid road"
            });
        }

    }
}
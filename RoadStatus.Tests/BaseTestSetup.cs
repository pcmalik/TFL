using Microsoft.Extensions.Options;
using Moq;
using RoadStatus.Models;
using RoadStatus.Repositories.Interfaces;

namespace RoadStatus.Tests
{
    public class BaseTestSetup
    {
        protected Mock<IRoadStatusRepository> _tflRepository;
        protected Mock<IOptions<AppSettings>> _config;

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

            _config = new Mock<IOptions<AppSettings>>();
            _config.Setup(x => x.Value).Returns(new AppSettings { AppId = "MOCK_APP_ID", AppKey = "MOCK_APP_KEY" });
        }

        protected virtual void SetupForInvalidRoad()
        {
            _tflRepository = new Mock<IRoadStatusRepository>();

            _tflRepository.Setup(x => x.GetRoadStatus(It.IsAny<string>())).Returns(new RoadInfo
                        {
                            Valid = false,
                            FailureStatusCode = "404",
                            FailureMessage = "The following road id is not recognised: A233"
                        });

            _config = new Mock<IOptions<AppSettings>>();
            _config.Setup(x => x.Value).Returns(new AppSettings { AppId = "MOCK_APP_ID", AppKey = "MOCK_APP_KEY" });
        }

    }
}
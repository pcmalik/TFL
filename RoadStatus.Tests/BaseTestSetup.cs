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

        protected virtual void Setup()
        {
            _tflRepository = new Mock<IRoadStatusRepository>();

            _tflRepository.Setup(x => x.GetRoadStatus(It.IsAny<string>())).Returns(new Road
                        {
                            SuccessStatus =new SuccessStatus
                                    {
                                        Type = "Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities",
                                        Id = "a2",
                                        DisplayName = "A2",
                                        StatusSeverity = "Good",
                                        StatusSeverityDescription = "No Exceptional Delays",
                                        Bounds = "[[-0.0857,51.44091],[0.17118,51.49438]]",
                                        Envelope = "[[-0.0857,51.44091],[-0.0857,51.49438],[0.17118,51.49438],[0.17118,51.44091],[-0.0857,51.44091]]",
                                        Url = "/Road/a2"
                                    }
                        });

            _config = new Mock<IOptions<AppSettings>>();
            _config.Setup(x => x.Value).Returns(new AppSettings { AppId = "MOCK_APP_ID", AppKey = "MOCK_APP_KEY" });
        }

    }
}
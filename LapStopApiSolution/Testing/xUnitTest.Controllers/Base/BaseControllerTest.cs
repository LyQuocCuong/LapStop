using Contracts.ILog;
using Contracts.IServices;
using Moq;

namespace xUnitTest.Controllers.Base
{
    public abstract class BaseControllerTest
    {
        protected readonly Mock<ILogService> _mockLogService = new Mock<ILogService>();
        protected readonly Mock<IServiceManager> _mockServiceManager = new Mock<IServiceManager>();
    }
}

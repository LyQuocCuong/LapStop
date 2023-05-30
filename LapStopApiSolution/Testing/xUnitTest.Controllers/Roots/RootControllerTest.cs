using Contracts.ILog;
using Contracts.IServices;
using Moq;

namespace xUnitTest.Controllers.Roots
{
    public abstract class RootControllerTest
    {
        protected readonly Mock<ILogService> _mockLogService = new Mock<ILogService>();
        protected readonly Mock<IServiceManager> _mockServiceManager = new Mock<IServiceManager>();
    }
}

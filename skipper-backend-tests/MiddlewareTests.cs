using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skipper_backend_tests
{
    using Moq;
    using NUnit.Framework;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;
    using skipper_backend.Middleware;
    using Microsoft.Extensions.Hosting;
    using System.IO;

    [TestFixture]
    public class ExceptionMiddlewareTests
    {
        private Mock<ILogger<ExceptionMiddleware>> _loggerMock;
        private Mock<IHostEnvironment> _envMock;
        private DefaultHttpContext _httpContext;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<ExceptionMiddleware>>();
            _envMock = new Mock<IHostEnvironment>();
            _httpContext = new DefaultHttpContext();
            _httpContext.Response.Body = new MemoryStream();
            _envMock.SetupGet(e => e.EnvironmentName).Returns("Development");

        }

        [Test]
        public async Task Middleware_Should_Process_Request_Without_Exception()
        {
            // Arrange
            RequestDelegate next = (HttpContext hc) => Task.CompletedTask;
            var middleware = new ExceptionMiddleware(next, _loggerMock.Object, _envMock.Object);

            // Act
            await middleware.InvokeAsync(_httpContext);

            // Assert
            Assert.AreEqual(StatusCodes.Status200OK, _httpContext.Response.StatusCode);
            Assert.AreEqual(0, _httpContext.Response.Body.Length);
        }

        [Test]
        public async Task Middleware_Should_Catch_Exception_And_Return_Proper_Response()
        {
            // Arrange
            var expectedException = new Exception("Test exception");
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(x => x.GetService(It.IsAny<Type>())).Returns(new object());

            _loggerMock.Setup(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)))
                .Verifiable();

            _httpContext.RequestServices = serviceProviderMock.Object;
            _httpContext.Response.Body = new MemoryStream();
            RequestDelegate next = (HttpContext hc) => throw expectedException;
            var middleware = new ExceptionMiddleware(next, _loggerMock.Object, _envMock.Object);

            // Act
            await middleware.InvokeAsync(_httpContext);

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Test exception")),
                    expectedException,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);

            _httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(_httpContext.Response.Body);
            var responseText = await reader.ReadToEndAsync();

            Assert.That(_httpContext.Response.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(responseText, Does.Contain("Test exception"));
        }
    }
}

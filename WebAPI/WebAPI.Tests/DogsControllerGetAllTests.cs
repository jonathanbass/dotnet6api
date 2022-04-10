namespace WebAPI.Tests
{
    using System.Collections.Generic;
    using AutoFixture;
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using WebAPI.Controllers;

    [TestFixture]
    public class GivenADogsController
    {
        private Mock<ILogger<DogsController>> mockLogger;
        private Mock<IDogRepository> mockDogRepository;
        private IEnumerable<Dog> actualDogs;

        [SetUp]
        public void WhenAllDogsAreRetrieved()
        {
            mockLogger = new Mock<ILogger<DogsController>>();
            mockDogRepository = new Mock<IDogRepository>();
            var fixture = new Fixture();
            var expectedDogs = fixture.CreateMany<Dog>(4);
            mockDogRepository.Setup(dr => dr.GetDogs()).Returns(expectedDogs);
            var dogsController = new DogsController(mockLogger.Object, mockDogRepository.Object);
            actualDogs = dogsController.GetDogs();
        }

        [Test]
        public void ThenTheDogsAreRetrievedFromTheRepository()
        {
            mockDogRepository.Verify(dr => dr.GetDogs(), Times.Once);
        }

        [Test]
        public void ThenTheCorrectLogIsWritten()
        {
            mockLogger.Verify(log => log.Log(
                    LogLevel.Debug,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("Get all dogs called", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
        }

        [Test]
        public void ThenTheCorrectNumberOfDogsAreReturned()
        {
            actualDogs.Count().Should().Be(4);
        }
    }
}
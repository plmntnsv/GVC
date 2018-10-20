using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportBetApp.Data.Models;
using SportBetApp.DTO;
using SportBetApp.Repository.Contracts;
using SportBetApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportBetApp.UnitTests.Services
{
    [TestClass]
    public class EventServiceTests
    {
        [TestMethod]
        public void GetAllShould_CallEventRepositoryGetAllMethod_Once()
        {
            // Arrange
            var eventRepoMock = new Mock<IEventRepository>();
            eventRepoMock.Setup(x => x.GetAll()).Returns(new List<Event>()
            {
                new Event()
                {
                    Id = 1,
                    Name = "Test",
                    OddsForFirstTeam = 1,
                    OddsForDraw = 2,
                    OddsForSecondTeam = 3,
                    StartDate = DateTime.Now
                }
            });

            var service = new EventService(eventRepoMock.Object);

            // Act
            var result = service.GetAll();

            // Assert
            eventRepoMock.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetAllShould_ReturnExpectedEventObject()
        {
            // Arrange
            var eventRepoMock = new Mock<IEventRepository>();
            var eventDto = new Event()
            {
                Id = 1,
                Name = "Test",
                OddsForFirstTeam = 1,
                OddsForDraw = 2,
                OddsForSecondTeam = 3,
                StartDate = DateTime.Now
            };

            eventRepoMock.Setup(x => x.GetAll()).Returns(new List<Event>()
            {
                eventDto
            });

            var service = new EventService(eventRepoMock.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual(result.ElementAt(0).Id, eventDto.Id);
            Assert.AreEqual(result.ElementAt(0).Name, eventDto.Name);
            Assert.AreEqual(result.ElementAt(0).OddsForFirstTeam, eventDto.OddsForFirstTeam);
            Assert.AreEqual(result.ElementAt(0).OddsForDraw, eventDto.OddsForDraw);
            Assert.AreEqual(result.ElementAt(0).OddsForSecondTeam, eventDto.OddsForSecondTeam);
            Assert.AreEqual(result.ElementAt(0).StartDate, eventDto.StartDate);
        }

        [TestMethod]
        public void EditShould_ThrowAgumentNullException_WhenNullParameterIsPassed()
        {
            // Arrange
            var eventRepoMock = new Mock<IEventRepository>();

            var service = new EventService(eventRepoMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Edit(null));
        }

        [TestMethod]
        public void AddShould_CallRepositoryAddMethod_Once()
        {
            // Arrange
            var eventRepoMock = new Mock<IEventRepository>();

            eventRepoMock.Setup(x => x.Add(It.IsAny<Event>())).Returns(
                new Event()
                {
                    Id = 1,
                    Name = "Test",
                    OddsForFirstTeam = 1,
                    OddsForDraw = 2,
                    OddsForSecondTeam = 3,
                    StartDate = DateTime.Now
                }
            );

            var service = new EventService(eventRepoMock.Object);

            // Act
            var result = service.Add();

            // Assert
            eventRepoMock.Verify(x => x.Add(It.IsAny<Event>()), Times.Once);
        }

        [TestMethod]
        public void AddShould_ReturnNewEventObject_WithExpectedProperties()
        {
            // Arrange
            var eventRepoMock = new Mock<IEventRepository>();
            var eventObj = new Event()
            {
                Id = 1,
                StartDate = DateTime.Now
            };

            eventRepoMock.Setup(x => x.Add(It.IsAny<Event>())).Returns(
                eventObj
            );

            var service = new EventService(eventRepoMock.Object);

            // Act
            var result = service.Add();

            // Assert
            Assert.AreEqual(eventObj.Id, result.Id);
            Assert.AreEqual(eventObj.StartDate, result.StartDate);
            Assert.AreEqual(eventObj.Name, null);
            Assert.AreEqual(eventObj.OddsForFirstTeam, null);
            Assert.AreEqual(eventObj.OddsForDraw, null);
            Assert.AreEqual(eventObj.OddsForSecondTeam, null);
        }
    }
}

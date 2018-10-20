using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportBetApp.DTO;
using SportBetApp.Services.Contracts;
using SportBetApp.Web.Controllers;
using SportBetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportBetApp.UnitTests.Controllers
{
    [TestClass]
    public class EventControllerTests
    {
        [TestMethod]
        public void IndexShould_ReturnExpectedModel()
        {
            // Arrange
            var eventServiceMock = new Mock<IEventService>();
            var eventDto1 = new EventDto()
            {
                Id = 1,
                Name = "Test",
                OddsForFirstTeam = 1,
                OddsForDraw = 2,
                OddsForSecondTeam = 3,
                StartDate = DateTime.Now
            };

            var eventDto2 = new EventDto()
            {
                Id = 2,
                Name = "Test2",
                OddsForFirstTeam = 4,
                OddsForDraw = 5,
                OddsForSecondTeam = 6,
                StartDate = DateTime.Now
            };

            eventServiceMock.Setup(x => x.GetAll()).Returns(new List<EventDto>()
            {
                eventDto1, eventDto2
            });

            var controller = new EventController(eventServiceMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(2, result.ViewEngineCollection.Count);
        }

        [TestMethod]
        public void AddShould_ReturnExpectedView()
        {
            // Arrange
            var eventServiceMock = new Mock<IEventService>();
            var eventDto = new EventDto()
            {
                Id = 1,
                Name = "Test",
                OddsForFirstTeam = 1,
                OddsForDraw = 2,
                OddsForSecondTeam = 3,
                StartDate = DateTime.Now
            };

            eventServiceMock.Setup(x => x.Add()).Returns(eventDto);

            var controller = new EventController(eventServiceMock.Object);

            // Act
            var result = controller.Add() as PartialViewResult;

            // Assert
            Assert.AreEqual("AddPartial", result.ViewName);
        }
    }
}

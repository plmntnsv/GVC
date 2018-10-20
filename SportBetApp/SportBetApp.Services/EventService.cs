using System;
using System.Collections.Generic;
using System.Linq;
using SportBetApp.Data.Models;
using SportBetApp.DTO;
using SportBetApp.Repository.Contracts;
using SportBetApp.Services.Contracts;

namespace SportBetApp.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public EventDto Add()
        {
            var model = new Event()
            {
                StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 00)
            };

            var returnedEvent = this.eventRepository.Add(model);

            return new EventDto()
            {
                Id = returnedEvent.Id,
                StartDate = returnedEvent.StartDate
            };
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("Id cannot be less than one!");
            }

            this.eventRepository.Delete(id);
        }

        public void Edit(EventDto modelToEdit)
        {
            if (modelToEdit == null)
            {
                throw new ArgumentNullException("Provided model cannot be null!");
            }

            var model = new Event()
            {
                Id = modelToEdit.Id,
                Name = modelToEdit.Name,
                OddsForFirstTeam = modelToEdit.OddsForFirstTeam,
                OddsForDraw = modelToEdit.OddsForDraw,
                OddsForSecondTeam = modelToEdit.OddsForSecondTeam,
                StartDate = modelToEdit.StartDate
            };

            this.eventRepository.Edit(model);
        }

        public IEnumerable<EventDto> GetAll()
        {
            var events = this.eventRepository.GetAll().Select(e => new EventDto()
            {
                Id = e.Id,
                Name = e.Name,
                OddsForFirstTeam = e.OddsForFirstTeam,
                OddsForDraw = e.OddsForDraw,
                OddsForSecondTeam = e.OddsForSecondTeam,
                StartDate = e.StartDate
            });

            return events;
        }
    }
}

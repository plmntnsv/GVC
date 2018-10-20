using SportBetApp.Common.Exceptions;
using SportBetApp.Data;
using SportBetApp.Data.Models;
using SportBetApp.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBetApp.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly SportBetAppDbContext context;

        public EventRepository(SportBetAppDbContext context)
        {
            this.context = context;
        }

        public Event Add(Event modelToAdd)
        {
            if (modelToAdd == null)
            {
                throw new ArgumentNullException("Provided model cannot be null!");
            }

            this.context.Events.Add(modelToAdd);
            SaveChanges();

            return modelToAdd;
        }

        public void Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("Id cannot be less than one!");
            }

            var model = this.context.Events.FirstOrDefault(e => e.Id == id) ?? throw new EventNotFoundException("No event with that id found!");

            this.context.Events.Remove(model);
            SaveChanges();
        }

        public void Edit(Event modelToEdit)
        {
            if (modelToEdit == null)
            {
                throw new ArgumentNullException("Provided model is null!");
            }

            var model = this.context.Events.FirstOrDefault(e => e.Id == modelToEdit.Id) ?? throw new EventNotFoundException("No event with that id found!");

            model.Name = modelToEdit.Name;
            model.OddsForFirstTeam = modelToEdit.OddsForFirstTeam;
            model.OddsForDraw = modelToEdit.OddsForDraw;
            model.OddsForSecondTeam = modelToEdit.OddsForSecondTeam;
            model.StartDate = modelToEdit.StartDate;

            SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return context.Events.ToList();
        }

        private void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}

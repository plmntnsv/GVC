using SportBetApp.Data.Models;
using System.Collections.Generic;

namespace SportBetApp.Repository.Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event Add(Event modelToAdd);
        void Edit(Event modelToEdit);
        void Delete(int id);
    }
}

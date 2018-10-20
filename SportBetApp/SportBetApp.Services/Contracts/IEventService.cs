using SportBetApp.DTO;
using System.Collections.Generic;

namespace SportBetApp.Services.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAll();
        EventDto Add();
        void Edit(EventDto modelToEdit);
        void Delete(int id);
    }
}

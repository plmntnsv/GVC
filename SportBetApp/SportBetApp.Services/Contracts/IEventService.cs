using SportBetApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBetApp.Services.Contracts
{
    public interface IEventService
    {
        IEnumerable<EventDto> GetAll();
        void Add(EventDto modelToAdd);
        void Edit(EventDto modelToEdit);
        void Delete(int id);
    }
}

using SportBetApp.Repository.Contracts;
using SportBetApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBetApp.Services
{
    public class EventService : IEventService
    {
        public EventService(IEventRepository eventRepository)
        {

        }
    }
}

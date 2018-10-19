using SportBetApp.Data;
using SportBetApp.Data.Contracts;
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
        public EventRepository(ISportBetAppDbContext context)
        {

        }
    }
}

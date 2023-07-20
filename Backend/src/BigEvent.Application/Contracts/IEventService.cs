using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BigEvent.Core.Models;

namespace BigEvent.Application.Contracts
{
    public interface IEventService
    {
        
        // General Methods
        Task<Event> AddEvent(Event model);

        Task<Event> UpdateEvent(int eventId, Event model);

        Task<bool> DeleteEvent(int eventId);


        // Specific Methods
        Task<Event> GetEventById(int eventId, bool includeSpeakers);

        Task<IEnumerable<Event>> GetAllEvents(bool includeSpeakers);

        Task<IEnumerable<Event>> GetEventByTheme(string theme, bool includeSpeakers); 


    }
}
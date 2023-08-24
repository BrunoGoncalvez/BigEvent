using System.Threading.Tasks;
using System.Collections.Generic;

using BigEvent.Application.ModelsDTO;

namespace BigEvent.Application.Contracts
{
    public interface IEventService
    {
        
        // General Methods
        Task<EventDTO> AddEvent(EventDTO model);

        Task<EventDTO> UpdateEvent(int eventId, EventDTO model);

        Task<bool> DeleteEvent(int eventId);


        // Specific Methods
        Task<EventDTO> GetEventById(int eventId, bool includeSpeakers);

        Task<IEnumerable<EventDTO>> GetAllEvents(bool includeSpeakers);

        Task<IEnumerable<EventDTO>> GetEventsByTheme(string theme, bool includeSpeakers); 


    }
}
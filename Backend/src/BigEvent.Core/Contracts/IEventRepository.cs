using System.Collections.Generic;
using System.Threading.Tasks;
using BigEvent.Core.Models;

namespace BigEvent.Core.Contracts
{
    public interface IEventRepository
    {
        
        Task<IEnumerable<Event>> GetAllEvents(bool includeSpeaker = false);

        Task<IEnumerable<Event>> GetEventsByThemeAsync(string theme, bool includeSpeaker = false);

        Task<Event> GetEventById(int id, bool includeSpeaker = false);

    }
}
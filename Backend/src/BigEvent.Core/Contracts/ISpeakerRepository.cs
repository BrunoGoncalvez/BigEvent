using System.Collections.Generic;
using System.Threading.Tasks;

using BigEvent.Core.Models;

namespace BigEvent.Core.Contracts
{
    public interface ISpeakerRepository
    {

        Task<Speaker> GetSpeakerById(int id, bool includeEvents );

        Task<IEnumerable<Speaker>> GetAllSpeakers(bool includeEvents);

        Task<IEnumerable<Speaker>> GetSpeakersByName(string name, bool includeEvents);
        
    }
}
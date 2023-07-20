using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using BigEvent.Core.Contracts;
using BigEvent.Core.Models;
using BigEvent.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace BigEvent.Data.Repository
{
    public class SpeakerRepository : Repository, ISpeakerRepository
    {

        private readonly DataContext _context;

        public SpeakerRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Speaker> GetSpeakerById(int id, bool includeEvents = false)
        {
            IQueryable<Speaker> query = this._context.Speakers
                .Include(s => s.SocialMedias);

            if(includeEvents)
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            
            return await query.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Speaker>> GetAllSpeakers(bool includeEvents = false)
        {
            IQueryable<Speaker> query = this._context.Speakers
                .Include(s => s.SocialMedias);

            if(includeEvents)
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            
            return await query.AsNoTracking().OrderBy(s => s.Name).ToListAsync();           
        }

        public async Task<IEnumerable<Speaker>> GetSpeakersByName(string name, bool includeEvents = false)
        {
            IQueryable<Speaker> query = this._context.Speakers
                .Include(s => s.SocialMedias);

            if(includeEvents)
                query = query.Include(s => s.SpeakerEvents).ThenInclude(se => se.Event);
            
            return await query.AsNoTracking().OrderBy(s => s.Name).Where(s => s.Name.ToLower().Contains(name.ToLower())).ToListAsync(); 
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using BigEvent.Core.Contracts;
using BigEvent.Core.Models;
using BigEvent.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace BigEvent.Data.Repository
{
    public class EventRepository : Repository, IEventRepository
    {

        private readonly DataContext _context;

        public EventRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Event> GetEventById(int id, bool includeSpeaker = false)
        {
            IQueryable<Event> query = this._context.Events
                .Include(e => e.Allotments)
                .Include(e => e.SocialMedias);

            if(includeSpeaker)
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
        
            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Event>> GetAllEvents(bool includeSpeaker = false)
        {
            IQueryable<Event> query = this._context.Events
                .Include(e => e.Allotments)
                .Include(e => e.SocialMedias)
                .OrderBy(e => e.Id);
            
            if(includeSpeaker)
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByThemeAsync(string theme, bool includeSpeaker = false)
        {
            IQueryable<Event> query = this._context.Events
                .Include(e => e.Allotments)
                .Include(e => e.SocialMedias);

            if(includeSpeaker)
                query = query.Include(e => e.SpeakerEvents).ThenInclude(se => se.Speaker);
            
            query = query.AsNoTracking().OrderBy(e => e.Theme).Where(e => e.Theme.ToLower().Contains(theme.ToLower()));

            return await query.ToListAsync();
        }
    }
}
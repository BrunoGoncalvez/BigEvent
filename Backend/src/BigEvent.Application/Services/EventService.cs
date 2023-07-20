using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BigEvent.Application.Contracts;
using BigEvent.Core.Contracts;
using BigEvent.Core.Models;

namespace BigEvent.Application.Services
{
    public class EventService : IEventService
    {

        private readonly IRepository _repository;
        private readonly IEventRepository _eventRepository;
        private readonly ISpeakerRepository _speakerRepository;
        
        public EventService(IRepository repository, IEventRepository eventRepository, ISpeakerRepository speakerRepository )
        {
            this._repository = repository;
            this._eventRepository = eventRepository;
            this._speakerRepository = speakerRepository;
        }

        public async Task<Event> AddEvent(Event model)
        {
            try
            {
                await this._repository.AddAsync<Event>(model);
                var success = await this._repository.SaveChangesAsync();

                if(!success)
                    return null;
                
                return await this._eventRepository.GetEventById(model.Id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event model)
        {
            try
            {
                var ev = await this._eventRepository.GetEventById(eventId);
                if(ev == null) return null;

                model.Id = ev.Id;

                this._repository.Update<Event>(model);

                var success = await this._repository.SaveChangesAsync();

                if(!success) 
                    return null;

                return await this._eventRepository.GetEventById(model.Id); 

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            var ev = await this._eventRepository.GetEventById(eventId);
            if(ev == null) 
                throw new Exception("Event not found");

            this._repository.Delete<Event>(ev);
            var success = await this._repository.SaveChangesAsync();
            return success;
        }

        public async Task<IEnumerable<Event>> GetAllEvents(bool includeSpeakers = false)
        {
            try
            {
                var events = await this._eventRepository.GetAllEvents(includeSpeakers);
                if(events == null)
                    return null;
                
                return events;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> GetEventById(int eventId, bool includeSpeakers)
        {
            try
            {
                var ev = await this._eventRepository.GetEventById(eventId, includeSpeakers);
                if(ev == null)
                    return null;
                
                return ev;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Event>> GetEventByTheme(string theme, bool includeSpeakers)
        {
            try
            {
                var events = await this._eventRepository.GetEventsByThemeAsync(theme, includeSpeakers);
                if(events == null)
                    return null;
                
                return events;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
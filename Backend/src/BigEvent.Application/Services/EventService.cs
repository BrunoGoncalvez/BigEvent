using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using BigEvent.Application.Contracts;
using BigEvent.Application.ModelsDTO;
using BigEvent.Core.Contracts;
using BigEvent.Core.Models;

namespace BigEvent.Application.Services
{
    public class EventService : IEventService
    {

        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private readonly IEventRepository _eventRepository;
        private readonly ISpeakerRepository _speakerRepository;
        
        public EventService(IMapper mapper, IRepository repository, IEventRepository eventRepository, ISpeakerRepository speakerRepository )
        {
            this._mapper = mapper;
            this._repository = repository;
            this._eventRepository = eventRepository;
            this._speakerRepository = speakerRepository;
        }

        public async Task<EventDTO> AddEvent(EventDTO model)
        {
            try
            {

                var evt = this._mapper.Map<Event>( model );

                await this._repository.AddAsync<Event>(evt);
                var success = await this._repository.SaveChangesAsync();

                if (!success)
                    return null;

                var eventResponse = await this._eventRepository.GetEventById(evt.Id);
                return this._mapper.Map<EventDTO>(eventResponse);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EventDTO> UpdateEvent(int eventId, EventDTO model)
        {
            try
            {
                var ev = await this._eventRepository.GetEventById(eventId);
                if (ev == null) return null;
                model.Id = ev.Id;

                this._mapper.Map(model, ev);

                this._repository.Update<Event>(ev);

                var success = await this._repository.SaveChangesAsync();

                if (!success)
                    return null;

                var eventResponse = await this._eventRepository.GetEventById(ev.Id);
                return this._mapper.Map<EventDTO>(eventResponse);

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

        public async Task<IEnumerable<EventDTO>> GetAllEvents(bool includeSpeakers = false)
        {
            try
            {
                var events = await this._eventRepository.GetAllEvents(includeSpeakers);
                if(events == null)
                    return null;

                var eventsResponse = this._mapper.Map<IEnumerable<EventDTO>>(events);

                return eventsResponse;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<EventDTO> GetEventById(int eventId, bool includeSpeakers)
        {
            try
            {
                var eventModel = await this._eventRepository.GetEventById(eventId, includeSpeakers);
                if(eventModel == null)
                    return null;

                var evt = this._mapper.Map<EventDTO>(eventModel);
                
                return evt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<EventDTO>> GetEventsByTheme(string theme, bool includeSpeakers)
        {
            try
            {
                var events = await this._eventRepository.GetEventsByThemeAsync(theme, includeSpeakers);
                if(events == null)
                    return null;

                var eventsResponse = this._mapper.Map<IEnumerable<EventDTO>>(events);
                
                return eventsResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
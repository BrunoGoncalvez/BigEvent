using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using BigEvent.Application.Contracts;
using BigEvent.Application.Resources;
using BigEvent.Application.ModelsDTO;


namespace BigEvent.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() // IActionResult permite retornar StatusCode
        {
            try
            {
                var events = await this._eventService.GetAllEvents(false);

                if (events == null)
                    return NoContent();

                return Ok(events);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                     $"Error when trying to return events. Error: {e.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var ev = await this._eventService.GetEventById(id, false);

                if(ev == null)
                    return NoContent();

                return Ok(ev);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to return event. Error: {e.Message}");
            }
        }

        [HttpGet("theme/{theme}")]
        public async Task<IActionResult> GetByTheme(string theme)
        {
            try
            {
                var events = await this._eventService.GetEventsByTheme(theme, false);

                if(events == null)
                    return NoContent();

                return Ok(events);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to return event. Error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventDTO model)
        {
            try
            {
                var ev = await this._eventService.AddEvent(model);
                if(ev == null) return BadRequest(ErrorMessages.CreateEventError);
                return Ok(ev);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, EventDTO model)
        {

            try
            {
                var ev = await this._eventService.UpdateEvent(id, model);
                if(ev == null) return BadRequest("Erro updating event");
                return Ok(ev);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ev = await this._eventService.GetEventById(id, false);
                if(ev == null) return BadRequest("Error delete event");

                await this._eventService.DeleteEvent(22);
                return Ok(ev);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {e.Message}");
            }
        }

    }
}
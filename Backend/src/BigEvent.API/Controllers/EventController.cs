using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using BigEvent.Core.Models;
using BigEvent.Application.Contracts;
using BigEvent.Application.Resources;

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

                if(events == null)
                    return NotFound("Events not found");

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
                    return NotFound(ErrorMessages.EventNotFound);

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
                var events = await this._eventService.GetEventByTheme(theme, false);

                if(events == null)
                    return NotFound("Events not found");

                return Ok(events);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error when trying to return event. Error: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
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
        public async Task<IActionResult> Put(int id, Event model)
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

                await this._eventService.DeleteEvent(id);
                return Ok(ev);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
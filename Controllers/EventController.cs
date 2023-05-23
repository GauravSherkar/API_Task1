using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _dbContext;

        public EventController(EventContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent()
        {
            if (_dbContext.Events == null)
            {
                return NotFound();
            }
            return await _dbContext.Events.ToListAsync();
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<Event>> GetEvent(int uid)
        {
            if (_dbContext.Events == null)
            {
                return NotFound();
            };

            var events = await _dbContext.Events.FindAsync(uid);
            if (events == null)
            {
                return NotFound();
            }
            return events;

        }
        //[HttpPost]
        //public async Task<ActionResult<Event>> PostEvent(Event Event)
        //{
        //    _dbContext.Events.Add(Event);
        //    await _dbContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetEvent), new { id = Event.uid }, Event);
        //}

        [HttpPost]
        public async Task<ActionResult> AddEvent(AddEventRequest addEventRequest)
        {

            var events = new Event()
            {

                type = addEventRequest.type,
                name = addEventRequest.name,
                tagline = addEventRequest.tagline,
                Schedule = addEventRequest.Schedule,
                description = addEventRequest.description,
                files = addEventRequest.files,
                moderator = addEventRequest.moderator,
                category = addEventRequest.category,
                sub_category = addEventRequest.sub_category,
                rigor_rank = addEventRequest.rigor_rank,
                attendees = addEventRequest.attendees

            };
            await _dbContext.Events.AddAsync(events);
            await _dbContext.SaveChangesAsync();


            return Ok(events);
            
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEvent(int id,UpdateEventRequest updateEventRequest)
        {
            var events = await _dbContext.Events.FindAsync(id);
            if (events != null)
            {
                events.type = updateEventRequest.type;
                events.name = updateEventRequest.name;
                events.tagline = updateEventRequest.tagline;
                events.Schedule = updateEventRequest.Schedule;
                events.description = updateEventRequest.description;
                events.files = updateEventRequest.files;
                events.moderator = updateEventRequest.moderator;
                events.category = updateEventRequest.category;
                events.sub_category = updateEventRequest.sub_category;
                events.rigor_rank = updateEventRequest.rigor_rank;
                events.attendees = updateEventRequest.attendees;
            };
            await _dbContext.SaveChangesAsync();
            return Ok(events);
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteEvent(int id)
        {
            var events = await _dbContext.Events.FindAsync(id);
            if (events != null)
            {
                _dbContext.Remove(events);
                await _dbContext.SaveChangesAsync();
                return Ok(events);
            }
            return NotFound();
           
        }
       
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZieDitAPI.Dto;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;

namespace ZieDitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Event>))]
        public IActionResult GetEvents()
        {
            var events = _mapper.Map<List<EventDto>>(_eventRepository.GetEvents());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetEvent(int eventId)
        {
            if (!_eventRepository.EventExists(eventId))
                return NotFound();

            var events = _mapper.Map<EventDto>(_eventRepository.GetEvent(eventId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}/poster")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetPosterByEvent(int eventId)
        {
            if (!_eventRepository.EventExists(eventId))
            {
                return NotFound();
            }

            var events = _mapper.Map<List<PosterDto>>(
                _eventRepository.GetPosterByEvent(eventId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(events);
        }

        [HttpGet("{eventId}/visitor")]
        [ProducesResponseType(200, Type = typeof(Event))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitorByEvent(int eventId)
        {
            if (!_eventRepository.EventExists(eventId))
            {
                return NotFound();
            }

            var visitors = _mapper.Map<List<VisitorDto>>(
                _eventRepository.GetVisitorByEvent(eventId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(visitors);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateEvent([FromBody] EventDto eventCreate)
        {
            if (eventCreate == null)
                return BadRequest(ModelState);

            var evenement = _eventRepository.GetEvents()
                .Where(c => c.EventTitle.Trim().ToUpper() == eventCreate.EventTitle.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (evenement != null)
            {
                ModelState.AddModelError("", "Event already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventMap = _mapper.Map<Event>(eventCreate);
            if (!_eventRepository.CreateEvent(eventMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving event.");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created.");
        }

        [HttpPut("{eventId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEvent(int eventId, [FromBody] EventDto updatedEvent)
        {
            if (updatedEvent == null)
                return BadRequest(ModelState);

            if (eventId != updatedEvent.Id)
                return BadRequest(ModelState);

            if (!_eventRepository.EventExists(eventId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var eventMap = _mapper.Map<Event>(updatedEvent);

            if (!_eventRepository.UpdateEvent(eventMap))
            {
                ModelState.AddModelError("", "Something went wrong updating event.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEvent(int eventId) 
        {
            if (!_eventRepository.EventExists(eventId))
            {
                return NotFound();
            }

            var eventToDelete = _eventRepository.GetEvent(eventId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_eventRepository.DeleteEvent(eventToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting event.");
            }

            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZieDitAPI.Dto;
using ZieDitAPI.Interfaces;
using ZieDitAPI.Models;
using ZieDitAPI.Repository;

namespace ZieDitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterController : Controller
    {
        private readonly IPosterRepository _posterRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public PosterController(IPosterRepository posterRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _posterRepository = posterRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Poster>))]
        public IActionResult GetPosters()
        {
            var posters = _mapper.Map<List<PosterDto>>(_posterRepository.GetPosters());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posters);
        }

        [HttpGet("{posterId}")]
        [ProducesResponseType(200, Type = typeof(Poster))]
        [ProducesResponseType(400)]
        public IActionResult GetPoster(int posterId)
        {
            if (!_posterRepository.PosterExists(posterId))
                return NotFound();

            var poster = _mapper.Map<PosterDto>(_posterRepository.GetPoster(posterId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(poster);
        }

        [HttpGet("{posterId}/presenter")]
        [ProducesResponseType(200, Type = typeof(Poster))]
        [ProducesResponseType(400)]
        public IActionResult GetPresenterOfAPoster(int posterId)
        {
            if (!_posterRepository.PosterExists(posterId))
            {
                return NotFound();
            }

            var presenters = _mapper.Map<List<PresenterDto>>(
                _posterRepository.GetPresenterOfAPoster(posterId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(presenters);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePoster([FromQuery] int eventId, [FromBody] PosterDto posterCreate)
        {
            if (posterCreate == null)
                return BadRequest(ModelState);

            var poster = _posterRepository.GetPosters()
                .Where(c => c.PosterImagePath.Trim().ToUpper() == posterCreate.PosterImagePath.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (poster != null)
            {
                ModelState.AddModelError("", "Poster already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var posterMap = _mapper.Map<Poster>(posterCreate);

            posterMap.Event = _eventRepository.GetEvent(eventId);

            if (!_posterRepository.CreatePoster(posterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving poster");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created.");
        }

        [HttpPut("{posterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePoster(int posterId, [FromBody] PosterDto updatedPoster)
        {
            if (updatedPoster == null)
                return BadRequest(ModelState);

            if (posterId != updatedPoster.Id)
                return BadRequest(ModelState);

            if (!_posterRepository.PosterExists(posterId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var posterMap = _mapper.Map<Poster>(updatedPoster);

            if (!_posterRepository.UpdatePoster(posterMap))
            {
                ModelState.AddModelError("", "Something went wrong updating poster.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{posterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePoster(int posterId)
        {
            if (!_posterRepository.PosterExists(posterId))
            {
                return NotFound();
            }

            var posterToDelete = _posterRepository.GetPoster(posterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_posterRepository.DeletePoster(posterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting poster.");
            }

            return NoContent();
        }
    }
}

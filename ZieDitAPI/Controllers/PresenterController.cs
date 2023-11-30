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
    public class PresenterController : Controller
    {
        private readonly IPresenterRepository _presenterRepository;
        private readonly IPosterRepository _posterRepository;
        private readonly IMapper _mapper;

        public PresenterController(IPresenterRepository presenterRepository, IPosterRepository posterRepository, IMapper mapper)
        {
            _presenterRepository = presenterRepository;
            _posterRepository = posterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Presenter>))]
        public IActionResult GetPresenters()
        {
            var presenters = _mapper.Map<List<PresenterDto>>(_presenterRepository.GetPresenters());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(presenters);
        }

        [HttpGet("{presenterId}")]
        [ProducesResponseType(200, Type = typeof(Presenter))]
        [ProducesResponseType(400)]
        public IActionResult GetPresenter(int presenterId)
        {
            if (!_presenterRepository.PresenterExists(presenterId))
                return NotFound();

            var presenter = _mapper.Map<PresenterDto>(_presenterRepository.GetPresenter(presenterId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(presenter);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePresenter([FromQuery] int posterId, [FromBody] PresenterDto presenterCreate)
        {
            if (presenterCreate == null)
                return BadRequest(ModelState);

            var presenter = _presenterRepository.GetPresenters()
                .Where(c => c.PresenterLastName.Trim().ToUpper() == presenterCreate.PresenterLastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (presenter != null)
            {
                ModelState.AddModelError("", "Presenter already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var presenterMap = _mapper.Map<Presenter>(presenterCreate);

            presenterMap.Posters = _posterRepository.GetPoster(posterId);

            if (!_presenterRepository.CreatePresenter(presenterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving presenter");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created.");
        }

        [HttpPut("{presenterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePresenter(int presenterId, [FromBody] PresenterDto updatedPresenter)
        {
            if (updatedPresenter == null)
                return BadRequest(ModelState);

            if (presenterId != updatedPresenter.Id)
                return BadRequest(ModelState);

            if (!_presenterRepository.PresenterExists(presenterId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var presenterMap = _mapper.Map<Presenter>(updatedPresenter);

            if (!_presenterRepository.UpdatePresenter(presenterMap))
            {
                ModelState.AddModelError("", "Something went wrong updating presenter.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{presenterId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePresenter(int presenterId)
        {
            if (!_presenterRepository.PresenterExists(presenterId))
            {
                return NotFound();
            }

            var presenterToDelete = _presenterRepository.GetPresenter(presenterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_presenterRepository.DeletePresenter(presenterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting presenter.");
            }

            return NoContent();
        }
    }
}

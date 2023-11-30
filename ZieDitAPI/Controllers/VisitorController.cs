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
    public class VisitorController : Controller
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorRepository visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Visitor>))]
        public IActionResult GetVisitors()
        {
            var visitors = _mapper.Map<List<VisitorDto>>(_visitorRepository.GetVisitors());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(visitors);
        }

        [HttpGet("{visitorId}")]
        [ProducesResponseType(200, Type = typeof(Visitor))]
        [ProducesResponseType(400)]
        public IActionResult GetVisitor(int visitorId)
        {
            if (!_visitorRepository.VisitorExists(visitorId))
                return NotFound();

            var visitor = _mapper.Map<VisitorDto>(_visitorRepository.GetVisitor(visitorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(visitor);
        }
    }
}

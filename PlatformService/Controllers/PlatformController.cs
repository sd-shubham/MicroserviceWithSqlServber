using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/platform")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public PlatformController(IPlatformRepository platformRepository,
        IMapper mapper
        , IHttpContextAccessor contextAccessor)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatform()
        {
            var platforms = _platformRepository.GetPlatforms();
            var platformReadDto = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
            return Ok(platformReadDto);
        }

        [HttpPost]
        public ActionResult CreatePlatform(PlatformCreateDto createDto)
        {
            var platform = _mapper.Map<Platform>(createDto);
            _platformRepository.CreatePlatform(platform);
            bool result = _platformRepository.SaveChanges();
            var message = result ? "created successfully" : "somthing went wrong while creating record";
            return Ok(message);

        }
        [HttpGet("{id}")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platform = _platformRepository.GetPlatformById(id);
            if (platform is null) return NotFound();
            return Ok(_mapper.Map<PlatformReadDto>(platform));
        }
    }
}
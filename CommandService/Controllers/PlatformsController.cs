using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CommandService.Data;
using CommandService.Dtos;

namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;
        
        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            System.Console.WriteLine("--> Getting Platforms from CommandsService");

            var platformItems = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }  

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            System.Console.WriteLine("--> Inbound POST # Command Service");

            return Ok("Inbound test of from Platfoms Controller");
        }
    }
}
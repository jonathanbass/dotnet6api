namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {

        private readonly ILogger<DogsController> _logger;
        private readonly IDogRepository _dogRepository;

        public DogsController(ILogger<DogsController> logger, IDogRepository dogRepository)
        {
            _logger = logger;
            _dogRepository = dogRepository;
        }



        [HttpGet]
        public IEnumerable<Dog> GetDogs()
        {
            _logger.LogDebug("Get all dogs called");
            return _dogRepository.GetDogs();
        }

        [HttpPost]
        public string AddDog([FromBody] Dog dog)
        {
            return _dogRepository.AddDog(dog);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateDog([FromRoute] string id, [FromBody] Dog dog)
        {
            _dogRepository.UpdateDog(id, dog);
        }

        [HttpDelete]
        [Route("{id}")]
        public void RemoveDog([FromRoute] string id)
        {
            _dogRepository.RemoveDog(id);
        }

    }
}
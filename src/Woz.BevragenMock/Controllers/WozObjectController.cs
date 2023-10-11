using Microsoft.AspNetCore.Mvc;
using Woz.BevragenMock.Generated;
using Woz.BevragenMock.Repositories;

namespace Woz.BevragenMock.Controllers
{
    [ApiController]
    public class WozObjectController : Generated.ControllerBase
    {
        private readonly WozObjectRepository _repository;

        public WozObjectController(WozObjectRepository repository)
        {
            _repository = repository;
        }
        public override async Task<ActionResult<WozObjectHal>> RaadpleegActueelWozobject(string identificatie, [FromQuery] string fields)
        {
            var retval = await _repository.Raadpleeg(identificatie);

            return retval != null
                ? Ok(retval)
                : NotFound();
        }

        public override async Task<ActionResult<WozObjectHalCollectie>> ZoekActueleWozobjecten([FromQuery] ZoekFilter zoekFilter)
        {
            var retval = await _repository.Zoek(zoekFilter);

            return Ok(retval);
        }
    }
}

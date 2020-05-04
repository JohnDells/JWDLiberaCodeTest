using LiberaLineDistanceApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiberaLineDistanceApi.Controllers
{
    [ApiController]
    public class StreetDistanceController : ControllerBase
    {
        private readonly IStreetManager _streetManager;

        public StreetDistanceController(IStreetManager streetManager)
        {
            _streetManager = streetManager;
        }

        [HttpGet]
        [Route("[controller]/closest")]
        public IActionResult Get(float x, float y)
        {
            var result = _streetManager.GetClosest(x, y);
            if (result != null)
            {
                return Ok(result);
            }

            return new NoContentResult();
        }

        [HttpPost]
        [Route("[controller]/street")]
        public void Add(StreetDto item)
        {
            _streetManager.Add(item);
        }
    }
}
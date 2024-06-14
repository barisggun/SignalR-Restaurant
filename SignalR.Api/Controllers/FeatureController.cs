using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.FeatureDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _FeatureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _FeatureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature Feature = new Feature()
            {
               Description1 = createFeatureDto.Description1,
               Description2 = createFeatureDto.Description2,
               Description3 = createFeatureDto.Description3,
               Title1 = createFeatureDto.Title1,
               Title2 = createFeatureDto.Title2,
               Title3 = createFeatureDto.Title3
               
            };
            _FeatureService.TAdd(Feature);
            return Ok("Feature added");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _FeatureService.TGetByID(id);
            _FeatureService.TDelete(values);

            return Ok("Feature deleted");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature Feature = new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Description1 = updateFeatureDto.Description1,
                Description2 = updateFeatureDto.Description2,
                Description3 = updateFeatureDto.Description3,
                Title1 = updateFeatureDto.Title1,
                Title2 = updateFeatureDto.Title2,
                Title3 = updateFeatureDto.Title3
            };
            _FeatureService.TUpdate(Feature);
            return Ok("Feature updated");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _FeatureService.TGetByID(id);
            return Ok(value);
        }
    }
}

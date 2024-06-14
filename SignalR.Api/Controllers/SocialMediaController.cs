using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.SocialMediaDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;

        public SocialMediaController(ISocialMediaService SocialMediaService)
        {
            _SocialMediaService = SocialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _SocialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia SocialMedia = new SocialMedia()
            {
              Icon = createSocialMediaDto.Icon,
              Title = createSocialMediaDto.Title,
            };
            _SocialMediaService.TAdd(SocialMedia);
            return Ok("SocialMedia added");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _SocialMediaService.TGetByID(id);
            _SocialMediaService.TDelete(values);

            return Ok("SocialMedia deleted");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia SocialMedia = new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
            };
            _SocialMediaService.TUpdate(SocialMedia);
            return Ok("SocialMedia updated");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetByID(id);
            return Ok(value);
        }
    }
}

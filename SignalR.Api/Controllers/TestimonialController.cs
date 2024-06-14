using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.TestimonialDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _TestimonialService;

        public TestimonialController(ITestimonialService TestimonialService)
        {
            _TestimonialService = TestimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _TestimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial Testimonial = new Testimonial()
            {
                Title = createTestimonialDto.Title,
                Name = createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = createTestimonialDto.Status

            };
            _TestimonialService.TAdd(Testimonial);
            return Ok("Testimonial added");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _TestimonialService.TGetByID(id);
            _TestimonialService.TDelete(values);

            return Ok("Testimonial deleted");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial Testimonial = new Testimonial()
            {
                TestimonialID = updateTestimonialDto.TestimonialID,
                Title = updateTestimonialDto.Title,
                Name = updateTestimonialDto.Name,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status
            };
            _TestimonialService.TUpdate(Testimonial);
            return Ok("Testimonial updated");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _TestimonialService.TGetByID(id);
            return Ok(value);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.DiscountDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _DiscountService;

        public DiscountController(IDiscountService DiscountService)
        {
            _DiscountService = DiscountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _DiscountService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount Discount = new Discount()
            {
                Description = createDiscountDto.Description,
                Title = createDiscountDto.Title,
                ImageUrl = createDiscountDto.ImageUrl,
                Amount = createDiscountDto.Amount
            };
            _DiscountService.TAdd(Discount);
            return Ok("Discount added");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _DiscountService.TGetByID(id);
            _DiscountService.TDelete(values);

            return Ok("Discount deleted");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount Discount = new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Description = updateDiscountDto.Description,
                Title = updateDiscountDto.Title,
                ImageUrl = updateDiscountDto.ImageUrl,
                Amount = updateDiscountDto.Amount
            };
            _DiscountService.TUpdate(Discount);
            return Ok("Discount updated");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _DiscountService.TGetByID(id);
            return Ok(value);
        }
    }
}

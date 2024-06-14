using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.ContactDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _ContactService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact Contact = new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone
            };
            _ContactService.TAdd(Contact);
            return Ok("Contact added");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _ContactService.TGetByID(id);
            _ContactService.TDelete(values);

            return Ok("Contact deleted");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact Contact = new Contact()
            {
                ContactID = updateContactDto.ContactID,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone
            };
            _ContactService.TUpdate(Contact);
            return Ok("Contact updated");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _ContactService.TGetByID(id);
            return Ok(value);
        }
    }
}

using AutoMapper;
using SignalR.Dto.ContactDto;
using SignalR.Entity.Entities;

namespace SignalR.Api.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
        }
    }
}

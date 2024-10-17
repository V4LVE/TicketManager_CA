using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Features.Events;
using TicketManager.Management.Domain.Entities;

namespace TicketManager.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Events
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}

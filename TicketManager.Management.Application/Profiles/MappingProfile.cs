using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManager.Management.Application.Features.Categories.Queries.GetCategoriesListWithEvent;
using TicketManager.Management.Application.Features.Events.Commands.CreateEvent;
using TicketManager.Management.Application.Features.Events.Commands.UpdateEvent;
using TicketManager.Management.Application.Features.Events.Queries.GetEventDetail;
using TicketManager.Management.Application.Features.Events.Queries.GetEventsList;
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

            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
        }
    }
}

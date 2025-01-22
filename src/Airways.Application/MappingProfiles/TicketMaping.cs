using Airways.Application.Models.Ticket;
using Airways.Core.Entity;
using AutoMapper;

namespace Airways.Application.MappingProfiles
{
    public class TicketMaping:Profile
    {
        public TicketMaping()
        {
            CreateMap<CreateTicketsModel, Ticket>();
            CreateMap<UpdateTicketModel, Ticket>().ReverseMap();

            CreateMap<Ticket, TicketResponceModel>();
        }
    }
}

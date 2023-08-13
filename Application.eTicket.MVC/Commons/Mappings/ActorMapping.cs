using Application.eTicket.MVC.UseCases.Actors.Commands;
using Application.eTicket.MVC.UseCases.Actors.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
public class ActorMapping : Profile
{
    public ActorMapping()
    {
        CreateMap<ActorResponce, Actor>().ReverseMap();
        CreateMap<CreateActorCommand, Actor>().ReverseMap();
    }
}

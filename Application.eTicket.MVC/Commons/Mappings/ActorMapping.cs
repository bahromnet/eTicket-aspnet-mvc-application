using Application.eTicket.MVC.UseCases.Actor.Commands;
using Application.eTicket.MVC.UseCases.Actor.Responce;
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

using Application.eTicket.MVC.UseCases.Cinemas.Commands;
using Application.eTicket.MVC.UseCases.Cinemas.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
public class CinemaMapping : Profile
{
    public CinemaMapping()
    {
        CreateMap<CinemaResponce, Cinema>().ReverseMap();
        CreateMap<CreateCinemaCommand, Cinema>().ReverseMap();
    }
}

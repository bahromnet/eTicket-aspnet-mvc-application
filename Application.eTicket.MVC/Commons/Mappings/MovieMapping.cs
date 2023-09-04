using Application.eTicket.MVC.UseCases.Movies.Commands;
using Application.eTicket.MVC.UseCases.Movies.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
public class MovieMapping : Profile
{
    public MovieMapping()
    {
        CreateMap<MovieResponce, Movie>().ReverseMap();
        CreateMap<CreateMovieCommand,  Movie>().ReverseMap();
    }
}

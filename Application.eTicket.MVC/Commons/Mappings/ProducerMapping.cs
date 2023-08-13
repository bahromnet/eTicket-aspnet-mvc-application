using Application.eTicket.MVC.UseCases.Producers.Commands;
using Application.eTicket.MVC.UseCases.Producers.Responce;
using AutoMapper;
using Domain.eTicket.MVC.Entities;

namespace Application.eTicket.MVC.Commons.Mappings;
public class ProducerMapping : Profile
{
    public ProducerMapping()
    {
        CreateMap<ProducerResponce, Producer>().ReverseMap();
        CreateMap<CreateProducerCommand, Producer>().ReverseMap();

    }
}

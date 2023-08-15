using Application.eTicket.MVC.Commons.Interfaces;
using AutoMapper;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Producers.Commands;
public record CreateProducerCommand : IRequest<Ulid>
{
    public string ProducerName { get; }
    public IFormFile? ProducerImage { get; }
    public string ProducerBio { get; }
}

public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, Ulid>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public CreateProducerCommandHandler(IMapper mapper, IApplicationDbContext context, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
    }

    public async Task<Ulid> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
    {
        var producer = _mapper.Map<Producer>(request);
        if (request.ProducerImage is not null)
        {
            producer.Id = Ulid.NewUlid();
            var producerImage = _configuration["ProducerImagePath"];
            string fileName = producer.Id + Path.GetExtension(request.ProducerImage.FileName);
            string producerImagePath = Path.Combine(producerImage, fileName);
            using (var fs = new FileStream(producerImagePath, FileMode.Create))
            {
                await request.ProducerImage.CopyToAsync(fs);
                producer.ProducerImage = producerImagePath;
            };
        }
        await _context.Producers.AddAsync(producer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return producer.Id;
    }
}

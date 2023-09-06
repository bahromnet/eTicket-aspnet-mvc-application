using Application.eTicket.MVC.Commons.Exceptions;
using Application.eTicket.MVC.Commons.Interfaces;
using Domain.eTicket.MVC.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.eTicket.MVC.UseCases.Producers.Commands;
public record UpdateProducerCommand : IRequest
{
    public Ulid Id { get; }
    public string ProducerName { get; }
    public IFormFile? ProducerImage { get; }
    public string ProducerBio { get; }
}

public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _config;

    public UpdateProducerCommandHandler(IApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public async Task Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
    {
        var foundProducer = await _context.Producers.FindAsync(new object[] { request.Id }, cancellationToken)
            ?? throw new NotFoundException(nameof(Producer), request.Id);

        foundProducer.ProducerName = request.ProducerName;
        foundProducer.ProducerBio = request.ProducerBio;
        if (request.ProducerImage is not null)
        {
            string? producerImageConfig = _config["ProducerImages"];
            string producerImageName = request.Id + Path.GetExtension(request.ProducerImage.FileName);
            string producerImagePath = Path.Combine(producerImageConfig, producerImageName);
            using (FileStream fs = new FileStream(producerImagePath, FileMode.Create))
            {
                await request.ProducerImage.CopyToAsync(fs);
                foundProducer.ProducerImage = producerImagePath;
            }
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

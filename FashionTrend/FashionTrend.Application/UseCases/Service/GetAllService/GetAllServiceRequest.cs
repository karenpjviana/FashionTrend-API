using MediatR;

public sealed record GetAllServiceRequest : IRequest<List<Service>>;
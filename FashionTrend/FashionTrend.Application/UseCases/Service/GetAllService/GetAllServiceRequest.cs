using MediatR;

public sealed record GetAllServiceRequest : IRequest<List<GetAllServiceResponse>>;
using MediatR;

public sealed record GetByTypeServiceRequest(ERequestType Type) : IRequest<List<GetByTypeServiceResponse>>;
using MediatR;

public sealed record GetServiceRequest(Guid Id) : IRequest<GetServiceResponse>;
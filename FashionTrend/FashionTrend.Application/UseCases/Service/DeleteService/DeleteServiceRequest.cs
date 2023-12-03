using MediatR;

public sealed record DeleteServiceRequest(Guid Id) : IRequest<DeleteServiceResponse>;
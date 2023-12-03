using MediatR;

public sealed record DeleteServiceOrderRequest(Guid Id) : IRequest<DeleteServiceOrderResponse>;
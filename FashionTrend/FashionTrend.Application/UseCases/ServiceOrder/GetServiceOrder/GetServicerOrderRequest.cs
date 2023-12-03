using MediatR;

public sealed record GetServiceOrderRequest(Guid Id) : IRequest<GetServiceOrderResponse>;
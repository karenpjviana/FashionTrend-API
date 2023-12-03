using MediatR;

public sealed record GetByServiceIdServiceOrderRequest(Guid Id) : IRequest<GetByServiceIdServiceOrderResponse>;
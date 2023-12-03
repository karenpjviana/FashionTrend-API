using MediatR;

public sealed record GetAllServiceOrderRequest : IRequest<List<GetAllServiceOrderResponse>>;
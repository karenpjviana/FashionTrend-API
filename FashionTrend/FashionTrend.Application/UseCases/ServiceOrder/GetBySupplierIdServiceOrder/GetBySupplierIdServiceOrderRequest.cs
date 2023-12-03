using MediatR;

public sealed record GetBySupplierIdServiceOrderRequest(Guid Id) : IRequest<List<GetBySupplierIdServiceOrderResponse>>;
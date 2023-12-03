using MediatR;

public sealed record UpdateServiceOrderRequest(
    Guid Id,
    ERequestStatus Status
    ) : IRequest<UpdateServiceOrderResponse>;
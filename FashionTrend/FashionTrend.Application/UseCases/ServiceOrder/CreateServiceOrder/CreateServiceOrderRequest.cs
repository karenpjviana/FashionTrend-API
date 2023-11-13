using MediatR;

public sealed record CreateServiceOrderRequest(
    Guid SupplierId,
    Guid ServiceId,
    DateTimeOffset EstimetedDate,
    ERequestStatus Status
    ) : IRequest<CreateServiceOrderResponse>;
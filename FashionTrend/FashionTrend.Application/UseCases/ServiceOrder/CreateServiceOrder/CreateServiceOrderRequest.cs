using MediatR;

public sealed record CreateServiceOrderRequest(
    Supplier Supplier,
    Service Service,
    DateTimeOffset EstimetedDate,
    ERequestStatus Status,
    bool Payment
    ) : IRequest<CreateServiceOrderResponse>;


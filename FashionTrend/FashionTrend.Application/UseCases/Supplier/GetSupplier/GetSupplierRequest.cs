using MediatR;

public sealed record GetSupplierRequest(Guid Id) : IRequest<GetSupplierResponse>;
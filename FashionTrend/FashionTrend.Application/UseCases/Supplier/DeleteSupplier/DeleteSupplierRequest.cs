using MediatR;

public sealed record DeleteSupplierRequest(Guid Id) : IRequest<DeleteSupplierResponse>;
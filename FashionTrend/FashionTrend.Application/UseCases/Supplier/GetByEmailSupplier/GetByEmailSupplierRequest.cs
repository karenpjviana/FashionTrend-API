using MediatR;

public sealed record GetByEmailSupplierRequest(string Email) : IRequest<GetByEmailSupplierResponse>;
using MediatR;

public sealed record GetAllSupplierRequest : IRequest<List<GetAllSupplierResponse>>;
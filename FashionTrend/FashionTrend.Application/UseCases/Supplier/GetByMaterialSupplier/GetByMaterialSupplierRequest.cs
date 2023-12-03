using MediatR;

public sealed record GetByMaterialSupplierRequest(string Material) : IRequest<List<GetByMaterialSupplierResponse>>;
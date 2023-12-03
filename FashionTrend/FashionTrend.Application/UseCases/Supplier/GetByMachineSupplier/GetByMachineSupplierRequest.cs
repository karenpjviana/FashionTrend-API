using MediatR;

public sealed record GetByMachineSupplierRequest(ESewingMachine Machine) : IRequest<List<GetByMachineSupplierResponse>>;
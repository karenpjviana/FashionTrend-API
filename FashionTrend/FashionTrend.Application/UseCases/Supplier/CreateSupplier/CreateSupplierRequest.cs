using MediatR;

public sealed record CreateSupplierRequest(
    string Name,
    string Email,
    string Password,
    List<EMaterial> Materials,
    List<ESewingMachine> SewingMachines
    ) : IRequest<CreateSupplierResponse>;
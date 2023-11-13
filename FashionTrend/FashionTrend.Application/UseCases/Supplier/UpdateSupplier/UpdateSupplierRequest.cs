using MediatR;

public sealed record UpdateSupplierRequest(
    Guid Id,
    string Name,
    string Email,
    string Password,
    List<EMaterial> Materials,
    List<ESewingMachine> SewingMachines
    ) : IRequest<UpdateSupplierResponse>;
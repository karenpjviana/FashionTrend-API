using MediatR;

public sealed record UpdateServiceRequest(
    Guid Id,
    string Description,
    bool Delivery,
    ERequestType Type,
    List<ESewingMachine> SewingMachines,
    List<EMaterial> Materials,
    decimal Price
    ) : IRequest<UpdateServiceResponse>;
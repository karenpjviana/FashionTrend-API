using MediatR;

public sealed record CreateServiceRequest(
    string Description,
    bool Delivery,
    ERequestType Type,
    List<EMaterial> Materials,
    List<ESewingMachine> SewingMachines
    ) : IRequest<CreateServiceResponse>;


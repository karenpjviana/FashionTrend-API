﻿using MediatR;

public sealed record CreateServiceRequest(
    string Description,
    bool Delivery,
    ERequestType Type,
    List<ESewingMachine> SewingMachines,
    List<EMaterial> Materials,
    decimal Price
    ) : IRequest<CreateServiceResponse>;
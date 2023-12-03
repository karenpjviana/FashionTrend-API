using MediatR;

public sealed record CreateContractRequest (
    Supplier supplier, 
    Service servise, 
    string Description, 
    DraftContract DraftContract
    ) : IRequest<CreateContractResponse>;


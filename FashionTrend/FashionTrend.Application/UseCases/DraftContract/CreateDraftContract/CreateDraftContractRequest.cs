using MediatR;

public sealed record CreateDraftContractRequest (
    ServiceOrder ServiceOrder, 
    string Description
    ) : IRequest<CreateDraftContractResponse>;

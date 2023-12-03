using MediatR;

public sealed record CreateDraftContractRequest (
    Supplier Supplier, Service Service, string Description
    ) : IRequest<CreateDraftContractResponse>;

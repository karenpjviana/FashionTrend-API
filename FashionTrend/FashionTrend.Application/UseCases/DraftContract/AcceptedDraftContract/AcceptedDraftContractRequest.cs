using MediatR;

public sealed record AcceptedDraftContractRequest (
    Guid Id,
    DraftContract Draft,
    bool Accepted
    ) : IRequest<AcceptedDraftContractResponse>;

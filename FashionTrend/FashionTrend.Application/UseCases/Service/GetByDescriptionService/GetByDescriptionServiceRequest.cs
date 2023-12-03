using MediatR;

public sealed record GetByDescriptionServiceRequest(string Description) : IRequest<GetByDescriptionServiceResponse>;
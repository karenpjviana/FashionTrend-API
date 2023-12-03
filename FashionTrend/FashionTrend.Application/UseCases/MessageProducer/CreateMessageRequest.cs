using MediatR;

public sealed record CreateMessageRequest(
    string sender,
    string receiver,
    string content,
    string topic
    ) : IRequest<CreateMessageResponse>;
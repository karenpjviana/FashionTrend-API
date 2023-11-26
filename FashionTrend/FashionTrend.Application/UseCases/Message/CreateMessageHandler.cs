using AutoMapper;
using MediatR;

public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, CreateMessageResponse>
{ 
    private readonly IKafkaProducer _kafkaProducer;
    private readonly IMapper _mapper;

    public CreateMessageHandler(IKafkaProducer kafkaRepository, IMapper mapper)
    {
        _kafkaProducer = kafkaRepository;
        _mapper = mapper;
    }

    public async Task<CreateMessageResponse> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var message = await _kafkaProducer.ProduceAsync(
            request.topic,
            request.sender,
            request.receiver,
            request.content);
        return _mapper.Map<CreateMessageResponse>(message);
    }
}
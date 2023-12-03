using AutoMapper;
using MediatR;

public class CreateDraftContractHandler : IRequestHandler<CreateDraftContractRequest, CreateDraftContractResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDraftContractRepository _draftRepository;
    private readonly IMapper _mapper;
    private readonly IKafkaProducer _kafkaRepository;


    public CreateDraftContractHandler(IUnitOfWork unitOfWork,
        IDraftContractRepository draftRepository,
        IMapper mapper, IKafkaProducer kafkaRepository)
    {
        _unitOfWork = unitOfWork;
        _draftRepository = draftRepository;
        _mapper = mapper;
        _kafkaRepository = kafkaRepository;
    }

    public async Task<CreateDraftContractResponse> Handle(CreateDraftContractRequest request, CancellationToken cancellationToken)
    {
        var draft = _mapper.Map<DraftContract>(request);

        _draftRepository.Create(draft);

        await _unitOfWork.Commit(cancellationToken);


        var notification = new CreateNotificationHandler("AC707d8afa36844454da6d1fd1a2e2b8e7", "2d820c66817ee777f50e0e9d29540c49", "+14133531057");

        notification.SendSMS("+5579999440110", "Minuta de contrato de serviço criada com sucesso!");

        return _mapper.Map<CreateDraftContractResponse>(draft);
    }
}
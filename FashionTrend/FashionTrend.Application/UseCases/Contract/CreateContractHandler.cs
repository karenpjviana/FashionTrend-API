using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class CreateContractHandler : IRequestHandler<CreateContractRequest, CreateContractResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IContractRepository _contractRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateContractHandler> _logger;

    public CreateContractHandler(IUnitOfWork unitOfWork, IContractRepository contractRepository,
        IMapper mapper, ILogger<CreateContractHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _contractRepository = contractRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateContractResponse> Handle(CreateContractRequest request, CancellationToken cancellationToken)
    {
        try
        {
            if (!request.DraftContract.Accepted)
                return default; //throw new ArgumentException("Contrato não aceito");

            var contract = _mapper.Map<Contract>(request);

            _contractRepository.Create(contract);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<CreateContractResponse>(contract);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Create Contract.");
            throw;
        }
    }
}
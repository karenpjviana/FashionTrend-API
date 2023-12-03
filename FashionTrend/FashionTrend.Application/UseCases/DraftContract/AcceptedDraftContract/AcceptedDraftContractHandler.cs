using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class AcceptedDraftContractHandler : IRequestHandler<AcceptedDraftContractRequest, AcceptedDraftContractResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDraftContractRepository _draftRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AcceptedDraftContractHandler> _logger;


    public AcceptedDraftContractHandler(IUnitOfWork unitOfWork, IDraftContractRepository draftRepository,
        IMapper mapper, ILogger<AcceptedDraftContractHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _draftRepository = draftRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AcceptedDraftContractResponse> Handle(AcceptedDraftContractRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var draft = await _draftRepository.Get(request.Id, cancellationToken);

            if (draft is null)
                throw new ArgumentException("Draft Contract não encontrado");

            draft.Accepted = request.Accepted;

            _draftRepository.Update(draft);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<AcceptedDraftContractResponse>(draft);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Accepted DraftContract.");
            throw;
        }
    }
}
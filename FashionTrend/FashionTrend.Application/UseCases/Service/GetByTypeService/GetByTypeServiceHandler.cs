using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByTypeServiceHandler : IRequestHandler<GetByTypeServiceRequest, List<GetByTypeServiceResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByTypeServiceHandler> _logger;

    public GetByTypeServiceHandler(IUnitOfWork unitOfWork, IServiceRepository ServiceRepository, IMapper mapper, ILogger<GetByTypeServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = ServiceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetByTypeServiceResponse>> Handle(GetByTypeServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var service = await _serviceRepository.GetByType(request.Type, cancellationToken);

            if (service is null)
                throw new ArgumentException("Services não encontrados");

            return _mapper.Map<List<GetByTypeServiceResponse>>(service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Service por Type.", request.Type);
            throw;
        }
       
    }
}
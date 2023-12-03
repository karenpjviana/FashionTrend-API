using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByDescriptionServiceHandler : IRequestHandler<GetByDescriptionServiceRequest, GetByDescriptionServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByDescriptionServiceHandler> _logger;

    public GetByDescriptionServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper, ILogger<GetByDescriptionServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetByDescriptionServiceResponse> Handle(GetByDescriptionServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Service = await _serviceRepository.GetByDescription(request.Description, cancellationToken);

            if (Service is null)
                throw new ArgumentException("Service não encontrado");

            return _mapper.Map<GetByDescriptionServiceResponse>(Service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Service por Description.", request.Description);
            throw;
        }
       
    }
}
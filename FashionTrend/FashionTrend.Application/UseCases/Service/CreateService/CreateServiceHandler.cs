using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, CreateServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateServiceHandler> _logger;

    public CreateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper, ILogger<CreateServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateServiceResponse> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var service = _mapper.Map<Service>(request);

            _serviceRepository.Create(service);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateServiceResponse>(service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Create Service.");
            throw;
        }
    }
}
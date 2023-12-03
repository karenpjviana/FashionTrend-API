using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetServiceHandler : IRequestHandler<GetServiceRequest, GetServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetServiceHandler> _logger;

    public GetServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper, ILogger<GetServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetServiceResponse> Handle(GetServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var service = await _serviceRepository.Get(request.Id, cancellationToken);

            if (service is null)
                throw new ArgumentException("Service não encontrado");

            return _mapper.Map<GetServiceResponse>(service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Service por ID.", request.Id);
            throw;
        }
    }
}
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByServiceIdServiceOrderHandler : IRequestHandler<GetByServiceIdServiceOrderRequest, GetByServiceIdServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByServiceIdServiceOrderHandler> _logger;

    public GetByServiceIdServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<GetByServiceIdServiceOrderHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetByServiceIdServiceOrderResponse> Handle(GetByServiceIdServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var service = await _serviceOrderRepository.GetByServiceId(request.Id, cancellationToken);

            if (service is null)
                throw new ArgumentException("Service não encontrado");

            return _mapper.Map<GetByServiceIdServiceOrderResponse>(service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Service por ServiceId.", request.Id);
            throw;
        }
       
    }
}
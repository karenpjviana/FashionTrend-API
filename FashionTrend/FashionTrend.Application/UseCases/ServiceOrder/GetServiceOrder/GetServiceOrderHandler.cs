using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetServiceOrderHandler : IRequestHandler<GetServiceOrderRequest, GetServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetServiceOrderHandler> _logger;

    public GetServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<GetServiceOrderHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetServiceOrderResponse> Handle(GetServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var serviceOrder = await _serviceOrderRepository.Get(request.Id, cancellationToken);

            if (serviceOrder is null)
                throw new ArgumentException("ServiceOrder não encontrado");

            return _mapper.Map<GetServiceOrderResponse>(serviceOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get ServiceOrder por ID.", request.Id);
            throw;
        }
    }
}
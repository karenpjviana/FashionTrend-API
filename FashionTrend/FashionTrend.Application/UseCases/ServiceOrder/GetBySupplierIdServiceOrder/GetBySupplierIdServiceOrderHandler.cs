using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetBySupplierIdServiceOrderHandler : IRequestHandler<GetBySupplierIdServiceOrderRequest, List<GetBySupplierIdServiceOrderResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetBySupplierIdServiceOrderHandler> _logger;

    public GetBySupplierIdServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<GetBySupplierIdServiceOrderHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetBySupplierIdServiceOrderResponse>> Handle(GetBySupplierIdServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var serviceOrder = await _serviceOrderRepository.GetBySupplierId(request.Id, cancellationToken);

            if (serviceOrder is null)
                throw new ArgumentException("ServiceOrders não encontrados");

            return _mapper.Map<List<GetBySupplierIdServiceOrderResponse>>(serviceOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get ServiceOrder por SupplierId.", request.Id);
            throw;
        }
       
    }
}
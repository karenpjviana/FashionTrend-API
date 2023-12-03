using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetAllServiceOrderHandler : IRequestHandler<GetAllServiceOrderRequest, List<GetAllServiceOrderResponse>>
{
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllServiceOrderHandler> _logger;


    public GetAllServiceOrderHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<GetAllServiceOrderHandler> logger)
    {
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetAllServiceOrderResponse>> Handle(GetAllServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var ServiceOrders = await _serviceOrderRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllServiceOrderResponse>>(ServiceOrders);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get All ServiceOrder.");
            throw;
        }
    }
}
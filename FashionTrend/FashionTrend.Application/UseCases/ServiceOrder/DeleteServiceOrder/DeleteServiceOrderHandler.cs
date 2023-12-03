using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class DeleteServiceOrderHandler : IRequestHandler<DeleteServiceOrderRequest, DeleteServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteServiceOrderHandler> _logger;

    public DeleteServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<DeleteServiceOrderHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DeleteServiceOrderResponse> Handle(DeleteServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var ServiceOrder = await _serviceOrderRepository.Get(request.Id, cancellationToken);

            if (ServiceOrder is null)
                throw new ArgumentException("ServiceOrder não encontrado");

            _serviceOrderRepository.Delete(ServiceOrder);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteServiceOrderResponse>(ServiceOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Delete ServiceOrder.", request.Id);
            throw;
        }
        
    }
}
using AutoMapper;
using MediatR;

public class CreateServiceOrderHandler : IRequestHandler<CreateServiceOrderRequest, CreateServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;

    public CreateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
    }

    public async Task<CreateServiceOrderResponse> Handle(CreateServiceOrderRequest request, CancellationToken cancellationToken)
    {
        var serviceOrder = _mapper.Map<ServiceOrder>(request);

        _serviceOrderRepository.Create(serviceOrder);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateServiceOrderResponse>(serviceOrder);
    }
}
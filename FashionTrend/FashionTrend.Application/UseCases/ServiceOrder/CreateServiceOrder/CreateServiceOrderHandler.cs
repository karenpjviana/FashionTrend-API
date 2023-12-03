using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class CreateServiceOrderHandler : IRequestHandler<CreateServiceOrderRequest, CreateServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateServiceOrderHandler> _logger;

    public CreateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository, IMapper mapper, ILogger<CreateServiceOrderHandler> logger, ISupplierRepository supplierRepository, IServiceRepository serviceRepository)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _serviceRepository = serviceRepository;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateServiceOrderResponse> Handle(CreateServiceOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var serviceOrder = _mapper.Map<ServiceOrder>(request);
            var service = await _serviceRepository.Get(request.Service.Id, cancellationToken);
            var supplier = await _supplierRepository.Get(request.Supplier.Id, cancellationToken);

            if (service == null)
                throw new ArgumentException("Service não encontrado");
            if (supplier == null) 
                throw new ArgumentException("Supplier não encontrado");

            bool haveSewingMachine = service.SewingMachines.All(s => supplier.SewingMachines.Contains(s));
            bool haveMaterial = service.Materials.All(m => supplier.Materials.Contains(m));

            if (!haveSewingMachine || !haveMaterial) 
                serviceOrder.Status = ERequestStatus.Rejected;

            serviceOrder.Supplier = supplier;
            serviceOrder.Service = service;

            _serviceOrderRepository.Create(serviceOrder);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateServiceOrderResponse>(serviceOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Create ServiceOrder.");
            throw;
        }
    }
}
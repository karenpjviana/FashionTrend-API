using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class CreateSupplierHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateSupplierHandler> _logger;

    public CreateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<CreateSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = _mapper.Map<Supplier>(request);

            _supplierRepository.Create(supplier);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateSupplierResponse>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Create Supplier.");
            throw;
        }
    }
}
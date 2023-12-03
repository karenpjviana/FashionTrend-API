using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByMaterialSupplierHandler : IRequestHandler<GetByMaterialSupplierRequest, List<GetByMaterialSupplierResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByMaterialSupplierHandler> _logger;

    public GetByMaterialSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<GetByMaterialSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetByMaterialSupplierResponse>> Handle(GetByMaterialSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.GetByMaterial(request.Material, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Suppliers não encontrados");

            return _mapper.Map<List<GetByMaterialSupplierResponse>>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Supplier por Material.", request.Material);
            throw;
        }
       
    }
}
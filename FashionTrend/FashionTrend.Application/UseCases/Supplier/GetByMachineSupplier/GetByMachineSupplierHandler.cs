using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByMachineSupplierHandler : IRequestHandler<GetByMachineSupplierRequest, List<GetByMachineSupplierResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByMachineSupplierHandler> _logger;

    public GetByMachineSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<GetByMachineSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetByMachineSupplierResponse>> Handle(GetByMachineSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.GetByMachine(request.Machine, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Suppliers não encontrados");

            return _mapper.Map<List<GetByMachineSupplierResponse>>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Supplier por Machine.", request.Machine);
            throw;
        }
       
    }
}
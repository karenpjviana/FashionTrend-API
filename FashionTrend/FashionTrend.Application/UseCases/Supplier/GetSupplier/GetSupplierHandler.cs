using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetSupplierHandler : IRequestHandler<GetSupplierRequest, GetSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSupplierHandler> _logger;

    public GetSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<GetSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetSupplierResponse> Handle(GetSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.Get(request.Id, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Supplier não encontrado");

            return _mapper.Map<GetSupplierResponse>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Supplier por ID.", request.Id);
            throw;
        }
    }
}
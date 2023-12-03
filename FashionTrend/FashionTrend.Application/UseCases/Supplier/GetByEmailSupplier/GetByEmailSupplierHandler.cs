using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetByEmailSupplierHandler : IRequestHandler<GetByEmailSupplierRequest, GetByEmailSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByEmailSupplierHandler> _logger;

    public GetByEmailSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<GetByEmailSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetByEmailSupplierResponse> Handle(GetByEmailSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.GetByEmail(request.Email, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Supplier não encontrado");

            return _mapper.Map<GetByEmailSupplierResponse>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get Supplier por Email.", request.Email);
            throw;
        }
       
    }
}
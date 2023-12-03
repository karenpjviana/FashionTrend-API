using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetAllSupplierHandler : IRequestHandler<GetAllSupplierRequest, List<GetAllSupplierResponse>>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllSupplierHandler> _logger;


    public GetAllSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper, ILogger<GetAllSupplierHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetAllSupplierResponse>> Handle(GetAllSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var suppliers = await _supplierRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllSupplierResponse>>(suppliers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get All Supplier.");
            throw;
        }
    }
}
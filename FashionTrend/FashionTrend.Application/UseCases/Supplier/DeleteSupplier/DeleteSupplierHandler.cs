using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class DeleteSupplierHandler : IRequestHandler<DeleteSupplierRequest, DeleteSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteSupplierHandler> _logger;

    public DeleteSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<DeleteSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DeleteSupplierResponse> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.Get(request.Id, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Supplier não encontrado");

            _supplierRepository.Delete(supplier);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteSupplierResponse>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Delete Supplier.", request.Id);
            throw;
        }
        
    }
}
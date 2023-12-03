using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateSupplierHandler> _logger;

    public UpdateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper, ILogger<UpdateSupplierHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UpdateSupplierResponse> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var supplier = await _supplierRepository.Get(request.Id, cancellationToken);

            if (supplier is null)
                throw new ArgumentException("Supplier não encontrado");

            supplier.Name = request.Name;
            supplier.Email = request.Email;
            supplier.Password = request.Password;
            supplier.SewingMachines = request.SewingMachines;
            supplier.Materials = request.Materials;

            _supplierRepository.Update(supplier);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateSupplierResponse>(supplier);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Update Supplier por ID.", request.Id);
            throw;
        }
    }
}
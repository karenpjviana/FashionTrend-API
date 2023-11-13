using AutoMapper;
using MediatR;

public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public UpdateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSupplierResponse> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.Get(request.Id, cancellationToken);

        if (supplier is null) return default;

        supplier.Name = request.Name;
        supplier.Email = request.Email;
        supplier.Password = request.Password;
        supplier.SewingMachines = request.SewingMachines;
        supplier.Materials = request.Materials;

        _supplierRepository.Update(supplier);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateSupplierResponse>(supplier);
    }
}
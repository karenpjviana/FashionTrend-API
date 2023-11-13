using AutoMapper;
using MediatR;

public class CreateSupplierHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public CreateSupplierHandler(IUnitOfWork unitOfWork, ISupplierRepository supplierRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = _mapper.Map<Supplier>(request);

        _supplierRepository.Create(supplier);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateSupplierResponse>(supplier);
    }
}
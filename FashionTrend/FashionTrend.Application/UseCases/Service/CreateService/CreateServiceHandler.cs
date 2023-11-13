using AutoMapper;
using MediatR;

public class CreateServiceHandler : IRequestHandler<CreateServiceRequest, CreateServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public CreateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<CreateServiceResponse> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<Service>(request);

        _serviceRepository.Create(service);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateServiceResponse>(service);
    }
}
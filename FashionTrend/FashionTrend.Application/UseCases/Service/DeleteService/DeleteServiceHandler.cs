using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceRequest, DeleteServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteServiceHandler> _logger;

    public DeleteServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository, IMapper mapper, ILogger<DeleteServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DeleteServiceResponse> Handle(DeleteServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var service = await _serviceRepository.Get(request.Id, cancellationToken);

            if (service is null)
                throw new ArgumentException("Service não encontrado");

            _serviceRepository.Delete(service);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteServiceResponse>(service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Delete Service.", request.Id);
            throw;
        }
        
    }
}
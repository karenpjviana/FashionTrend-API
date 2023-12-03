using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceRequest, UpdateServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _ServiceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateServiceHandler> _logger;

    public UpdateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository ServiceRepository, IMapper mapper, ILogger<UpdateServiceHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _ServiceRepository = ServiceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<UpdateServiceResponse> Handle(UpdateServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var Service = await _ServiceRepository.Get(request.Id, cancellationToken);

            if (Service is null)
                throw new ArgumentException("Service não encontrado");

            Service.Description = request.Description;
            Service.Type = request.Type;
            Service.Delivery = request.Delivery;
            Service.SewingMachines = request.SewingMachines;
            Service.Materials = request.Materials;
            Service.Price = request.Price;

            _ServiceRepository.Update(Service);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateServiceResponse>(Service);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Update Service por ID.", request.Id);
            throw;
        }
    }
}
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

public class GetAllServiceHandler : IRequestHandler<GetAllServiceRequest, List<GetAllServiceResponse>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllServiceHandler> _logger;


    public GetAllServiceHandler(IServiceRepository serviceRepository, IMapper mapper, ILogger<GetAllServiceHandler> logger)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetAllServiceResponse>> Handle(GetAllServiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var services = await _serviceRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllServiceResponse>>(services);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro no método Get All Service.");
            throw;
        }
    }
}
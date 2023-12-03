using AutoMapper;
public class GetByTypeServiceMapper : Profile
{
    public GetByTypeServiceMapper()
    {
        CreateMap<Service, GetByTypeServiceResponse>();
    }
}   
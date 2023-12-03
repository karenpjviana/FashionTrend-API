using AutoMapper;
public class GetServiceMapper : Profile
{
    public GetServiceMapper()
    {
        CreateMap<Service, GetServiceResponse>();
    }
}   
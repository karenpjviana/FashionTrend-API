using AutoMapper;
public class GetAllServiceMapper : Profile
{
    public GetAllServiceMapper()
    {
        CreateMap<Service, GetAllServiceResponse>();
    }
}   
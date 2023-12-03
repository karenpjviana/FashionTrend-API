using AutoMapper;
public class GetByDescriptionServiceMapper : Profile
{
    public GetByDescriptionServiceMapper()
    {
        CreateMap<Service, GetByDescriptionServiceResponse>();
    }
}   
using AutoMapper;
public class CreateServiceMapper : Profile
{
    public CreateServiceMapper()
    {
        CreateMap<CreateServiceRequest, Service>();
        CreateMap<Service, CreateServiceResponse>();
    }
}   
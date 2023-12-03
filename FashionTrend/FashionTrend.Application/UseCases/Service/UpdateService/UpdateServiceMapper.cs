using AutoMapper;
public class UpdateServiceMapper : Profile
{
    public UpdateServiceMapper()
    {
        CreateMap<UpdateServiceRequest, Service>();
        CreateMap<Service, UpdateServiceResponse>();
    }
}   
using AutoMapper;
public class DeleteServiceMapper : Profile
{
    public DeleteServiceMapper()
    {
        CreateMap<DeleteServiceRequest, Service>();
        CreateMap<Service, DeleteServiceResponse>();
    }
}   
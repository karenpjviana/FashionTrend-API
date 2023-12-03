using AutoMapper;
public class GetServiceOrderMapper : Profile
{
    public GetServiceOrderMapper()
    {
        CreateMap<ServiceOrder, GetServiceOrderResponse>();
    }
}   
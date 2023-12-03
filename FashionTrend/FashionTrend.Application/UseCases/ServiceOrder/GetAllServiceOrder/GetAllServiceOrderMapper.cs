using AutoMapper;
public class GetAllServiceOrderMapper : Profile
{
    public GetAllServiceOrderMapper()
    {
        CreateMap<ServiceOrder, GetAllServiceOrderResponse>();
    }
}   
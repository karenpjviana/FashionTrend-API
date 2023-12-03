using AutoMapper;
public class GetByServiceIdServiceOrderMapper : Profile
{
    public GetByServiceIdServiceOrderMapper()
    {
        CreateMap<Service, GetByServiceIdServiceOrderResponse>();
    }
}   
using AutoMapper;
public class UpdateServiceOrderMapper : Profile
{
    public UpdateServiceOrderMapper()
    {
        CreateMap<UpdateServiceOrderRequest, ServiceOrder>();
        CreateMap<ServiceOrder, UpdateServiceOrderResponse>();
    }
}   
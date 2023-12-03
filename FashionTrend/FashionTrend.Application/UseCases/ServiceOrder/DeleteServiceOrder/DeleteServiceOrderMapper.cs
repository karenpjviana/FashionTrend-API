using AutoMapper;
public class DeleteServiceOrderMapper : Profile
{
    public DeleteServiceOrderMapper()
    {
        CreateMap<DeleteServiceOrderRequest, ServiceOrder>();
        CreateMap<ServiceOrder, DeleteServiceOrderResponse>();
    }
}   
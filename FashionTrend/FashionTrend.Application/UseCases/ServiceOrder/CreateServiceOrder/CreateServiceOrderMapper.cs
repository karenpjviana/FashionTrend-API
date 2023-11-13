using AutoMapper;
public class CreateServiceOrderMapper : Profile
{
    public CreateServiceOrderMapper()
    {
        CreateMap<CreateServiceOrderRequest, ServiceOrder>();
        CreateMap<ServiceOrder, CreateServiceOrderResponse>();
    }
}   
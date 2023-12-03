using AutoMapper;
public class GetBySupplierIdServiceOrderMapper : Profile
{
    public GetBySupplierIdServiceOrderMapper()
    {
        CreateMap<ServiceOrder, GetBySupplierIdServiceOrderResponse>();
    }
}   
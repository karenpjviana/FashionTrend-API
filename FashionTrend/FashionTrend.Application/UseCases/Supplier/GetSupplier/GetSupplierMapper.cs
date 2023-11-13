using AutoMapper;
public class GetSupplierMapper : Profile
{
    public GetSupplierMapper()
    {
        CreateMap<GetSupplierRequest, Supplier>();
        CreateMap<Supplier, GetSupplierResponse>();
    }
}   
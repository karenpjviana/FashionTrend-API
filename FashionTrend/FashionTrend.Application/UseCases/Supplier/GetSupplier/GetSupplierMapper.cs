using AutoMapper;
public class GetSupplierMapper : Profile
{
    public GetSupplierMapper()
    {
        CreateMap<Supplier, GetSupplierResponse>();
    }
}   
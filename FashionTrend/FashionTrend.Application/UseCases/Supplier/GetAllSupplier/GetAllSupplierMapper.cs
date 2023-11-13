using AutoMapper;
public class GetAllSupplierMapper : Profile
{
    public GetAllSupplierMapper()
    {
        CreateMap<Supplier, GetAllSupplierResponse>();
    }
}   
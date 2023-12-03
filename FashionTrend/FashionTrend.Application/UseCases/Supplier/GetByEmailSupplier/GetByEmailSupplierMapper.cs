using AutoMapper;
public class GetByEmailSupplierMapper : Profile
{
    public GetByEmailSupplierMapper()
    {
        CreateMap<Supplier, GetByEmailSupplierResponse>();
    }
}   
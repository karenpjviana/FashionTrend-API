using AutoMapper;
public class GetByMaterialSupplierMapper : Profile
{
    public GetByMaterialSupplierMapper()
    {
        CreateMap<Supplier, GetByMaterialSupplierResponse>();
    }
}   
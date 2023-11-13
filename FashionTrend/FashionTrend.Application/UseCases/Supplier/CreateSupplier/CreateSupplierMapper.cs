using AutoMapper;
public class CreateSupplierMapper : Profile
{
    public CreateSupplierMapper()
    {
        CreateMap<CreateSupplierRequest, Supplier>();
        CreateMap<Supplier, CreateSupplierResponse>();
    }
}   